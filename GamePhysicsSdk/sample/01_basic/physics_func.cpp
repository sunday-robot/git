﻿#include <stdlib.h>
#include "../common/common.h"
#include "../common/geometry_data.h"
#include "physics_func.h"

using namespace EasyPhysics;

///////////////////////////////////////////////////////////////////////////////
// シミュレーション定義

const int maxRigidBodies = 500;	// 剛体の最大数
const int maxJoints = 100;		// ジョイントの最大数
const int maxPairs = 5000;		// 衝突判定時の剛体のペアの最大数?
const float timeStep = 0.016f;	// 単位時間
const float contactBias = 0.1f;	// ?衝突判定のための何か?
const float contactSlop = 0.001f;	// ?衝突判定のための何か?
const int iteration = 10;		// ?何かの繰り返し最大数?
const EpxVector3 gravity(0.0f, -9.8f, 0.0f);	// 重力

///////////////////////////////////////////////////////////////////////////////
// シミュレーションデータ

// 剛体
EpxState states[maxRigidBodies];
EpxRigidBody bodies[maxRigidBodies];
EpxCollidable collidables[maxRigidBodies];
EpxUInt32 numRigidBodies = 0;

// ジョイント
EpxBallJoint joints[maxJoints];
EpxUInt32 numJoints = 0;

// ペア
unsigned int pairSwap;
EpxUInt32 numPairs[2];
EpxPair pairs[2][maxPairs];

static int frame = 0;

///////////////////////////////////////////////////////////////////////////////
// メモリアロケータ

class DefaultAllocator : public EpxAllocator {
public:
	void *allocate(size_t bytes) {
		return malloc(bytes);
	}

	void deallocate(void *p) {
		free(p);
	}
} allocator;

///////////////////////////////////////////////////////////////////////////////
// シミュレーション関数

struct Perf {
	unsigned long long count;
	int frame;

	void setFrame(int f) {
		frame = f;
	}

	void begin() {
		count = perfGetCount();
	}

	void end(const char *msg) {
		unsigned long long count2 = perfGetCount();
		float msec = perfGetTimeMillisecond(count, count2);
		if (frame % 100 == 0) {
			epxPrintf("%s : %.2f msec\n", msg, msec);
		}
	}
};

void physicsSimulate() {
	Perf perf;
	perf.setFrame(frame);

	pairSwap = 1 - pairSwap;

	perf.begin();
	for (EpxUInt32 i = 0; i < numRigidBodies; i++) {
		EpxVector3 externalForce = gravity * bodies[i].m_mass;
		EpxVector3 externalTorque(0.0f);
		epxApplyExternalForce(states[i], bodies[i], externalForce, externalTorque, timeStep);
	}
	perf.end("apply force");

	perf.begin();
	epxBroadPhase(
		states, collidables, numRigidBodies,
		pairs[1 - pairSwap], numPairs[1 - pairSwap],
		pairs[pairSwap], numPairs[pairSwap],
		maxPairs, &allocator, NULL, NULL);
	perf.end("broadphase");

	perf.begin();
	epxDetectCollision(
		states, collidables, numRigidBodies,
		pairs[pairSwap], numPairs[pairSwap]);
	perf.end("collision");

	perf.begin();
	epxSolveConstraints(
		states, bodies, numRigidBodies,
		pairs[pairSwap], numPairs[pairSwap],
		joints, numJoints,
		iteration, contactBias, contactSlop, timeStep, &allocator);
	perf.end("solver");

	perf.begin();
	epxIntegrate(states, numRigidBodies, timeStep);
	perf.end("integrate");

	//epxPrintf("--- frame %d -------------\n",frame);
	//for(int i=0;i<numPairs[pairSwap];i++) {
	//	EpxPair &p = pairs[pairSwap][i];
	//	epxPrintf("RB %u,%u CP %u\n",p.rigidBodyA,p.rigidBodyB,p.contact->m_numContacts);
	//}

	frame++;
}

///////////////////////////////////////////////////////////////////////////////
// シーンの作成

static int fireRigidBodyId;

void createFireBody() {
	fireRigidBodyId = numRigidBodies++;

	EpxVector3 scale(0.5f);

	states[fireRigidBodyId].reset();
	states[fireRigidBodyId].m_motionType = EpxMotionTypeStatic;
	states[fireRigidBodyId].m_position = EpxVector3(999.0f);
	bodies[fireRigidBodyId].reset();
	bodies[fireRigidBodyId].m_mass = 1.0f;
	bodies[fireRigidBodyId].m_inertia = epxCalcInertiaBox(scale, 1.0f);
	collidables[fireRigidBodyId].reset();

	EpxShape shape;
	shape.reset();

	epxCreateConvexMesh(&shape.m_geometry, sphere_vertices, sphere_numVertices, sphere_indices, sphere_numIndices, scale);
	shape.userData = (void*) createRenderMesh(&shape.m_geometry);

	collidables[fireRigidBodyId].addShape(shape);
	collidables[fireRigidBodyId].finish();
}

