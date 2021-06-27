using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IMoveHelper : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetHostDlg(IntPtr ptr, Entity* host);

        public SetHostDlg _SetHost;
        
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void ProcessImpactsDlg(IntPtr ptr);

        public ProcessImpactsDlg _ProcessImpacts;

        public IMoveHelper(IntPtr Address) : base(Address)
        {
            _ProcessImpacts = GetInterfaceFunction<ProcessImpactsDlg>(4);
            _SetHost = GetInterfaceFunction<SetHostDlg>(1);
        }

        public void ProcessImpacts()
        {
            _ProcessImpacts(Address);
        }
        
        public void SetHost(Entity* host)
        {
            _SetHost(Address, host);
        }
    }
}