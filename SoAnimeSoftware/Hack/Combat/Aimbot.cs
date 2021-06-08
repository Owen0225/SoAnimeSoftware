using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using static SoAnimeSoftware.Utils.ExtraMath;
using static SoAnimeSoftware.CSGO.EHitGroup;
using static SoAnimeSoftware.CSGO.EHitboxes;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Utils;
using SoAnimeSoftware.Objects;

namespace SoAnimeSoftware.Hack.Combat
{
    unsafe class Aimbot
    {
        private static CConVar* weapon_recoil_scale;
        public static bool aiming = false;

        public static int[] BoneIds = new[]
        {
            8, // head
            7, // neck
            11, // left 
            39, // right
            6, // body
            78, // left leg
            71, // right leg
        };

        public static void Run(CUserCmd* cmd)
        {
            if (!Settings.aimbot)
                return;

            aiming = false;

            if ((cmd->m_iButtons & (int) EButtonState.IN_ATTACK) == 0)
                return;


            var activeWeapon = SDK.g_LocalPlayer()->GetActiveWeapon();
            if (activeWeapon == null)
                return;

            if (!activeWeapon->IsGun())
                return;
            
            if (activeWeapon->IsReloading() || activeWeapon->m_iClip1 == 0)
                return;

            var weaponData = activeWeapon->GetWeaponData();
            if (weaponData == null)
                return;

            if (SDK.g_LocalPlayer()->m_iShotsFired > 0 && weaponData->bFullAuto == 0)
                return;

            var weaponType = weaponData->WeaponType;

            var punch = (SDK.g_LocalPlayer()->m_aimPunchAngle * WeaponRecoilScale);
            var currentAngle = new Vector();
            SDK.Engine.GetViewAngles(ref currentAngle);

            var startAngle = currentAngle + punch;

            var target = TargetList.GetBestTarget(startAngle, out var tick, out var aim);

            if (target == null)
                return;

            cmd->m_iTickCount = Backtrack.TimeToTicks(tick.Simtime + Backtrack.interpolation_time);

            aim.NormalizeAngle();

            var fov = CalcFov(startAngle, aim);

            if (fov > Settings.fov)
                return;

            aim = aim - punch;
            cmd->m_vecViewAngles = LinearSmooth(currentAngle, aim, Settings.smooth);

            cmd->m_vecViewAngles.NormalizeAngle();
            cmd->m_vecViewAngles.Clamp();

            aiming = true;
        }

        public static float WeaponRecoilScale
        {
            get
            {
                if (weapon_recoil_scale == null)
                {
                    weapon_recoil_scale = SDK.CVar.FindVar("weapon_recoil_scale");
                }

                return weapon_recoil_scale->GetFloat();
            }
        }

        public static bool HitChance(Tick tick, int hitGroup, Vector viewAngle, float hitChance)
        {
            var weapon = SDK.g_LocalPlayer()->GetActiveWeapon();
            var cWeaponInfo = weapon->GetWeaponData();

            viewAngle += SDK.g_LocalPlayer()->m_aimPunchAngle * WeaponRecoilScale;
            viewAngle.NormalizeAngle();
            ExtraMath.AngleVectors(viewAngle,
                out Vector forward, out Vector right, out Vector up);

            weapon->UpdateAccuracyPenalty();
            float inaccuracy = weapon->GetInaccuracy();
            float spread = weapon->GetSpread();
            int shotsMissed = 0;
            int shotsNeeded = (int) (256 * (hitChance / 100f));
            int shotsPass = 0;
            var ri = weapon->Get<float>(Offsets.DT_WeaponCSBase.m_flRecoilIndex);
            var di = weapon->m_iItemDefinitionIndex;


            for (int i = 0; i < 256; i++)
            {
                HitChanceParallel(tick.Entity, hitGroup, ref forward, ref right, ref up, inaccuracy, spread,
                    cWeaponInfo, ri,
                    di, ref shotsMissed, ref shotsNeeded, ref shotsPass);
            }

            if (256 - shotsMissed < shotsNeeded)
                return false;
            if (shotsPass >= shotsNeeded)
                return true;

            throw new Exception("Cursed hitchance");
            return true;
        }

