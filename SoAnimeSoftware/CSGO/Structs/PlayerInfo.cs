using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct PlayerInfo
    {
        public Int64 pad;
        public int xuidLow;
        public int xuidHigh;
        public Char_t szName;
        fixed byte szNamePad[127];
        public int userid;
        public fixed byte guid[20];
        public fixed byte pad1[16];
        public int friendsid;
        public fixed byte szFriendsName[128];
        public byte fakeplayer;
        public byte ishltv;
        public fixed int customfiles[4];
        public byte filesdownloaded;
    }
}