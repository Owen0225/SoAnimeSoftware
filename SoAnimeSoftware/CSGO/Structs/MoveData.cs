using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CMoveData
    {
        // пиздато согласен
        public byte m_bFirstRunOfFunctions;
        public byte m_bGameCodeMovedPlayer;
        public int m_nPlayerHandle; // edict index on server, client entity handle on client=
        public int m_nImpulseCommand; // Impulse command issued.
        public Vector m_vecViewAngles; // Command view angles (local space)
        public Vector m_vecAbsViewAngles; // Command view angles (world space)
        public int m_nButtons; // Attack buttons.
        public int m_nOldButtons; // From host_client->oldbuttons;
        public float m_flForwardMove;
        public float m_flSideMove;
        public float m_flUpMove;
        public float m_flMaxSpeed;
        public float m_flClientMaxSpeed;
        public Vector m_vecVelocity; // edict::velocity        // Current movement direction.
        public Vector m_vecAngles; // edict::angles
        public Vector m_vecOldAngles;
        public float m_outStepHeight; // how much you climbed this move
        public Vector m_outWishVel; // This is where you tried 
        public Vector m_outJumpVel; // This is your jump velocity
        public Vector m_vecConstraintCenter;
        public float m_flConstraintRadius;
        public float m_flConstraintWidth;
        public float m_flConstraintSpeedFactor;
        public fixed float m_flUnknown[5];
        public Vector m_vecAbsOrigin;


        public void ToZero()
        {
            this = new CMoveData();
        }
    }
}