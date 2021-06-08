using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Hack.Grief;
using SoAnimeSoftware.Hack.Misc;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;
using SoAnimeSoftware.Hack.Visuals;
using SoAnimeSoftware.Objects;
using SoAnimeSoftware.Utils;


namespace SoAnimeSoftware.Hack
{
    public unsafe class Hooks
    {
        public static RawHook<IClientMode.SetViewSetupDlg> SetViewSetupRawHook;
        public static RawHook<IClientMode.CreateMoveDlg> CreateMoveRawHook;
        public static RawHook<IClientMode.DoPostScreenEffectsDlg> DoPostScreenEffectsRawHook;
        public static RawHook<IClient.FrameStageNotifyDlg> FrameStageNotifyRawHook;
        public static RawHook<NetVarManager.ViewModelSequenceDlg> ViewModelSequenceRawHook;

        public static RawHook<IGameEventManager.FireEventClientSideDlg> FireEventClientSideRawHook;
        public static RawHook<IPanel.PaintTraverseDlg> PaintTraverseRawHook;
        public static RawHook<IModelRender.DrawModelExecuteDlg> DrawModelExecuteRawHook;
        public static RawHook<INetChannel.SendNetMsg> SendNetMsgRawHook;
        public static RawHook<ISound.EmitSoundDlg> EmitSoundRawHook;
        public static RawHook<ISurface.LockCursorDlg> LockCursorRawHook;

        public static RawHook<IRenderView.SceneEndDlg> SceneEndRawHook;
        public static RawHook<IRenderToRTHelper.CreateRenderToRTDataDlg> CreateRenderToRtDataRawHook;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate uint PresentDlg(IntPtr device, IntPtr src, IntPtr dest, IntPtr windowOverride,
            IntPtr dirtyRegion);

        public static RawHook<PresentDlg> PresentHookRawHook;

        public static void Init()
        {
            //PresentHookRawHook = new RawHook<PresentDlg>(*(IntPtr*) Offsets.DxPresentPointer, PresentHooked);
            //PresentHookRawHook.Hook();

            SetViewSetupRawHook = SDK.ClientMode.HookFunction<IClientMode.SetViewSetupDlg>(18, SetViewSetupHooked);
            SetViewSetupRawHook.Hook();
            FrameStageNotifyRawHook =
                SDK.Client.HookFunction<IClient.FrameStageNotifyDlg>(37, FrameStageNotifyHooked);
            FrameStageNotifyRawHook.Hook();
            DoPostScreenEffectsRawHook =
                SDK.ClientMode.HookFunction<IClientMode.DoPostScreenEffectsDlg>(44, DoPostScreenEffectsHooked);
            DoPostScreenEffectsRawHook.Hook();


            ViewModelSequenceRawHook = new RawHook<NetVarManager.ViewModelSequenceDlg>(
                (IntPtr) NetVarManager.GetProp("DT_BaseViewModel", "m_nSequence") + 8 * 4, ViewModelSequenceHooked);
            ViewModelSequenceRawHook.Hook();

            _ebpPtr = Marshal.AllocHGlobal(sizeof(int));
            *(int*) _ebpPtr = 0;

            var ebp = BitConverter.GetBytes((int) _ebpPtr);

            var shellcode = new byte[]
            {
                0x89, 0x2D, ebp[0], ebp[1], ebp[2], ebp[3], // mov    DWORD PTR ds:0x0,ebp
            };

            CreateMoveRawHook =
                SDK.ClientMode.HookFunction<IClientMode.CreateMoveDlg>(24, shellcode, CreateMoveHooked);
            CreateMoveRawHook.Hook();

            FireEventClientSideRawHook =
                SDK.GameEventManager.HookFunction<IGameEventManager.FireEventClientSideDlg>(9,
                    FireEventClientSideHooked);
            FireEventClientSideRawHook.Hook();

            PaintTraverseRawHook = SDK.Panel.HookFunction<IPanel.PaintTraverseDlg>(41, PaintTraverseHooked);
            PaintTraverseRawHook.Hook();

            DrawModelExecuteRawHook =
                SDK.ModelRender.HookFunction<IModelRender.DrawModelExecuteDlg>(21, DrawModelExecuteHooked);
            DrawModelExecuteRawHook.Hook();

            EmitSoundRawHook = SDK.Sound.HookFunction<ISound.EmitSoundDlg>(5, EmitSoundHooked);
            EmitSoundRawHook.Hook();

            LockCursorRawHook = SDK.Surface.HookFunction<ISurface.LockCursorDlg>(67, LockCursorHooked);
            LockCursorRawHook.Hook();

            SceneEndRawHook = SDK.RenderView.HookFunction<IRenderView.SceneEndDlg>(9, SceneEndHooked);
            //SceneEndRawHook.Hook(); unoptimized chams draw

            if (SDK.ClientState != null && SDK.ClientState->m_NetChannel != null)
            {
                SendNetMsgRawHook =
                    RawHook<INetChannel.SendNetMsg>.InVTable((IntPtr) SDK.ClientState->m_NetChannel, 40,
                        SendNetMsgHooked);
                SendNetMsgRawHook.Hook();
            }
        }

