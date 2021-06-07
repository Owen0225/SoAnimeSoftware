using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Hack.Grief
{
    unsafe class DoorSpammer
    {
        private static bool _spamming = false;

        public static void Run(CUserCmd* cmd)
        {
            if (!Settings.doorSpammer)
                return;
            if (SDK.g_LocalPlayer() == null)
                return;
            if (!SDK.g_LocalPlayer()->IsAlive())
                return;

            if (GUI.Input.KeyDown(Settings.doorSpammerKey) && _spamming)
            {
                cmd->m_iButtons |= (int) EButtonState.IN_USE;
            }

            _spamming = !_spamming;
        }
    }
}