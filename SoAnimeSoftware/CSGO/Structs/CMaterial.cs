using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.GUI.Elements;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CMaterial
    {
        public void SetTintColor(FloatColor color)
        {
            FinaVar("$envmaptint")->SetVecValue(color);
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* GetNameDlg(CMaterial* ptr);

        public string GetName()
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<GetNameDlg>((IntPtr) ptr, 0)(ptr)->ToString();
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate Char_t* GetTextureGroupNameDlg(CMaterial* ptr);

        public string GetTextureGroupName()
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<GetTextureGroupNameDlg>((IntPtr) ptr, 1)(ptr)->ToString();
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate CMaterialVar* FinaVarDlg(CMaterial* ptr, string name, IntPtr found, byte complain);

        public CMaterialVar* FinaVar(string name)
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<FinaVarDlg>((IntPtr) ptr, 11)(ptr, name, IntPtr.Zero, 1);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte AlphaModulateDlg(CMaterial* ptr, float alpha);

        public byte AlphaModulate(float alpha)
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<AlphaModulateDlg>((IntPtr) ptr, 27)(ptr, alpha);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte ColorModulateDlg(CMaterial* ptr, FloatColor color);

        public byte ColorModulate(FloatColor color)
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<ColorModulateDlg>((IntPtr) ptr, 28)(ptr, color);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IsPrecachedDlg(CMaterial* ptr);

        public bool IsPrecached()
        {
            fixed (CMaterial* ptr = &this)
            {
                return Memory.GetVTableFunction<IsPrecachedDlg>((IntPtr) ptr, 70)(ptr) != 0;
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte IncrementReferenceCountDlg(CMaterial* ptr);

        public void IncrementReferenceCount()
        {
            fixed (CMaterial* ptr = &this)
            {
                Memory.GetVTableFunction<IncrementReferenceCountDlg>((IntPtr) ptr, 12)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte DecrementReferenceCountDlg(CMaterial* ptr);

        public void DecrementReferenceCount()
        {
            fixed (CMaterial* ptr = &this)
            {
                Memory.GetVTableFunction<DecrementReferenceCountDlg>((IntPtr) ptr, 13)(ptr);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate byte SetMaterialVarFlagDlg(CMaterial* ptr, EMaterialVarFlag flag, byte on);

        public void SetMaterialVarFlag(EMaterialVarFlag flag, bool on)
        {
            fixed (CMaterial* ptr = &this)
            {
                Memory.GetVTableFunction<SetMaterialVarFlagDlg>((IntPtr) ptr, 29)(ptr, flag, (byte) (on ? 1 : 0));
            }
        }

        public CMaterial* Ptr()
        {
            fixed (CMaterial* ptr = &this)
                return ptr;
        }
    }
}