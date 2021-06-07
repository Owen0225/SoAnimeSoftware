using System;
using System.Windows.Forms.VisualStyles;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class SlidingFadingGameText : SlidingFadingGameElement, IText
    {
        public SlidingFadingGameText(DateTime maxLifeTime, ByteColor color, Vector realPosition, int finalOpacity,
            float fadeTime, float slideTime, Vector finalPosition, float factor, uint font, IDataSource data) : base(
            maxLifeTime, color, realPosition, finalOpacity, fadeTime, slideTime, finalPosition, factor)
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

            if (!Calculate())
                return;

            Render.Text(X, Y, Data.GetData(), Color, Font);
        }

        public uint Font { get; set; }
        public IDataSource Data { get; set; }
    }
}