        public static float GetHitChance(Tick tick, int hitGroup, Vector viewAngle)
        {
            var weapon = SDK.g_LocalPlayer()->GetActiveWeapon();
            var cWeaponInfo = weapon->GetWeaponData();

            viewAngle += SDK.g_LocalPlayer()->m_aimPunchAngle * WeaponRecoilScale;
            viewAngle.NormalizeAngle();
            ExtraMath.AngleVectors(viewAngle,
                out Vector forward, out Vector right, out Vector up);

            weapon->UpdateAccuracyPenalty();
            float inaccuracy = weapon->GetInaccuracy();
            float spread = weapon->GetSpread();
            int shotsMissed = -512;
            int shotsNeeded = 256;
            int shotsPass = 0;
            var ri = weapon->Get<float>(Offsets.DT_WeaponCSBase.m_flRecoilIndex);
            var di = weapon->m_iItemDefinitionIndex;


            for (int i = 0; i < 256; i++)
            {
                HitChanceParallel(tick.Entity, hitGroup, ref forward, ref right, ref up, inaccuracy, spread,
                    cWeaponInfo, ri,
                    di, ref shotsMissed, ref shotsNeeded, ref shotsPass);
            }

            return shotsPass / 256f;
        }

        // todo actually parallel this
        public static void HitChanceParallel(Entity* e, int hitGroup, ref Vector forward, ref Vector right,
            ref Vector up, float inaccuracy, float weaponSpread, CWeaponInfo* wInfo, float recoilIndex,
            int defIndex, ref int shotsMissed, ref int shotsNeeded, ref int shotsPass)
        {
            if (256 - shotsMissed < shotsNeeded || shotsPass >= shotsNeeded)
                return;

            Vector spread = CalcSpread(inaccuracy, weaponSpread, wInfo, recoilIndex, defIndex);
            Vector dir = forward + (right * spread.X) + (up * spread.Y);
            dir.Normalize();
            var start = SDK.g_LocalPlayer()->GetEyePosition();
            var dst = start + (dir * wInfo->flRange);
            var trace = SDK.EngineTrace.ClipRayToEntity(start, dst, e, (uint) EMask.SHOT);


            if (trace.hit_entity != e || (trace.hitgroup != hitGroup && hitGroup != (int) Generic))
                shotsMissed++;
            else
                shotsPass++;
        }

        public static Vector CalcSpread(float inaccuracy, float weaponSpread, CWeaponInfo* wInfo, float recoilIndex,
            int defIndex)
        {
            if (wInfo == null || wInfo->iBullets == 0)
                return new Vector();

            float r1 = NextFloat(0, 1);
            float r2 = NextFloat(0, PI * 2f);
            float r3 = NextFloat(0, 1);
            float r4 = NextFloat(0, PI * 2f);

            if (defIndex == (int) EItemDefinitionIndex.REVOLVER)
            {
                r1 = 1f - (r1 * r1);
                r1 = 1f - (r3 * r3);
            }
            else if (defIndex == (int) EItemDefinitionIndex.NEGEV)
            {
                for (int i = 3; i > recoilIndex; --i)
                {
                    r1 *= r1;
                    r3 *= r3;
                }

                r1 = 1f - r1;
                r3 = 1f - r3;
            }

            float c1 = (float) Math.Cos(r2);
            float c2 = (float) Math.Cos(r4);

            float s1 = (float) Math.Sin(r2);
            float s2 = (float) Math.Sin(r4);

            return new Vector((c1 * (r1 * inaccuracy)) + (c2 * (r3 * weaponSpread)),
                (s1 * (r1 * inaccuracy)) + (s2 * (r3 * weaponSpread)), 0.0f);
        }

        public static int[] hitScanBones = new int[] {3, 4, 5, 6, 8, 11, 12, 39, 40, 66, 68, 73, 75};
        public static int[] hitScanDamage = new int[76];

        public static Vector Smooth(Vector src, Vector dst, float factor)
        {
            var delta = dst - src;
            delta.NormalizeAngle();
            delta = delta / factor;

            src += delta;
            src.NormalizeAngle();
            return src;
        }

        public static Vector LinearSmooth(Vector src, Vector dst, float speed)
        {
            if (speed == 0)
                return dst;

            var delta = dst - src;

            if (delta.Length == 0f)
                return src;

            delta.NormalizeAngle();
            delta.Normalize();

            var result = src + delta * speed;

            delta = dst - src;
            delta.NormalizeAngle();

            if (delta.Length - (result - src).Length < 0)
                return dst;

            return result;
        }


        public static int tickSkip = 0;

        public static void AutoStop(CUserCmd* cmd)
        {
            if (!Settings.autoStop)
                return;

            var direction = EnginePrediction.preVelocity.ToAngle();
            float speed = EnginePrediction.preVelocity.Length2D;

            direction.Y = cmd->m_vecViewAngles.Y - direction.Y;

            Vector negatedDirection = direction.ToVector() * -speed;

            cmd->m_flForwardmove = negatedDirection.X;
            cmd->m_flSidemove = negatedDirection.Y;


            cmd->m_iButtons &= ~(int) EButtonState.IN_ATTACK;
        }



