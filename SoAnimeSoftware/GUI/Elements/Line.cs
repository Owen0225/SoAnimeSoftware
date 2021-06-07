using System;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class Line : ElementBase, ILine
    {
        public Line(DateTime maxLifeTime, ByteColor color) : base(maxLifeTime, color)
        {
        }

        public Line(DateTime maxLifeTime, int x, int y, ByteColor color) : base(maxLifeTime, x, y, color)
        {
        }

        public override bool Calculate()
        {
            return true;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            SDK.Surface.SetDrawColor(Color);
            SDK.Surface.DrawLine(X, Y, X2, Y2);
        }

        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}