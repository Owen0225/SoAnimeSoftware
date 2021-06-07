using System;
using System.Runtime.InteropServices;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.CSGO
{
    public class IRenderView : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SceneEndDlg(IntPtr ptr);

        public SceneEndDlg SceneEnd;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetColorModulationDlg(IntPtr ptr, ref FloatColor color);

        public SetColorModulationDlg _SetColorModulation;

        public IRenderView(IntPtr Address) : base(Address)
        {
            SceneEnd = GetInterfaceFunction<SceneEndDlg>(9);
            _SetColorModulation = GetInterfaceFunction<SetColorModulationDlg>(6);
        }

        public void SetColorModulation(FloatColor color)
        {
            _SetColorModulation(Address, ref color);
        }
    }
}