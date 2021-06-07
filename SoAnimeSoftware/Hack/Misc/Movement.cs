using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Hack.Combat;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SoAnimeSoftware.Utils;
using static SoAnimeSoftware.Utils.ExtraMath;
using static SoAnimeSoftware.CSGO.EMoveType;
using static SoAnimeSoftware.CSGO.EEntityFlags;


namespace SoAnimeSoftware.Hack.Misc
{
    unsafe class Movement
    {
        public static void MovementFix(CUserCmd* cmd, Vector wish_angle, Vector old_angles)
        {
            Vector wish_forward, wish_right, wish_up, cmd_forward, cmd_right, cmd_up;

            var viewangles = old_angles;
            var movedata = new Vector(cmd->m_flForwardmove, cmd->m_flSidemove, cmd->m_flUpmove);
            viewangles.NormalizeAngle();

            if (!((SDK.g_LocalPlayer()->m_fFlags & (int) EEntityFlags.FL_ONGROUND) != 0) && viewangles.Z != 0f)
                movedata.Y = 0f;

            ExtraMath.AngleVectors(wish_angle, out wish_forward, out wish_right, out wish_up);
            ExtraMath.AngleVectors(viewangles, out cmd_forward, out cmd_right, out cmd_up);

            var v8 = (float) Math.Sqrt(wish_forward.X * wish_forward.X + wish_forward.Y * wish_forward.Y);
            var v10 = (float) Math.Sqrt(wish_right.X * wish_right.X + wish_right.Y * wish_right.Y);
            var v12 = (float) Math.Sqrt(wish_up.Z * wish_up.Z);

            Vector wish_forward_norm = new Vector(1.0f / v8 * wish_forward.X, 1.0f / v8 * wish_forward.Y, 0f),
                wish_right_norm = new Vector(1.0f / v10 * wish_right.X, 1.0f / v10 * wish_right.Y, 0f),
                wish_up_norm = new Vector(0f, 0f, 1.0f / v12 * wish_up.Z);

            var v14 = (float) Math.Sqrt(cmd_forward.X * cmd_forward.X + cmd_forward.Y * cmd_forward.Y);
            var v16 = (float) Math.Sqrt(cmd_right.X * cmd_right.X + cmd_right.Y * cmd_right.Y);
            var v18 = (float) Math.Sqrt(cmd_up.Z * cmd_up.Z);

            Vector cmd_forward_norm =
                    new Vector(1.0f / v14 * cmd_forward.X, 1.0f / v14 * cmd_forward.Y, 1.0f / v14 * 0.0f),
                cmd_right_norm = new Vector(1.0f / v16 * cmd_right.X, 1.0f / v16 * cmd_right.Y, 1.0f / v16 * 0.0f),
                cmd_up_norm = new Vector(0f, 0f, 1.0f / v18 * cmd_up.Z);

            var v22 = wish_forward_norm.X * movedata.X;
            var v26 = wish_forward_norm.Y * movedata.X;
            var v28 = wish_forward_norm.Z * movedata.X;
            var v24 = wish_right_norm.X * movedata.Y;
            var v23 = wish_right_norm.Y * movedata.Y;
            var v25 = wish_right_norm.Z * movedata.Y;
            var v30 = wish_up_norm.X * movedata.Z;
            var v27 = wish_up_norm.Z * movedata.Z;
            var v29 = wish_up_norm.Y * movedata.Z;

            Vector correct_movement;
            correct_movement.X = cmd_forward_norm.X * v24 + cmd_forward_norm.Y * v23 + cmd_forward_norm.Z * v25 +
                                 (cmd_forward_norm.X * v22 + cmd_forward_norm.Y * v26 + cmd_forward_norm.Z * v28) +
                                 (cmd_forward_norm.Y * v30 + cmd_forward_norm.X * v29 + cmd_forward_norm.Z * v27);
            correct_movement.Y = cmd_right_norm.X * v24 + cmd_right_norm.Y * v23 + cmd_right_norm.Z * v25 +
                                 (cmd_right_norm.X * v22 + cmd_right_norm.Y * v26 + cmd_right_norm.Z * v28) +
                                 (cmd_right_norm.X * v29 + cmd_right_norm.Y * v30 + cmd_right_norm.Z * v27);
            correct_movement.Z = cmd_up_norm.X * v23 + cmd_up_norm.Y * v24 + cmd_up_norm.Z * v25 +
                                 (cmd_up_norm.X * v26 + cmd_up_norm.Y * v22 + cmd_up_norm.Z * v28) +
                                 (cmd_up_norm.X * v30 + cmd_up_norm.Y * v29 + cmd_up_norm.Z * v27);

            correct_movement.X = Clamp(correct_movement.X, -450f, 450f);
            correct_movement.Y = Clamp(correct_movement.Y, -450f, 450f);
            correct_movement.Z = Clamp(correct_movement.Z, -450, 450);

            cmd->m_flForwardmove = correct_movement.X;
            cmd->m_flSidemove = correct_movement.Y;
            cmd->m_flUpmove = correct_movement.Z;

            cmd->m_iButtons &= ~((int) EButtonState.IN_MOVERIGHT | (int) EButtonState.IN_MOVELEFT |
                                 (int) EButtonState.IN_BACK | (int) EButtonState.IN_FORWARD);
            if (cmd->m_flSidemove != 0.0)
            {
                if (cmd->m_flSidemove <= 0.0)
                    cmd->m_iButtons |= (int) EButtonState.IN_MOVELEFT;
                else
                    cmd->m_iButtons |= (int) EButtonState.IN_MOVERIGHT;
            }

            if (cmd->m_flForwardmove != 0.0)
            {
                if (cmd->m_flForwardmove <= 0.0)
                    cmd->m_iButtons |= (int) EButtonState.IN_BACK;
                else
                    cmd->m_iButtons |= (int) EButtonState.IN_FORWARD;
            }
        }

