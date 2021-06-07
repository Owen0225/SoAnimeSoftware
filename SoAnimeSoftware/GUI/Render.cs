using System;
using System.Drawing;
using System.Numerics;
using SoAnimeSoftware.CSGO;
using SoAnimeSoftware.CSGO.Structs;
using static SoAnimeSoftware.CSGO.EFontFlags;

namespace SoAnimeSoftware.GUI
{
    public static class Render
    {
        public static DateTime GlobalTime;
        public static int MaxWidth;
        public static int MaxHeight;

        public static ByteColor Primary = new ByteColor(Color.Plum);
        public static ByteColor DarkBG = new ByteColor(Color.FromArgb(18, 18, 18));
        public static ByteColor MinorText = new ByteColor(Color.FromArgb(169, 169, 169));

        public static Vector4 Bg = new Vector4(0.07f, 0.07f, 0.07f, 1f);

        public static void TestDraw(IntPtr device)
        {
        }

        public static void UpdateTime()
        {
            var screenSize = SDK.Surface.GetScreenSize();
            MaxWidth = screenSize[0];
            MaxHeight = screenSize[1];
            GlobalTime = DateTime.Now;
        }

        public static void Text(int x, int y, string data, ByteColor color, uint font)
        {
            SDK.Surface.SetTextColor(color);
            SDK.Surface.SetTextFont(font);
            SDK.Surface.SetTextPosition(x, y);
            SDK.Surface.PrintText(data);
        }


        public static void FilledRect(int x, int y, int w, int h, ByteColor color)
        {
            SDK.Surface.SetDrawColor(color);
            SDK.Surface.DrawFilledRect(x, y, x + w, y + h);
        }

        public static void GradientRect(int x, int y, int w, int h, ByteColor color1, ByteColor color2,
            bool horizontal = false)
        {
            SDK.Surface.SetDrawColor(color1);
            SDK.Surface.DrawFilledRectFade(x, y, x + w, y + h, 255, 0, horizontal ? (byte) 1 : (byte) 0);

            SDK.Surface.SetDrawColor(color2);
            SDK.Surface.DrawFilledRectFade(x, y, x + w, y + h, 0, 255, horizontal ? (byte) 1 : (byte) 0);
        }

        public static void Ellipse(int x, int y, int radiusX, int radiusY, ByteColor color,
            AlignStyle style = AlignStyle.CENTER, int quality = 20)
        {
            Vertex[] circle = new Vertex[quality];

            switch (style)
            {
                case AlignStyle.CENTER:
                    break;
                case AlignStyle.BOTTOM_LEFT:
                    x += radiusX;
                    y -= radiusY;
                    break;
            }

            for (int i = 0; i < quality; i++)
            {
                float angle = (float) i / -quality * (float) Math.PI * 2;

                circle[i].x = x + (float) Math.Cos(angle) * radiusX;
                circle[i].y = y + (float) Math.Sin(angle) * radiusY;
            }

            SDK.Surface.DrawPolygon(quality, ref circle[0], color);
        }


        public static uint TITLE;
        public static uint MENU;
        public static uint MENUBIG;
        public static uint ESP;
        public static uint smallESP;
        public static uint SPOTIFY;
        public static uint tahoma12;
        public static uint tahoma12o;
        public static uint tahoma14;
        public static uint tahoma14o;
        public static uint tahoma16;
        public static uint verdana12;
        public static uint verdana12o;
        public static uint verdana14;
        public static uint verdana14o;
        public static uint verdana16o;
        public static uint SPOTIFYo;
        public static uint tahoma72;
        public static uint tahomaTest;
        public static uint icons22;
        public static uint icons22o;
        public static uint icons_glyph22;
        public static uint icons_glyph22o;
        public static uint vksans12;
        public static uint vksans14;
        public static uint vksans16;
        public static uint Roboto_Medium12;
        public static uint Roboto_Medium14;
        public static uint Roboto_Medium16;
        public static uint Roboto_Regular12;
        public static uint Roboto_Regular14;
        public static uint Roboto_Regular16;


