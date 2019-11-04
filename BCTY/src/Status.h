#pragma once

// DEAD2 というのは、戦車は死んでしまったがその弾がまだ生きている
// (かもしれない)という状態
// DEAD3 は、戦車が今、死んだことを示す
// DISP_POINT は、敵戦車が死んでその点数を表示している状態
enum Status {
	DEAD,
	DEAD2,
	DEAD3,
	DISP_POINT,
	BORN,
	ALIVE,
	BURST
};
