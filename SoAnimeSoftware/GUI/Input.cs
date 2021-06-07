using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoAnimeSoftware.GUI
{
    class Input
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Keys vKey);

        static bool[] KeyStates = new bool[256];

        public static bool KeyPressed(int i)
        {
            if (((GetAsyncKeyState(i) & 0x8000) != 0) != KeyStates[i])
                return KeyStates[i] = !KeyStates[i];
            else
                return false;
        }

        public static bool KeyPressed(Keys key)
        {
            return KeyPressed((int) key);
        }

        public static bool KeyDown(int i)
        {
            return ((GetAsyncKeyState(i) & 0x8000) != 0);
        }

        public static bool KeyDown(Keys key)
        {
            return KeyDown((int) key);
        }
    }
}