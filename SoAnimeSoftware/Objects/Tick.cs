using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Combat;
using SoAnimeSoftware.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Objects
{
    public unsafe class Tick
    {
        public readonly Entity* Entity;
        public float Simtime;
        public Vector Origin;
        public readonly Matrix3x4[] Matrix;

        public Vector Mins;
        public Vector Maxs;
        public Vector Angles;

        public Tick(Entity* e, CUserCmd* cmd)
        {
            this.Entity = e;

            this.Origin = e->m_vecOrigin;

            this.Simtime = e->m_flSimulationTime;

            this.Mins = *e->m_vecMins;

            this.Maxs = *e->m_vecMaxs;

            this.Angles = *e->GetAbsAngles();

            var oldPos = *e->GetAbsOrigin();

            e->SetAbsOrigin(ref Origin);

            e->SetAbsAngles(ref Angles);

            e->InvalidateBoneCache();

            this.Matrix = new Matrix3x4[256];

            e->SetupBones(ref Matrix[0], 256, 256, 0);

            e->SetAbsOrigin(ref oldPos);
        }

        public bool IsValid()
        {
            var delta = Math.Abs(Backtrack.out_delay -
                                 (Backtrack.correct_nexttime - Simtime - Backtrack.interpolation_time));
            return delta <= 0.2f;
        }

        public void Setup()
        {
            Entity->SetAbsOrigin(ref Origin);
            Entity->m_vecOrigin = Origin;
            Entity->SetAbsAngles(ref Angles);

            Entity->SetCollisionBounds(ref Mins, ref Maxs);
            //tick.entity->InvalidateBoneCache();

            fixed (Matrix3x4* ptr = &Matrix[0])
                Entity->m_pBones = ptr;
        }
    }
}