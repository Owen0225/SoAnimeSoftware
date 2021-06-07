using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct GameEvent
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* GetNameDlg(GameEvent* ptr);

        public Char_t* GetName()
        {
            fixed (GameEvent* ptr = &this)
            {
                return Memory.GetVTableFunction<GetNameDlg>((IntPtr) ptr, 1)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetIntDlg(GameEvent* ptr, string keyName, int defaultValue);

        public int GetInt(string keyName, int defaultValue = 0)
        {
            fixed (GameEvent* ptr = &this)
            {
                return Memory.GetVTableFunction<GetIntDlg>((IntPtr) ptr, 6)(ptr, keyName, defaultValue);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* GetStringDlg(GameEvent* ptr, string keyName, string defaultValue = "");

        public string GetString(string keyName, string defaultValue = "")
        {
            fixed (GameEvent* ptr = &this)
            {
                return Memory.GetVTableFunction<GetStringDlg>((IntPtr) ptr, 9)(ptr, keyName, defaultValue)->ToString();
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetStringDlg(GameEvent* ptr, string keyName, string value);

        public void SetString(string keyName, string value)
        {
            fixed (GameEvent* ptr = &this)
            {
                Memory.GetVTableFunction<SetStringDlg>((IntPtr) ptr, 16)(ptr, keyName, value);
            }
        }
    }
}