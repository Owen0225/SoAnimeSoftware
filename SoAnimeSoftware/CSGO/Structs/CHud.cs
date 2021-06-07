using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Hack;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CHud
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr FindHudElementDlg(IntPtr ptr, byte[] name);

        public IntPtr FindHudElement(string name)
        {
            fixed (CHud* ptr = &this)
            {
                IntPtr result =
                    (Marshal.GetDelegateForFunctionPointer<FindHudElementDlg>(Offsets.FindHudElementFnPointer)(
                        (IntPtr) ptr, Encoding.UTF8.GetBytes(name)));
                return result;
            }
        }
    }

    public unsafe struct CHudWeapon
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int ClearHudWeaponDlg(IntPtr ptr, int index);

        public int ClearHudWeapon(int index)
        {
            fixed (CHudWeapon* ptr = &this)
                return Marshal.GetDelegateForFunctionPointer<ClearHudWeaponDlg>(Offsets.ClearHudWeaponFnPointer)(
                    (IntPtr) ptr, index);
        }
    }

    public unsafe struct CHudChat
    {
        public delegate void PrintDlg(CHudChat* ptr, int* edx, int entityid, int filter, byte[] msg);

        public void Notify(string msg)
        {
            Print(' ', ChatColor.Gray, "SoAnimeSoftware +", ChatColor.Purple, '|', ' ',
                ChatColor.White, msg);
        }

        public void Print(params object[] msg)
        {
            int edx = 256;
            fixed (CHudChat* ptr = &this)
            {
                byte[] buffer = new byte[1024];
                var result = ParseMsg(msg);

                PrintDlg fn = Memory.GetVTableFunction<PrintDlg>((IntPtr) ptr, 28);
                fn(ptr, &edx, 0, 0, result);
            }
        }

        public byte[] ParseMsg(params object[] msg)
        {
            byte[] result = new byte[1024];
            int max = 1023;
            int current = 0;
            foreach (object obj in msg)
            {
                switch (obj)
                {
                    case string s:
                        if (current + s.Length >= max)
                            break;

                        byte[] temp = Encoding.UTF8.GetBytes(s);
                        for (int i = 0; i < temp.Length; i++)
                        {
                            result[current] = temp[i];
                            current++;
                        }

                        break;
                    case byte[] bar:
                        for (int i = 0; i < bar.Length; i++)
                        {
                            if (current + i >= max)
                                break;
                            result[current + i] = bar[i];
                            current++;
                        }

                        break;
                    case byte b:
                        if (current + 1 >= max)
                            break;

                        result[current] = b;
                        current++;
                        break;
                    case object o:
                        string so = obj.ToString();
                        if (current + so.Length >= max)
                            break;

                        byte[] tempo = Encoding.UTF8.GetBytes(so);
                        for (int i = 0; i < tempo.Length; i++)
                        {
                            result[current] = tempo[i];
                            current++;
                        }

                        break;
                }
            }

            return result;
        }
    }

    public struct ChatColor
    {
        public static string White = "\x01";
        public static string Red = "\x02";
        public static string Purple = "\x03";
        public static string LightGreen = "\x04";
        public static string DarkGreen = "\x05";
        public static string Green = "\x06";
        public static string LightRed = "\x07";
        public static string Gray = "\x08";
        public static string Yellow = "\x09";
        public static string LightBlue = "\x0A";
        public static string Blue = "\x0C";
        public static string Orange = "\x10";
    }
}