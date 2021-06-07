using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware
{
    unsafe class GVars
    {
        public static bool Unhook = false;

        public static int TeamKills = 0;
        public static int TeamDamage = 0;
        public static bool OverlayUpdated = true;

        public static string MainPath = Path.Combine(Path.GetPathRoot(Environment.SystemDirectory), "SoAnimeSoftware");
        public static string MainAudioPath = Path.Combine(MainPath, "VoiceRecords");

        public static bool MenuOpened = false;

        public static void OnNewGame()
        {
            TeamKills = 0;
            TeamDamage = 0;
        }
    }
}