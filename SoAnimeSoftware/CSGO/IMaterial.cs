using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IMaterial : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate ConstChar* GetNameDlg(Material* ptr);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate ConstChar* GetTextureGroupNameDlg(Material* ptr);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte AlphaModulateDlg(Material* ptr, float alpha);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte ColorModulateDlg(Material* ptr, SColor color);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsPrecachedDlg(Material* ptr);

        public GetNameDlg GetName;
        public GetTextureGroupNameDlg GetTextureGroupName;
        public AlphaModulateDlg AlphaModulate;
        public ColorModulateDlg ColorModulate;
        public IsPrecachedDlg _IsPrecached;
        public IMaterial(IntPtr Address) : base(Address)
        {
            GetName = GetInterfaceFunction<GetNameDlg>(0);
            GetTextureGroupName = GetInterfaceFunction<GetTextureGroupNameDlg>(1);
            AlphaModulate = GetInterfaceFunction<AlphaModulateDlg>(27);
            ColorModulate = GetInterfaceFunction<ColorModulateDlg>(28);
            _IsPrecached = GetInterfaceFunction<IsPrecachedDlg>(70);
        }

        public bool IsPrecached(Material* ptr) { return _IsPrecached(ptr) == 1; }
    }
}