        public static int GetBestFov(CUserCmd* cmd)
        {
            int bestEntity = -1;
            float bestFov = float.MaxValue;
            Vector lVa = cmd->m_vecViewAngles;

            for (int i = 1; i < SDK.Engine.GetMaxClients(); i++)
            {
                Entity* e = SDK.EntityList.GetEntityByIndex(i);
                if (e == null)
                    continue;
                if (e->IsDormant())
                    continue;
                if (!e->IsAlive())
                    continue;
                if (!Settings.aimbotFF && !e->IsEnemy())
                    continue;
                if (Settings.visibleOnly && !e->IsVisible())
                    continue;

                float fov = CalcFov(lVa, (e->GetBonePosition(8) - SDK.g_LocalPlayer()->GetEyePosition()).ToAngle());

                if (fov < bestFov)
                {
                    bestEntity = i;
                    bestFov = fov;
                }
            }

            return bestEntity;
        }

        public static float CalcFov(Vector src, Vector dst)
        {
            var delta = dst - src;
            delta.NormalizeAngle();
            return delta.Length2D;
        }

        public static float CalcFov(Vector dst)
        {
            Vector start = new Vector();
            SDK.Engine.GetViewAngles(ref start);
            var delta = dst - start;
            delta.NormalizeAngle();
            return delta.Length2D;
        }

        public static Vector CalcAngles(Vector src, Vector dst)
        {
            Vector delta = dst - src;
            Vector angles = new Vector()
            {
                X = r2d((float) Math.Atan2(-delta.Z, Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y))),
                Y = r2d((float) Math.Atan2(delta.Y, delta.X)),
                Z = 0
            };
            return angles;
        }

        public static float GetDamage(Entity* entity, Vector start, Vector dest, CWeaponInfo* weaponData,
            out int hitgroup)
        {
            hitgroup = 0;

            Vector direction = dest - start;
            direction /= direction.Length;

            ShotData shotData = new ShotData()
            {
                start = start,
                direction = direction,
                damage = weaponData->iDamage,
                hitLeft = 4
            };


            while (shotData.damage > 1.0f && shotData.hitLeft > 0)
            {
                shotData.remainLength = weaponData->flRange - shotData.traceLength;
                dest = shotData.start + shotData.direction * shotData.remainLength;


                shotData.trace = SDK.EngineTrace.TraceRay(shotData.start, dest + shotData.direction * 40f, 0x4600400B);

                if (shotData.trace.fraction == 1.0f)
                    return 0f;

                if (shotData.trace.hit_entity == entity && shotData.trace.hitgroup > (int) EHitGroup.Generic &&
                    shotData.trace.hitgroup < (int) EHitGroup.RightLeg)
                {
                    shotData.traceLength += shotData.trace.fraction * shotData.remainLength;

                    shotData.damage *= (float) Math.Pow(weaponData->flRangeModifier, shotData.traceLength * 0.002f);

                    ScaleDamage(shotData.trace.hitgroup, entity, weaponData->flArmorRatio, ref shotData.damage);
                    hitgroup = shotData.trace.hitgroup;
                    return shotData.damage;
                }

                if (!SimBulletPenetration(ref shotData, weaponData))
                    return 0;
            }

            return 0;
        }

        public static bool SimBulletPenetration(ref ShotData shotData, CWeaponInfo* weaponData)
        {
            var enterSurfaceData = SDK.PhysicsSurfaceProps.GetSurfaceData(shotData.trace.surface.surfaceProps);
            var enterMaterial = enterSurfaceData->material;
            float enterPenetrationModifier = enterSurfaceData->penetrationModifier;

            shotData.traceLength += shotData.trace.fraction * shotData.remainLength;
            shotData.damage *= (float) Math.Pow(weaponData->flRangeModifier, shotData.traceLength * 0.002f);

            if (shotData.traceLength > 3000f || enterPenetrationModifier < 0.1f)
                return false;

            if (!TraceToExit(shotData.trace, shotData.trace.end, shotData.direction, out var exitTrace))
                return false;

            var exitSurfaceData = SDK.PhysicsSurfaceProps.GetSurfaceData(exitTrace.surface.surfaceProps);
            var exitMaterial = exitSurfaceData->material;


            float exitPenetrationModifier = exitSurfaceData->penetrationModifier;
            float finalDamageModifier = 0.16f;
            float combinedPenetrationModifier = 0.0f;


            if ((shotData.trace.contents & (int) EContents.GRATE) != 0 || enterMaterial == 89 || enterMaterial == 71)
            {
                combinedPenetrationModifier = 3.0f;
                finalDamageModifier = 0.05f;
            }
            else
                combinedPenetrationModifier = (enterPenetrationModifier + exitPenetrationModifier) * 0.5f;

            if (enterMaterial == exitMaterial)
            {
                if (exitMaterial == 87 || exitMaterial == 85)
                    combinedPenetrationModifier = 3.0f;
                else if (exitMaterial == 76)
                    combinedPenetrationModifier = 2.0f;
            }

            float v34 = Math.Max(0f, 1.0f / combinedPenetrationModifier);
            float v35 = (shotData.damage * finalDamageModifier) +
                        v34 * 3.0f * Math.Max(0.0f, (3.0f / weaponData->flPenetration) * 1.25f);
            float thickness = (exitTrace.end - shotData.trace.end).Length;

            thickness *= thickness;
            thickness *= v34;
            thickness /= 24.0f;

            float lostDamage = Math.Max(0.0f, v35 + thickness);

            if (lostDamage > shotData.damage)
                return false;

            if (lostDamage >= 0.0f)
                shotData.damage -= lostDamage;

            if (shotData.damage < 1.0f)
                return false;

            shotData.start = exitTrace.end;
            shotData.hitLeft--;

            return true;
        }

