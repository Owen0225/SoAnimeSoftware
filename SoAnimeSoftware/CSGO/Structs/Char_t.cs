using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Char_t
    {
        public override string ToString()
        {
            int len = 0;
            fixed (Char_t* ptr = &this)
            {
                while (Marshal.ReadByte((IntPtr) ptr, len) != 0)
                    len++;

                return Encoding.UTF8.GetString(Memory.ReadBytes((IntPtr) ptr, len));
            }
        }

        public bool Contains(string target)
        {
            return this.ToString().Contains(target);
        }

        public static Char_t* Ptr(ref byte[] source)
        {
            fixed (byte* ptr = &source[0])
                return (Char_t*) (ptr);
        }
    }
}