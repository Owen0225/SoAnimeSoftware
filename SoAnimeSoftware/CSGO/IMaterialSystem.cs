using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class IMaterialSystem : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate CMaterial* CreateMaterialDlg(IntPtr ptr, byte[] materialName, KeyValue* keyValues);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate short FirstMaterialDlg(IntPtr ptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate short NextMaterialDlg(IntPtr ptr, short prevHandle);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate short InvalidMaterialDlg(IntPtr ptr);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate CMaterial* GetMaterialDlg(IntPtr ptr, short handle);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate CMaterial* FindMaterialDlg(IntPtr ptr, string name, string group);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate IntPtr FindDlg(IntPtr ptr);

        public CreateMaterialDlg _CreateMaterial;
        public FirstMaterialDlg _FirstMaterial;
        public NextMaterialDlg _NextMaterial;
        public InvalidMaterialDlg _InvalidMaterial;
        public GetMaterialDlg _GetMaterial;
        public FindMaterialDlg _FindMaterial;
        public FindDlg _Find;

        public IMaterialSystem(IntPtr Address) : base(Address)
        {
            _CreateMaterial = GetInterfaceFunction<CreateMaterialDlg>(83);
            _FirstMaterial = GetInterfaceFunction<FirstMaterialDlg>(86);
            _NextMaterial = GetInterfaceFunction<NextMaterialDlg>(87);
            _InvalidMaterial = GetInterfaceFunction<InvalidMaterialDlg>(88);
            _GetMaterial = GetInterfaceFunction<GetMaterialDlg>(89);
            _FindMaterial = GetInterfaceFunction<FindMaterialDlg>(84);
            _Find = GetInterfaceFunction<FindDlg>(152);
        }

        public CMaterial* CreateMaterial(string materialName, KeyValue* keyValues)
        {
            return _CreateMaterial(Address, Encoding.UTF8.GetBytes(materialName), keyValues);
        }

        public CMaterial* CreateCustomMaterial(string type, string buff)
        {
            KeyValue* kv = (KeyValue*) Marshal.AllocHGlobal(36);
            kv->Init(type);
            string name = DateTime.Now.Ticks.ToString().Substring(0, 16);
            kv->Load(name, buff);
            CMaterial* mat = SDK.MaterialSystem.CreateMaterial(name, kv);
            mat->IncrementReferenceCount();

            return mat;
        }

        public short FirstMaterial()
        {
            return _FirstMaterial(this.Address);
        }

        public short NextMaterial(short prevHandle)
        {
            return _NextMaterial(this.Address, prevHandle);
        }

        public short InvalidMaterial()
        {
            return _InvalidMaterial(this.Address);
        }

        public CMaterial* GetMaterial(short handle)
        {
            return _GetMaterial(this.Address, handle);
        }

        public CMaterial* FindMaterial(string name)
        {
            return _FindMaterial(this.Address, name, null);
        }
    }
}