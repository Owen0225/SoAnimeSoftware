using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CInput
    {
        fixed byte pad1[173];
        byte _isCameraInThirdPerson;
        fixed byte pad2[2];
        public Vector cameraOffset;

        public bool isCameraInThirdPerson
        {
            get { return _isCameraInThirdPerson != 0; }
            set { _isCameraInThirdPerson = value ? (byte) 1 : (byte) 0; }
        }
    }
}