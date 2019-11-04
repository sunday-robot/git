using EasyPhisicsDotNet;
using SampleDotNet.ConvexMesh;
using SampleDotNet.Simulator;

namespace SampleDotNet
{
    class MainProgram
    {
        static int fireRigidBodyId;

        public static void Main(string[] args)
        {
            var simulator = new Simulator.Simulator();
            addRigidBodies(simulator);
            for (int i = 0; i < 10; i++)
                simulator.Tick();
        }

        static void addRigidBodies(Simulator.Simulator simulator)
        {
            simulator.AddRigidBody(createGround()); // 地面
            simulator.AddRigidBody(createBox1()); // 箱1
            simulator.AddRigidBody(createBox2()); // 箱2
            fireRigidBodyId = simulator.AddRigidBody(createBall()); // 弾
        }

        static RigidBody createGround()
        {
            var state = new EpxState();
            state.IsStatic = true;
            state.Position = new EpxVector3(0, -1, 0);

            var collidable = new EpxCollidable();
            var scale = new EpxVector3(10, 1, 10);
            var mesh = new BoxConvexMesh(scale);
            var shape = new EpxShape(mesh, null);
            collidable.AddShape(shape);
            collidable.updateAABB();

            return new RigidBody(state, null, collidable);
        }

        static RigidBody createBox1()
        {
            EpxVector3 boxSize = new EpxVector3(2.0f, 0.25f, 1.0f); // 直方体のサイズの半分(中心を原点とする、XYZ正方向の頂点の座標)

            var state = new EpxState();
            state.Position = new EpxVector3(0, 0.25f, 0);

            var properties = new EpxRigidBody(1, EpxMass.epxCalcInertiaBox(boxSize, 1.0f));

            var collidable = new EpxCollidable();
            var convexMesh = new BoxConvexMesh(boxSize);
            EpxShape shape = new EpxShape(convexMesh, null);
            collidable.AddShape(shape);
            collidable.updateAABB();

            return new RigidBody(state, properties, collidable);
        }

        static RigidBody createBox2()
        {
            EpxVector3 boxSize = new EpxVector3(2.0f, 0.25f, 1.0f); // 直方体のサイズの半分(中心を原点とする、XYZ正方向の頂点の座標)

            var state = new EpxState();
            state.Position = new EpxVector3(0, 3, 0);
            state.Orientation = EpxQuat.RotationZ(2.0f) * EpxQuat.RotationY(0.7f);

            var properties = new EpxRigidBody(1, EpxMass.epxCalcInertiaBox(boxSize, 1.0f));

            var collidable = new EpxCollidable();
            var convexMesh = new BoxConvexMesh(boxSize);
            EpxShape shape = new EpxShape(convexMesh, null);
            collidable.AddShape(shape);
            collidable.updateAABB();

            return new RigidBody(state, properties, collidable);
        }

        static RigidBody createBall()
        {
            var state = new EpxState();
            state.IsStatic = true;
            state.Position = new EpxVector3(999.0f);

            var scale = new EpxVector3(0.5f);

            var properties = new EpxRigidBody(1, EpxMass.epxCalcInertiaBox(scale, 1.0f));

            var collidable = new EpxCollidable();
            var convexMesh = new SphereConvexMesh(scale);
            var shape = new EpxShape(convexMesh, null);
            collidable.AddShape(shape);
            collidable.updateAABB();

            return new RigidBody(state, properties, collidable);
        }

    }
}
