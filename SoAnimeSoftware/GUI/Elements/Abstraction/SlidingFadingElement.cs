using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class SlidingFadingElement : FadingElement, ISliding
    {
        protected SlidingFadingElement(DateTime maxLifeTime, int x, int y, ByteColor color, int finalOpacity,
            float fadeTime, int finalX, int finalY, float slideTime, float factor) : base(maxLifeTime, x, y, color,
            finalOpacity, fadeTime)
        {
            this.FinalX = finalX;
            this.FinalY = finalY;
            this.SlideTime = slideTime;
            this.Factor = factor;
        }

        public void Shift()
        {
            if (TimeLeft > SlideTime)
                return;

            X += (int) ((FinalX - X) * ((1 - TimeLeft / SlideTime) * Factor));
            Y += (int) ((FinalY - Y) * ((1 - TimeLeft / SlideTime) * Factor));
        }

        public void Update()
        {
            Fade();
            Shift();
        }

        public int FinalX { get; set; }
        public int FinalY { get; set; }
        public float SlideTime { get; set; }
        public float Factor { get; set; }
    }
}