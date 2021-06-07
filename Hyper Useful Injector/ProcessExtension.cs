using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Hyper_Useful_Injector.WinAPI;

namespace Hyper_Useful_Injector
{
    public static class ProcessExtensions
    {
        public static IntPtr Alloc(this Process proc, int size)
        {
            return VirtualAllocEx(proc.Handle, IntPtr.Zero, (IntPtr) size,
                AllocationType.Commit | AllocationType.Reserve,
                MemoryProtection.ExecuteReadWrite);
        }

        public static bool Free(this Process proc, IntPtr ptr)
        {
            return VirtualFreeEx(proc.Handle, ptr, 0,
                FreeType.Decommit | FreeType.Release);
        }

        public static bool Write(this Process proc, IntPtr ptr, byte[] data)
        {
            IntPtr nBytes;
            return WriteProcessMemory(proc.Handle, ptr, data,
                data.Length, out nBytes);
        }

        public static byte[] Read(this Process proc, IntPtr ptr, int size)
        {
            var data = new byte[size];
            IntPtr nBytes;
            ReadProcessMemory(proc.Handle, ptr, data, size, out nBytes);
            return data;
        }

        public static IntPtr CallAsync(this Process proc, IntPtr ptr, IntPtr arg)
        {
            IntPtr hThreadId;
            var hThread = CreateRemoteThread(proc.Handle, IntPtr.Zero, 0,
                ptr, arg, 0, out hThreadId);
            return hThread;
        }

        public static int Call(this Process proc, IntPtr ptr, IntPtr arg)
        {
            IntPtr hThreadId;
            var hThread = CreateRemoteThread(proc.Handle, IntPtr.Zero, 0, ptr, arg, 0, out hThreadId);
            WaitForSingleObject(hThread, unchecked((uint) -1));
            uint exitCode;
            GetExitCodeThread(hThread, out exitCode);
            return (int) exitCode;
        }

        public static IntPtr LoadLibrary(this Process proc, string lib)
        {
            var libData = Encoding.UTF8.GetBytes(lib);
            var ptr = proc.Alloc(libData.Length);
            proc.Write(ptr, libData);
            var addr = proc.Call(GetProcAddress(WinAPI.LoadLibrary("kernel32"), "LoadLibraryA"), ptr);
            return (IntPtr) addr;
        }

        public static ProcessModule FindModule(this Process proc, string moduleName)
        {
            foreach (ProcessModule module in proc.Modules)
            {
                if (module.ModuleName == moduleName)
                    return module;
            }

            return null;
        }

        public static IntPtr FindPattern(this Process proc, string moduleName, string signature,
            bool withModuleBase = true)
        {
            var module = proc.FindModule(moduleName);
            IntPtr moduleBase = module.BaseAddress;
            int moduleSize = module.ModuleMemorySize;
            byte[] moduleBytes = new byte[moduleSize];
            IntPtr numBytes = IntPtr.Zero;
            var pattern = SignatureToPattern(signature);

            if (ReadProcessMemory(proc.Handle, (IntPtr) moduleBase, moduleBytes, moduleSize, out numBytes))
            {
                for (int i = 0; i < moduleSize; i++)
                {
                    bool found = true;

                    for (int l = 0; l < pattern.Length; l++)
                    {
                        found = pattern[l] == -1 || moduleBytes[l + i] == pattern[l];

                        if (!found)
                            break;
                    }

                    if (found)
                        if (withModuleBase)
                            return (IntPtr) (moduleBase + i);
                        else
                            return (IntPtr) i;
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
    }

    [Flags]
    public enum FreeType
    {
        Decommit = 0x4000,
        Release = 0x8000,
    }

    [Flags]
    public enum AllocationType
    {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Reset = 0x80000,
        Physical = 0x400000,
        TopDown = 0x100000,
        WriteWatch = 0x200000,
        LargePages = 0x20000000
    }

    [Flags]
    public enum MemoryProtection
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        GuardModifierflag = 0x100,
        NoCacheModifierflag = 0x200,
        WriteCombineModifierflag = 0x400
    }
}