using System;
using System.Drawing;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class FadingGameText : FadingGameElement, IText
    {
        public FadingGameText(DateTime maxLifeTime, ByteColor color, Vector realPosition, int finalOpacity,
            float fadeTime, uint font, IDataSource data) : base(maxLifeTime, color, realPosition, finalOpacity,
            fadeTime)
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