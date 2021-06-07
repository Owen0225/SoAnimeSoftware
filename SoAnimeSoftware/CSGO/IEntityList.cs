using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IEntityList : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Entity* GetEntityDlg(IntPtr ptr, int index);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Entity* GetEntityFromHandleDlg(IntPtr ptr, int handle);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int GetHighestEntityIndexDlg(IntPtr ptr);


        public GetEntityDlg _GetEntity;
        public GetEntityFromHandleDlg _GetEntityFromHandle;
        public GetHighestEntityIndexDlg _GetHighestEntityIndex;

        public IEntityList(IntPtr Address) : base(Address)
        {
            _GetEntity = GetInterfaceFunction<GetEntityDlg>(3);
            _GetEntityFromHandle = GetInterfaceFunction<GetEntityFromHandleDlg>(4);
            _GetHighestEntityIndex = GetInterfaceFunction<GetHighestEntityIndexDlg>(6);
        }

        public Entity* GetEntityByIndex(int index)
        {
            return _GetEntity(this.Address, index);
        }

        public Entity* GetEntityFromHandle(int handle)
        {
            return _GetEntityFromHandle(this.Address, handle);
        }

        public int GetHighestEntityIndex()
        {
            return _GetHighestEntityIndex(this.Address);
        }
    }
}