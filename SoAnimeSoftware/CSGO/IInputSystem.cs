using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IInputSystem : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void EnableInputDlg(IntPtr ptr, byte enable);

        public EnableInputDlg _EnableInput;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsButtonDownDlg(IntPtr ptr, int buttonCode);

        public IsButtonDownDlg _IsButtonDown;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ResetInputStateDlg(IntPtr ptr);

        public ResetInputStateDlg _ResetInputState;


        public IInputSystem(IntPtr Address) : base(Address)
        {
            _EnableInput = GetInterfaceFunction<EnableInputDlg>(11);
            _IsButtonDown = GetInterfaceFunction<IsButtonDownDlg>(15);
            _ResetInputState = GetInterfaceFunction<ResetInputStateDlg>(39);
        }

        public void EnableInput(bool enable)
        {
            _EnableInput(Address, enable ? (byte) 1 : (byte) 0);
        }

        public bool IsButtonDown(int buttonCode)
        {
            return _IsButtonDown(Address, buttonCode) != 0;
        }

        public void ResetInputState()
        {
            _ResetInputState(Address);
        }
    }
}