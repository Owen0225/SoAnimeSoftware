using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;
using System;
using System.Collections.Generic;

namespace SoAnimeSoftware.Hack.Combat
{
    unsafe class Backtrack
    {
        public static float interpolation_time;
        public static float network_delay;
        public static float latency_delay;
        public static float out_delay;
        public static float correct_nexttime;

        public static CConVar* cl_updaterate;
        public static CConVar* sv_maxupdaterate;
        public static CConVar* cl_interp;
        public static CConVar* cl_interp_ratio;
        public static CConVar* sv_client_min_interp_ratio;
        public static CConVar* sv_client_max_interp_ratio;
        public static CConVar* sv_maxunlag;
        

        public static void GetNetDelays(int tick_count)
        {
            var nci = SDK.Engine.GetNetworkChannel();

            var unlag = sv_maxunlag->GetFloat();
            interpolation_time = GetInterpolationCompensation();

            latency_delay = nci->GetLatency(0) + nci->GetLatency(1);
            network_delay = ExtraMath.Clamp(latency_delay + interpolation_time, 0f, unlag);
            out_delay = ExtraMath.Clamp(nci->GetLatency(0) + interpolation_time, 0f, unlag);

            correct_nexttime = TicksToTime(tick_count + 1) + network_delay;
        }

        public static float TicksToTime(int ticks)
        {
            return SDK.GlobalVars->interval_per_tick * ticks;
        }

        public static int TimeToTicks(float time)
        {
            return (int) (0.5f + time / SDK.GlobalVars->interval_per_tick);
        }

        public static float GetInterpolationCompensation()
        {
            float ratio = cl_interp_ratio->GetFloat();
            if (ratio == 0)
                ratio = 1.0f;

            if (sv_client_min_interp_ratio->GetFloat() != 1f)
                ratio = ExtraMath.Clamp(ratio, sv_client_min_interp_ratio->GetFloat(),
                    sv_client_max_interp_ratio->GetFloat());

            var ud_rate = sv_maxupdaterate->GetInt();

            return Math.Max(cl_interp->GetFloat(), (ratio / ud_rate));
        }

        public static void Init()
        {
            cl_updaterate = SDK.CVar.FindVar("cl_updaterate");
            sv_maxupdaterate = SDK.CVar.FindVar("sv_maxupdaterate");
            cl_interp = SDK.CVar.FindVar("cl_interp");
            cl_interp_ratio = SDK.CVar.FindVar("cl_interp_ratio");
            sv_client_min_interp_ratio = SDK.CVar.FindVar("sv_client_min_interp_ratio");
            sv_client_max_interp_ratio = SDK.CVar.FindVar("sv_client_max_interp_ratio");
            sv_maxunlag = SDK.CVar.FindVar("sv_client_max_interp_ratio");
        }
    }
}