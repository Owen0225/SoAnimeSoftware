using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.GUI;

namespace SoAnimeSoftware.Hack.Grief
{
    static unsafe class TeamDamageTracker
    {
        public static Dictionary<int, int> PlayersHealth = new Dictionary<int, int>();
        public static Dictionary<long, int> PlayersTeamDamage = new Dictionary<long, int>();
        public static Dictionary<long, int> PlayersTeamKills = new Dictionary<long, int>();

        public static void Run(GameEvent* e)
        {
            if (!Settings.overlay)
                return;

            string eventName = e->GetName()->ToString();
            if (eventName == "player_hurt")
            {
                var target = SDK.Engine.GetEntityByUserID(e->GetInt("userid"));
                var attacker = SDK.Engine.GetEntityByUserID(e->GetInt("attacker"));

                if (target == null || attacker == null)
                    return;

                if (attacker == target)
                    return;

                if (e->GetInt("attacker") == 0)
                    return;

                if (attacker->IsEnemy() || target->IsEnemy())
                    return;

                var targetInfo = target->PlayerInfo();
                var attackerSteam = attacker->PlayerInfo().xuidLow;

                if (attacker->PlayerInfo().fakeplayer == 1)
                    return;


                if (e->GetInt("health") != 0)
                {
                    PlayersTeamDamage[attackerSteam] = PlayersTeamDamage.TryGetValue(attackerSteam, out var damage)
                        ? damage + e->GetInt("dmg_health")
                        : e->GetInt("dmg_health");
                }

                if (attacker == SDK.g_LocalPlayer() && !target->IsEnemy())
                {
                    if (e->GetInt("health") != 0)
                    {
                        GVars.TeamDamage += e->GetInt("dmg_health");
                    }


                    CSGO.SDK.Engine.ClientCmd_Unrestricted(@"play buttons\button10", 0);
                    GVars.OverlayUpdated = false;
                }
            }
            else if (eventName == "player_death")
            {
                var target = SDK.Engine.GetEntityByUserID(e->GetInt("userid"));
                var attacker = SDK.Engine.GetEntityByUserID(e->GetInt("attacker"));


                if (target == null || attacker == null)
                    return;

                if (attacker == target)
                    return;

                var targetInfo = target->PlayerInfo();

                if (e->GetInt("attacker") == 0)
                    return;

                if (attacker->IsEnemy() || target->IsEnemy())
                    return;

                var attackerSteam = attacker->PlayerInfo().xuidLow;

                if (attacker->PlayerInfo().fakeplayer == 1)
                    return;

                PlayersTeamKills[attackerSteam] =
                    PlayersTeamKills.TryGetValue(attackerSteam, out var kills) ? kills + 1 : 1;
                PlayersTeamDamage[attackerSteam] = PlayersTeamDamage.TryGetValue(attackerSteam, out var damage)
                    ? damage + PlayersHealth[e->GetInt("userid")]
                    : PlayersHealth[e->GetInt("userid")];

                if (attacker == SDK.g_LocalPlayer() && !target->IsEnemy())
                {
                    CSGO.SDK.Engine.ClientCmd_Unrestricted(@"play buttons\button8", 0);
                    GVars.TeamKills += 1;
                    GVars.TeamDamage += PlayersHealth[e->GetInt("userid")];
                    GVars.OverlayUpdated = false;
                }
            }
        }

        public static bool OverlayDrawing = false;

        public static void FetchPlayersHealth()
        {
            for (int i = 1; i < CSGO.SDK.Engine.GetMaxClients(); i++)
            {
                var e = CSGO.SDK.EntityList.GetEntityByIndex(i);

                if (e == null)
                    continue;

                var info = e->PlayerInfo();
                var id = info.userid;
                var health = e->m_iHealth;

                if (health == 0)
                    continue;

                PlayersHealth[id] = health;
            }
        }
        
        private static DateTime _startTime = DateTime.Now;
        private static bool _overlayUpdating = false;
        private static int _alpha = 255;

        public static void DamageOverlayDraw()
        {
            if (!Settings.overlay)
                return;

            if (_overlayUpdating)
            {
                if ((DateTime.Now - _startTime).Seconds < 5)
                {
                    string text = "Team kills: " + GVars.TeamKills.ToString();
                    text += " Team damage: " + GVars.TeamDamage.ToString();
                    var textSize = SDK.Surface.GetTextSize(Render.SPOTIFYo, text);
                    var size = SDK.Surface.GetScreenSize();
                    int x = (size[0] - textSize[0]) / 2;
                    int y = (int) (size[1] * 0.25f);
                    if ((DateTime.Now - _startTime).Seconds > 3)
                    {
                        _alpha -= 2;
                        if (_alpha < 0)
                        {
                            _alpha = 0;
                            _overlayUpdating = false;
                            return;
                        }
                    }

                    SDK.Surface.SetTextFont(Render.SPOTIFYo);
                    SDK.Surface.SetTextColor(245, 222, 240, _alpha);
                    SDK.Surface.SetTextPosition(x, y);
                    SDK.Surface.PrintText(text);
                }
                else
                {
                    _overlayUpdating = false;
                }
            }

            if (GVars.OverlayUpdated)
            {
                return;
            }
            else
            {
                _alpha = 255;
                _startTime = DateTime.Now;
                _overlayUpdating = true;
                GVars.OverlayUpdated = true;
                return;
            }
        }

        public static void TeamDamageOverlayDraw()
        {
            if (!Settings.overlay)
                return;

            if (!Grief.TeamDamageTracker.OverlayDrawing)
                return;

            int y = 360;

            var padding = SDK.Surface.GetTextSize(GUI.Render.tahoma14o, "A")[1];

            SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
            SDK.Surface.SetTextColor(Color.LightPink);
            SDK.Surface.SetTextPosition(10, y);
            SDK.Surface.PrintText("Name");

            SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
            SDK.Surface.SetTextColor(Color.LightPink);
            SDK.Surface.SetTextPosition(170, y);
            SDK.Surface.PrintText("Damage");

            SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
            SDK.Surface.SetTextColor(Color.LightPink);
            SDK.Surface.SetTextPosition(230, y);
            SDK.Surface.PrintText("Kills");

            y += padding + 10;

            for (int i = 1; i < CSGO.SDK.Engine.GetMaxClients(); i++)
            {
                var e = CSGO.SDK.EntityList.GetEntityByIndex(i);

                if (e == null)
                    continue;

                if (e->IsEnemy())
                    continue;

                var info = e->PlayerInfo();

                if (info.fakeplayer == 1)
                    continue;

                var id = info.xuidLow;

                var name = info.szName.ToString();
                name = name.Length > 16 ? name.Substring(0, 16) : name;

                SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
                SDK.Surface.SetTextColor(Color.LightPink);
                SDK.Surface.SetTextPosition(10, y);
                SDK.Surface.PrintText(name);

                SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
                SDK.Surface.SetTextColor(Color.LightPink);
                SDK.Surface.SetTextPosition(170, y);
                SDK.Surface.PrintText((Grief.TeamDamageTracker.PlayersTeamDamage.TryGetValue(id, out var damage)
                    ? damage
                    : 0).ToString());

                SDK.Surface.SetTextFont(GUI.Render.tahoma14o);
                SDK.Surface.SetTextColor(Color.LightPink);
                SDK.Surface.SetTextPosition(230, y);
                SDK.Surface.PrintText((Grief.TeamDamageTracker.PlayersTeamKills.TryGetValue(id, out var kills)
                    ? kills
                    : 0).ToString());

                y += padding;
            }
        }
    }
}