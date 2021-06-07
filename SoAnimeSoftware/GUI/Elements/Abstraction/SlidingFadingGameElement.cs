using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class SlidingFadingGameElement : FadingGameElement, IGameSliding
    {
        public void Shift()
        {
            if (TimeLeft > SlideTime)
                return;


            realPosition.X += (int) ((FinalPosition.X - realPosition.X) * ((1 - TimeLeft / SlideTime) * Factor));
            realPosition.Y += (int) ((FinalPosition.Y - realPosition.Y) * ((1 - TimeLeft / SlideTime) * Factor));
            realPosition.Z += (int) ((FinalPosition.Z - realPosition.Z) * ((1 - TimeLeft / SlideTime) * Factor));
        }

        protected SlidingFadingGameElement(DateTime maxLifeTime, ByteColor color, Vector realPosition, int finalOpacity,
            float fadeTime, float slideTime, Vector finalPosition, float factor) : base(maxLifeTime, color,
            realPosition, finalOpacity, fadeTime)
        {
            this.SlideTime = slideTime;
            this.FinalPosition = finalPosition;
            this.Factor = factor;
        }

        public void Update()
        {
            Fade();
            Shift();
        }

        public float SlideTime { get; set; }
        public Vector FinalPosition { get; set; }
        public float Factor { get; set; }
    }
}