        public static void FastStop(CUserCmd* cmd)
        {
            if (!Settings.fastStop)
                return;

            if ((cmd->m_iButtons & (int) EButtonState.IN_JUMP) != 0)
                return;

            if ((SDK.g_LocalPlayer()->m_fFlags & (int) EEntityFlags.FL_ONGROUND) == 0)
                return;

            var direction = EnginePrediction.preVelocity.ToAngle();
            float speed = EnginePrediction.preVelocity.Length2D;

            if (speed <= 15)
                return;

            direction.Y = cmd->m_vecViewAngles.Y - direction.Y;

            Vector negated_direction = direction.ToVector() * -speed;


            if ((cmd->m_iButtons & (int) EButtonState.IN_FORWARD) == 0 &&
                (cmd->m_iButtons & (int) EButtonState.IN_BACK) == 0)
                cmd->m_flForwardmove = negated_direction.X;
            if ((cmd->m_iButtons & (int) EButtonState.IN_MOVELEFT) == 0 &&
                (cmd->m_iButtons & (int) EButtonState.IN_MOVERIGHT) == 0)
                cmd->m_flSidemove = negated_direction.Y;
        }

        public static void AutoLadderJump(CUserCmd* cmd)
        {
            if (!Settings.autoLadderJump)
                return;

            if (SDK.g_LocalPlayer()->m_nMoveType == (int) EMoveType.LADDER)
                cmd->m_iButtons |= (int) EButtonState.IN_JUMP;
        }

        public static void EdgeJump(CUserCmd* cmd)
        {
            if (!Settings.edgeJump)
                return;

            if (!Input.KeyDown(Keys.E))
                return;

            if (SDK.g_LocalPlayer()->m_nMoveType == (int) EMoveType.LADDER ||
                SDK.g_LocalPlayer()->m_nMoveType == (int) EMoveType.NOCLIP)
                return;


            if ((EnginePrediction.preFlags & (int) EEntityFlags.FL_ONGROUND) != 0 &&
                (SDK.g_LocalPlayer()->m_fFlags & (int) EEntityFlags.FL_ONGROUND) == 0)
            {
                cmd->m_iButtons |= (int) EButtonState.IN_JUMP;
            }
        }

        private static bool _lastOnGround = false;

        public static void PreJump(CUserCmd* cmd)
        {
            if (!Settings.crouchJump)
                return;

            var onGround = (SDK.g_LocalPlayer()->m_fFlags & (int) EEntityFlags.FL_ONGROUND) != 0;

            if (_lastOnGround && onGround && (cmd->m_iButtons & (int) EButtonState.IN_JUMP) != 0)
                cmd->m_iButtons |= (int) EButtonState.IN_DUCK;

            _lastOnGround = onGround;
        }


        private static bool _jbugging = false;

        public static void JumpBug(CUserCmd* cmd)
        {
            if (!Settings.jumpBug)
                return;

            if (!Input.KeyDown(Keys.X))
            {
                _jbugging = false;
                return;
            }

            if (_jbugging)
            {
                cmd->m_iButtons &= ~(int) EButtonState.IN_DUCK;
                _jbugging = false;
            }
            else if ((EnginePrediction.preFlags & (int) EEntityFlags.FL_ONGROUND) == 0 &&
                     (SDK.g_LocalPlayer()->m_fFlags & (int) EEntityFlags.FL_ONGROUND) != 0)
            {
                _jbugging = true;
                cmd->m_iButtons |= (int) EButtonState.IN_DUCK;
                //cmd->m_iButtons &= (int)ButtonState.IN_JUMP;
            }
        }