void createSceneTwoBox() {
	// 地面
	{
		int id = numRigidBodies++;

		EpxVector3 scale(10.0f, 1.0f, 10.0f);

		// 剛体を表現するための各種データを初期化
		states[id].reset();
		states[id].m_motionType = EpxMotionTypeStatic;
		states[id].m_position = EpxVector3(0.0f, -scale[1], 0.0f);
		bodies[id].reset();
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		// 凸メッシュを作成
		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
		// 描画用メッシュは、終了時に自動的に破棄される
		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		// 凸メッシュ形状を登録
		collidables[id].addShape(shape);
		collidables[id].finish();
	}

	// ボックス
	{
		int id = numRigidBodies++;

		EpxVector3 scale(2.0f, 0.25f, 1.0f);

		// 剛体を表現するための各種データを初期化
		states[id].reset();
		states[id].m_position = EpxVector3(0.0f, scale[1], 0.0f);
		bodies[id].reset();
		bodies[id].m_mass = 1.0f;
		bodies[id].m_inertia = epxCalcInertiaBox(scale, 1.0f);
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		// 凸メッシュを作成
		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
		// 描画用メッシュは、シーン切り替え時に自動的に破棄される
		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		// 凸メッシュ形状を登録
		collidables[id].addShape(shape);
		collidables[id].finish();
	}

	{
		int id = numRigidBodies++;

		EpxVector3 scale(2.0f, 0.25f, 1.0f);

		// 剛体を表現するための各種データを初期化
		states[id].reset();
		states[id].m_position = EpxVector3(0.0f, 3.0f, 0.0f);
		states[id].m_orientation = EpxQuat::rotationZ(2.0f) * EpxQuat::rotationY(0.7f);
		bodies[id].reset();
		bodies[id].m_mass = 1.0f;
		bodies[id].m_inertia = epxCalcInertiaBox(scale, 1.0f);
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		// 凸メッシュを作成
		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
		// 描画用メッシュは、シーン切り替え時に自動的に破棄される
		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		// 凸メッシュ形状を登録
		collidables[id].addShape(shape);
		collidables[id].finish();
	}
}

void createSceneFriction() {
	const EpxFloat angle = 0.4f;

	// 地面
	{
		int id = numRigidBodies++;

		EpxVector3 scale(10.0f, 0.5f, 10.0f);

		states[id].reset();
		states[id].m_motionType = EpxMotionTypeStatic;
		states[id].m_position = EpxVector3(0.0f, -scale[1], 0.0f);
		states[id].m_orientation = EpxQuat::rotationX(angle);
		bodies[id].reset();
		bodies[id].m_friction = 0.4f;
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		collidables[id].addShape(shape);
		collidables[id].finish();
	}

	int renderMeshId = -1;
	const EpxVector3 brickScale(0.5f, 0.125f, 0.5f);

	for (int i = 0; i < 5; i++) {
		int id = numRigidBodies++;

		// 剛体を表現するための各種データを初期化
		states[id].reset();
		states[id].m_position = EpxVector3(2.0f*(i - 2), 3.0f, 0.0f);
		states[id].m_orientation = EpxQuat::rotationX(angle);
		bodies[id].reset();
		bodies[id].m_mass = 2.0f;
		bodies[id].m_inertia = epxCalcInertiaBox(brickScale, 2.0f);
		bodies[id].m_friction = 0.25f * i;
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		// 凸メッシュを作成
		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, brickScale);

		// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
		// 描画用メッシュは、シーン切り替え時に自動的に破棄される
		if (renderMeshId < 0) {
			renderMeshId = createRenderMesh(&shape.m_geometry);
		}
		shape.userData = (void*) renderMeshId;

		// 凸メッシュ形状を登録
		collidables[id].addShape(shape);
		collidables[id].finish();
	}
}

void createSceneRestitution() {
	// 地面
	{
		int id = numRigidBodies++;

		EpxVector3 scale(10.0f, 0.5f, 10.0f);

		states[id].reset();
		states[id].m_motionType = EpxMotionTypeStatic;
		states[id].m_position = EpxVector3(0.0f, -scale[1], 0.0f);
		bodies[id].reset();
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		collidables[id].addShape(shape);
		collidables[id].finish();
	}

	int renderMeshId = -1;
	const EpxVector3 scale(0.5f);

	for (int i = 0; i < 5; i++) {
		int id = numRigidBodies++;

		// 剛体を表現するための各種データを初期化
		states[id].reset();
		states[id].m_position = EpxVector3(2.0f*(i - 2), 5.0f, 0.0f);
		bodies[id].reset();
		bodies[id].m_mass = 2.0f;
		bodies[id].m_inertia = epxCalcInertiaSphere(1.0f, 2.0f);
		bodies[id].m_restitution = 0.25f * i;
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		// 凸メッシュを作成
		epxCreateConvexMesh(&shape.m_geometry, sphere_vertices, sphere_numVertices, sphere_indices, sphere_numIndices, scale);

		// 同時に描画用メッシュを作成、ポインタをユーザーデータに保持
		// 描画用メッシュは、シーン切り替え時に自動的に破棄される
		if (renderMeshId < 0) {
			renderMeshId = createRenderMesh(&shape.m_geometry);
		}
		shape.userData = (void*) renderMeshId;

		// 凸メッシュ形状を登録
		collidables[id].addShape(shape);
		collidables[id].finish();
	}
}

