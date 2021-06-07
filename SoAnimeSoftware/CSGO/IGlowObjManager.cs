using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IGlowObjManager : InterfaceBase
    {
        public IGlowObjManager(IntPtr Address) : base(Address)
        {
        }

        public GlowObjectDefinition* GetGlowObject(int index) //UtlVector<glowobjdef> 0x0
        {
            return (GlowObjectDefinition*) (Memory.ReadPointer(Memory.ReadPointer(Address)) + 0x38 * index);
        }

        public int GlowObjectCount()
        {
            return *(int*) (Memory.ReadPointer(Address) + 0xC);
        }
    }
}