        public static void FastCrouch(CUserCmd* cmd)
        {
            if (Settings.fastCrouch)
                cmd->m_iButtons |= (int) EButtonState.IN_BULLRUSH;
        }

        public static void SlideWalk(CUserCmd* cmd)
        {
            if (Settings.slideWalk && SDK.g_LocalPlayer()->m_nMoveType != (int) EMoveType.LADDER)
                cmd->m_iButtons ^= (int) EButtonState.IN_FORWARD | (int) EButtonState.IN_BACK |
                                   (int) EButtonState.IN_MOVELEFT | (int) EButtonState.IN_MOVERIGHT;
        }

        static int _wasLastTimeOnGround = 0;

        public unsafe static void BHop(CUserCmd* cmd)
        {
            if (!Settings.bunnyHop)
                return;

            if (SDK.g_LocalPlayer() == null)
                return;

            if ((SDK.g_LocalPlayer()->m_fFlags & 1) == 0 && _wasLastTimeOnGround == 0 &&
                SDK.g_LocalPlayer()->m_nMoveType != (int) EMoveType.LADDER)
            {
                cmd->m_iButtons &= ~(int) EButtonState.IN_JUMP;
            }

            _wasLastTimeOnGround = SDK.g_LocalPlayer()->m_fFlags & 1;
        }

        static bool last_jumped = false;
        static bool should_fake = false;

        public unsafe static void BHop(CUserCmd* cmd, bool debil)
        {
            if (!Settings.bunnyHop)
                return;

            if (SDK.g_LocalPlayer() == null)
                return;

            if (SDK.g_LocalPlayer()->m_nMoveType == (int) EMoveType.LADDER ||
                SDK.g_LocalPlayer()->m_nMoveType == (int) EMoveType.NOCLIP)
                return;

            if (!last_jumped && should_fake)
            {
                should_fake = false;
                cmd->m_iButtons |= (int) EButtonState.IN_JUMP;
            }
            else if ((cmd->m_iButtons & (int) EButtonState.IN_JUMP) != 0)
            {
                if ((SDK.g_LocalPlayer()->m_fFlags & (int) FL_ONGROUND) != 0)
                {
                    last_jumped = true;
                    should_fake = true;
                }
                else
                {
                    cmd->m_iButtons &= ~(int) EButtonState.IN_JUMP;
                    last_jumped = false;
                }
            }
            else
            {
                last_jumped = false;
                should_fake = false;
            }
        }

        public static void PropAutoStrafe(CUserCmd* cmd)
        {
            if (!Settings.autoStrafe)
                return;

            if (Settings.autoStrafeOnJump)
                if (!Input.KeyDown(Keys.Space))
                    return;

            // removed
        }

        public static CConVar* sv_accelerate;
        public static CConVar* sv_maxspeed;

        public static void ReduceSpeed(CUserCmd* cmd, float newSpeed)
        {
            var velocity = SDK.g_LocalPlayer()->m_vecVelocity;
            velocity.Z = 0;
            float speed = velocity.Length2D;

            if (newSpeed >= speed)
                return;

            float acceleration = sv_accelerate->GetFloat();
            float maxspeed = sv_maxspeed->GetFloat();
            float surface_friction = SDK.g_LocalPlayer()->Get<float>(0x3210);
            float max_accel_speed = acceleration * SDK.GlobalVars->interval_per_tick * maxspeed * surface_friction;

            float wishspeed = 0f;

            if (speed - max_accel_speed <= -1f)
            {
                wishspeed = max_accel_speed / (speed / (acceleration * SDK.GlobalVars->interval_per_tick));
            }
            else
            {
                wishspeed = max_accel_speed;
            }


            velocity *= -1;
            var resistance = velocity.ToAngle();

            resistance.Y = cmd->m_vecViewAngles.Y - resistance.Y;

            var resistance_vec = resistance.ToVector();

            cmd->m_flForwardmove = ExtraMath.Clamp(resistance_vec.X * wishspeed, 0.0f, 450.0f);
            cmd->m_flSidemove = ExtraMath.Clamp(resistance_vec.Y * wishspeed, 0.0f, 450.0f);
        }

        public static void ReduceSpeed2(CUserCmd* cmd, float newSpeed)
        {
            var velocity = SDK.g_LocalPlayer()->m_vecVelocity;
            float speed = velocity.Length2D;
            if (speed <= newSpeed)
                return;

            var direction = velocity.ToAngle();

            direction.Y = cmd->m_vecViewAngles.Y - direction.Y;

            Vector negated_direction = direction.ToVector() * -speed;

            cmd->m_flForwardmove = negated_direction.X;
            cmd->m_flSidemove = negated_direction.Y;
        }
    }
}