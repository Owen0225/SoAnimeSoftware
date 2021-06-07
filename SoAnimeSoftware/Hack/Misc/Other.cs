using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Hack.Combat;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DiscordRPC;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.Hack.Misc
{
    unsafe class Other
    {
        public static Random random = new Random((int) DateTime.Now.Ticks);

        public static void RecoilCrosshair()
        {
            if (Settings.recoilCrosshair)
                CSGO.SDK.CVar.Force("cl_crosshair_recoil", 1);
            else
                CSGO.SDK.CVar.Force("cl_crosshair_recoil", 0);
        }

        public static void GrenadePrediction()
        {
            if (Settings.grenadePrediction)
                CSGO.SDK.CVar.Force("cl_grenadepreview", 1);
            else
                CSGO.SDK.CVar.Force("cl_grenadepreview", 0);
        }

        public unsafe static void HitSound(GameEvent* e)
        {
            if (e->GetName()->ToString() != "player_hurt")
                return;

            if (!Settings.hitSound)
                return;

            if (e->GetInt("attacker") == CSGO.SDK.g_LocalPlayer()->UserID())
                CSGO.SDK.Engine.ClientCmd_Unrestricted("play buttons/arena_switch_press_02", 0);
        }

        static bool hasClanTag = false;
        static float lastTimeTag = 0;

        public static void VelocityClanTag()
        {
            if (SDK.g_LocalPlayer()->m_iHealth <= 0)
                return;

            if (SDK.GlobalVars->timeInSeconds - lastTimeTag < 0.1f)
            {
                return;
            }

            if (!Settings.velocityTag)
            {
                if (hasClanTag)
                    SDK.Engine.SetClanTag("");
                hasClanTag = false;
                return;
            }

            var tag = $"velocity {(int) SDK.g_LocalPlayer()->m_vecVelocity.Length2D}";
            SDK.Engine.SetClanTag(tag);
            hasClanTag = true;
            lastTimeTag = SDK.GlobalVars->timeInSeconds;
        }

        private static float _lastTimeChat = 0;
        private static int _messageIndex = 0;

        private static readonly string[] SpamMessages = new string[]
        {
            "﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽﷽ ﷽﷽",
        };

        public static void ChatBreaker()
        {
            if (!Settings.chatBreaker)
                return;

            if (SDK.GlobalVars->timeInSeconds - _lastTimeChat < 0.11f)
                return;

            SDK.Engine.ClientCmd_Unrestricted($"say {SpamMessages[_messageIndex]}", 0);
            _lastTimeChat = SDK.GlobalVars->timeInSeconds;

            if (_messageIndex < SpamMessages.Length - 1)
                _messageIndex++;
            else
                _messageIndex = 0;
        }


        private static string mainPath = GVars.MainAudioPath;

        public static void VoiceEvents(GameEvent* e = null)
        {
            if (!Settings.voiceEvents)
                return;

            if (!Directory.Exists(mainPath))
                Directory.CreateDirectory(mainPath);

            string fileName = "";

            switch (e->GetName()->ToString())
            {
                case "item_equip":
                {
                    if (e->GetInt("userid") != CSGO.SDK.g_LocalPlayer()->UserID())
                        return;

                    if (e->GetInt("weptype") != (int) EWeaponType.Rifle)
                        return;

                    fileName = "onRifle";
                    break;
                }
                case "player_death":
                {
                    if (e->GetInt("attacker") != CSGO.SDK.g_LocalPlayer()->UserID())
                        return;
                    /*
                    SDK.Engine.ClientCmd_Unrestricted(
                        $"playerchatwheel . \"{ChatColor.LightRed + "П" + ChatColor.LightGreen + "О" + ChatColor.Blue + "С" + ChatColor.DarkGreen + "О" + ChatColor.Orange + "С" + ChatColor.Yellow + "И"}\"");
                    */
                    fileName = "onKill";
                    var activeWeapon = SDK.g_LocalPlayer()->GetActiveWeapon();
                    if (activeWeapon->IsKnife())
                        fileName = "onKnifeKill";
                    break;
                }
            }

            VoiceAudioPlayer.Play(fileName);
        }

        public static bool RpcNeedUpdate = true;
        public static DiscordRpcClient Discord;

        public static void DiscordIntegration(CancellationToken ct)
        {
            string lastLevel = String.Empty;
            string lastMode = String.Empty;
            
            while (true)
            {
                Thread.Sleep(100);

                if (ct.IsCancellationRequested)
                {
                    Discord?.ClearPresence();
                    Discord?.Deinitialize();
                    Discord?.Dispose();
                    
                    return;
                }

                Thread.Sleep(5000);

                if (Discord == null)
                {
                    Discord = new DiscordRpcClient("768547727553855518",
                        client: new DiscordRPC.IO.ManagedNamedPipeClient());
                    Discord.Initialize();
                }

                int game_type = SDK.game_type->GetInt();
                int game_mode = SDK.game_mode->GetInt();

                string mode = "Idle";

                if (SDK.Engine.IsInGame())
                {
                    switch (game_type)
                    {
                        case 0:
                            switch (game_mode)
                            {
                                case 0:
                                    mode = "Casual";
                                    break;
                                case 1:
                                    mode = "Competitive";
                                    break;
                                case 2:
                                    mode = "Wingman";
                                    break;
                            }

                            break;
                        case 1:
                            switch (game_mode)
                            {
                                case 0:
                                    mode = "Arms Race";
                                    break;
                                case 1:
                                    mode = "Demolition";
                                    break;
                                case 2:
                                    mode = "Deathmatch";
                                    break;
                            }

                            break;
                        case 3:
                            mode = "Custom";
                            break;
                        case 4:
                            switch (game_mode)
                            {
                                case 0:
                                    mode = "Guardian";
                                    break;
                                case 1:
                                    mode = "Co-op Strike";
                                    break;
                            }

                            break;
                        case 6:
                            mode = "Danger Zone";
                            break;
                    }
                }

                var level = SDK.Engine.IsInGame()
                    ? SDK.Engine.GetLevelName()->ToString().Replace(".bsp", "").Replace("maps\\", "")
                    : "Main menu";
                
                if(level.Equals(lastLevel) && lastMode.Equals(mode))
                    continue;
                
                Discord.ClearPresence();
                
                var task = Task.Run(() => Discord.SetPresence(new RichPresence()
                {
                    Details = mode,
                    State = level,
                    Timestamps = new Timestamps(start: DateTime.UtcNow),
                    Assets = new Assets()
                    {
                        LargeImageKey = "anime",
                        LargeImageText = "Playing with vip chit.",
                        SmallImageKey = ""
                    }
                }));

                task.Wait();
                lastLevel = level;
                lastMode = mode;
            }
        }

        public static int voted = 0;

        public static void Golosovanie(GameEvent* e)
        {
            if (e->GetName()->ToString() != "vote_cast")
                return;

            var ent = SDK.EntityList.GetEntityByIndex(e->GetInt("entityid"));

            if (ent == null || ent->isEnemy())
                return;

            if (voted == 0)
            {
                if (!Directory.Exists(mainPath))
                    Directory.CreateDirectory(mainPath);

                string fileName = "onVote.wav";

                if (Settings.voiceEvents)
                    VoiceAudioPlayer.Play("onVote");

                voted++;
            }
            else if (!VoiceAudioPlayer.IsVoiceUsing || voted == 5)
            {
                voted = 0;
            }
            else
            {
                voted++;
            }
        }

        public delegate byte AcceptMatchDlg(ref byte[] skip);

        public static void AutoAccept(string sound)
        {
            if (!Settings.autoAccept)
                return;

            if (sound != "UIPanorama.popup_accept_match_beep")
                return;

            var fnPtr = Memory.FindPattern("client.dll",
                "55 8B EC 83 E4 F8 8B 4D 08 BA ? ? ? ? E8 ? ? ? ? 85 C0 75 12");
            var fn = Memory.GetFunction<AcceptMatchDlg>(fnPtr);

            byte[] temp = {0x0, 0x0};
            fn(ref temp);
        }

        public static void RankReveal(CUserCmd* cmd)
        {
            if (!Settings.rankReveal)
                return;

            if ((cmd->m_iButtons & (int) EButtonState.IN_SCORE) != 0)
                SDK.Client.DispatchUserMessage(50, 0, 0, 0);
        }

        public unsafe static void ConsolePrint(string baseString)
        {
            byte[] imageBytes = Convert.FromBase64String(baseString);
            Image img = Image.FromStream(new MemoryStream(imageBytes));
            Bitmap bitmap = new Bitmap(img, new Size(128, (int) Math.Ceiling(img.Height / (float) img.Width * 128)));

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    ByteColor pixel = new ByteColor(bitmap.GetPixel(j, i));
                    Tier.ConColorMsg(&pixel, Settings.printChars);
                }

                Tier.ConMsg("\n");
            }
        }

        public unsafe static void StartMessage()
        {
            string[] source =
            {
                @"    ___          _               _____       ______                         ",
                @"   /   |  ____  (_)___ ___  ___ / ___/____  / __/ /__      ______ _________ ",
                @"  / /| | / __ \/ / __ `__ \/ _ \\__ \/ __ \/ /_/ __/ | /| / / __ `/ ___/ _ \",
                @" / ___ |/ / / / / / / / / /  __/__/ / /_/ / __/ /_ | |/ |/ / /_/ / /  /  __/",
                @"/_/  |_/_/ /_/_/_/ /_/ /_/\___/____/\____/_/  \__/ |__/|__/\__,_/_/   \___/ ",
                @"                                                                            "
            };
            ByteColor[] source_colors =
            {
                new ByteColor(Color.FromArgb(248, 240, 250)),
                new ByteColor(Color.FromArgb(243, 232, 247)),
                new ByteColor(Color.FromArgb(239, 223, 244)),
                new ByteColor(Color.FromArgb(235, 215, 241)),
                new ByteColor(Color.FromArgb(231, 208, 239)),
                new ByteColor(Color.FromArgb(231, 208, 239)),
            };
            for (int i = 0; i < source.Length; i++)
            {
                fixed (ByteColor* color = &source_colors[i])
                {
                    int length = source[i].Length;
                    int margin = (128 - length) / 2 - 1;
                    Tier.ConColorMsg(color,
                        Settings.printChars + new string(' ', margin) + source[i] +
                        new string(' ', 128 - margin - length - 2) + Settings.printChars + "\n");
                }
            }

            fixed (ByteColor* color = &source_colors[source_colors.Length - 1])
                Tier.ConColorMsg(color, new string('@', 128) + "\n");
        }

        private static bool _rasprijkaLastTime = false;

        public static void Rasprijka(CUserCmd* cmd)
        {
            if (!Settings.rasprijka)
                return;

            var onGround = SDK.g_LocalPlayer()->OnGround();

            if ((!SDK.g_LocalPlayer()->IsAlive() || (_rasprijkaLastTime && onGround)) && VoiceAudioPlayer.IsVoiceUsing)
            {
                VoiceAudioPlayer.Stop();
            }
            else if (!VoiceAudioPlayer.IsVoiceUsing && !onGround)
            {
                VoiceAudioPlayer.Play("rasprijka");
            }

            _rasprijkaLastTime = onGround;
        }
    }
}