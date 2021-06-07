using System;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using SoAnimeSoftware.GUI.Elements.Abstraction;

namespace SoAnimeSoftware.GUI.Elements
{
    public class GameText : GameElement, IText
    {
        public uint Font { get; set; }
        public IDataSource Data { get; set; }

        public GameText(DateTime maxLifeTime, ByteColor color, Vector realPosition, uint font, IDataSource data) : base(
            maxLifeTime, color, realPosition)
        {
            this.Font = font;
            this.Data = data;
        }

        public override void Draw()
        {
            TimeUpdate();

            if (!IsValid)
                return;

            if (!base.Calculate())
                return;

            Render.Text(X, Y, Data.GetData(), Color, Font);
        }
    }
}