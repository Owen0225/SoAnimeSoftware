using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO
{
    public static class Tier
    {
        public delegate IntPtr ConMsgDlg(string msg, params string[] args);

        public unsafe delegate IntPtr ConColorMsgDlg(ByteColor* color, string msg, params string[] args);

        public delegate IntPtr DevMsgDlg(string msg, params string[] args);

        static public ConMsgDlg ConMsg;
        static public ConColorMsgDlg ConColorMsg;
        static public DevMsgDlg DevMsg;

        public static void Init()
        {
            ConMsg = Memory.GetFunctionFromModule<ConMsgDlg>("tier0.dll", "?ConMsg@@YAXPBDZZ");
            ConColorMsg = Memory.GetFunctionFromModule<ConColorMsgDlg>("tier0.dll", "?ConColorMsg@@YAXABVColor@@PBDZZ");
            DevMsg = Memory.GetFunctionFromModule<DevMsgDlg>("tier0.dll", "?DevMsg@@YAXPBDZZ");
        }
    }
}