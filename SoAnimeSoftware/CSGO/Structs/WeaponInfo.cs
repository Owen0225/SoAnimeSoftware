using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CWeaponInfo
    {
        // fixed byte pad_0000[4]; //0x0000
        //public ConstChar* szConsoleName; //0x0004
        // fixed byte pad_0008[12]; //0x0008
        //public int iMaxReservedAmmo; //0x0014
        // fixed byte pad_0018[104]; //0x0018
        //public ConstChar* szBulletType; //0x0080
        // fixed byte _unk[4];
        //public ConstChar* szHudName;
        //public ConstChar* _szHudName; //0x008C
        // fixed byte pad_0090[56]; //0x0090
        //public int WeaponType;
        // fixed byte pad4[4];
        //public int iWeaponPrice;
        //public int iKillAward;
        // fixed byte pad5[20];
        private fixed byte pad[20];
        public int maxClip;
        private fixed byte pad2[112];
        public Char_t* szHudName;
        private fixed byte pad3[60];
        public int WeaponType;
        private fixed byte pad4[4];
        public int price;
        private fixed byte pad5[0x8];
        public float cycletime;
        private fixed byte pad6[12];

        public byte bFullAuto;
        fixed byte pad7[3];
        public int iDamage;
        public float flArmorRatio;
        public int iBullets;
        public float flPenetration;
        fixed byte pad_0100[8]; //0x0100
        public float flRange; //0x0108
        public float flRangeModifier; //0x010C
    }
}