using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    [Flags]
    enum EButtonState
    {
        IN_ATTACK = 1 << 0,
        IN_JUMP = 1 << 1,
        IN_DUCK = 1 << 2,
        IN_FORWARD = 1 << 3,
        IN_BACK = 1 << 4,
        IN_USE = 1 << 5,
        IN_MOVELEFT = 1 << 9,
        IN_MOVERIGHT = 1 << 10,
        IN_ATTACK2 = 1 << 11,
        IN_SCORE = 1 << 16,
        IN_BULLRUSH = 1 << 22
    };

    [Serializable]
    public struct CUserCmd
    {
        public int pVft; //0
        public int m_iCmdNumber; //4
        public int m_iTickCount; //8
        public Vector m_vecViewAngles; //12
        public Vector m_vecAimDirection; //24
        public float m_flForwardmove; //36
        public float m_flSidemove; //40
        public float m_flUpmove; //44
        public int m_iButtons; //48
        public int m_bImpulse; // 52
        public int m_iWeaponSelect; //56 
        public int m_iWeaponSubtype; //60
        public int m_iRandomSeed; //64
        public short m_siMouseDx; // 68
        public short m_siMouseDy; // 70
        public byte _m_bHasBeenPredicted;

        public bool m_bHasBeenPredicted()
        {
            return _m_bHasBeenPredicted != 0;
        }
        
    };
}