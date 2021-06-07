using System;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct CPaintKit
    {
        public int nID;

        fixed int sName[4];
        fixed int sDescriptionString[4];
        fixed int sDescriptionTag[4];
        fixed int pad[4];
        private fixed int pattern[4];
        fixed int sLogoMaterial[4];
        fixed int pad1[4];

        int bBaseDiffuseOverride;
        int phongboost;
        public int nStyle;

        public ByteColor color1;
        public ByteColor color2;
        public ByteColor color3;
        public ByteColor color4;
        private ByteColor logoColor1;
        private ByteColor logoColor2;
        private ByteColor logoColor3;
        private ByteColor logoColor4;
        float flWearDefault;
        float flWearRemapMin;
        float flWearRemapMax;
        byte nFixedSeed;
        byte uchPhongExponent;
        byte uchPhongAlbedoBoost;
        byte uchPhongIntensity;
        float flPatternScale;
        float flPatternOffsetXStart;
        float flPatternOffsetXEnd;
        float flPatternOffsetYStart;
        float flPatternOffsetYEnd;
        float flPatternRotateStart;
        float flPatternRotateEnd;
        float flLogoScale;
        float flLogoOffsetX;
        float flLogoOffsetY;
        float flLogoRotation;
        int bIgnoreWeaponSizeScale;
        int nViewModelExponentOverrideSize;
        int bOnlyFirstMaterial;
        public float pearlescent;
        fixed int sVmtPath[4];
        int kvVmtOverrides;
    }
}