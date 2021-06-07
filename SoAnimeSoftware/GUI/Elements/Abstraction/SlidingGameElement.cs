using System;
using SoAnimeSoftware.CSGO.Structs;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class SlidingGameElement : GameElement, IGameSliding
    {
        public SlidingGameElement(DateTime maxLifeTime, ByteColor color, Vector realPosition, float slideTime,
            Vector finalPosition, float factor) : base(maxLifeTime, color, realPosition)
        {
            this.SlideTime = slideTime;
            this.FinalPosition = finalPosition;
            this.Factor = factor;
        }

        public void Shift()
        {
            realPosition.X += (int) ((FinalPosition.X - realPosition.X) / (TimeLeft * Factor));
            realPosition.Y += (int) ((FinalPosition.Y - realPosition.Y) / (TimeLeft * Factor));
            realPosition.Z += (int) ((FinalPosition.Z - realPosition.Z) / (TimeLeft * Factor));
        }

        public float SlideTime { get; set; }
        public Vector FinalPosition { get; set; }
        public float Factor { get; set; }

        public void Update()
        {
            Shift();
        }
    }
}