using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CMaterialVar
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetValueDlg(CMaterialVar* ptr, float value);

        public void SetValue(float value)
        {
            fixed (CMaterialVar* ptr = &this)
            {
                Memory.GetVTableFunction<SetValueDlg>((IntPtr) ptr, 4)(ptr, value);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetVecValueDlg(CMaterialVar* ptr, float a, float b, float c);

        public void SetVecValue(FloatColor value)
        {
            fixed (CMaterialVar* ptr = &this)
            {
                Memory.GetVTableFunction<SetVecValueDlg>((IntPtr) ptr, 11)(ptr, value.R, value.G, value.B);
            }
        }
    }
}