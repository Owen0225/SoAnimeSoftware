using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Objects;
using SoAnimeSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoAnimeSoftware.GUI.Elements;
using SoAnimeSoftware.GUI.Elements.Abstraction;
using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Hack.Grief;
using SoAnimeSoftware.Hack.Misc;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;

namespace SoAnimeSoftware.Hack.Visuals
{
    unsafe class Perception
    {
        public static bool tpActivated = false;
        private static Random rnd = new Random();

        public static LinkedList<IRenderable> TickDrawList = new LinkedList<IRenderable>();

        public static void RenderTickDrawList()
        {
            foreach (var renderable in TickDrawList)
            {
                if (renderable.IsValid)
                    renderable.Draw();
            }

            TickDrawList.Clear();
        }

        public static DrawList GDrawList = new DrawList();

        public static void RenderDrawList()
        {
            GDrawList.Draw();
        }

        public static DrawList OverlayDrawList = new DrawList();
        public static string[] DeadKaomoji = new[] {"(╥﹏╥)", "｡･ﾟﾟ*(>д<)*ﾟﾟ･｡", "｡ﾟ･ (>﹏<) ･ﾟ｡", "(；⌣̀_⌣́)"};
        public static string DeadString = "｡ﾟ･ (>﹏<) ･ﾟ｡";

        public static void BottomOverlay()
        {
            if (SDK.g_LocalPlayer() == null)
                return;

            var p1 = Render.MaxWidth * 0.2f;
            var p2 = Render.MaxWidth * 0.35f;
            var p3 = Render.MaxWidth * 0.65f;
            var p4 = Render.MaxWidth * 0.8f;

            var mid = Render.MaxWidth / 2;

            var h = 15;

            var color1 = new ByteColor(0, 0, 0, 0);
            var black = new ByteColor(0, 0, 0, 200);
            var plum = new ByteColor(Color.Plum);

            var font = Render.Roboto_Medium12;

            SDK.Surface.SetDrawColor(black);
            SDK.Surface.DrawFilledRectFade((int) p1, Render.MaxHeight - h, (int) p2, Render.MaxHeight, 0, 255,
                (byte) 1);

            Render.FilledRect((int) p2, Render.MaxHeight - h, (int) p3 - (int) p2, h, black);

            SDK.Surface.SetDrawColor(black);
            SDK.Surface.DrawFilledRectFade((int) p3, Render.MaxHeight - h, (int) p4, Render.MaxHeight, 255, 0,
                (byte) 1);

            SDK.Surface.SetDrawColor(plum);
            SDK.Surface.DrawFilledRectFade((int) p1, Render.MaxHeight - h - 1, (int) p2, Render.MaxHeight - h, 0,
                255, (byte) 1);

            SDK.Surface.SetDrawColor(plum);
            SDK.Surface.DrawLine((int) p2 - 1, Render.MaxHeight - h - 1, (int) p3, Render.MaxHeight - h - 1);

            SDK.Surface.SetDrawColor(plum);
            SDK.Surface.DrawFilledRectFade((int) p3, Render.MaxHeight - h - 1, (int) p4, Render.MaxHeight - h, 255,
                0, (byte) 1);

            Render.Text((int) p2 + 1 - 50, Render.MaxHeight - h + 1 + 1, "hey o(≧▽≦)o", plum,
                font);
            Render.Text((int) p2 - 50, Render.MaxHeight - h + 1, "hey o(≧▽≦)o",
                new ByteColor(Color.White), font);

            if (BombTimerDrawing == Status.ENABLED)
            {
                var x = mid - 145;
                var y = Render.MaxHeight - h + 1;
                Render.Text(x + 1, y + 1, "Remaining time:", plum, font);
                Render.Text(x, y, "Remaining time:", new ByteColor(Color.White), font);

                var textSize = SDK.Surface.GetTextSize(font, "Remaining time:");
                x += textSize[0] + 3;

                if (RemainingTime - RemainingTimeOld > 0)
                    RemainingTimeOld = RemainingTime;

                if (RemainingTimeOld - RemainingTime > 1f)
                {
                    OverlayDrawList.AddLast(new SlidingFadingText(Render.GlobalTime.AddSeconds(1), x, y,
                        plum, 0, 1,
                        x, y - 10, 1, 1, font, new StringSource(RemainingTime.ToString("N3"))));

                    RemainingTimeOld = RemainingTime;
                }

                var x1 = mid + 45;

                Render.Text(x1 + 1, y + 1, "HP left:", plum, font);
                Render.Text(x1, y, "HP left:", new ByteColor(Color.White), font);

                textSize = SDK.Surface.GetTextSize(font, "HP left:");
                x1 += textSize[0] + 3;

                if (HpRemaining - HpRemainingOld > 2 || -HpRemaining + HpRemainingOld > 2)
                {
                    OverlayDrawList.AddLast(new SlidingFadingText(Render.GlobalTime.AddSeconds(1), x1, y,
                        plum, 0, 1,
                        x1, y - 10, 1, 1, font, new StringSource(HpRemaining.ToString())));
                    DeadString = DeadKaomoji[rnd.Next(DeadKaomoji.Length)];
                    HpRemainingOld = HpRemaining;
                }

                OverlayDrawList.Draw();


                var src = HpRemaining == 0 ? DeadString : HpRemaining.ToString();
                Render.Text(x1 + 1, y + 1, src, plum, font);
                Render.Text(x1, y, src, new ByteColor(Color.White), font);

                Render.Text(x + 1, y + 1, RemainingTime.ToString("N3"), plum, font);
                Render.Text(x, y, RemainingTime.ToString("N3"), new ByteColor(Color.White), font);
            }
            else if (BombTimerDrawing == Status.ENABLED_DONE)
            {
                var x = mid - 145;
                var y = Render.MaxHeight - h + 1;

                OverlayDrawList.AddLast(new SlidingFadingText(Render.GlobalTime.AddSeconds(1), x, y, plum, 0, 1,
                    x, y - 10, 1, 1, font, new StringSource("Remaining time:")));

                x = mid + 45;

                OverlayDrawList.AddLast(new SlidingFadingText(Render.GlobalTime.AddSeconds(1), x, y, plum, 0, 1,
                    x, y - 10, 1, 1, font, new StringSource("HP left:")));

                BombTimerDrawing = Status.DISABLED;
            }
            else
            {
                OverlayDrawList.Draw();
            }

            //Render.GradientRect((int)p1,Render.MaxHeight - h,(int)p2 - (int)p1, 1, new VColor(0,0,0,0), new VColor(Color.Plum), true);
        }

