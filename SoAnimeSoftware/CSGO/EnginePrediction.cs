using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Hack;
using SoAnimeSoftware.Objects;
using SoAnimeSoftware.Utils;
using Vector = SoAnimeSoftware.CSGO.Structs.Vector;

namespace SoAnimeSoftware.CSGO
{
    unsafe static class EnginePrediction
    {
        public struct BackupData
        {
            public int Flags;
            public IntPtr GroundEntity;

            public int v1;
            public int v2;
            public int v3;

            public bool AllowAutoMovement;

            public Vector Origin;
            public Vector Velocity;
            public Vector AbsOrigin;
        }


        public static int Buttons;
        public static int Flags;
        public static int MoveType;
        public static float CurrentTime;
        public static int TickCount;
        public static int TickBase;
        public static int ServerTick;
        public static float FrameTime;
        public static Vector Origin;
        public static Vector Velocity;

        public static byte FirstTimePredicted;
        public static byte v17;


        public static BackupData LastBackup;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int sub_3BE9B310Dlg(Entity* _this, ref int v6);

        private static sub_3BE9B310Dlg sub_3BE9B310 = null;

        public static void Start(CUserCmd* cmd)
        {
            if (!SDK.Engine.IsInGame())
                return;

            if (SDK.g_LocalPlayer() == null)
                return;

            if (!SDK.g_LocalPlayer()->IsAlive())
                return;

            *SDK.m_pPredictionRandomSeed = cmd->m_iRandomSeed & 0x7FFFFFFF;

            Entity* lp = SDK.g_LocalPlayer();

            Origin = lp->m_vecOrigin;
            Buttons = cmd->m_iButtons;
            CurrentTime = SDK.GlobalVars->curtime;
            FrameTime = SDK.GlobalVars->frametime;
            Flags = lp->m_fFlags;
            MoveType = lp->m_nMoveType;
            Velocity = lp->m_vecVelocity;

            SDK.GlobalVars->curtime = lp->m_nTickBase * SDK.GlobalVars->interval_per_tick;
            SDK.GlobalVars->frametime = SDK.GlobalVars->interval_per_tick;

            SDK.GameMovement.StartTrackPredictionErrors(lp);

            //Marshal.WriteInt32((IntPtr)SDK.MoveData, 0);
            SDK.MoveData->ToZero();

            SDK.MoveHelper.SetHost(lp);
            SDK.Prediction.SetupMove(lp, cmd, SDK.MoveHelper.Address, SDK.MoveData);
            SDK.GameMovement.ProcessMovement(lp, SDK.MoveData);
            SDK.Prediction.FinishMove(lp, cmd, SDK.MoveData);
        }
        
