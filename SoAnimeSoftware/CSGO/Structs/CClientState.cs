using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct INetChannel
    {
        public fixed byte pad_0000[20]; //0x0000
        public byte m_bProcessingMessages; //0x0014
        public byte m_bShouldDelete; //0x0015
        public fixed byte pad_0016[2]; //0x0016
        public int m_nOutSequenceNr; //0x0018 last send outgoing sequence number
        public int m_nInSequenceNr; //0x001C last received incoming sequnec number
        public int m_nOutSequenceNrAck; //0x0020 last received acknowledge outgoing sequnce number
        public int m_nOutReliableState; //0x0024 state of outgoing reliable data (0/1) flip flop used for loss detection
        public int m_nInReliableState; //0x0028 state of incoming reliable data
        public int m_nChokedPackets; //0x002C number of choked packets
        public fixed byte pad_0030[1044]; //0x0030

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte SendNetMsg(INetChannel* pNetChan, INetMessage* msg, byte bForceReliable, byte bVoice);
    }

    public unsafe struct INetMessage
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetGroupDlg(INetMessage* ptr);

        public int GetGroup()
        {
            fixed (INetMessage* ptr = &this)
            {
                return Memory.GetVTableFunction<GetGroupDlg>((IntPtr) ptr, 8)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetTypeDlg(INetMessage* ptr);

        public int GetType()
        {
            fixed (INetMessage* ptr = &this)
            {
                return Memory.GetVTableFunction<GetTypeDlg>((IntPtr) ptr, 7)(ptr);
            }
        }
    }

    public unsafe struct CClientState
    {
        //public fixed byte pad_0000[156]; //0x0000
        //public INetChannel* m_NetChannel; //0x009C
        //public int m_nChallengeNr; //0x00A0
        //public fixed byte pad_00A4[100]; //0x00A4
        //public int m_nSignonState; //0x0108
        //public fixed byte pad_010C[8]; //0x010C
        //public float m_flNextCmdTime; //0x0114
        //public int m_nServerCount; //0x0118
        //public int m_nCurrentSequence; //0x011C
        //public fixed byte pad_0120[8]; //0x0120
        //public CClockDriftMgr m_ClockDriftMgr; //0x0128
        //public int m_nDeltaTick; //0x0174

        public fixed byte pad000[0x9C];
        public INetChannel* m_NetChannel;
        public int m_nChallengeNr;
        public fixed byte pad001[0x4];
        public double m_connect_time;
        public int m_retry_number;
        public fixed byte pad002[0x54];
        public int m_nSignonState;
        public fixed byte pad003[0x4];
        public double m_flNextCmdTime;
        public int m_nServerCount;
        public int m_nCurrentSequence;
        public fixed byte pad004[0x8];
        public CClockDriftMgr m_ClockDriftMgr;
        public int m_nDeltaTick;

        public byte m_bPaused; //0x0178
        public fixed byte pad_017D[3]; //0x017D
        public int m_nViewEntity; //0x0180
        public int m_nPlayerSlot; //0x0184
        public fixed byte m_szLevelName[260]; //0x0188
        public fixed byte m_szLevelNameShort[80]; //0x028C
        public fixed byte m_szGroupName[80]; //0x02DC
        public fixed byte pad_032С[92]; //0x032С
        public int m_nMaxClients; //0x0388
        public fixed byte pad_0314[18824]; //0x0314
        public float m_flLastServerTickTime; //0x4C98
        public byte insimulation; //0x4C9C
        public fixed byte pad_4C9D[3]; //0x4C9D
        public int oldtickcount; //0x4CA0
        public float m_tickRemainder; //0x4CA4
        public float m_frameTime; //0x4CA8
        public int lastoutgoingcommand; //0x4CAC
        public int chokedcommands; //0x4CB0
        public int last_command_ack; //0x4CB4
        public int command_ack; //0x4CB8
        public int m_nSoundSequence; //0x4CBC
        public fixed byte pad_4CC0[80]; //0x4CC0
        public Vector viewangles; //0x4D10
        public fixed byte pad_4D1C[208]; //0x4D1C
    }

    public unsafe struct CClockDriftMgr
    {
        public fixed float m_ClockOffsets[16]; //0x0000
        public int m_iCurClockOffset; //0x0044
        public int m_nServerTick; //0x0048
        public int m_nClientTick; //0x004C
    }
}