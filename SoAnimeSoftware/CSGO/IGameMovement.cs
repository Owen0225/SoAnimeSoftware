using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IGameMovement : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ProcessMovementDlg(IntPtr ptr, Entity* localPlayer, CMoveData* moveData);

        public ProcessMovementDlg _ProcessMovement;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void StartTrackPredictionErrorsDlg(IntPtr ptr, Entity* player);

        public StartTrackPredictionErrorsDlg _StartTrackPredictionErrors;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void FinishTrackPredictionErrorsDlg(IntPtr ptr, Entity* player);

        public FinishTrackPredictionErrorsDlg _FinishTrackPredictionErrors;


        public IGameMovement(IntPtr Address) : base(Address)
        {
            _ProcessMovement = GetInterfaceFunction<ProcessMovementDlg>(1);
            _StartTrackPredictionErrors = GetInterfaceFunction<StartTrackPredictionErrorsDlg>(3);
            _FinishTrackPredictionErrors = GetInterfaceFunction<FinishTrackPredictionErrorsDlg>(4);
        }

        public void ProcessMovement(Entity* localPlayer, CMoveData* moveData)
        {
            _ProcessMovement(Address, localPlayer, moveData);
        }

        public void StartTrackPredictionErrors(Entity* player)
        {
            _StartTrackPredictionErrors(Address, player);
        }

        public void FinishTrackPredictionErrors(Entity* player)
        {
            _FinishTrackPredictionErrors(Address, player);
        }
    }
}