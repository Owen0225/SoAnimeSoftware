using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class ISound : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void EmitSoundDlg(SoundData data);

        public EmitSoundDlg EmitSound;

        public ISound(IntPtr Address) : base(Address)
        {
            EmitSound = GetInterfaceFunction<EmitSoundDlg>(5);
        }
    }

    public unsafe struct SoundData
    {
        fixed byte pad[4];
        public int entityIndex;
        public int channel;
        public Char_t* soundEntry;
        fixed byte pad1[8];
        public float volume;
        fixed byte pad2[44];
    }
}