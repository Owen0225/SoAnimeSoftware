using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    unsafe public class IModelInfo : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate StudioHdr* GetStudioHdrDlg(IntPtr ptr, MStudioModel* model);

        public GetStudioHdrDlg _GetStudioHdr;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetModelIndexDlg(IntPtr ptr, string name);

        public GetModelIndexDlg _GetModelIndex;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate MStudioModel* GetModelDlg(IntPtr ptr, int index);

        public GetModelDlg _GetModel;

        public IModelInfo(IntPtr Address) : base(Address)
        {
            _GetStudioHdr = GetInterfaceFunction<GetStudioHdrDlg>(32);
            _GetModelIndex = GetInterfaceFunction<GetModelIndexDlg>(2);
            _GetModel = GetInterfaceFunction<GetModelDlg>(1);
        }

        public StudioHdr* GetStudioHdr(MStudioModel* model)
        {
            return _GetStudioHdr(Address, model);
        }

        public int GetModelIndex(string name)
        {
            return _GetModelIndex(Address, name);
        }

        public MStudioModel* GetModel(int index)
        {
            return _GetModel(Address, index);
        }
    }
}