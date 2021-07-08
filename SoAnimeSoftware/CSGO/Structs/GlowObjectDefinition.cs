using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.CSGO.Structs
{
    public unsafe struct GlowObjectDefinition
    {
        public int nextFreeSlot;
        public Entity* entity;
        public FloatColor glowColor;
        public float glowAlpha;
        public byte _glowAlphaCappedByRenderAlpha;
        public float glowAlphaFunctionOfMaxVelocity;
        public float glowAlphaMax;
        public float glowPulseOverdrive;
        public byte _renderWhenOccluded;
        public byte _renderWhenUnoccluded;
        public byte _fullBloomRender;
        public int fullBloomStencilTestValue;
        public int glowStyle;
        public int splitScreenSlot;

        public bool IsUnused()
        {
            return nextFreeSlot != ENTRY_IN_USE;
        }

        public bool glowAlphaCappedByRenderAlpha()
        {
            return _glowAlphaCappedByRenderAlpha == 1;
        }

        public bool renderWhenOccluded()
        {
            return _renderWhenOccluded == 1;
        }

        public bool renderWhenUnoccluded()
        {
            return _renderWhenUnoccluded == 1;
        }

        public bool fullBloomRender()
        {
            return _fullBloomRender == 1;
        }

        private static readonly int END_OF_FREE_LIST = -1;
        private static readonly int ENTRY_IN_USE = -2;
    }
}