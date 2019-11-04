#include "screen.h"
#include "stage.h"
#include "sted.h"

class StageEditScreen : public Screen {
	Stage *stage;
public:
	StageEditScreen();
	virtual void show();
	void setStage(Stage *_stage);
	void endEdit(Stage *_stage);
};

// Map Edit Panel
#define MEP_X 16
#define MEP_Y 14
#define MEP_WIDTH (MAP_SIZE * 16)
#define MEP_HEIGHT (MAP_SIZE * 14)

// Map Parts Panel
#define MSP_X (MEP_X + MEP_WIDTH + 2 * 16)
#define MSP_Y (400 - 64)
#define MSP_WIDTH (nParts * 16)
#define MSP_HEIGHT 14

// Current Map Parts
#define CMP_X MSP_X
#define CMP_Y (MSP_Y - 3 * 14)
#define CMP_WIDTH (2 * 16)
#define CMP_HEIGHT (2 * 14)

// Set Pensize
#define SPB_X (CMP_X + CMP_WIDTH + 16)
#define SPB_Y (CMP_Y + CMP_HEIGHT - 16)
#define SPB_WIDTH (4 * 8)
#define SPB_HEIGHT 16

// Map Parts Size Button
#define MPSB_X (CMP_X + CMP_WIDTH + 16)
#define MPSB_Y (MMP_Y - 2 * 16)
#define MPSB_WIDTH (4 * 8)
#define MPSB_HEIGHT 16

// Tank Edit Panel
#define TEP_X ((MAP_SIZE + 3) * 16)
#define TEP_Y 16
#define TEP_WIDTH (5 * 32)
#define TEP_HEIGHT (4 * 32)

// Current Tank Panel
#define CTP_X TEP_X
#define CTP_Y (TEP_Y + TEP_HEIGHT + 16)
#define CTP_WIDTH 32
#define CTP_HEIGHT 32

// Tank Select Panel
#define TSP_X TEP_X
#define TSP_Y (CTP_Y + CTP_HEIGHT + 16)
#define TSP_WIDTH (4 * 32)
#define TSP_HEIGHT (2 * 32)

extern StageEditScreen stage_edit_screen;
