using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware;

namespace SoAnimeSoftware.CSGO
{
    public class ITier
    {
        public delegate IntPtr ConMsgDlg(string msg, params string[] args);
        public delegate IntPtr ConColorMsgDlg(byte[] color, string msg, params string[] args);
        public delegate IntPtr DevMsgDlg(string msg, params string[] args);

        public ConMsgDlg ConMsg;
        public ConColorMsgDlg ConColorMsg;
        public DevMsgDlg DevMsg;

        public ITier()
        {
            ConMsg = Memory.GetFunction<ConMsgDlg>(WinAPI.GetProcAddress(WinAPI.GetModuleHandle("tier0.dll"), "?ConMsg@@YAXPBDZZ"));
            ConColorMsg = Memory.GetFunction<ConColorMsgDlg>(WinAPI.GetProcAddress(WinAPI.GetModuleHandle("tier0.dll"), "?ConColorMsg@@YAXABVColor@@PBDZZ"));
            DevMsg = Memory.GetFunction<DevMsgDlg>(WinAPI.GetProcAddress(WinAPI.GetModuleHandle("tier0.dll"), "?DevMsg@@YAXPBDZZ"));
        }
    }
}
