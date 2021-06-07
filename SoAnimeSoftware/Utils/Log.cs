using System;
using System.Linq;

namespace SoAnimeSoftware.Utils
{
    class Log
    {
        public static void Error(params object[] args)
        {
            Console.WriteLine(
                $"[{DateTime.Now.ToString()}] [Error] {string.Join(" ", args.Select(x => x.ToString()))}");
        }

        public static void Info(params object[] args)
        {
            Console.WriteLine($"[{DateTime.Now.ToString()}] [Info] {string.Join(" ", args.Select(x => x.ToString()))}");
        }

        public static void Debug(params object[] args)
        {
            if (!Settings.debugMode)
                return;
            Console.WriteLine(
                $"[{DateTime.Now.ToString()}] [Debug] {string.Join(" ", args.Select(x => x.GetType().Equals(typeof(IntPtr)) ? ((IntPtr) x).ToString("X") : x.ToString()))}");
        }

        public static void HandleAllExceptions()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                if (args.ExceptionObject is Exception exception)
                    Log.Error(exception.ToString());
            };
        }
    }
}