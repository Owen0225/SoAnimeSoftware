using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.Hack.Misc.MovementRecorder
{

        [Serializable]
        public struct MovementTick
        {
            public CUserCmd Cmd;
            public Vector Origin;
            public Vector Velocity;
        }
    
}