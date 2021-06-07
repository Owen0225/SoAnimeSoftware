using System;
using System.Drawing;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.GUI.Elements
{
    class Text : ElementBase, IText
    {
        public Text(DateTime maxLifeTime, int x, int y, ByteColor color, uint font, IDataSource data) : base(
            maxLifeTime, x, y,
            color)
        {
            this.Font = font;
            this.Data = data;
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

            SDK.Surface.SetTextFont(Font);
            SDK.Surface.SetTextColor(Color);
            SDK.Surface.SetTextPosition(X, Y);
            SDK.Surface.PrintText(Data.GetData());
        }

        public uint Font { get; set; }
        public IDataSource Data { get; set; }
    }
}