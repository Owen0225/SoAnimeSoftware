using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct RecvProp
    {
        public Char_t* m_pVarName;
        public int m_RecvType;
        public int m_Flags;
        public int m_StringBufferSize;
        public int m_bInsideArray;
        public IntPtr m_pExtraData;
        public RecvProp* m_pArrayProp;
        public IntPtr m_ArrayLengthProxy;
        public IntPtr m_ProxyFn; // 8
        public IntPtr m_DataTableProxyFn;
        public RecvTable* m_pDataTable;
        public int m_Offset;
        public int m_ElementStride;
        public int m_nElements;
        public Char_t* m_pParentArrayPropName;
    }
}