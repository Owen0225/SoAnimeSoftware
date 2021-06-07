using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public class IGameEventManager : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate byte AddListenerDlg(IntPtr ptr, string name, byte da = 0);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate byte FireEventClientSideDlg(IntPtr ptr, GameEvent* e);

        public AddListenerDlg _AddListener;
        public FireEventClientSideDlg FireEventClientSide;

        public IGameEventManager(IntPtr Address) : base(Address)
        {
            _AddListener = GetInterfaceFunction<AddListenerDlg>(3);

            FireEventClientSide = GetInterfaceFunction<FireEventClientSideDlg>(9);
        }

        public void AddListener(string name)
        {
            _AddListener(Address, name);
        }
    }
}