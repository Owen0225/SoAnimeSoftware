using System;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class SlidingFadingText : SlidingFadingElement, IText
    {
        public SlidingFadingText(DateTime maxLifeTime, int x, int y, ByteColor color, int finalOpacity, float fadeTime,
            int finalX, int finalY, float slideTime, float factor, uint font, IDataSource data) : base(maxLifeTime, x,
            y, color, finalOpacity, fadeTime, finalX, finalY, slideTime, factor)
        {
            this.Font = font;
            this.Data = data;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            Update();

            Render.Text(X, Y, Data.GetData(), Color, Font);
        }

        public uint Font { get; set; }
        public IDataSource Data { get; set; }
    }
}