        public static Status BombTimerDrawing = Status.DISABLED;
        public static DrawList Box = new DrawList();
        public static int HpRemaining;
        public static float RemainingTime;
        public static int HpRemainingOld;
        public static float RemainingTimeOld;
        public static bool ElProblema = false;

        public static void BombTimer()
        {
            for (int i = 1; i < SDK.EntityList.GetHighestEntityIndex(); i++)
            {
                var e = SDK.EntityList.GetEntityByIndex(i);
                if (e == null)
                    continue;

                if (e->GetClientClass()->m_ClassID == (int) EClassId.CPlantedC4)
                {
                    if (SDK.g_LocalPlayer() == null)
                        continue;

                    if (e->Get<byte>(Offsets.DT_PlantedC4.m_bBombTicking) != 0)
                    {
                        var explodeTime = e->Get<float>(Offsets.DT_PlantedC4.m_flC4Blow);
                        RemainingTime = explodeTime -
                                        (SDK.GlobalVars->interval_per_tick * SDK.g_LocalPlayer()->m_nTickBase);

                        if (RemainingTime < 0)
                            continue;

                        if (!ElProblema && RemainingTime <= 3.8f && Settings.voiceEvents)
                        {
                            VoiceAudioPlayer.Play("onExplosion");
                            ElProblema = true;
                        }

                        HpRemaining = SDK.g_LocalPlayer()->m_iHealth;
                        var distance = (SDK.g_LocalPlayer()->GetEyePosition() - e->m_vecOrigin).Length;

                        var factor = ((distance - 75.68f) / 789.2f);
                        var rawDamage = 450.7f * (float) Math.Exp(factor * -factor);

                        var damage = ArmorScale(rawDamage, SDK.g_LocalPlayer()->m_ArmorValue);
                        HpRemaining = (int) (HpRemaining - damage);

                        HpRemaining = ExtraMath.Clamp(HpRemaining, 0, SDK.g_LocalPlayer()->m_iHealth);

                        Box.Draw();

                        BombTimerDrawing = Status.ENABLED;
                        return;
                    }
                    else
                    {
                        ElProblema = false;
                    }
                }
            }

            BombTimerDrawing = BombTimerDrawing != Status.DISABLED ? Status.ENABLED_DONE : Status.DISABLED;
        }

