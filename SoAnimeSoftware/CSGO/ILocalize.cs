using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class ILocalize : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* FindAsUTF8Dlg(IntPtr address, Char_t* token);

        public FindAsUTF8Dlg _FindAsUTF8Dlg;

        public ILocalize(IntPtr Address) : base(Address)
        {
            _FindAsUTF8Dlg = GetInterfaceFunction<FindAsUTF8Dlg>(47);
        }

        public Char_t* FindAsUTF8(Char_t* token)
        {
            return _FindAsUTF8Dlg(Address, token);
        }
    }
}