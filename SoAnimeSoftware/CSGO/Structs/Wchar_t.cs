using System;
using System.Runtime.InteropServices;
using System.Text;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Wchar_t
    {
        public override string ToString()
        {
            int len = 0;
            fixed (Wchar_t* ptr = &this)
            {
                while (Marshal.ReadByte((IntPtr) ptr, len) != 0 && Marshal.ReadByte((IntPtr) ptr, len + 1) != 0)
                    len += 2;

                return Encoding.UTF8.GetString(Memory.ReadBytes((IntPtr) ptr, len));
            }
        }

        public bool Contains(string target)
        {
            return this.ToString().Contains(target);
        }

        public static Wchar_t* Ptr(ref byte[] source)
        {
            fixed (byte* ptr = &source[0])
                return (Wchar_t*) (ptr);
        }
    }
}