        public static float ArmorScale(float damage, int armorValue)
        {
            float armor_ratio = 0.5f;
            float armor_bonus = 0.5f;
            if (armorValue > 0)
            {
                float armorNew = damage * armor_ratio;
                float armor = (damage - armorNew) * armor_bonus;

                if (armor > (armorValue))
                {
                    armor = armorValue * (1f / armor_bonus);
                    armorNew = damage - armor;
                }

                damage = armorNew;
            }

            return damage;
        }

        public static void Thirdperson()
        {
            if (Input.KeyPressed(Keys.V))
                tpActivated = !tpActivated;

            SDK.Input->isCameraInThirdPerson = (tpActivated && Settings.thirdPerson);

            if (!SDK.Input->isCameraInThirdPerson)
                return;

            Vector angle = new Vector();
            SDK.Engine.GetViewAngles(ref angle);

            Vector backward = new Vector(-angle.X, angle.Y + 180, angle.Z);
            backward.NormalizeAngle();

            backward = backward.ToVector();
            backward *= 8192f;

            var start = SDK.g_LocalPlayer()->GetEyePosition();
            var trace = SDK.EngineTrace.TraceRay(start, start + backward,
                (EMask) ((int) EMask.SHOT | (int) EContents.GRATE));

            angle.Z = Math.Min((trace.end - start).Length * 0.95f, 150f);
            SDK.Input->cameraOffset = angle;
        }

        public static void RemoveScopeOverlay()
        {
            if (!Settings.removeScopeOverlay)
                return;

            if (SDK.g_LocalPlayer() == null || !SDK.g_LocalPlayer()->m_bIsScoped)
                return;

            var screenSize = SDK.Surface.GetScreenSize();
            SDK.Surface.SetDrawColor(new ByteColor(Color.Black));
            SDK.Surface.DrawLine(screenSize[0] / 2, 0, screenSize[0] / 2, screenSize[1]);
            SDK.Surface.SetDrawColor(new ByteColor(Color.Black));
            SDK.Surface.DrawLine(0, screenSize[1] / 2, screenSize[0], screenSize[1] / 2);
        }

        public static void DisablePostprocessing(EFrameStage stage)
        {
            return; // it breaks light
            
            if (stage != EFrameStage.RENDER_START && stage != EFrameStage.RENDER_END)
                return;

            *Offsets.DisablePostprocessing = (stage == EFrameStage.RENDER_START && Settings.disablePostprocessing
                ? (byte) 1
                : (byte) 0);
        }

        public static void ViewmodelOffset()
        {
            if (!Settings.viewmodelOverride)
                return;

            SDK.CVar.Force("viewmodel_offset_x", Settings.viewmodel_x);
            SDK.CVar.Force("viewmodel_offset_y", Settings.viewmodel_y);
            SDK.CVar.Force("viewmodel_offset_z", Settings.viewmodel_z);
        }

        public static int CircleOpacity = 0;

        public static void AimCircle()
        {
            if (CircleOpacity == 0)
                return;

            var size = SDK.Surface.GetScreenSize();

            SDK.Surface.SetDrawColor(Color.White.R, Color.White.G, Color.White.B, CircleOpacity);
            SDK.Surface.DrawOutlinedCircle(size[0] / 2, size[1] / 2,
                (int) (Settings.fov / 2 * size[0] / Settings.visualFov));

            CircleOpacity--;
        }

        static LinkedList<IRenderable> hitMarks = new LinkedList<IRenderable>();

