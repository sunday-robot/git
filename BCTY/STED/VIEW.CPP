#include <gr.h>
//#include <super.h>
#include "init_fin.h"
#include "stg_lst.h"
#include "ev_mngr.h"

EventManager event_manager(2);

StageList stage_list(100);

void main()
{
	init();
	stage_list.read("bcty.stg");
	stage_list.show(0);
}
