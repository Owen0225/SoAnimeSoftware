using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IModelRender : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawModelExecuteDlg(IntPtr ptr, IntPtr ctx, IntPtr state, ModelRenderInfo* info,
            ref Matrix3x4 customBoneToWorld);

        public DrawModelExecuteDlg DrawModelExecute;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsForcedMaterialOverrideDlg(IntPtr ptr);

        public IsForcedMaterialOverrideDlg _IsForcedMaterialOverride;


        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte ForcedMaterialOverrideDlg(IntPtr ptr, CMaterial* newMaterial, int nOverrideType,
            int nOverrides);

        public ForcedMaterialOverrideDlg _ForcedMaterialOverride;

        public IModelRender(IntPtr Address) : base(Address)
        {
            DrawModelExecute = GetInterfaceFunction<DrawModelExecuteDlg>(21);
            _IsForcedMaterialOverride = GetInterfaceFunction<IsForcedMaterialOverrideDlg>(2);
            _ForcedMaterialOverride = GetInterfaceFunction<ForcedMaterialOverrideDlg>(1);
        }

        public bool IsForcedMaterialOverride()
        {
            return _IsForcedMaterialOverride(Address) != 0;
        }

        public void ForcedMaterialOverride(CMaterial* newMaterial, int nOverrideType = 0, int nOverrides = 0)
        {
            _ForcedMaterialOverride(Address, newMaterial, nOverrides, nOverrides);
        }
    }
}