        public static void HitMarkerOnEvent(GameEvent* e)
        {
            if (e->GetName()->ToString() != "player_hurt")
                return;

            var target = SDK.Engine.GetEntityByUserID(e->GetInt("userid"));
            var attacker = SDK.Engine.GetEntityByUserID(e->GetInt("attacker"));

            if (target == null || attacker == null)
                return;

            if (attacker != SDK.g_LocalPlayer())
                return;


            var pos = target->GetEyePosition() - (target->m_vecViewOffset / 10 * e->GetInt("hitgroup")) +
                      new Vector(rnd.Next(-30, 30), rnd.Next(-30, 30), rnd.Next(-30, 30));

            var color = new ByteColor(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), 255);
            hitMarks.AddLast(new SlidingFadingGameText(DateTime.Now.AddSeconds(1), color, pos, 0, 0.5f
                , 1, pos + new Vector(0, 0, 30), 1, Render.verdana16o,
                new StringSource(e->GetInt("dmg_health").ToString())));
            //hitMarks.AddLast(new FadingText(DateTime.Now.AddSeconds(1), pos, e->GetInt("dmg_health").ToString(), color,
            //    GVars.verdana16o, 0, 0.5f, 1, pos + new Vector(0, 0, 30)));
        }

        private static IRenderable hitChanceSign;
        private static float oldHc = 0;
        private static int skip = 0;

        public static void PassiveHitchanceOnCreateMove(CUserCmd* cmd)
        {
            if (!Settings.passiveHC)
                return;


            if (!SDK.g_LocalPlayer()->GetActiveWeapon()->IsGun())
                return;

            var target = TargetList.GetBestTarget(cmd->m_vecViewAngles, out var _, out var __);
            if (target == null)
                return;

            var tick = target.MainTick;
            if (tick == null)
                return;

            var bone = ExtraMath.GetBonePosition(tick.Matrix, 6);

            if (skip == 0)
            {
                Vector aim = Aimbot.CalcAngles(SDK.g_LocalPlayer()->GetEyePosition(), bone);
                aim.NormalizeAngle();

                var punch = (SDK.g_LocalPlayer()->m_aimPunchAngle * Aimbot.WeaponRecoilScale);
                aim = aim - punch;
                aim.NormalizeAngle();

                var hitChance = Aimbot.GetHitChance(tick, (int) EHitGroup.Generic, aim) * 100;
                oldHc = hitChance;
                skip = 10;
            }
            else
            {
                skip--;
            }

            hitChanceSign = new FadingGameText(DateTime.Now.AddSeconds(0.4f), new ByteColor(Color.White), bone, 0, 0.2f,
                Render.tahoma14o, new StringSource("HC: " + oldHc.ToString("F1") + '%'));
        }

        public static void PassiveHitchanceDraw()
        {
            hitChanceSign?.Draw();
        }

        public static void HitMarker()
        {
            var node = hitMarks.First;
            while (node != null)
            {
                var next = node.Next;
                if (node.Value.IsValid)
                {
                    node.Value.Draw();
                }
                else
                {
                    hitMarks.Remove(node);
                }

                node = next;
            }
        }
        
        public static void Watermark()
        {
            var text = $"animesoftware.moe |  {DateTime.Now.ToShortTimeString()}";

            var color1 = new ByteColor(Color.Plum);
            var color2 = new ByteColor(Color.White);

            var font = Render.Roboto_Regular16;
            var textSize = SDK.Surface.GetTextSize(font, text);

            var textW = textSize[0];

            var x = SDK.Surface.GetScreenSize()[0] - textW - 12;
            var y = 5;

            Render.GradientRect(x - 5, y, textW + 10, 24, new ByteColor(0, 0, 0, 200), new ByteColor(0, 0, 0, 0));
            SDK.Surface.SetDrawColor(color1);
            SDK.Surface.DrawLine(x - 5, y, x + textW + 5, y);

            Render.Text((int) x + 1, y + 2 + 1, text, color1, font);
            Render.Text((int) x, y + 2, text, color2, font);
        }

