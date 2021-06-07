using System;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public abstract class GameElement : ElementBase
    {
        protected Vector realPosition;


        protected GameElement(DateTime maxLifeTime, ByteColor color, Vector realPosition) : base(maxLifeTime, color)
        {
            this.realPosition = realPosition;
        }

        protected GameElement(DateTime maxLifeTime, int x, int y, ByteColor color, Vector realPosition) : base(
            maxLifeTime,
            x, y, color)
        {
            this.realPosition = realPosition;
        }

        public override bool Calculate()
        {
            var vector = new Vector();
            if (ExtraMath.WorldToScreen(realPosition, ref vector))
            {
                X = (int) vector.X;
                Y = (int) vector.Y;
                return true;
            }

            return false;
        }
    }
}