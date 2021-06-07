using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    unsafe public struct MStudioBBox
    {
        public int bone;
        public int group;
        public Vector bbmin;
        public Vector bbmax;
        public int szhitboxnameindex;
        public Vector offsetOrientation;
        public float m_flRadius;
        public fixed int m_iPad02[4];
    }

    unsafe public struct MStudioHitboxSet
    {
        public int sznameindex;
        public int numhitboxes;
        public int hitboxindex;

        public string GetName()
        {
            fixed (MStudioHitboxSet* ptr = &this)
            {
                if (sznameindex == 0) return null;
                return ((Char_t*) ((uint) ptr + sznameindex))->ToString();
            }
        }

        public MStudioBBox* GetHitbox(int i)
        {
            if (i > numhitboxes) return null;
            fixed (MStudioHitboxSet* ptr = &this)
                return (MStudioBBox*) ((uint) ptr + hitboxindex) + i * sizeof(MStudioBBox);
        }
    }

    public unsafe struct StudioHdr
    {
        public int id; //0x0000
        public int version; //0x0004
        public int checksum; //0x0008
        public fixed byte szName[64]; //0x000C
        public int length; //0x004C
        public Vector vecEyePos; //0x0050
        public Vector vecIllumPos; //0x005C
        public Vector vecHullMin; //0x0068
        public Vector vecHullMax; //0x0074
        public Vector vecBBMin; //0x0080
        public Vector vecBBMax; //0x008C
        public int flags; //0x0098
        public int numbones; //0x009C
        public int boneindex; //0x00A0
        public int numbonecontrollers; //0x00A4
        public int bonecontrollerindex; //0x00A8
        public int numhitboxsets; //0x00AC
        public int hitboxsetindex; //0x00B0
        public int numlocalanim; //0x00B4
        public int localanimindex; //0x00B8
        public int numlocalseq; //0x00BC
        public int localseqindex; //0x00C0
        public int activitylistversion; //0x00C4
        public int eventsindexed; //0x00C8
        public int numtextures; //0x00CC
        public int textureindex; //0x00D0

        public MStudioHitboxSet* GetHitboxSet(int i)
        {
            if (i > numhitboxsets) return null;
            fixed (StudioHdr* ptr = &this)
                return (MStudioHitboxSet*) ((uint) ptr + hitboxsetindex) + i * sizeof(MStudioHitboxSet);
        }

        public MStudioBone* GetBone(int i)
        {
            if (i > numbones) return null;
            fixed (StudioHdr* ptr = &this)
                return (MStudioBone*) ((uint) ptr + boneindex) + i * sizeof(MStudioBone);
        }
    }; //Size=0x00D4 

    public unsafe struct MStudioBone
    {
        public int sznameindex;
        public int parent; // parent bone
        public fixed int bonecontroller[6]; // bone controller index, -1 == none
        public Vector pos;
        public fixed float quat[4];
        public fixed float rot[3];
        public Vector posscale;
        public Vector rotscale;

        public Matrix3x4 poseToBone;
        public fixed float qAlignment[4];
        public int flags;
    }

    public unsafe struct MStudioModel
    {
        public IntPtr fnHandle; //0x0000
        public Char_t szName;
        fixed byte szNamePad[259]; //0x0004
        public int nLoadFlags; //0x0108
        public int nServerCount; //0x010C
        public int type; //0x0110
        public int flags; //0x0114
        public Vector vecMins; //0x0118
        public Vector vecMaxs; //0x0124
        public float radius; //0x0130
        public fixed byte pad[0x1C]; //0x0134

        //public string GetName()
        //{
        //	fixed (byte* ptr = szName)
        //		return ((ConstChar*)ptr)->ToString();
        //}
    }; //Size=0x0150
}