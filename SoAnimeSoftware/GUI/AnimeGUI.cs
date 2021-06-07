using SoAnimeSoftware.CSGO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoAnimeSoftware.GUI
{
    class AnimeGUI
    {
        public static Point MousePosition;
        public static Point MouseOffset;


        public static void Render()
        {
            if (!GVars.MenuOpened)
                return;

            MouseOffset = new Point(Control.MousePosition.X - MousePosition.X,
                Control.MousePosition.Y - MousePosition.Y);
            MousePosition = Control.MousePosition;
        }
        
    }
}