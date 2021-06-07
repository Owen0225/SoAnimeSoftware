using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IStudioRender : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ForcedMaterialOverrideDlg(IntPtr ptr, CMaterial* material, int typel, int index);

        public ForcedMaterialOverrideDlg _ForcedMaterialOverride;

        public IStudioRender(IntPtr Address) : base(Address)
        {
            _ForcedMaterialOverride = GetInterfaceFunction<ForcedMaterialOverrideDlg>(33);
        }

        public void ForcedMaterialOverride(CMaterial* material, EOverrideType typel = EOverrideType.Normal,
            int index = -1)
        {
            _ForcedMaterialOverride(Address, material, (int) typel, index);
        }
    }
}