void createSceneGeometries() {
	// 地面
	{
		int id = numRigidBodies++;

		EpxVector3 scale(10.0f, 1.0f, 10.0f);

		states[id].reset();
		states[id].m_motionType = EpxMotionTypeStatic;
		states[id].m_position = EpxVector3(0.0f, -scale[1], 0.0f);
		bodies[id].reset();
		collidables[id].reset();

		EpxShape shape;
		shape.reset();

		epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);

		shape.userData = (void*) createRenderMesh(&shape.m_geometry);

		collidables[id].addShape(shape);
		collidables[id].finish();
	}

	srand(9999);

	const int width = 5;
	for (int i = 0; i < width; i++) {
		for (int j = 0; j < width; j++) {
			int id = numRigidBodies++;

			EpxVector3 scale(0.1f + (rand() % 90) / 100.0f, 0.1f + (rand() % 90) / 100.0f, 0.1f + (rand() % 90) / 100.0f);

			states[id].reset();
			states[id].m_position = EpxVector3(
				(float) (2 * (j - width / 2)),
				2.0f + 2 * i,
				0.0f);
			bodies[id].reset();
			bodies[id].m_mass = 1.0f;
			bodies[id].m_inertia = epxCalcInertiaBox(scale, 1.0f);
			collidables[id].reset();

			EpxShape shape;
			shape.reset();

			switch ((i*width + j) % 4) {
			case 0:
				epxCreateConvexMesh(&shape.m_geometry, sphere_vertices, sphere_numVertices, sphere_indices, sphere_numIndices, scale);
				break;

			case 1:
				epxCreateConvexMesh(&shape.m_geometry, box_vertices, box_numVertices, box_indices, box_numIndices, scale);
				break;

			case 2:
				epxCreateConvexMesh(&shape.m_geometry, cylinder_vertices, cylinder_numVertices, cylinder_indices, cylinder_numIndices, scale);
				break;

			case 3:
				epxCreateConvexMesh(&shape.m_geometry, tetrahedron_vertices, tetrahedron_numVertices, tetrahedron_indices, tetrahedron_numIndices, scale);
				break;
			}

			shape.userData = (void*) createRenderMesh(&shape.m_geometry);
			collidables[id].addShape(shape);
			collidables[id].finish();
		}
	}
}

static const int maxScenes = 4;
static const char titles[][32] = {
	"basic rigid bodies",
	"friction test",
	"restitution test",
	"various convex shapes",
};

const char *physicsGetSceneTitle(int i) {
	return titles[i % maxScenes];
}

void physicsCreateScene(int sceneId) {
	frame = 0;

	numRigidBodies = 0;
	numJoints = 0;
	numPairs[0] = numPairs[1] = 0;
	pairSwap = 0;

	switch (sceneId % maxScenes) {
	case 0:
		createSceneTwoBox();
		break;

	case 1:
		createSceneFriction();
		break;

	case 2:
		createSceneRestitution();
		break;

	case 3:
		createSceneGeometries();
		break;
	}

	createFireBody();
}

///////////////////////////////////////////////////////////////////////////////
// 初期化、解放

bool physicsInit() {
	return true;
}

void physicsRelease() {
}

///////////////////////////////////////////////////////////////////////////////
// 外部から物理データへのアクセス

int physicsGetNumRigidbodies() {
	return numRigidBodies;
}

const EpxState &physicsGetState(int i) {
	return states[i];
}

const EpxRigidBody &physicsGetRigidBody(int i) {
	return bodies[i];
}

const EpxCollidable &physicsGetCollidable(int i) {
	return collidables[i];
}

int physicsGetNumContacts() {
	return numPairs[pairSwap];
}

const EasyPhysics::EpxContact &physicsGetContact(int i) {
	return *pairs[pairSwap][i].contact;
}

EpxUInt32 physicsGetRigidBodyAInContact(int i) {
	return pairs[pairSwap][i].rigidBodyA;
}

EpxUInt32 physicsGetRigidBodyBInContact(int i) {
	return pairs[pairSwap][i].rigidBodyB;
}

void physicsFire(const EasyPhysics::EpxVector3 &position, const EasyPhysics::EpxVector3 &velocity) {
	states[fireRigidBodyId].m_motionType = EpxMotionTypeActive;
	states[fireRigidBodyId].m_position = position;
	states[fireRigidBodyId].m_linearVelocity = velocity;
	states[fireRigidBodyId].m_angularVelocity = EpxVector3(0.0f);
}
