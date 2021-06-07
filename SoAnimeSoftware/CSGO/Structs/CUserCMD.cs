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
        public int pVft;
        public int m_iCmdNumber;
        public int m_iTickCount;
        public Vector m_vecViewAngles;
        public Vector m_vecAimDirection;
        public float m_flForwardmove;
        public float m_flSidemove;
        public float m_flUpmove;
        public int m_iButtons;
        public int m_bImpulse;
        public int m_iWeaponSelect;
        public int m_iWeaponSubtype;
        public int m_iRandomSeed;
        public short m_siMouseDx;
        public short m_siMouseDy;
        public byte _m_bHasBeenPredicted;

        public bool m_bHasBeenPredicted()
        {
            return _m_bHasBeenPredicted != 0;
        }

        public bool Attack
        {
            get => (m_iButtons & (int) EButtonState.IN_ATTACK) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_ATTACK;
        }

        public bool Attack2
        {
            get => (m_iButtons & (int) EButtonState.IN_ATTACK2) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_ATTACK2;
        }

        public bool Jump
        {
            get => (m_iButtons & (int) EButtonState.IN_JUMP) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_JUMP;
        }

        public bool Duck
        {
            get => (m_iButtons & (int) EButtonState.IN_DUCK) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_DUCK;
        }

        public bool Forward
        {
            get => (m_iButtons & (int) EButtonState.IN_FORWARD) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_FORWARD;
        }

        public bool Right
        {
            get => (m_iButtons & (int) EButtonState.IN_MOVERIGHT) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_MOVERIGHT;
        }

        public bool Left
        {
            get => (m_iButtons & (int) EButtonState.IN_MOVELEFT) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_MOVELEFT;
        }

        public bool Back
        {
            get => (m_iButtons & (int) EButtonState.IN_BACK) != 0;
            set => m_iButtons &= ~(int) EButtonState.IN_BACK;
        }
    };
}