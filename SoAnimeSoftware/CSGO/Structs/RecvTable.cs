using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct RecvTable
    {
        public RecvProp* m_pProps;
        public int m_nProps;
        public IntPtr m_pDecoder;
        public Char_t* m_pNetTableName;
        public byte m_bInitialized;
        public byte m_bInMainList;
    }
}