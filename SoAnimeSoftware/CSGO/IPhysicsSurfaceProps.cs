using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IPhysicsSurfaceProps : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate CSurfaceData* GetSurfaceDataDlg(IntPtr address, int index);

        public GetSurfaceDataDlg _GetSurfaceData;

        public IPhysicsSurfaceProps(IntPtr Address) : base(Address)
        {
            _GetSurfaceData = GetInterfaceFunction<GetSurfaceDataDlg>(5);
        }

        public CSurfaceData* GetSurfaceData(int index)
        {
            return _GetSurfaceData(Address, index);
        }
    }

    public unsafe struct CSurfaceData
    {
        fixed byte pad[80]; // surfacephysicsparams_t  surfaceaudioparams_t  surfacesoundnames_t
        public float maxSpeedFactor;
        public float jumpFactor;
        public float penetrationModifier;
        public float damageModifier;
        public ushort material;
        public byte climbable;
    }
}