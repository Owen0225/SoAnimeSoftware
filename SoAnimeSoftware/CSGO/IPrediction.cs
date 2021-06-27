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
        
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CheckMovingGroundDlg(IntPtr ptr, Entity* localPlayer, ref float frametime);

        public CheckMovingGroundDlg _CheckMovingGround;
        
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetViewAnglesDlg(IntPtr ptr, ref Vector vec);

        public SetViewAnglesDlg _SetViewAngles;

        public IPrediction(IntPtr Address) : base(Address)
        {
            _SetViewAngles = GetInterfaceFunction<SetViewAnglesDlg>(13);
            _CheckMovingGround = GetInterfaceFunction<CheckMovingGroundDlg>(18);
            _SetupMove = GetInterfaceFunction<SetupMoveDlg>(20);
            _FinishMove = GetInterfaceFunction<FinishMoveDlg>(21);
        }

        public void SetViewAngles(ref Vector vec)
        {
            _SetViewAngles(Address, ref vec);
        }

        public void CheckMovingGround(Entity* localPlayer, ref float frametime)
        {
            _CheckMovingGround(Address, localPlayer, ref frametime);
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