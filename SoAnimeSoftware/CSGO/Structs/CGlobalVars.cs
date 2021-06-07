using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CGlobalVars
    {
        public float realtime; // 0x0000
        public int framecount; // 0x0004
        public float absoluteframetime; // 0x0008
        public float absoluteframestarttimestddev; // 0x000C
        public float curtime; // 0x0010
        public float frametime; // 0x0014
        public int maxClients; // 0x0018
        public int tickcount; // 0x001C
        public float interval_per_tick; // 0x0020
        public float interpolation_amount; // 0x0024
        public int simTicksThisFrame; // 0x0028
        public int network_protocol; // 0x002C
        public IntPtr pSaveData; // 0x0030
        public byte _m_bClient; // 0x0031
        public byte _m_bRemoteClient; // 0x0032

        public float timeInSeconds
        {
            get { return tickcount * interval_per_tick; }
        }

        public bool m_bClient
        {
            get { return _m_bClient != 0; }
            set { _m_bClient = (byte) (value ? 1 : 0); }
        }

        public bool m_bRemoteClient
        {
            get { return _m_bRemoteClient != 0; }
            set { _m_bRemoteClient = (byte) (value ? 1 : 0); }
        }

        public static int tick;
        public static CUserCmd* lastCmd;

        public float servertime(CUserCmd* cmd)
        {
            if (cmd != null)
            {
                if (SDK.g_LocalPlayer() != null && (lastCmd == null || lastCmd->m_bHasBeenPredicted()))
                {
                    tick = SDK.g_LocalPlayer()->m_nTickBase;
                }
                else
                {
                    tick++;
                }

                lastCmd = cmd;
            }

            return tick * interval_per_tick;
        }
    }
}