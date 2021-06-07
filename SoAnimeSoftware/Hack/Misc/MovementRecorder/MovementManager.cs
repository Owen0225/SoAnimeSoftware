using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.GUI.Elements;
using SoAnimeSoftware.GUI.Elements.Abstraction;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack.Misc.MovementRecorder
{
    unsafe static class MovementManager
    {
        private const int MaxRecordTickCount = 3840;

        public static readonly Replays Replays = new Replays(Path.Combine(GVars.MainPath, "MovementRecorder"));
        public static Record ActiveRecord;
        public static Record TempRecord;
        public static Record ClipRecord;
        public static Record EditedRecord;


        public static int MaxTicks = int.MaxValue;
        static int _nextTickIndex;
        public static bool IsPlaying;
        public static bool IsReady;
        public static bool IsEditing;
        static int _skipTicks;
        public static bool IsRecording;
        static bool _inited;
        public static bool NeedAttack = false;

        static int _clipTickIndex;
        static bool _canClip;


        public static void OnEvent(GameEvent* e)
        {
            if (e->GetName()->ToString() == "player_hurt")
            {
                Entity* target = SDK.Engine.GetEntityByUserID(e->GetInt("userid"));

                if (target == SDK.g_LocalPlayer() && e->GetInt("attacker") != SDK.g_LocalPlayer()->UserID() &&
                    e->GetInt("attacker") != 0)
                    Stop();
            }
        }

        public static void HandleInput(CUserCmd* cmd)
        {
            if (_skipTicks > 0)
            {
                if ((cmd->m_iButtons & (int) EButtonState.IN_USE) != 0 ||
                    (cmd->m_iButtons & (int) EButtonState.IN_SCORE) != 0)
                {
                    cmd->m_iButtons &= ~(int) EButtonState.IN_USE;
                    cmd->m_iButtons &= ~(int) EButtonState.IN_SCORE;
                }

                _skipTicks--;
                return;
            }

            if ((cmd->m_iButtons & (int) EButtonState.IN_USE) != 0 &&
                (cmd->m_iButtons & (int) EButtonState.IN_SCORE) != 0)
            {
                cmd->m_iButtons &= ~(int) EButtonState.IN_USE;
                cmd->m_iButtons &= ~(int) EButtonState.IN_SCORE;

                if (IsPlaying)
                    Stop();
                else if (!IsRecording && !IsReady)
                    Start();
                else if (IsRecording)
                {
                    Stop();
                    Replays.Save(TempRecord);
                    Replays.Add(TempRecord);
                }

                _skipTicks = 15;
            }
            else if ((Input.KeyDown(0x10) && Input.KeyPressed(0x45)) ||
                     (Input.KeyPressed(0x10) && Input.KeyDown(0x45)))
            {
                if (_canClip)
                {
                    _canClip = false;

                    Replays.Save(ClipRecord);
                    Replays.Add(ClipRecord);

                    SDK.HudChat->Notify("Clip saved.");

                    cmd->m_iButtons &= ~(int) EButtonState.IN_USE;

                    _skipTicks = 15;
                }
            }

            if (IsPlaying || IsRecording)
                return;

            bool found = false;

            for (int i = 0; i < Replays.Count; i++)
            {
                if ((SDK.g_LocalPlayer()->m_vecOrigin - Replays[i].StartPosition).Length < 0.35f &&
                    Replays[i].LevelName == SDK.Engine.GetLevelName()->ToString().Replace("_scrimmagemap", ""))
                {
                    ActiveRecord = Replays[i];
                    if (!IsReady)
                    {
                        MaxTicks = ActiveRecord.Ticks.ToList().FindIndex(x => x.Cmd.m_iTickCount == 0);
                        if (MaxTicks == -1)
                            MaxTicks = 3840;
                    }

                    found = true;
                    break;
                }
            }

            if (found)
            {
                if (!IsReady)
                {
                    SDK.HudChat->Notify("Press USE button to run.");
                    _lastPoint = new Vector();
                    IsReady = true;
                }

                if ((cmd->m_iButtons & (int) EButtonState.IN_USE) != 0 &&
                    (cmd->m_iButtons & (int) EButtonState.IN_SCORE) == 0)
                {
                    _nextTickIndex = 0;
                    SDK.HudChat->Notify("Ебашим B-)");
                    IsPlaying = true;
                    IsReady = false;
                    cmd->m_iButtons &= ~(int) EButtonState.IN_USE;
                }

                if (EditedRecord.Ticks == null || EditedRecord.Ticks.Length == 0)
                    EditedRecord = ActiveRecord;

                if (Input.KeyPressed(Keys.Oemplus))
                {
                    IsEditing = true;
                    MaxTicks++;
                }
                else if (Input.KeyPressed(Keys.OemMinus))
                {
                    IsEditing = true;
                    MaxTicks--;
                }
                else if (Input.KeyPressed(Keys.Enter))
                {
                    Replays.Save(ActiveRecord, "Backups");
                    EditedRecord.Ticks[MaxTicks].Cmd.m_iTickCount = 0;
                    Replays.Save(EditedRecord);
                    Replays.Refresh();
                    IsEditing = false;
                    SDK.HudChat->Notify("Saved d-_-b");
                }
                else if (Input.KeyPressed(Keys.Delete))
                {
                    Replays.Delete(ActiveRecord);
                    Replays.Refresh();
                    SDK.HudChat->Notify("Deleted 0_0");
                }
            }
            else
            {
                EditedRecord.Ticks = null;
                IsReady = false;
            }
        }

        public static void Play(CUserCmd* cmd)
        {
            if (IsRecording || !IsPlaying)
                return;

            if (_nextTickIndex < ActiveRecord.Ticks.Length)
            {
                var tick = ActiveRecord.Ticks[_nextTickIndex];
                if (tick.Cmd.m_iTickCount == 0 || _nextTickIndex >= MaxTicks)
                {
                    IsPlaying = false;
                    SDK.HudChat->Notify("Жестко ты трахнул брат )))");
                    return;
                }

                var va = cmd->m_vecViewAngles;
                cmd->m_flForwardmove = tick.Cmd.m_flForwardmove;
                cmd->m_flSidemove = tick.Cmd.m_flSidemove;
                cmd->m_siMouseDx = tick.Cmd.m_siMouseDx;
                cmd->m_siMouseDy = tick.Cmd.m_siMouseDy;
                cmd->m_vecAimDirection = tick.Cmd.m_vecAimDirection;
                cmd->m_vecViewAngles = tick.Cmd.m_vecViewAngles;
                cmd->m_flUpmove = tick.Cmd.m_flUpmove;
                cmd->m_iButtons = tick.Cmd.m_iButtons;
                cmd->m_iWeaponSelect = tick.Cmd.m_iWeaponSelect;

                if (Settings.silentMove)
                {
                    Movement.MovementFix(cmd, cmd->m_vecViewAngles, va);
                    cmd->m_vecViewAngles = va;
                }

                _nextTickIndex++;
            }
            else
            {
                SDK.HudChat->Notify("Жестко ты трахнул брат )))");
                IsPlaying = false;
                IsReady = false;
            }

            if (NeedAttack)
                cmd->m_iButtons |= (int) EButtonState.IN_ATTACK;
        }

        public static void Start()
        {
            if (IsRecording || IsPlaying)
                return;

            if (SDK.g_LocalPlayer()->m_vecVelocity.Length != 0)
            {
                SDK.HudChat->Notify("Stop first.");
                return;
            }

            IsRecording = true;
        }

        public static void Assist(CUserCmd* cmd)
        {
            if (IsPlaying || IsRecording || IsReady)
                return;

            if ((cmd->m_iButtons & (int) EButtonState.IN_FORWARD) != 0 ||
                (cmd->m_iButtons & (int) EButtonState.IN_BACK) != 0 ||
                (cmd->m_iButtons & (int) EButtonState.IN_MOVELEFT) != 0 ||
                (cmd->m_iButtons & (int) EButtonState.IN_MOVERIGHT) != 0)
                return;

            for (int i = 0; i < Replays.Count; i++)
            {
                var distance = (Replays[i].StartPosition - SDK.g_LocalPlayer()->m_vecOrigin).Length;
                if (distance < 10 && distance > 0.35f)
                {
                    float angle = cmd->m_vecViewAngles.Y -
                                  (Replays[i].StartPosition - SDK.g_LocalPlayer()->m_vecOrigin).ToAngle().Y;

                    cmd->m_flSidemove = (float) Math.Sin(angle * 0.0174533) * 25 * distance;
                    cmd->m_flForwardmove = (float) Math.Cos(angle * 0.0174533) * 25 * distance;
                }
            }
        }

        public static void Clip(CUserCmd* cmd)
        {
            if (SDK.g_LocalPlayer()->m_vecVelocity.Length < 0.006f)
            {
                ClipRecord = new Record("Clip " + DateTime.Now,
                    SDK.Engine.GetLevelName()->ToString().Replace("_scrimmagemap", ""),
                    SDK.g_LocalPlayer()->m_vecOrigin, cmd->m_vecViewAngles, SDK.g_LocalPlayer()->GetEyePosition());
                _clipTickIndex = 0;
                _canClip = true;
            }
            else if (_canClip && _clipTickIndex < ClipRecord.Ticks.Length)
            {
                ClipRecord.Ticks[_clipTickIndex].Cmd = *cmd;
                ClipRecord.Ticks[_clipTickIndex].Origin = SDK.g_LocalPlayer()->m_vecOrigin;
                ClipRecord.Ticks[_clipTickIndex].Velocity = SDK.g_LocalPlayer()->m_vecVelocity;
                _clipTickIndex++;
            }
            else
            {
                _canClip = false;
            }
        }

        public static void Run(CUserCmd* cmd)
        {
            Clip(cmd);
            Recording(cmd);
            Play(cmd);
        }

        public static void Recording(CUserCmd* cmd)
        {
            if (!IsRecording)
                return;

            if (!_inited)
            {
                TempRecord = new Record("Record " + DateTime.Now,
                    SDK.Engine.GetLevelName()->ToString().Replace("_scrimmagemap", ""),
                    SDK.g_LocalPlayer()->m_vecOrigin, cmd->m_vecViewAngles, SDK.g_LocalPlayer()->GetEyePosition());
                _inited = true;
                _nextTickIndex = 0;
                SDK.HudChat->Notify("Start recording.");
            }

            if (_nextTickIndex < TempRecord.Ticks.Length)
            {
                TempRecord.Ticks[_nextTickIndex].Cmd = *cmd;
                TempRecord.Ticks[_nextTickIndex].Origin = SDK.g_LocalPlayer()->m_vecOrigin;
                TempRecord.Ticks[_nextTickIndex].Velocity = SDK.g_LocalPlayer()->m_vecVelocity;
                _nextTickIndex++;
            }
            else
            {
                Stop();
            }
        }

        public static void Stop()
        {
            if (!IsRecording && !IsPlaying)
                return;

            _inited = false;
            IsRecording = false;
            IsPlaying = false;
            _nextTickIndex = 0;
            SDK.HudChat->Notify("Stopped.");
        }

        private static DrawList _tracers = new DrawList();
        private static Vector _lastPoint;
        private static int _startTick;

        public static void Draw()
        {
            Vector point;

            if (IsReady || IsPlaying)
            {
                if (_startTick >= ActiveRecord.Ticks.Length)
                {
                    _startTick = 0;
                    _lastPoint = new Vector();
                }

                var tick = ActiveRecord.Ticks[_startTick];

                if (tick.Cmd.m_iTickCount == 0 || _startTick >= MaxTicks)
                {
                    _startTick = 0;
                    _lastPoint = new Vector();
                }

                point = tick.Origin;

                if (_startTick != 0 || _tracers.Count == 0)
                {
                    _startTick++;

                    if (!_lastPoint.IsZero())
                    {
                        var red = (int) (tick.Velocity.Length2D / 350 * 255);
                        red = ExtraMath.Clamp(red, 60, 255);
                        
                        var time = DateTime.Now.AddSeconds(1);
                        _tracers.AddLast(new FadingGameLine(time, new ByteColor(Color.FromArgb(red, 199, 255)),
                            _lastPoint, 0, 1f, point));
                    }
                }

                _lastPoint = point;
            }

            _tracers.Draw();

            for (int i = 0; i < Replays.Count; i++)
            {
                point = Replays[i].StartPosition;

                var len = (point - SDK.g_LocalPlayer()->m_vecOrigin).Length;

                if (len > 500)
                    continue;

                if (Replays[i].LevelName !=
                    SDK.Engine.GetLevelName()->ToString().Replace("_scrimmagemap", ""))
                    continue;

                var p1 = point - new Vector(5);
                var p2 = point + new Vector(5);
                var p3 = point - new Vector(0, 5);
                var p4 = point + new Vector(0, 5);

                if (ExtraMath.WorldToScreen(p1, ref p1) && ExtraMath.WorldToScreen(p2, ref p2) &&
                    ExtraMath.WorldToScreen(p3, ref p3) && ExtraMath.WorldToScreen(p4, ref p4))
                {
                    SDK.Surface.SetDrawColor(Color.Pink);
                    SDK.Surface.DrawLine(p1.X, p1.Y, p2.X, p2.Y);
                    SDK.Surface.DrawLine(p3.X, p3.Y, p4.X, p4.Y);
                }

                if (ExtraMath.WorldToScreen(point, ref point))
                {
                    SDK.Surface.SetTextColor(Color.FromArgb(122, 199, 255));
                    SDK.Surface.SetTextFont(Render.smallESP);
                    var size = SDK.Surface.GetTextSize(Render.smallESP, Replays[i].Title);
                    SDK.Surface.SetTextPosition((int) (point.X - size[0] / 2), (int) point.Y - size[1] * 2);
                    SDK.Surface.PrintText(Replays[i].Title);
                }
            }

            if (IsReady && !IsPlaying)
            {
                point = SDK.EngineTrace.TraceRay(ActiveRecord.StartEyePosition,
                    ActiveRecord.StartEyePosition +
                    ActiveRecord.StartViewAngles.ToVector() * 10000, EMask.SOLID_BRUSHONLY).end;
                if (ExtraMath.WorldToScreen(point, ref point))
                {
                    SDK.Surface.SetDrawColor(Color.Red);
                    SDK.Surface.DrawLine(point.X - 5, point.Y - 5, point.X + 5, point.Y + 5);
                    SDK.Surface.DrawLine(point.X + 5, point.Y - 5, point.X - 5, point.Y + 5);

                    SDK.Surface.SetTextColor(Color.FromArgb(122, 199, 255));
                    SDK.Surface.SetTextFont(Render.smallESP);
                    var size = SDK.Surface.GetTextSize(Render.smallESP, "Eye");
                    SDK.Surface.SetTextPosition((int) (point.X - size[0] / 2), (int) point.Y - size[1] * 2);
                    SDK.Surface.PrintText("Eye");
                }
            }
        }
    }
}