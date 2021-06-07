using System;
using System.Runtime.InteropServices;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.Hack.Misc.MovementRecorder
{

        [Serializable]
        public struct Record
        {
            public Record(string name, string map, Vector start, Vector eye, Vector eyePos, int ticksCount = 3840)
            {
                Title = name;
                Ticks = new MovementTick[ticksCount];
                StartPosition = start;
                StartViewAngles = eye;
                StartEyePosition = eyePos;
                LevelName = map;
            }

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3840)]
            public MovementTick[] Ticks;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string Title;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string LevelName;

            public Vector StartPosition;
            public Vector StartViewAngles;
            public Vector StartEyePosition;
        }
    
}