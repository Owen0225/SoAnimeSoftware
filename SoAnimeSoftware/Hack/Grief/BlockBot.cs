using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Hack.Combat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Hack.Grief
{
    unsafe class BlockBot
    {
        public static Entity* GetTarget()
        {
            float bestDistance = float.MaxValue;
            float tempDistance = 0;
            Entity* target = null;
            for (int i = 1; i < CSGO.SDK.Engine.GetMaxClients(); i++)
            {
                var e = CSGO.SDK.EntityList.GetEntityByIndex(i);

                if (e == null)
                    continue;

                if (e == CSGO.SDK.g_LocalPlayer())
                    continue;

                if (!e->IsAlive())
                    continue;

                if ((tempDistance = (e->m_vecOrigin - SDK.g_LocalPlayer()->m_vecOrigin).Length2D) < bestDistance)
                {
                    bestDistance = tempDistance;
                    target = e;
                }
            }

            return target;
        }

        private static Entity* _oldTarget;

        public static void Run(CUserCmd* cmd)
        {
            if (!Settings.blockBot)
            {
                _oldTarget = null;
                return;
            }

            if (!SDK.g_LocalPlayer()->IsAlive())
                return;

            try
            {
                if (!Input.KeyDown(0x12))
                {
                    _oldTarget = null;
                    return;
                }

                if (_oldTarget == null)
                    _oldTarget = GetTarget();

                if (_oldTarget == null)
                    return;

                if (!_oldTarget->IsAlive() || _oldTarget->IsDormant())
                {
                    _oldTarget = null;
                    return;
                }

                Vector va = cmd->m_vecViewAngles;
                Vector targetOrigin = _oldTarget->m_vecOrigin;
                Vector lpOrigin = SDK.g_LocalPlayer()->m_vecOrigin;

                if (_oldTarget == null)
                    return;

                if ((lpOrigin - _oldTarget->GetBonePosition(8)).Length < 43)
                {
                    if (_oldTarget == null)
                        return;
                    targetOrigin += _oldTarget->m_vecVelocity * Settings.trajFactor;

                    float distance = (targetOrigin - lpOrigin).Length2D;
                    distance *= Settings.distanceFactor;

                    if (distance > 10)
                        distance = 10;

                    float angle = va.Y - Aimbot.CalcAngles(lpOrigin, targetOrigin).Y;

                    cmd->m_flSidemove = (float) Math.Sin(angle * 0.0174533) * 45 * distance;
                    cmd->m_flForwardmove = (float) Math.Cos(angle * 0.0174533) * 45 * distance;
                }
                else
                {
                    Vector angle = va - Aimbot.CalcAngles(lpOrigin, targetOrigin);
                    angle.NormalizeAngle();

                    float sidemove = angle.Y * 40;
                    cmd->m_flSidemove = sidemove > 450 ? 450 : sidemove < -450 ? -450 : sidemove;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}