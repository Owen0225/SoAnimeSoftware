using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Objects
{
    public unsafe class Target
    {
        public LinkedList<Tick> Ticks = new LinkedList<Tick>();
        public Tick MainTick;
        public bool Valid = false;

        public void Add(Entity* e, CUserCmd* cmd)
        {
            MainTick = new Tick(e, cmd);
            Ticks.AddLast(MainTick);
            if (!Settings.backtrack && Ticks.Count > 1)
            {
                Ticks.RemoveFirst();
            }

            Valid = true;
        }

        public void Clear()
        {
            if (Valid)
            {
                Ticks = new LinkedList<Tick>();
                Valid = false;
            }
        }


        public Tick GetBestTick(Vector start, out Vector bestAngle, out float bestFov)
        {
            Tick bestTick = null;
            bestFov = float.MaxValue;
            bestAngle = start;

            var vp = SDK.g_LocalPlayer()->GetEyePosition();

            var e = MainTick.Entity;

            if (e == null || e->IsDormant() || !e->IsAlive())
                return bestTick;

            foreach (var tick in Ticks)
            {
                if (Settings.visibleOnly)
                    tick.Setup();

                for (var i = 0; i < Aimbot.BoneIds.Length; i++)
                {
                    if (!Settings.bones[i])
                        continue;

                    var pos = ExtraMath.GetBonePosition(tick.Matrix, Aimbot.BoneIds[i]);

                    if (Settings.visibleOnly)
                    {
                        if (!e->IsVisible(pos))
                            continue;
                    }

                    var dst = Aimbot.CalcAngles(vp, pos);
                    var fov = Aimbot.CalcFov(start, dst);

                    if (fov < bestFov)
                    {
                        bestFov = fov;
                        bestTick = tick;
                        bestAngle = dst;
                    }
                }
            }

            if (Settings.visibleOnly)
                MainTick.Setup();

            return bestTick;
        }


        public void DeleteInvalidTicks()
        {
            while (Ticks.Count > 0 && !Ticks.First.Value.IsValid())
            {
                Ticks.RemoveFirst();
            }
        }
    }
}