        public static void OnEvent(GameEvent* e)
        {
            if (e->GetName()->ToString() == "server_spawn")
            {
                if (SDK.ClientState != null && SDK.ClientState->m_NetChannel != null && SendNetMsgRawHook == null)
                {
                    SendNetMsgRawHook =
                        RawHook<INetChannel.SendNetMsg>.InVTable((IntPtr) SDK.ClientState->m_NetChannel, 40,
                            SendNetMsgHooked);
                    SendNetMsgRawHook.Hook();
                }
            }
        }

        public static void Unhook()
        {
            GVars.Unhook = true;

            //PresentHookRawHook.Unhook();
            //WinAPI.SetWindowLongPtr32(g_hWnd, -4, oPtrWndProc);

            SetViewSetupRawHook.Unhook();

            CreateMoveRawHook.Unhook(true);

            DoPostScreenEffectsRawHook.Unhook();
            FrameStageNotifyRawHook.Unhook();

            ViewModelSequenceRawHook.Unhook();

            FireEventClientSideRawHook.Unhook();
            PaintTraverseRawHook.Unhook();

            DrawModelExecuteRawHook.Unhook();

            if (SDK.ClientState != null && SDK.ClientState->m_NetChannel != null)
                SendNetMsgRawHook.Unhook();

            EmitSoundRawHook.Unhook();
            LockCursorRawHook.Unhook();
            SceneEndRawHook.Unhook();
            //CreateRenderToRtDataRawHook.Unhook();
        }


