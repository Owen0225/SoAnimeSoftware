using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO
{
    public unsafe struct NetworkChannel
    {
        fixed byte pad[44];
        public int chokedPackets;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate float GetLatencyDlg(NetworkChannel* ptr, int flow);

        public float GetLatency(int flow)
        {
            fixed (NetworkChannel* ptr = &this)
            {
                return Memory.GetVTableFunction<GetLatencyDlg>((IntPtr) ptr, 9)(ptr, flow);
            }
        }
    }

    public unsafe class IEngine : InterfaceBase
    {
        public delegate byte GetPlayerInfoDlg(int index, ref PlayerInfo info);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetPlayerByUserIDDlg(IntPtr ptr, int userId);

        public delegate int GetLocalPlayerDlg();

        public delegate void ClientCmd_UnrestrictedDlg(byte[] text, int flags);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void GetViewAnglesDlg(IntPtr address, ref Vector qangle);

        public delegate void SetViewAngleDlg(ref Vector qangle);

        public delegate int GetMaxClientsDlg();

        public delegate byte IsInGameDlg();

        public delegate Matrix4x4* WorldToScreenMatrixDlg();

        public delegate byte IsConnectedDlg();

        public delegate Char_t* GetLevelNameDlg();

        public delegate NetworkChannel* GetNetworkChannelDlg();

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetClanTagDlg(byte[] a, byte[] b);


        public GetPlayerInfoDlg GetPlayerInfo;
        public GetPlayerByUserIDDlg GetPlayerByUserID;
        public GetLocalPlayerDlg GetLocalPlayer;
        public GetViewAnglesDlg _GetViewAngles;
        public SetViewAngleDlg SetViewAngles;
        public GetMaxClientsDlg GetMaxClients;
        public IsInGameDlg _IsInGame;
        public IsConnectedDlg _IsConnected;
        public WorldToScreenMatrixDlg WorldToScreenMatrix;
        public ClientCmd_UnrestrictedDlg _ClientCmd_Unrestricted;
        public GetNetworkChannelDlg GetNetworkChannel;
        public GetLevelNameDlg GetLevelName;
        public SetClanTagDlg _SetClanTag;


        public IEngine(IntPtr Address) : base(Address)
        {
            GetPlayerInfo = GetInterfaceFunction<GetPlayerInfoDlg>(8);
            GetPlayerByUserID = GetInterfaceFunction<GetPlayerByUserIDDlg>(9);
            GetLocalPlayer = GetInterfaceFunction<GetLocalPlayerDlg>(12);
            _GetViewAngles = GetInterfaceFunction<GetViewAnglesDlg>(18);
            SetViewAngles = GetInterfaceFunction<SetViewAngleDlg>(19);
            GetMaxClients = GetInterfaceFunction<GetMaxClientsDlg>(20);
            _IsInGame = GetInterfaceFunction<IsInGameDlg>(26);
            _IsConnected = GetInterfaceFunction<IsConnectedDlg>(27);
            WorldToScreenMatrix = GetInterfaceFunction<WorldToScreenMatrixDlg>(37);
            _ClientCmd_Unrestricted = GetInterfaceFunction<ClientCmd_UnrestrictedDlg>(114);
            GetLevelName = GetInterfaceFunction<GetLevelNameDlg>(52);
            GetNetworkChannel = GetInterfaceFunction<GetNetworkChannelDlg>(78);
        }

        public void GetViewAngles(ref Vector angle)
        {
            _GetViewAngles(Address, ref angle);
        }

        public void ClientCmd_Unrestricted(string txt, int flag = 0)
        {
            _ClientCmd_Unrestricted(Encoding.UTF8.GetBytes(txt), flag);
        }

        public void SetClanTag(string tag)
        {
            var buffer = Encoding.UTF8.GetBytes(tag);
            _SetClanTag(buffer, buffer);
        }

        public bool IsInGame()
        {
            return _IsInGame() != 0;
        }

        public bool IsConnected()
        {
            return _IsConnected() != 0;
        }

        public Entity* GetEntityByUserID(int userid)
        {
            return SDK.EntityList.GetEntityByIndex(GetPlayerByUserID(Address, userid));
        }
    }
}