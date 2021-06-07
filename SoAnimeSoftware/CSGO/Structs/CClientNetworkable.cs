using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CClientNetworkable
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate ClientClass* GetClientClassDlg(IntPtr ptr);

        public ClientClass* GetClientClass()
        {
            fixed (CClientNetworkable* ptr = &this)
            {
                return Memory.GetVTableFunction<GetClientClassDlg>((IntPtr) ptr, 2)((IntPtr) ptr);
            }
        }
    }
}