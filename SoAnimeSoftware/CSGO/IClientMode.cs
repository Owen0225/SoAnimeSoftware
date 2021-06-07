using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO
{
    public class IClientMode : InterfaceBase
    {
        public unsafe delegate void SetViewSetupDlg(CViewSetup* setup);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate byte CreateMoveDlg(IntPtr thisPtr, float flInputSampleTime, CUserCmd* cmd);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate IntPtr DoPostScreenEffectsDlg(IntPtr thisPtr, IntPtr a1);

        public SetViewSetupDlg SetViewSetup;
        public CreateMoveDlg CreateMove;
        public DoPostScreenEffectsDlg DoPostScreenEffects;

        public IClientMode(IntPtr Address) : base(Address)
        {
            SetViewSetup = GetInterfaceFunction<SetViewSetupDlg>(18);
            CreateMove = GetInterfaceFunction<CreateMoveDlg>(24);
            DoPostScreenEffects = GetInterfaceFunction<DoPostScreenEffectsDlg>(44);
        }
    }
}