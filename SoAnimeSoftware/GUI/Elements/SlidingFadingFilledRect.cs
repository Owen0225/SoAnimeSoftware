using System;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class SlidingFadingFilledRect : SlidingFadingElement, IFilledRect
    {
        public SlidingFadingFilledRect(DateTime maxLifeTime, int x, int y, ByteColor color, int finalOpacity,
            float fadeTime, int finalX, int finalY, float slideTime, float factor, int h, int w) : base(maxLifeTime, x,
            y, color, finalOpacity, fadeTime, finalX, finalY, slideTime, factor)
        {
            this.H = h;
            this.W = w;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            Update();

            Render.FilledRect(X, Y, W, H, Color);
        }

        public int H { get; set; }
        public int W { get; set; }
    }
}