using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Visuals;
using SoAnimeSoftware.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Hack.Misc
{
    unsafe class Checks
    {
        public static bool needUpdate = true;

        public static void OnEvent(GameEvent* e)
        {
            var eventName = e->GetName()->ToString();
            if (eventName == "server_spawn")
            {
                for (int i = 0; i < Hack.Visuals.Esp.PlayerBoxes.Length; i++)
                {
                    Hack.Visuals.Esp.PlayerBoxes[i] = new Esp.Box();
                }

                MovementRecorder.MovementManager.Replays.Refresh();
                Hack.Grief.TeamDamageTracker.PlayersHealth.Clear();
                Hack.Grief.TeamDamageTracker.PlayersTeamKills.Clear();
                Hack.Grief.TeamDamageTracker.PlayersTeamDamage.Clear();

                TargetList.ClearTargets();
                Settings.worldColoring =
                    Settings.worldColoring == Status.ENABLED_DONE || Settings.worldColoring == Status.ENABLED
                        ? Status.ENABLED
                        : Status.DISABLED;
                needUpdate = true;
                SkinChanger.ModelIndexes = null;
                GVars.OnNewGame();
                Hack.Misc.Other.RpcNeedUpdate = true;
            }
            else if (eventName == "cs_game_disconnected")
            {
                Hack.Misc.Other.RpcNeedUpdate = true;
            }
            else if (eventName == "player_connect_full")
            {
            }
        }

        public static void Update()
        {
            if (!needUpdate)
                return;

            if (!SDK.Engine.IsInGame())
                return;

            if (SDK.g_LocalPlayer() == null)
                return;

            if (SDK.g_LocalPlayer()->IsDormant())
                return;

            Hack.Visuals.Perception.WorldColor();
            Hack.Visuals.Perception.Valorant();
            Hack.Visuals.Perception.Minecraft();

            if (!SDK.g_LocalPlayer()->IsAlive())
                return;

            Hack.Misc.Other.GrenadePrediction();
            Hack.Misc.Other.RecoilCrosshair();
            Hack.Visuals.Perception.ViewmodelOffset();

            needUpdate = false;
        }
    }
}