        public static void Finish(CUserCmd* cmd)
        {
            SDK.GameMovement.FinishTrackPredictionErrors(SDK.g_LocalPlayer());
            SDK.MoveHelper.SetHost((Entity*) IntPtr.Zero);

            *SDK.m_pPredictionRandomSeed = -1;

            SDK.GlobalVars->curtime = CurrentTime;
            SDK.GlobalVars->frametime = FrameTime;
        }

        
        // almost copied from reversed clarity crack 
        // CheckMovingGround will crash you
        // cmdlcache fields not implemented 
        public static void Start2(CUserCmd* cmd, bool for_funcs = false, bool crouch = false)
        {
            
            var lp = SDK.g_LocalPlayer();

            CurrentTime = SDK.GlobalVars->curtime;
            TickCount = SDK.GlobalVars->tickcount;
            FrameTime = SDK.GlobalVars->frametime;
            TickBase = lp->m_nTickBase;
            ServerTick = SDK.GlobalVars->ServerTick(cmd);
            

            FirstTimePredicted = *(byte*) (SDK.Prediction.Address + 24);
            v17 = *(byte*) (SDK.Prediction.Address + 8);
            

            *(CUserCmd*) ((IntPtr) lp + 13112) = *cmd;

            *SDK.m_pPredictionRandomSeed = cmd != null ? cmd->m_iRandomSeed : -1;
            

            // *(IntPtr*) Offsets.PredictionHost = (IntPtr) lp;
            

            SDK.GlobalVars->curtime = SDK.GlobalVars->interval_per_tick * ServerTick;
            SDK.GlobalVars->tickcount = ServerTick;
            var kek = SDK.GlobalVars->frametime;
            SDK.GlobalVars->frametime =
                (*(byte*) (SDK.Prediction.Address + 10) != 0) ? 0 : SDK.GlobalVars->interval_per_tick;
            

            *(byte*) (SDK.Prediction.Address + 24) = 0;
            *(byte*) (SDK.Prediction.Address + 8) = 1;

            cmd->m_iButtons |= *(int*) ((IntPtr) lp + 13104);
            cmd->m_iButtons &= ~(*(int*) ((IntPtr) lp + 13108));

            var v16 = cmd->m_iButtons;
            var v15 = (int*) ((IntPtr) lp + 12792);
            var v9 = *v15 ^ v16;
            *(int*) ((IntPtr) lp + 12780) = *(int*) ((IntPtr) lp + 12792);
            *v15 = v16;
            *(int*) ((IntPtr) lp + 12784) = v9 & v16;
            *(int*) ((IntPtr) lp + 12788) = v9 & ~v16;
            

            SDK.MoveHelper.SetHost(lp);
            SDK.GameMovement.StartTrackPredictionErrors(lp);
            // SDK.Prediction.CheckMovingGround(lp, ref kek);
            SDK.Prediction.SetViewAngles(ref cmd->m_vecViewAngles);
            

            int v6 = 0;
            if (sub_3BE9B310 == null)
            {
                sub_3BE9B310 = Marshal.GetDelegateForFunctionPointer<sub_3BE9B310Dlg>(Offsets.off_3BFB61DC);
            }

            if (sub_3BE9B310(lp, ref v6) != 0)
            {
                lp->sub_3BDCA4D0();
            }
            

            *SDK.MoveData = new CMoveData();
            SDK.Prediction.SetupMove(lp, cmd, SDK.MoveHelper.Address, SDK.MoveData);

            if (for_funcs)
            {
                if (crouch)
                    SDK.MoveData->m_nButtons |= (int) EButtonState.IN_DUCK;

                SDK.MoveData->m_nButtons &= 0xFFFFFDFF;
                SDK.MoveData->m_nButtons &= 0xFFFFFBFF;
                SDK.MoveData->m_nButtons &= 0xFFFFFFF7;
                SDK.MoveData->m_nButtons &= 0xFFFFFFEF;

                SDK.MoveData->m_flSideMove = 0;
                SDK.MoveData->m_flForwardMove = 0;

                if (!Settings.bunnyHop)
                {
                    SDK.MoveData->m_nButtons &= 0xFFFFFFFD;
                    SDK.MoveData->m_nButtons &= 0xFFFFFFFD;
                }
            }
            
            
            SDK.GameMovement.ProcessMovement(lp, SDK.MoveData);
            SDK.Prediction.FinishMove(lp, cmd, SDK.MoveData);
            SDK.MoveHelper.ProcessImpacts();
            SDK.GameMovement.FinishTrackPredictionErrors(lp);
            
            // cmdlcache here

            var v3 = TickBase;
            lp->m_nTickBase = v3;
            
            *(byte*) (SDK.Prediction.Address + 24) = FirstTimePredicted;
            *(byte*) (SDK.Prediction.Address + 8) = v17;
        }

        public static void Finish2(CUserCmd* cmd)
        {
            SDK.MoveHelper.SetHost((Entity*)0);
            
            *(int*) ((IntPtr) SDK.g_LocalPlayer() + 13112) = 0;
            
            *SDK.m_pPredictionRandomSeed = -1;                // m_pPredictionRandomSeed = -1
            
            // *(IntPtr*) Offsets.PredictionHost = IntPtr.Zero;
            
            SDK.GlobalVars->curtime = CurrentTime;
            SDK.GlobalVars->tickcount = TickCount;
            SDK.GlobalVars->frametime = FrameTime;
            
            
            SDK.GameMovement.Reset();
            
        }

        public static void Save()
        {
            var p = new BackupData();

            var lp = SDK.g_LocalPlayer();
            p.GroundEntity = *(IntPtr*) ((IntPtr) lp + 0x150);
            p.Flags = lp->m_fFlags;
            p.v1 = *(int*) ((IntPtr) lp + 0x3014);
            p.v2 = *(int*) ((IntPtr) lp + 0x322c);
            p.v3 = *(int*) ((IntPtr) lp + 0xe0);

            p.AllowAutoMovement = lp->m_bAllowAutoMovement;

            p.Velocity = lp->m_vecBaseVelocity;
            p.Origin = lp->m_vecOrigin;
            p.AbsOrigin = *lp->GetAbsOrigin();

            LastBackup = p;
        }

        public static void Backup()
        {
            var lp = SDK.g_LocalPlayer();
            var p = LastBackup;

            *(IntPtr*) ((IntPtr) lp + 0x150) = p.GroundEntity;
            lp->m_fFlags = p.Flags;
            *(int*) ((IntPtr) lp + 0x3014) = p.v1;
            *(int*) ((IntPtr) lp + 0x322c) = p.v2;
            *(int*) ((IntPtr) lp + 0xe0) = p.v3;

            lp->m_bAllowAutoMovement = p.AllowAutoMovement;

            lp->m_vecBaseVelocity = p.Velocity;
            lp->m_vecOrigin = p.Origin;
            *lp->GetAbsOrigin() = p.AbsOrigin;
        }
    }
}