using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Hyper_Useful_Injector.Properties;

namespace Hyper_Useful_Injector
{
    class Injector
    {
        static Random rnd = new Random();
        public static bool Inject(Process process, string path, string mainMethod = null)
        {
            if (process.ProcessName == "csgo")
                LdrBypass(process);

            var newPath = path;

            if (Settings.Default.doCopy)
            {
                newPath = Path.Combine(Path.GetTempPath(), "temp_" + rnd.Next(1000000, 9999999).ToString() + ".dll");
                File.Copy(path, newPath);
            }

            var injectedLibPtr = process.LoadLibrary(newPath);

            if (mainMethod != null)
            {
                var lib = WinAPI.LoadLibrary(newPath);
                var ptr = WinAPI.GetProcAddress(lib, mainMethod);

                var diff = IntPtr.Subtract(ptr, (int)lib);

                process.CallAsync(IntPtr.Add(injectedLibPtr, (int)diff), IntPtr.Zero);
            }
            return true;
        }

        public static void LdrBypass(Process process)
        {
            var address = process.FindPattern(process.MainModule.ModuleName, "1B F6 45 0C 20") - 1;
            process.Write(address, new byte[] { (byte)(process.Read(address, 1)[0] == 0x74 ? 0xEB : 0xEB) });

            address = process.FindPattern("client.dll", "69 6A ? 6A 04") - 1;
            process.Write(address, new byte[] { (byte)(process.Read(address, 1)[0] == 0x74 ? 0xEB : 0xEB) });
        }
    }
}
