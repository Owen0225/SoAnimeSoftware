using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Vertex
    {
        public float x;
        public float y;
        public float xuy;
        public float nya;

        public Vertex(float X, float Y)
        {
            x = X;
            y = Y;
            xuy = nya = 0f;
        }
    }
}