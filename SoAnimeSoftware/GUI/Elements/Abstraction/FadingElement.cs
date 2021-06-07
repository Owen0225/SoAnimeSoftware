using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class FadingElement : ElementBase, IFading
    {
        public FadingElement(DateTime maxLifeTime, int x, int y, ByteColor color, int finalOpacity, float fadeTime) :
            base(maxLifeTime, x, y, color)
        {
            this.FinalOpacity = finalOpacity;
            this.FadeTime = fadeTime;
            this.OpacityOffset = finalOpacity - color.A;
        }

        public override bool Calculate()
        {
            return true;
        }

        public void Update()
        {
            Fade();
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
    }
}