using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CConVar
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public unsafe delegate void ChangeCallbackDlg();

        fixed byte pad[24];
        IntPtr changeCallbackPtr;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void SetValueStringDlg(CConVar* ptr, byte[] value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetValueFloatDlg(CConVar* ptr, float value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetValueIntDlg(CConVar* ptr, int value);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float GetFloatDlg(CConVar* ptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte GetBoolDlg(CConVar* ptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte GetIntDlg(CConVar* ptr);

        public void SetValueString(string value)
        {
            Memory.GetVTableFunction<SetValueStringDlg>((IntPtr) Ptr(), 14)(Ptr(), Encoding.UTF8.GetBytes(value));
        }

        public void SetValueString(byte[] value)
        {
            Memory.GetVTableFunction<SetValueStringDlg>((IntPtr) Ptr(), 14)(Ptr(), value);
        }

        public void SetValueFloat(float value)
        {
            Memory.GetVTableFunction<SetValueFloatDlg>((IntPtr) Ptr(), 15)(Ptr(), value);
        }

        public void SetValueInt(int value)
        {
            Memory.GetVTableFunction<SetValueIntDlg>((IntPtr) Ptr(), 16)(Ptr(), value);
        }

        public float GetFloat()
        {
            return Memory.GetVTableFunction<GetFloatDlg>((IntPtr) Ptr(), 12)(Ptr());
        }

        public bool GetBool()
        {
            return Memory.GetVTableFunction<GetBoolDlg>((IntPtr) Ptr(), 13)(Ptr()) != 0;
        }

        public int GetInt()
        {
            return Memory.GetVTableFunction<GetIntDlg>((IntPtr) Ptr(), 13)(Ptr());
        }

        public void ChangeCallback()
        {
            Marshal.GetDelegateForFunctionPointer<ChangeCallbackDlg>(changeCallbackPtr)();
        }

        public void ClearCallback()
        {
            *(int*)((IntPtr) Ptr() + 0x44 + 0xC) = 0;
        }

        public CConVar* Ptr()
        {
            fixed (CConVar* ptr = &this)
                return ptr;
        }
    }
}