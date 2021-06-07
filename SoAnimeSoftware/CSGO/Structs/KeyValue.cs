using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.Hack;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct KeyValue
    {
        public fixed byte size[36];

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void InitDlg(KeyValue* ptr, byte[] name);

        public void Init(string name)
        {
            fixed (KeyValue* ptr = &this)
            {
                Marshal.GetDelegateForFunctionPointer<InitDlg>(Offsets.KeyValueInit)(ptr, Encoding.UTF8.GetBytes(name));
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void LoadDlg(KeyValue* thisptr, byte[] resourceName, byte[] pBuffer, IntPtr pFileSystem,
            IntPtr pPathID, IntPtr pfnEvaluateSymbolProc, int unk);

        public void Load(string resourceName, string pBuffer, int pFileSystem = 0, int pPathID = 0,
            int pfnEvaluateSymbolProc = 0, int unk = 0)
        {
            fixed (KeyValue* ptr = &this)
            {
                Marshal.GetDelegateForFunctionPointer<LoadDlg>(Offsets.KeyValueLoad)(ptr,
                    Encoding.UTF8.GetBytes(resourceName), Encoding.UTF8.GetBytes(pBuffer), (IntPtr) pFileSystem,
                    (IntPtr) pPathID, (IntPtr) pfnEvaluateSymbolProc, unk);
                ;
            }
        }
    }
}