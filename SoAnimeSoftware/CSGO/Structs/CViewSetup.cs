using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    unsafe public struct CViewSetup
    {
        fixed byte pad[176];
        public float fov;
        fixed byte pad1[32];
        public float fovZ;
    }
}