        public static void Init()
        {
            TITLE = SDK.Surface.DefineFont("Verdana", 16, 400, 0, 0,
                FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE | FONTFLAG_DROPSHADOW);
            MENU = SDK.Surface.DefineFont("Tahoma", 12, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);
            MENUBIG = SDK.Surface.DefineFont("Verdana", 12, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);
            ESP = SDK.Surface.DefineFont("Verdana", 16, 600, 0, 0, FONTFLAG_OUTLINE);
            smallESP = SDK.Surface.DefineFont("Tahoma", 12, 600, 0, 0, FONTFLAG_OUTLINE);
            SPOTIFY = SDK.Surface.DefineFont("Verdana", 14, 800, 0, 0, 0);
            SPOTIFYo = SDK.Surface.DefineFont("Verdana", 16, 800, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);

            tahoma12 = SDK.Surface.DefineFont("Tahoma", 12, 400, 0, 0, FONTFLAG_ANTIALIAS);
            tahoma12o = SDK.Surface.DefineFont("Tahoma", 12, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);
            tahoma14 = SDK.Surface.DefineFont("Tahoma", 14, 400, 0, 0, FONTFLAG_ANTIALIAS);
            tahoma14o = SDK.Surface.DefineFont("Tahoma", 14, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);
            tahoma16 = SDK.Surface.DefineFont("Tahoma", 16, 400, 0, 0, FONTFLAG_ANTIALIAS);
            tahomaTest = SDK.Surface.DefineFont("Tahoma", 72, 100, 0, 0, FONTFLAG_ANTIALIAS);

            verdana16o = ESP;
            verdana12 = SDK.Surface.DefineFont("Verdana", 12, 400, 0, 0, FONTFLAG_ANTIALIAS);
            verdana12o = SDK.Surface.DefineFont("Verdana", 12, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);
            verdana14 = SDK.Surface.DefineFont("Verdana", 14, 400, 0, 0, FONTFLAG_ANTIALIAS);
            verdana14o = SDK.Surface.DefineFont("Verdana", 14, 400, 0, 0, FONTFLAG_ANTIALIAS | FONTFLAG_OUTLINE);


            WinApi.AddFontMemResourceEx(Properties.FontResources.undefeated, Properties.FontResources.undefeated.Length,
                IntPtr.Zero,
                out _);


            WinApi.AddFontMemResourceEx(Properties.FontResources.Roboto_Medium,
                Properties.FontResources.Roboto_Medium.Length, IntPtr.Zero, out _);

            WinApi.AddFontMemResourceEx(Properties.FontResources.Roboto_Regular,
                Properties.FontResources.Roboto_Regular.Length, IntPtr.Zero, out _);

            Render.icons22 = SDK.Surface.DefineFont("undefeated", 24, 600, 0, 0, FONTFLAG_ANTIALIAS);

            Render.Roboto_Medium12 = SDK.Surface.DefineFont("Roboto Medium", 12, 400, 0, 0, FONTFLAG_ANTIALIAS);
            Render.Roboto_Medium14 = SDK.Surface.DefineFont("Roboto Medium", 14, 400, 0, 0, FONTFLAG_ANTIALIAS);
            Render.Roboto_Medium16 = SDK.Surface.DefineFont("Roboto Medium", 16, 400, 0, 0, FONTFLAG_ANTIALIAS);

            Render.Roboto_Regular12 = SDK.Surface.DefineFont("Roboto", 12, 400, 0, 0, FONTFLAG_ANTIALIAS);
            Render.Roboto_Regular14 = SDK.Surface.DefineFont("Roboto", 14, 400, 0, 0, FONTFLAG_ANTIALIAS);
            Render.Roboto_Regular16 = SDK.Surface.DefineFont("Roboto", 16, 400, 0, 0, FONTFLAG_ANTIALIAS);
        }
    }
}