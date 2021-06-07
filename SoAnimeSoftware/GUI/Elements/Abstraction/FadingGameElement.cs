using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class FadingGameElement : GameElement, IFading
    {
        protected FadingGameElement(DateTime maxLifeTime, ByteColor color, Vector realPosition, int finalOpacity,
            float fadeTime) : base(maxLifeTime, color, realPosition)
        {
            this.FinalOpacity = finalOpacity;
            this.FadeTime = fadeTime;
            this.OpacityOffset = finalOpacity - color.A;
        }

        public int FinalOpacity { get; set; }
        public float FadeTime { get; set; }
        public int OpacityOffset { get; set; }

        public void Fade()
        {
            if (TimeLeft > FadeTime)
                return;

            var factor = TimeLeft / FadeTime;
            Color.A = (byte) (FinalOpacity - OpacityOffset * (factor));
        }

        public void Update()
        {
            Fade();
        }
    }
}