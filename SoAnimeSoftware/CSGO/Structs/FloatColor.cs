using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public struct FloatColor
    {
        public float R;
        public float G;
        public float B;

        public FloatColor(Color c)
        {
            R = c.R / 255f;
            G = c.G / 255f;
            B = c.B / 255f;
        }

        public FloatColor(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}