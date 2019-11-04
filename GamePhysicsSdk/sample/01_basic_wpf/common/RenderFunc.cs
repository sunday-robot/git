using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_basic_wpf.common
{
    public class RenderFunc
    {
        public static void renderInit(string title)
    {
	s_enableGlWindow = (title != null);

	s_screenWidth = DISPLAY_WIDTH;
	s_screenHeight = DISPLAY_HEIGHT;

	if(s_enableGlWindow) {
		if(!createWindow(title,s_screenWidth,s_screenHeight)) {
			MessageBox(NULL,"Can't create gl window.","ERROR",MB_OK|MB_ICONEXCLAMATION);
			assert(0);
		}
	}

	// initalize matrix
	s_pMat = EpxMatrix4::perspective(3.1415f/4.0f, (float)s_screenWidth/(float)s_screenHeight,0.1f, 1000.0f);

	// initalize parameters
	s_lightRadius = 40.0f;
	s_lightRadX = -0.6f;
	s_lightRadY = 0.6f;
	s_viewRadius = 20.0f;
	s_viewRadX = -0.01f;
	s_viewRadY = 0.0f;
	s_viewHeight = 1.0f;

	s_viewTgt = EpxVector3(0.0f,s_viewHeight,0.0f);
	
	s_meshBuff = new vector<MeshBuff>();
}
    }
}