        public unsafe struct ShotData
        {
            public Vector start;
            public CBaseTrace trace;
            public Vector direction;
            public float traceLength;
            public float remainLength;
            public float damage;
            public int hitLeft;
        }


        public static bool TraceToExit(CBaseTrace enterTrace, Vector start, Vector direction, out CBaseTrace exitTrace)
        {
            float distance = 0f;
            Vector end = new Vector();
            exitTrace = new CBaseTrace();

            while (distance <= 90f)
            {
                distance += 4;
                end = start + direction * distance;

                int pointContents =
                    SDK.EngineTrace.GetPointContents(ref end, (int) EMask.SHOT_HULL | (int) EContents.HITBOX);
                if ((pointContents & (int) EMask.SHOT_HULL) != 0 && (pointContents & (int) EContents.HITBOX) == 0)
                    continue;

                var new_end = end - (direction * 4f);

                exitTrace = SDK.EngineTrace.TraceRay(end, new_end, 0x4600400B);

                if (exitTrace.startSolid != 0 && (exitTrace.surface.flags & (int) ESurf.HITBOX) != 0)
                {
                    exitTrace = SDK.EngineTrace.TraceRay(end, start, 0x600400B, exitTrace.hit_entity);

                    if ((exitTrace.fraction < 1f || exitTrace.allSolid != 0) && exitTrace.startSolid == 0)
                    {
                        end = exitTrace.end;
                        return true;
                    }

                    continue;
                }

                if (!(exitTrace.fraction < 1f || exitTrace.allSolid != 0 || exitTrace.startSolid != 0) ||
                    exitTrace.startSolid != 0)
                {
                    if (exitTrace.hit_entity != null)
                    {
                        if (enterTrace.hit_entity != null &&
                            enterTrace.hit_entity == SDK.EntityList.GetEntityByIndex(0))
                            return true;
                    }

                    continue;
                }

                if ((exitTrace.surface.flags >> 7 & 1) != 0 && (enterTrace.surface.flags >> 7 & 1) == 0)
                    continue;

                if (exitTrace.plane.normal.DotProduct(direction.X, direction.Y, direction.Z) <= 1f)
                {
                    var fraction = exitTrace.fraction * 4f;
                    end = end - direction * fraction;

                    return true;
                }
            }

            return false;
        }

        public static void ScaleDamage(int hit_group, Entity* player, float weapon_armor_ratio,
            ref float current_damage)
        {
            var has_helmet = player->m_bHasHelmet;
            var armor_value = player->m_ArmorValue;

            switch ((EHitGroup) hit_group)
            {
                case Head:
                    current_damage *= 4f;
                    break;
                case Stomach:
                    current_damage *= 1.25f;
                    break;
                case LeftLeg:
                case RightLeg:
                    current_damage *= 0.75f;
                    break;
            }

            var armor = armor_value;
            if (armor > 0)
            {
                float ratio = 0f;
                switch ((EHitGroup) hit_group)
                {
                    case Head:
                        if (has_helmet)
                        {
                            ratio = (weapon_armor_ratio * 0.5f) * current_damage;
                            if (((current_damage - ratio) * 0.5f) > armor)
                            {
                                ratio = current_damage - (armor * 2.0f);
                            }

                            current_damage = ratio;
                        }

                        break;
                    case Generic:
                    case Chest:
                    case Stomach:
                    case LeftArm:
                    case RightArm:
                        ratio = (weapon_armor_ratio * 0.5f) * current_damage;
                        if (((current_damage - ratio) * 0.5f) > armor)
                        {
                            ratio = current_damage - (armor * 2.0f);
                        }

                        current_damage = ratio;
                        break;
                }
            }
        }
    }
}