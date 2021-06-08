using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Objects
{
    unsafe static class TargetList
    {
        public static Target[] Targets = new Target[65];

        public static void Fetch(CUserCmd* cmd)
        {
            for (int i = 0; i < SDK.Engine.GetMaxClients(); i++)
            {
                var e = CSGO.SDK.EntityList.GetEntityByIndex(i);
                if (e == null || e->IsDormant() || !e->IsAlive() || e->m_bGunGameImmunity ||
                    (!e->IsEnemy() && !Settings.aimbotFF))
                {
                    Targets[i].Clear();
                }
                else
                {
                    Targets[i].Add(e, cmd);
                    Targets[i].DeleteInvalidTicks();
                }
            }
        }

        public static void ClearTargets()
        {
            for (int i = 0; i < Targets.Length; i++)
            {
                Targets[i] = new Target();
            }
        }


        public static Target GetBestTarget(Vector start, out Tick bestTick, out Vector bestAngle)
        {
            Target result = null;
            bestTick = null;
            bestAngle = start;
            float bestFov = float.MaxValue;
            
            foreach (var t in Targets)
            {
                if (!t.Valid)
                    continue;

                var tick = t.GetBestTick(start, out var dst, out var fov);

                if (fov < bestFov)
                {
                    bestAngle = dst;
                    bestTick = tick;
                    result = t;
                    bestFov = fov;
                }
            }

            if (bestTick == null)
            {
                bestTick = result?.MainTick;
            }

            return result;
        }
    }
}