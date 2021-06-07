using System;
using System.Runtime.InteropServices;
using System.Threading;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using SoAnimeSoftware.Utils;
using System.Text;
using System.IO;
using System.Linq;
using SoAnimeSoftware.GUI;
using System.Runtime;
using System.Threading.Tasks;
using DiscordRPC;
using SoAnimeSoftware.Hack;
using SoAnimeSoftware.Hack.Visuals;
using SoAnimeSoftware.Hack.Misc;
using SoAnimeSoftware.Hack.Misc.MovementRecorder;
using SoAnimeSoftware.Objects;

namespace SoAnimeSoftware
{
    internal static class Main
    {
        public static void FormInit()
        {
            Application.EnableVisualStyles();
            Application.Run(new NotSoDX());
        }


        [DllExport("Init")]
        public static void Init()
        {
            unsafe
            {
                AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
                {
                    try
                    {
                        if (args.Name.Contains("Discord"))
                        {
                            Log.Debug("Discord loaded");
                            return Assembly.Load(Properties.Assemblies.DiscordRPC);
                        }

                        if (args.Name.Contains("Json"))
                        {
                            Log.Debug("Json loaded");
                            return Assembly.Load(Properties.Assemblies.Newtonsoft_Json);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.ToString());
                    }

                    return null;
                };

                IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;

                DebugHelper.ShowConsoleWindow();

                SDK.Init();

                Render.Init();
                Hack.Combat.Backtrack.Init();
                Hack.Visuals.Chams.Init();
                TargetList.ClearTargets();
                MovementManager.Replays.Refresh();
                
                SDK.Engine.ClientCmd_Unrestricted("clear", 0);

                Hooks.Init();

                Thread formLoad = new Thread(FormInit)
                {
                    IsBackground = true
                };
                formLoad.Start();

                Thread.Sleep(50);

                Hack.Misc.Other.ConsolePrint(Settings.startImage);
                Hack.Misc.Other.StartMessage();
            }
        }
    }
}