        private static void SceneEndHooked(IntPtr ptr)
        {
            FloatColor[] colors = new FloatColor[]
                {new FloatColor(Color.DeepPink), new FloatColor(Color.Coral), new FloatColor(Color.CornflowerBlue)};
            try
            {
                for (int j = 0; j < TargetList.Targets.Length; j++)
                {
                    var target = TargetList.Targets[j];

                    if (target == null || !target.Valid || target.Ticks == null || target.Ticks.Count == 0 ||
                        target.MainTick.Entity == null)
                        continue;

                    if (SDK.EntityList.GetEntityByIndex(j) != target.MainTick.Entity)
                        continue;


                    var last = target.Ticks.Last;
                    for (int i = 0; i < target.Ticks.Count / 3; i++)
                    {
                        if (i > 2)
                            break;

                        last = last.Previous;
                        last = last.Previous;
                        var tick = last.Value;
                        var orig = tick.Entity->m_vecOrigin;
                        tick.Entity->SetAbsOrigin(ref tick.Origin);
                        if (tick.Entity == null || tick.Entity->IsDormant())
                            continue;

                        if (!tick.Entity->IsVisible())
                            continue;

                        SDK.StudioRender.ForcedMaterialOverride(Chams.Flat);


                        SDK.RenderView.SetColorModulation(colors[i % 3]);

                        tick.Entity->DrawModel(0x1, 255);
                        CSGO.SDK.StudioRender.ForcedMaterialOverride((CMaterial*) IntPtr.Zero);
                        tick.Entity->SetAbsOrigin(ref orig);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }

            SceneEndRawHook.O(ptr);
        }

        private static int ViewModelSequenceHooked(CRecvProxyData* pDataConst, IntPtr pStruct, IntPtr pOut)
        {
            SkinChanger.SequenceFix(pDataConst, pStruct);

            return ViewModelSequenceRawHook.O(pDataConst, pStruct, pOut);
        }

        private static void SetViewSetupHooked(CViewSetup* setup)
        {
            if (SDK.g_LocalPlayer() == null || SDK.g_LocalPlayer()->m_bIsScoped)
            {
                SetViewSetupRawHook.O(setup);
                return;
            }

            if (SDK.g_LocalPlayer() != null && SDK.g_LocalPlayer()->IsAlive())
            {
                Perception.Thirdperson();
            }

            setup->fov = Settings.visualFov;

            SetViewSetupRawHook.O(setup);
        }


        public static byte* SendPackets;
        private static IntPtr _ebpPtr;


        public static byte CreateMoveHooked(IntPtr thisPtr, float flInputSampleTime, CUserCmd* cmd)
        {
            var result = CreateMoveRawHook.O(thisPtr, flInputSampleTime, cmd);
            if (result == 0)
                return 0;

            if (cmd == null || cmd->m_iCmdNumber == 0 || !SDK.Engine.IsInGame())
                return result;


            SendPackets = (byte*) (Memory.ReadPointer(_ebpPtr) - 0x1c);

            if (Input.KeyDown(System.Windows.Forms.Keys.H))
                *SendPackets = 0;

            SDK.GlobalVars->servertime(cmd);

            MovementManager.NeedAttack = (cmd->m_iButtons & (int) EButtonState.IN_ATTACK) != 0;
            TeamDamageTracker.OverlayDrawing = (cmd->m_iButtons & (int) EButtonState.IN_SCORE) != 0;

            VoiceAudioPlayer.AutoStopAudio();
            Other.Rasprijka(cmd);

            Other.RankReveal(cmd);

            Movement.BHop(cmd, true);

            Movement.FastCrouch(cmd);
            Other.VelocityClanTag();
            TeamDamageTracker.FetchPlayersHealth();


            if (SDK.g_LocalPlayer() != null && SDK.g_LocalPlayer()->IsAlive())
            {
                Movement.AutoLadderJump(cmd);

                Other.ChatBreaker();

                MovementManager.HandleInput(cmd);
                Movement.PropAutoStrafe(cmd);

                EnginePrediction.Start(cmd);
                Backtrack.GetNetDelays(cmd->m_iTickCount);

                try
                {
                    TargetList.Fetch(cmd);
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }
                
                

                Movement.JumpBug(cmd);

                EnginePrediction.Finish(cmd);

                //Hack.Misc.Movement.EdgeBugTracker(cmd);
                Movement.EdgeJump(cmd);
                Movement.PreJump(cmd);

                

                try
                {
                    Aimbot.Run(cmd);
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.ToString());
                }

                Perception.PassiveHitchanceOnCreateMove(cmd);
                Movement.FastStop(cmd);
                MovementManager.Assist(cmd);
                DoorSpammer.Run(cmd);
                BlockBot.Run(cmd);

                MovementManager.Run(cmd);
            }

            Movement.SlideWalk(cmd);

            cmd->m_vecViewAngles.NormalizeAngle();
            cmd->m_vecViewAngles.Clamp();

            if ((cmd->m_iButtons & (int) EButtonState.IN_ATTACK) != 0 && Settings.silent)
                return (byte) 0;
            else
                return (byte) 1;
        }

        private static IntPtr DoPostScreenEffectsHooked(IntPtr ptr, IntPtr a1)
        {
            if (SDK.Engine.IsInGame())
            {
                Glow.Run();
                Perception.ReduceFlash(Settings.flashReduce ? 70 : 0);
                Checks.Update();
                Perception.Thirdperson();
            }

            return DoPostScreenEffectsRawHook.O(ptr, a1);
        }

        private static void FrameStageNotifyHooked(EFrameStage stage)
        {
            if (SDK.Engine.IsInGame())
            {
                if (stage == EFrameStage.NET_UPDATE_POSTDATAUPDATE_START)
                {
                    SkinChanger.Run();
                    SkinChanger.UpdateHud();
                }

                Perception.DisablePostprocessing(stage);
            }

            FrameStageNotifyRawHook.O(stage);
        }

        public static void EmitSoundHooked(SoundData data)
        {
            if (!SDK.Engine.IsInGame())
                Misc.Other.AutoAccept(data.soundEntry->ToString());

            EmitSoundRawHook.O(data);
        }

        public static byte SendNetMsgHooked(INetChannel* pNetChan, INetMessage* msg, byte bForceReliable, byte bVoice)
        {
            if (msg->GetType() == 14 && Settings.sv_pure_bypass) //sv_pure bypass
            {
                return 0;
            }

            return SendNetMsgRawHook.O(pNetChan, msg, bForceReliable, bVoice);
        }

        private static void DrawModelExecuteHooked(IntPtr ptr, IntPtr ctx, IntPtr state, ModelRenderInfo* info,
            ref Matrix3x4 customBoneToWorld)
        {
            Visuals.Chams.Render(ptr, ctx, state, info, ref customBoneToWorld);
        }

        private static void PaintTraverseHooked(IntPtr ptr, IntPtr vguiPanel, byte forceRepaint, byte allowForce)
        {
            var name = CSGO.SDK.Panel.GetName(vguiPanel)->ToString();
            switch (name)
            {
                case "MatSystemTopPanel":
                {
                    Hack.Visuals.Perception.Watermark();
                    Render.UpdateTime();
                    AnimeGUI.Render();
                    Visuals.Perception.BombTimer();
                    Visuals.Perception.RenderDrawList();
                    Visuals.Perception.RenderTickDrawList();
                    Visuals.Perception.RemoveScopeOverlay();

                    if (CSGO.SDK.Engine.IsInGame())
                    {
                        Visuals.Esp.Draw();
                        Visuals.Perception.DamageOverlay();
                        Visuals.Perception.TeamDamageOverlay();
                        Visuals.Perception.MovementRecorderPoints();
                        Visuals.Perception.SpectatorList();
                        Visuals.Perception.AimCircle();
                        Visuals.Perception.HitMarker();
                        Visuals.Perception.PassiveHitchanceDraw();
                        Visuals.Perception.TraceDebug();
                        Visuals.Perception.BottomOverlay();
                    }

                    break;
                }
                case "HudZoom":
                {
                    if (Settings.removeScopeOverlay)
                        return;
                    break;
                }
            }

            PaintTraverseRawHook.O(ptr, vguiPanel, forceRepaint, allowForce);
        }

        private static byte FireEventClientSideHooked(IntPtr ptr, GameEvent* e)
        {
            if (Settings.debugEvents)
                Log.Debug("New event:", e->GetName()->ToString(), (IntPtr) e);

            Hooks.OnEvent(e);
            Misc.Checks.OnEvent(e);

            if (SDK.g_LocalPlayer() == null)
                return FireEventClientSideRawHook.O(ptr, e);

            Grief.VoteLogger.Run(e);
            Misc.Other.HitSound(e);
            try
            {
                Grief.TeamDamageTracker.Run(e);
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }

            Misc.Other.VoiceEvents(e);
            Misc.Other.Golosovanie(e);
            Visuals.SkinChanger.FixHudIcon(e);
            MovementManager.OnEvent(e);
            Visuals.Perception.HitMarkerOnEvent(e);

            return FireEventClientSideRawHook.O(ptr, e);
        }


        public static void LockCursorHooked(IntPtr ptr)
        {
            if (GVars.MenuOpened)
            {
                SDK.Surface.UnlockCursor();
                SDK.InputSystem.EnableInput(false);
            }
            else
            {
                LockCursorRawHook.O(ptr);
                SDK.InputSystem.EnableInput(true);
            }
        }
    }
}