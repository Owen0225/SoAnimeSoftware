using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class ElementBase : RenderableBase
    {
        protected int X, Y;
        protected ByteColor Color;

        protected ElementBase(DateTime maxLifeTime, ByteColor color) : base(maxLifeTime)
        {
            this.Color = color;
        }

        protected ElementBase(DateTime maxLifeTime, int x, int y, ByteColor color) : base(maxLifeTime)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
        }
    }
}