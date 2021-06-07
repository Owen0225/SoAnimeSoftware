using System;
using System.Runtime.InteropServices;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IRenderToRTHelper : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate RenderToRTData_t* CreateRenderToRTDataDlg(IntPtr Address, IntPtr IRenderToRTHelperObjectpObject,
            ref IVTFTexture pResultVTF);

        public CreateRenderToRTDataDlg _CreateRenderToRTData;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void StartRenderToRTDlg(IntPtr Address, ref RenderToRTData_t pRendertoRTData);

        public StartRenderToRTDlg _StartRenderToRT;


        public IRenderToRTHelper(IntPtr Address) : base(Address)
        {
            _CreateRenderToRTData = GetInterfaceFunction<CreateRenderToRTDataDlg>(2);
            _StartRenderToRT = GetInterfaceFunction<StartRenderToRTDlg>(3);
        }

        public RenderToRTData_t* CreateRenderToRTData(IntPtr IRenderToRTHelperObjectpObject, ref IVTFTexture pResultVTF)
        {
            return _CreateRenderToRTData(this.Address, IRenderToRTHelperObjectpObject, ref pResultVTF);
        }

        public void StartRenderToRT(ref RenderToRTData_t pRendertoRTData)
        {
            _StartRenderToRT(this.Address, ref pRendertoRTData);
        }
    }

    public unsafe struct IVTFTexture
    {
    }

    public unsafe struct RenderToRTData_t
    {
    }
}