        public static void WorldColor()
        {
            if (Settings.worldColoring != Status.ENABLED)
                return;

            int iterationCount = 0;

            SDK.CVar.Force("r_drawspecificstaticprop", 0);
            SDK.CVar.Force("cl_brushfastpath", 0);

            var ptr = SDK.MaterialSystem.Address;

            for (short h = SDK.MaterialSystem.FirstMaterial();
                h != SDK.MaterialSystem.InvalidMaterial();
                h = SDK.MaterialSystem.NextMaterial(h))
            {
                CMaterial* mat = SDK.MaterialSystem.GetMaterial(h);

                if (mat == null)
                    continue;

                string groupName = mat->GetTextureGroupName();

                if (groupName.Contains("World"))
                {
                    mat->ColorModulate(Settings.worldColor);
                    iterationCount++;
                }
                else if (groupName.Contains("StaticProp"))
                {
                    if (mat->GetName().ToLower().Contains("sky"))
                    {
                        mat->ColorModulate(Settings.skyboxColor);
                        mat->AlphaModulate(0.25f);
                        continue;
                    }

                    mat->ColorModulate(Settings.staticColor);
                    mat->AlphaModulate(Settings.asusProp);
                    iterationCount++;
                }
                else if (groupName.Contains("SkyBox"))
                {
                    mat->ColorModulate(Settings.skyboxColor);
                    iterationCount++;
                }
            }

            if (iterationCount > 0)
                Settings.worldColoring = Status.ENABLED_DONE;
        }

        public static void Valorant()
        {
            if (Settings.valorant == Status.ENABLED)
            {
                SDK.CVar.Force("mat_drawgray", 1);
                Settings.valorant = Status.ENABLED_DONE;
            }
            else if (Settings.valorant == Status.DISABLED)
            {
                SDK.CVar.Force("mat_drawgray", 0);
                Settings.valorant = Status.ENABLED_DONE;
            }
        }

        public static void Minecraft()
        {
            if (Settings.minecraft == Status.ENABLED)
            {
                SDK.CVar.Force("mat_showlowresimage", 1);
                Settings.minecraft = Status.ENABLED_DONE;
            }
            else if (Settings.minecraft == Status.DISABLED)
            {
                SDK.CVar.Force("mat_showlowresimage", 0);
                Settings.minecraft = Status.ENABLED_DONE;
            }
        }

        public static void SpectatorList()
        {
            if (!Settings.spectatorList)
                return;

            var size = SDK.Surface.GetScreenSize();


            var textSize = SDK.Surface.GetTextSize(Render.verdana14o, "Spectators:");
            int offset = textSize[1];
            SDK.Surface.SetTextPosition(size[0] - textSize[0] - 5, offset + textSize[1]);
            offset += textSize[1];
            SDK.Surface.SetTextColor(Color.MediumPurple);
            SDK.Surface.SetTextFont(Render.verdana14o);
            SDK.Surface.PrintText("Spectators:");

            for (int i = 1; i < SDK.Engine.GetMaxClients(); i++)
            {
                var e = SDK.EntityList.GetEntityByIndex(i);

                if (e == null)
                    continue;

                if (e == SDK.g_LocalPlayer())
                    continue;

                if (e->IsAlive())
                    continue;

                if (e->GetObserverTarget() == SDK.g_LocalPlayer() || (!SDK.g_LocalPlayer()->IsAlive() &&
                                                                      e->GetObserverTarget() ==
                                                                      SDK.g_LocalPlayer()->GetObserverTarget()))
                {
                    var name = e->PlayerInfo().szName.ToString() + "  ";
                    textSize = SDK.Surface.GetTextSize(Render.verdana14o, name);
                    SDK.Surface.SetTextPosition(size[0] - textSize[0] - 5, offset + textSize[1]);
                    offset += textSize[1];
                    SDK.Surface.SetTextColor(Color.MediumPurple);
                    SDK.Surface.SetTextFont(Render.verdana14o);
                    SDK.Surface.PrintText(name);
                }
            }
        }

        public static void ReduceFlash(int percent = 100)
        {
            SDK.g_LocalPlayer()->m_flFlashMaxAlpha = 255f - percent * 2.55f;
        }

        public static LinkedList<IRenderable> tracers = new LinkedList<IRenderable>();

        public static void TraceDebug()
        {
            if (!Settings.tracerDebug)
                return;

            var node = tracers.First;

            while (node != null)
            {
                var line = node.Value;
                var next = node.Next;

                if (line.IsValid)
                {
                    line.Draw();
                }
                else
                {
                    tracers.Remove(node);
                }

                node = next;
            }
        }

        

        public static void MovementRecorderPoints() => MovementManager.Draw();

        public static void DamageOverlay() => TeamDamageTracker.DamageOverlayDraw();

        public static void TeamDamageOverlay() => TeamDamageTracker.TeamDamageOverlayDraw();
    
    }
}