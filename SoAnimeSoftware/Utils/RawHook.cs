using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace SoAnimeSoftware.Utils
{
    public unsafe class RawHook<T> where T : Delegate
    {
        private readonly IntPtr target;
        private readonly IntPtr oFnPtr;
        private readonly IntPtr hkFnPtr;
        private readonly T oFn;
        private readonly T hkFn;
        private readonly IntPtr asmBlock;
        private bool hooked;
        public bool IsHooked => hooked;
        public T O => oFn;

        public IntPtr OFnPtr => oFnPtr;

        public RawHook(IntPtr target, T hk)
        {
            this.target = target;

            oFnPtr = Memory.ReadPointer(target);
            oFn = Marshal.GetDelegateForFunctionPointer<T>(oFnPtr);
            hkFn = hk;
            hkFnPtr = Marshal.GetFunctionPointerForDelegate(hkFn);
        }

        public RawHook(IntPtr target, IntPtr hkPtr) : this(target, Marshal.GetDelegateForFunctionPointer<T>(hkPtr))
        {
        }

        public RawHook(IntPtr target, byte[] shellcode, T hk) : this(target, hk)
        {
            shellcode = shellcode.Concat(new byte[] {0xe9, 0x00, 0x00, 0x00, 0x00}).ToArray(); // jmp ptr
            fixed (byte* ptr = shellcode)
            {
                asmBlock = Marshal.AllocHGlobal(shellcode.Length);

                var rel = (int) hkFnPtr - ((int) asmBlock + shellcode.Length - 5) - 5;
                var jmp = BitConverter.GetBytes(rel);

                shellcode[shellcode.Length - 4] = jmp[0];
                shellcode[shellcode.Length - 3] = jmp[1];
                shellcode[shellcode.Length - 2] = jmp[2];
                shellcode[shellcode.Length - 1] = jmp[3];

                WinApi.VirtualProtect(asmBlock, shellcode.Length, 0x40, out _);
                Memory.WriteBytes(asmBlock, shellcode);
            }
        }

        public RawHook(IntPtr target, byte[] shellcode, IntPtr hkPtr) : this(target, shellcode,
            Marshal.GetDelegateForFunctionPointer<T>(hkPtr))
        {
        }


        public static RawHook<T> InVTable(IntPtr classPtr, int index, T hk)
        {
            return new RawHook<T>(Memory.ReadPointer(classPtr) + 4 * index, hk);
        }

        public static RawHook<T> InVTable(IntPtr classPtr, int index, byte[] shellcode, T hk)
        {
            return new RawHook<T>(Memory.ReadPointer(classPtr) + 4 * index, shellcode, hk);
        }

        public static RawHook<T> InVTable(IntPtr classPtr, int index, IntPtr hkPtr)
        {
            return new RawHook<T>(Memory.ReadPointer(classPtr) + 4 * index, hkPtr);
        }

        public static RawHook<T> InVTable(IntPtr classPtr, int index, byte[] shellcode, IntPtr hkPtr)
        {
            return new RawHook<T>(Memory.ReadPointer(classPtr) + 4 * index, shellcode, hkPtr);
        }

        public void Hook()
        {
            if (hooked)
                return;
            WinApi.VirtualProtect(target, 4, (int) WinApi.Protection.PAGE_EXECUTE_READWRITE, out int skip);

            if (asmBlock != IntPtr.Zero)
                Marshal.WriteIntPtr(target, asmBlock);
            else
                Marshal.WriteIntPtr(target, hkFnPtr);
            WinApi.VirtualProtect(target, 4, skip, out skip);
            hooked = true;
        }

        public void Unhook(bool clearAsmBlock = false)
        {
            if (!hooked)
                return;

            if (oFnPtr == IntPtr.Zero || target == IntPtr.Zero)
                return;

            if (clearAsmBlock && asmBlock != IntPtr.Zero)
                Marshal.FreeHGlobal(asmBlock);

            WinApi.VirtualProtect(target, 4, (int) WinApi.Protection.PAGE_EXECUTE_READWRITE, out int skip);
            Marshal.WriteIntPtr(target, oFnPtr);
            WinApi.VirtualProtect(target, 4, skip, out skip);
            hooked = false;
        }
    }
}