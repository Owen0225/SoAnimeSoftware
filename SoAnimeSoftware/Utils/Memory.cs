using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SoAnimeSoftware.Utils
{
    public static unsafe class Memory
    {
        public static IntPtr ReadPointer(IntPtr address)
        {
            return *(IntPtr*) address;
        }

        public static byte[] ReadBytes(IntPtr address, int length)
        {
            byte[] buff = new byte[length];
            Marshal.Copy(address, buff, 0, length);
            return buff;
        }

        public static void WriteBytes(IntPtr address, byte[] bytes)
        {
            Marshal.Copy(bytes, 0, address, bytes.Length);
        }

        public static void Write<T>(IntPtr address, T value)
        {
            int length = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[length];

            IntPtr ptr = Marshal.AllocHGlobal(length);
            Marshal.StructureToPtr(value, ptr, true);
            Marshal.Copy(ptr, buffer, 0, length);
            Marshal.FreeHGlobal(ptr);

            Memory.WriteBytes(address, buffer);
        }

        public static T GetFunction<T>(IntPtr address)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(address);
        }

        public static T GetVTableFunction<T>(IntPtr address, int index)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(
                Memory.ReadPointer(Memory.ReadPointer(address) + index * 4));
        }

        public static T GetFunctionFromModule<T>(string moduleName, string funcName)
        {
            return GetFunction<T>(WinApi.GetProcAddress(WinApi.GetModuleHandle(moduleName), funcName));
        }

        public static IntPtr SetVTableFunction<T>(IntPtr address, int index, T func) where T : Delegate
        {
            IntPtr adr = ReadPointer(address) + index * 4;
            var originalFunc = Memory.ReadPointer(adr);
            WinApi.VirtualProtect(adr, 4, (int) WinApi.Protection.PAGE_EXECUTE_READWRITE, out int skip);
            Marshal.WriteIntPtr(adr, Marshal.GetFunctionPointerForDelegate(func));
            return originalFunc;
        }

        public static IntPtr SetVTableFunction(IntPtr address, int index, IntPtr funcPtr)
        {
            IntPtr adr = ReadPointer(address) + index * 4;
            var originalFunc = Memory.ReadPointer(adr);
            WinApi.VirtualProtect(adr, 4, (int) WinApi.Protection.PAGE_EXECUTE_READWRITE, out int skip);
            Marshal.WriteIntPtr(adr, funcPtr);
            return originalFunc;
        }

        public static unsafe IntPtr FindPattern(IntPtr start, int length, string signature)
        {
            int[] pattern = SignatureToPattern(signature);
            for (int i = start.ToInt32(); i < start.ToInt32() + length; i++)
            {
                byte b = *(byte*) i;
                if (b == pattern[0])
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        b = *(byte*) (i + j);
                        if (b == pattern[j] || pattern[j] == -1)
                        {
                            if (j == pattern.Length - 1)
                            {
                                return (IntPtr) i;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return IntPtr.Zero;
        }

        public static IntPtr FindPattern(string moduleName, string signature)
        {
            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                if (module.ModuleName == moduleName)
                {
                    return FindPattern(module.BaseAddress, module.ModuleMemorySize, signature);
                }
            }

            return IntPtr.Zero;
        }

        public static int[] SignatureToPattern(string signature)
        {
            List<int> temp = new List<int>();

            foreach (string s in signature.Split())
            {
                if (s.Contains("?"))
                {
                    temp.Add(-1);
                    continue;
                }

                temp.Add(Convert.ToInt32(s, 16));
            }

            return temp.ToArray();
        }

        public static IntPtr Dereference(IntPtr address, int offset)
        {
            return address + (*(int*) (address + offset) + offset + sizeof(int));
        }
    }
}