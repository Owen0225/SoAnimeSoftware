using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO
{
    public abstract class InterfaceBase
    {
        public IntPtr Address;

        public InterfaceBase(IntPtr Address)
        {
            this.Address = Address;
        }

        internal T GetInterfaceFunction<T>(int index)
        {
            IntPtr result = Memory.ReadPointer(Memory.ReadPointer(Address) + index * 4);
            return Memory.GetFunction<T>(result);
        }

        internal IntPtr GetInterfaceFunctionAddress<T>(int index)
        {
            return Memory.ReadPointer(Memory.ReadPointer(Address) + index * 4);
        }

        internal RawHook<T> HookFunction<T>(int index, T hkFn) where T : Delegate
        {
            return new RawHook<T>(Memory.ReadPointer(Address) + index * 4, hkFn);
        }

        internal RawHook<T> HookFunction<T>(int index, byte[] shellcode, T hkFn) where T : Delegate
        {
            return new RawHook<T>(Memory.ReadPointer(Address) + index * 4, shellcode, hkFn);
        }

        internal RawHook<T> HookFunction<T>(int index, IntPtr hkFnPtr) where T : Delegate
        {
            return new RawHook<T>(Memory.ReadPointer(Address) + index * 4, hkFnPtr);
        }

        internal RawHook<T> HookFunction<T>(int index, byte[] shellcode, IntPtr hkFnPtr) where T : Delegate
        {
            return new RawHook<T>(Memory.ReadPointer(Address) + index * 4, shellcode, hkFnPtr);
        }
    }
}