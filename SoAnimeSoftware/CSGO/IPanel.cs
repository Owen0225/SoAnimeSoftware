using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IPanel : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void PaintTraverseDlg(IntPtr ptr, IntPtr vguiPanel, byte forceRepaint, byte allowForce);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void GetPanelDlg(IntPtr ptr, int type);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* GetNameDlg(IntPtr ptr, IntPtr panel);

        public PaintTraverseDlg PaintTraverse;
        public GetPanelDlg GetPanel;
        public GetNameDlg _GetName;

        public IPanel(IntPtr Address) : base(Address)
        {
            GetPanel = GetInterfaceFunction<GetPanelDlg>(1);
            _GetName = GetInterfaceFunction<GetNameDlg>(36);
            PaintTraverse = GetInterfaceFunction<PaintTraverseDlg>(41);
        }

        public Char_t* GetName(IntPtr panel)
        {
            return _GetName(Address, panel);
        }
    }
}