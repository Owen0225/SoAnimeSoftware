using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IPrediction : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetupMoveDlg(IntPtr ptr, Entity* localPlayer, CUserCmd* cmd, IntPtr moveHelper,
            CMoveData* moveData);

        public SetupMoveDlg _SetupMove;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void FinishMoveDlg(IntPtr ptr, Entity* localPlayer, CUserCmd* cmd, CMoveData* moveData);

        public FinishMoveDlg _FinishMove;


        public IPrediction(IntPtr Address) : base(Address)
        {
            _SetupMove = GetInterfaceFunction<SetupMoveDlg>(20);
            _FinishMove = GetInterfaceFunction<FinishMoveDlg>(21);
        }

        public void FinishMove(Entity* localPlayer, CUserCmd* cmd, CMoveData* moveData)
        {
            _FinishMove(Address, localPlayer, cmd, moveData);
        }

        public void SetupMove(Entity* localPlayer, CUserCmd* cmd, IntPtr moveHelper, CMoveData* moveData)
        {
            _SetupMove(Address, localPlayer, cmd, moveHelper, moveData);
        }
    }
}