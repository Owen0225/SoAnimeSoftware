using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IClient : InterfaceBase
    {
        public delegate void FrameStageNotifyDlg(EFrameStage stage);

        public unsafe delegate ClientClass* GetAllClassesDlg();

        public delegate byte DispatchUserMessageDlg(int messageType, int arg, int arg1, int data);

        public delegate void CreateMoveDlg(int sequence_number, float input_sample_frametime, byte bSendPackets);

        public FrameStageNotifyDlg FrameStageNotify;
        public GetAllClassesDlg GetAllClasses;
        public DispatchUserMessageDlg DispatchUserMessage;
        public CreateMoveDlg CreateMove;

        public IClient(IntPtr Address) : base(Address)
        {
            FrameStageNotify = GetInterfaceFunction<FrameStageNotifyDlg>(37);
            GetAllClasses = GetInterfaceFunction<GetAllClassesDlg>(8);
            DispatchUserMessage = GetInterfaceFunction<DispatchUserMessageDlg>(38);
            CreateMove = GetInterfaceFunction<CreateMoveDlg>(22);
        }
    }
}