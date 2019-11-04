#define PAT_16 0
#define PAT_32_1 53
#define PAT_32_2 (PAT_32_1 + 64)
#define PAT_64 (PAT_32_2 + 30)

#define PAT_ROAD PAT_16
#define PAT_RENGA PAT_ROAD
#define PAT_WOOD (PAT_16 + 16)
#define PAT_ICE (PAT_16 + 17)
#define PAT_CONCRETE (PAT_16 + 18)
#define PAT_RIVER (PAT_16 + 19)
#define PAT_FRAME_H (PAT_16 + 32)
#define PAT_FRAME_V (PAT_16 + 33)
#define PAT_FRAME_UL (PAT_16 + 34)
#define PAT_FRAME_UR (PAT_16 + 35)
#define PAT_FRAME_LL (PAT_16 + 36)
#define PAT_FRAME_LR (PAT_16 + 37)

#define PAT_INFO_BOX_1 (PAT_16 + 38)
#define PAT_INFO_BOX_2 (PAT_16 + 39)
#define PAT_INFO_BOX_2U (PAT_16 + 40)
#define PAT_INFO_BOX_2D (PAT_16 + 41)
#define PAT_INFO_BOX_2L (PAT_16 + 42)
#define PAT_INFO_BOX_2R (PAT_16 + 43)
#define PAT_INFO_BOX_2UL (PAT_16 + 44)
#define PAT_INFO_BOX_2UR (PAT_16 + 45)
#define PAT_INFO_BOX_2DL (PAT_16 + 46)
#define PAT_INFO_BOX_2DR (PAT_16 + 47)
#define PAT_COM_ICON (PAT_16 + 48)
#define PAT_PLAYER_1_ICON (PAT_16 + 49)
#define PAT_PLAYER_2_ICON (PAT_16 + 50)
#define PAT_STAGE_ICON (PAT_16 + 51)

#define PAT_GUN (PAT_16 + 20)
#define PAT_BASE (PAT_16 + 24)
#define PAT_W_FLAG (PAT_16 + 28)
#define PAT_BATU (PAT_16 + 52)

#define PAT_PLAYER1_TANK PAT_32_1
#define PAT_PLAYER2_TANK (PAT_PLAYER1_TANK + 4 * 4)
#define PAT_COMP_TANK (PAT_PLAYER2_TANK + 4 * 4)

#define PAT_BARRIER (PAT_32_2 + 12)
#define PAT_BORN (PAT_BARRIER + 2)
#define PAT_BURST2 (PAT_BORN + 3)
#define PAT_ITEM (PAT_BURST2 + 2)

#define PAT_POINT (PAT_32_2 + 25)

#define PAT_BURST PAT_64
