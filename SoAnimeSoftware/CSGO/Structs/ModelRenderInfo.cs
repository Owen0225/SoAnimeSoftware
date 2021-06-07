using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct ModelRenderInfo
    {
        public Vector origin;
        public Vector angles;
        public fixed byte pad[4];
        public void* renderable;
        public MStudioModel* model;
        public Matrix3x4* modelToWorld;
        public Matrix3x4* lightingOffset;
        public Vector* lightingOrigin;
        public int flags;
        public int entityIndex;
    }

    public unsafe struct Model
    {
        public IntPtr fnHandle; //0x0000
        public Char_t szName;
        fixed byte szNamePad[259]; //0x0004
    }
}