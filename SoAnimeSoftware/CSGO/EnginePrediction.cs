using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    struct Prediction
    {
        public int Buttons;
        public int Flags;
        public int MoveType;
        public float CurrentTime;
        public float FrameTime;
        public Vector Origin;
        public Vector Velocity;
    }

    unsafe class EnginePrediction
    {
        public static int oldButtons;

        public static int preButtons;
        public static int preFlags;
        public static int preMoveType;
        public static float preCurrentTime;
        public static float preFrameTime;
        public static Vector preOrigin;
        public static Vector preVelocity;

        public static Prediction[] prediction = new Prediction[4];

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

            preOrigin = lp->m_vecOrigin;
            preButtons = cmd->m_iButtons;
            preCurrentTime = SDK.GlobalVars->curtime;
            preFrameTime = SDK.GlobalVars->frametime;
            preFlags = lp->m_fFlags;
            preMoveType = lp->m_nMoveType;
            preVelocity = lp->m_vecVelocity;

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

        public static void withCrouch(CUserCmd* cmd)
        {
            if (!Settings.autoCrouch)
                return;

            var lp = SDK.g_LocalPlayer();

            if ((EnginePrediction.preFlags & (int) EEntityFlags.FL_ONGROUND) != 0)
                return;

            if ((cmd->m_iButtons & (int) EButtonState.IN_DUCK) != 0)
            {
                cmd->m_iButtons &= ~(int) EButtonState.IN_DUCK;
            }
            else
            {
                cmd->m_iButtons |= (int) EButtonState.IN_DUCK;
            }

            prediction[0].Origin = lp->m_vecOrigin;
            prediction[0].Buttons = cmd->m_iButtons;
            prediction[0].CurrentTime = SDK.GlobalVars->curtime;
            prediction[0].FrameTime = SDK.GlobalVars->frametime;
            prediction[0].Flags = lp->m_fFlags;
            prediction[0].MoveType = lp->m_nMoveType;
            prediction[0].Velocity = lp->m_vecVelocity;

            for (int i = 1; i < prediction.Length; i++)
            {
                Hack.Misc.Movement.PropAutoStrafe(cmd);
                Start(cmd);
                Finish(cmd);
                prediction[i].Origin = lp->m_vecOrigin;
                prediction[i].Buttons = cmd->m_iButtons;
                prediction[i].CurrentTime = SDK.GlobalVars->curtime;
                prediction[i].FrameTime = SDK.GlobalVars->frametime;
                prediction[i].Flags = lp->m_fFlags;
                prediction[i].MoveType = lp->m_nMoveType;
                prediction[i].Velocity = lp->m_vecVelocity;
            }

            //Reset();
        }

        public static void Reset()
        {
            var lp = SDK.g_LocalPlayer();
            lp->m_vecOrigin = EnginePrediction.preOrigin;
            lp->m_fFlags = EnginePrediction.preFlags;
            lp->m_nMoveType = EnginePrediction.preMoveType;
            lp->m_vecVelocity = EnginePrediction.preVelocity;
            SDK.GlobalVars->curtime = EnginePrediction.preCurrentTime;
            SDK.GlobalVars->frametime = EnginePrediction.preFrameTime;
        }

        public static void Finish(CUserCmd* cmd)
        {
            SDK.GameMovement.FinishTrackPredictionErrors(SDK.g_LocalPlayer());
            SDK.MoveHelper.SetHost((Entity*) IntPtr.Zero);

            *SDK.m_pPredictionRandomSeed = -1;

            SDK.GlobalVars->curtime = preCurrentTime;
            SDK.GlobalVars->frametime = preFrameTime;
        }
    }
}