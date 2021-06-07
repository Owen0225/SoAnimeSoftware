using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct Matrix3x4
    {
        public float _11, _12, _13, _14;
        public float _21, _22, _23, _24;
        public float _31, _32, _33, _34;
    }

    public unsafe struct Matrix4x4
    {
        public float _11, _12, _13, _14;
        public float _21, _22, _23, _24;
        public float _31, _32, _33, _34;
        public float _41, _42, _43, _44;

        public override string ToString()
        {
            return
                $"\n{_11} {_12} {_13} {_14}\n{_21} {_22} {_23} {_24}\n{_31} {_32} {_33} {_34}\n{_41} {_42} {_43} {_44}";
        }
    }
}