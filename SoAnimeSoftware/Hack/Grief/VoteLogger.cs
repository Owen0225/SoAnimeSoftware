using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Hack.Grief
{
    static class VoteLogger
    {
        public static unsafe void Run(GameEvent* e)
        {
            if (!Settings.voteLogger)
                return;

            if (e->GetName()->ToString() != "vote_cast")
                return;

            PlayerInfo pInfo = new PlayerInfo();
            SDK.Engine.GetPlayerInfo(e->GetInt("entityid"), ref pInfo);
            SDK.HudChat->Notify(
                $"{pInfo.szName.ToString()} {ChatColor.Gray} voted for {(e->GetInt("vote_option") == 0 ? ChatColor.Green + "Yes" : ChatColor.Red + "No")}"
            );
        }
    }
}