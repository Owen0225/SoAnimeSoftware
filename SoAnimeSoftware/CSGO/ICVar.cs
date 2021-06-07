using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class ICVar : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate CConVar* FindVarDlg(IntPtr ptr, string name);

        private readonly FindVarDlg findVar;

        public ICVar(IntPtr address) : base(address)
        {
            findVar = GetInterfaceFunction<FindVarDlg>(15);
        }

        public CConVar* FindVar(string name)
        {
            return findVar(this.Address, name);
        }

        public void Force(string name, float value, bool clearCallback = true)
        {
            var cv = SDK.CVar.FindVar(name);
            if (clearCallback)
                cv->ClearCallback();
            cv->SetValueFloat(value);
        }
        
        public void Force(string name, int value, bool clearCallback = true)
        {
            var cv = SDK.CVar.FindVar(name);
            if (clearCallback)
                cv->ClearCallback();
            cv->SetValueInt(value);
        }
        
        public void Force(string name, string value, bool clearCallback = true)
        {
            var cv = SDK.CVar.FindVar(name);
            if (clearCallback)
                cv->ClearCallback();
            cv->SetValueString(value);
        }
        
        public void Force(string name, byte[] value, bool clearCallback = true)
        {
            var cv = SDK.CVar.FindVar(name);
            if (clearCallback)
                cv->ClearCallback();
            cv->SetValueString(value);
        }
    }
}