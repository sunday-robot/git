using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _01_basic_wpf.common
{
    public enum ButtonID : int
    {
        BTN_SCENE_RESET = 0,
        BTN_SCENE_NEXT,
        BTN_SIMULATION,
        BTN_STEP,
        BTN_UP,
        BTN_DOWN,
        BTN_LEFT,
        BTN_RIGHT,
        BTN_ZOOM_IN,
        BTN_ZOOM_OUT,
        BTN_PICK,
        BTN_NUM
    };

    public enum ButtonStatus : int
    {
        BTN_STAT_NONE = 0,
        BTN_STAT_DOWN,
        BTN_STAT_UP,
        BTN_STAT_KEEP
    };

    public class CtrlFunc
    {
        private static KeyStates[,] s_keyState = new KeyStates[2, (int)ButtonID.BTN_NUM];
        private static int s_keySw = 0;

        public static void ctrlInit()
        {
            s_keySw = 0;
        }

        public static void ctrlRelease()
        {
        }

        public static void ctrlUpdate()
        {
            s_keyState[s_keySw, (int)ButtonID.BTN_SCENE_RESET] = Keyboard.GetKeyStates(Key.F1);
            s_keyState[s_keySw, (int)ButtonID.BTN_SCENE_NEXT] = Keyboard.GetKeyStates(Key.F2);
            s_keyState[s_keySw, (int)ButtonID.BTN_SIMULATION] = Keyboard.GetKeyStates(Key.F3);
            s_keyState[s_keySw, (int)ButtonID.BTN_STEP] = Keyboard.GetKeyStates(Key.F4);
            s_keyState[s_keySw, (int)ButtonID.BTN_UP] = Keyboard.GetKeyStates(Key.Up);
            s_keyState[s_keySw, (int)ButtonID.BTN_DOWN] = Keyboard.GetKeyStates(Key.Down);
            s_keyState[s_keySw, (int)ButtonID.BTN_LEFT] = Keyboard.GetKeyStates(Key.Left);
            s_keyState[s_keySw, (int)ButtonID.BTN_RIGHT] = Keyboard.GetKeyStates(Key.Right);
            s_keyState[s_keySw, (int)ButtonID.BTN_ZOOM_IN] = Keyboard.GetKeyStates(Key.Insert);
            s_keyState[s_keySw, (int)ButtonID.BTN_ZOOM_OUT] = Keyboard.GetKeyStates(Key.Delete);
            s_keyState[s_keySw, (int)ButtonID.BTN_PICK] = Keyboard.GetKeyStates(Key.LeftShift/* VK_LBUTTON*/);

            s_keySw = 1 - s_keySw;
        }

        public static ButtonStatus ctrlButtonPressed(ButtonID btnId)
        {
            Boolean previousPressed = (s_keyState[s_keySw, (int)btnId] != 0);
            Boolean currentPressed = (s_keyState[1 - s_keySw, (int)btnId] != 0);

            if (currentPressed)
                if (previousPressed)
                    return ButtonStatus.BTN_STAT_KEEP;
                else
                    return ButtonStatus.BTN_STAT_DOWN;
            else
                if (previousPressed)
                return ButtonStatus.BTN_STAT_UP;
            else
                return ButtonStatus.BTN_STAT_NONE;
        }

        public static void ctrlSetScreenSize(int w, int h)
        {
        }

        public static void ctrlGetCursorPosition(out int cursorX, out int cursorY)
        {
            cursorX = 0;
            cursorY = 0;

            //HWND hWnd = ::GetActiveWindow();

            //POINT pnt;
            //RECT rect;
            //::GetCursorPos(&pnt);
            //::ScreenToClient(hWnd, &pnt);
            //::GetClientRect(hWnd, &rect);
            //cursorX = pnt.x - (rect.right - rect.left) / 2;
            //cursorY = (rect.bottom - rect.top) / 2 - pnt.y;
        }

        public System.Windows.Input.KeyStates a { get; set; }
    }
}
