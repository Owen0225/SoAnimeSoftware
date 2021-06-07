namespace SoAnimeSoftware.CSGO.Structs
{
    unsafe public struct PlayerAnimState
    {
        public void* pThis;
        fixed byte pad2[91];
        public void* pBaseEntity; //0x60
        public void* pActiveWeapon; //0x64
        public void* pLastActiveWeapon; //0x68
        public float m_flLastClientSideAnimationUpdateTime; //0x6C
        public int m_iLastClientSideAnimationUpdateFramecount; //0x70
        public float m_flEyePitch; //0x74
        public float m_flEyeYaw; //0x78
        public float m_flPitch; //0x7C
        public float m_flGoalFeetYaw; //0x80
        public float m_flCurrentFeetYaw; //0x84
        public float m_flCurrentTorsoYaw; //0x88
        public float m_flUnknownVelocityLean; //0x8C //changes when moving/jumping/hitting ground
        public float m_flLeanAmount; //0x90
        fixed byte pad4[4]; //NaN
        public float m_flFeetCycle; //0x98 0 to 1
        public float m_flFeetYawRate; //0x9C 0 to 1
        public float m_fUnknown2;
        public float m_fDuckAmount; //0xA4
        public float m_fLandingDuckAdditiveSomething; //0xA8
        public float m_fUnknown3; //0xAC
        public Vector m_vOrigin; //0xB0, 0xB4, 0xB8
        public Vector m_vLastOrigin; //0xBC, 0xC0, 0xC4
        public float m_vVelocityX; //0xC8
        public float m_vVelocityY; //0xCC
        fixed byte pad5[4];
        public float m_flUnknownFloat1; //0xD4 Affected by movement and direction
        fixed byte pad6[8];
        public float m_flUnknownFloat2; //0xE0 //from -1 to 1 when moving and affected by direction
        public float m_flUnknownFloat3; //0xE4 //from -1 to 1 when moving and affected by direction
        public float m_unknown; //0xE8
        public float speed_2d; //0xEC
        public float flUpVelocity; //0xF0
        public float m_flSpeedNormalized; //0xF4 //from 0 to 1

        public float
            m_flFeetSpeedForwardsOrSideWays; //0xF8 //from 0 to 2. something  is 1 when walking, 2.something when running, 0.653 when crouch walking

        public float m_flFeetSpeedUnknownForwardOrSideways; //0xFC //from 0 to 3. something
        public float m_flTimeSinceStartedMoving; //0x100
        public float m_flTimeSinceStoppedMoving; //0x104
        public byte m_bOnGround; //0x108
        public byte m_bInHitGroundAnimation; //0x109
        public fixed byte pad7[10];
        public float m_flLastOriginZ; //0x114
        public float m_flHeadHeightOrOffsetFromHittingGroundAnimation; //0x118 from 0 to 1, is 1 when standing

        public float
            m_flStopToFullRunningFraction; //0x11C from 0 to 1, doesnt change when walking or crouching, only running

        fixed byte pad8[4]; //NaN
        public float m_flUnknownFraction; //0x124 affected while jumping and running, or when just jumping, 0 to 1
        fixed byte pad9[4]; //NaN
        public float m_flUnknown3;
        fixed byte pad10[528];
    }
}