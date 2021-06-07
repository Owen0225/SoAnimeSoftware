using System;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.GUI.Elements.Abstraction
{
    public class FadingGameLine : FadingGameElement, ILine
    {
        protected Vector SecondPosition;

        public FadingGameLine(DateTime maxLifeTime, ByteColor color, Vector realPosition, int finalOpacity, float fadeTime, Vector secondPosition) : base(maxLifeTime, color, realPosition, finalOpacity, fadeTime)
        {
            this.SecondPosition = secondPosition;
        }
        
        public override bool Calculate()
        {
            Vector dst = new Vector();
            if (base.Calculate() && ExtraMath.WorldToScreen(SecondPosition, ref dst))
            {
                X2 = (int) dst.X;
                Y2 = (int) dst.Y;
                return true;
            }

            return false;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            Update();

            if (!Calculate() )
                return;
            
            SDK.Surface.SetDrawColor(Color);
            SDK.Surface.DrawLine(X, Y, X2, Y2);
        }

        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}