using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct ClientClass
    {
        public IntPtr m_pCreateFn;
        public IntPtr m_pCreateEventFn;
        public Char_t* m_pNetworkName;
        public RecvTable* m_pRecvTable;
        public ClientClass* m_pNext;
        public int m_ClassID;
    }
}