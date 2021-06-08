using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SoAnimeSoftware.GUI;
using SoAnimeSoftware.Utils;
using static SoAnimeSoftware.CSGO.EFontFlags;

namespace SoAnimeSoftware.CSGO
{
    public unsafe class ISurface : InterfaceBase
    {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetDrawColorDlg(IntPtr ptr, int r, int g, int b, int a);

        public SetDrawColorDlg _SetDrawColor;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawFilledRectDlg(IntPtr ptr, int x0, int y0, int x1, int y1);

        public DrawFilledRectDlg _DrawFilledRect;


        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawOutlinedRectDlg(IntPtr ptr, int x0, int y0, int x1, int y1);

        public DrawOutlinedRectDlg _DrawOutlinedRect;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawPolyLineDlg(IntPtr ptr, IntPtr x_arr, IntPtr y_arr, int count);

        public DrawPolyLineDlg _DrawPolyLine;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawLineDlg(IntPtr ptr, int x0, int y0, int x1, int y1);

        public DrawLineDlg _DrawLine;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetTextFontDlg(IntPtr ptr, uint font);

        public SetTextFontDlg _SetTextFont;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetTextColorDlg(IntPtr ptr, int r, int g, int b, int a);

        public SetTextColorDlg _SetTextColor;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetTextPositionDlg(IntPtr ptr, int x, int y);

        public SetTextPositionDlg _SetTextPosition;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void PrintTextDlg(IntPtr ptr, byte[] text, int length, int drawType);

        public PrintTextDlg _PrintText;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void SetTextureDlg(IntPtr ptr, int textureID);

        public SetTextureDlg _SetTexture;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DeleteTextureByIDDlg(IntPtr ptr, int id);

        public DeleteTextureByIDDlg _DeleteTextureByID;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate int CreateNewTextureIDDlg(IntPtr ptr, byte procedural);

        public CreateNewTextureIDDlg _CreateNewTextureID;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void GetScreenSizeDlg(IntPtr ptr, int* width, int* height);

        public GetScreenSizeDlg _GetScreenSize;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void UnlockCursorDlg(IntPtr ptr);

        public UnlockCursorDlg _UnlockCursor;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void LockCursorDlg(IntPtr ptr);

        public LockCursorDlg _LockCursor;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate void GetTextSizeDlg(IntPtr ptr, uint font, byte[] text, int* width, int* height);

        public GetTextSizeDlg _GetTextSize;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate uint CreateFontDlg(IntPtr ptr);

        public CreateFontDlg CreateFont;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public unsafe delegate byte SetFontGlyphSetDlg(IntPtr ptr, uint font, byte[] fontName, int tall, int weight,
            int blur, int scanlines, int flags, int rangeMin, int rangeMax);

        public SetFontGlyphSetDlg _SetFontGlyphSet;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawTexturedPolyLineDlg(IntPtr ptr, ref Vertex pVertice, int count);

        public DrawTexturedPolyLineDlg _DrawTexturedPolyLine;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawTexturedPolygonDlg(IntPtr ptr, int count, ref Vertex pVertice, byte bClipVertices);

        public DrawTexturedPolygonDlg _DrawTexturedPolygon;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawOutlinedCircleDlg(IntPtr ptr, int x, int y, int r, int seg);

        public DrawOutlinedCircleDlg _DrawOutlinedCircle;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void DrawFilledRectFadeDlg(IntPtr Address, int x0, int y0, int x1, int y1, uint alpha0,
            uint alpha1, byte bHorizontal);

        public DrawFilledRectFadeDlg _DrawFilledRectFade;


        public ISurface(IntPtr Address) : base(Address)
        {
            _SetDrawColor = GetInterfaceFunction<SetDrawColorDlg>(15);
            _DrawFilledRect = GetInterfaceFunction<DrawFilledRectDlg>(16);
            _DrawOutlinedRect = GetInterfaceFunction<DrawOutlinedRectDlg>(18);
            _DrawPolyLine = GetInterfaceFunction<DrawPolyLineDlg>(20);
            _DrawLine = GetInterfaceFunction<DrawLineDlg>(19);
            _SetTextFont = GetInterfaceFunction<SetTextFontDlg>(23);
            _SetTextColor = GetInterfaceFunction<SetTextColorDlg>(25);
            _SetTextPosition = GetInterfaceFunction<SetTextPositionDlg>(26);
            _PrintText = GetInterfaceFunction<PrintTextDlg>(28);
            _SetTexture = GetInterfaceFunction<SetTextureDlg>(38);
            _DeleteTextureByID = GetInterfaceFunction<DeleteTextureByIDDlg>(39);
            _CreateNewTextureID = GetInterfaceFunction<CreateNewTextureIDDlg>(43);
            _GetScreenSize = GetInterfaceFunction<GetScreenSizeDlg>(44);
            _UnlockCursor = GetInterfaceFunction<UnlockCursorDlg>(66);
            _LockCursor = GetInterfaceFunction<LockCursorDlg>(67);
            _GetTextSize = GetInterfaceFunction<GetTextSizeDlg>(79);
            CreateFont = GetInterfaceFunction<CreateFontDlg>(71);
            _SetFontGlyphSet = GetInterfaceFunction<SetFontGlyphSetDlg>(72);
            _DrawOutlinedCircle = GetInterfaceFunction<DrawOutlinedCircleDlg>(103);
            _DrawTexturedPolyLine = GetInterfaceFunction<DrawTexturedPolyLineDlg>(104);
            _DrawTexturedPolygon = GetInterfaceFunction<DrawTexturedPolygonDlg>(106);
            _DrawFilledRectFade = GetInterfaceFunction<DrawFilledRectFadeDlg>(123);
        }

        public void DrawFilledRectFade(int x0, int y0, int x1, int y1, uint alpha0, uint alpha1, byte bHorizontal)
        {
            _DrawFilledRectFade(this.Address, x0, y0, x1, y1, alpha0, alpha1, bHorizontal);
        }


        public uint DefineFont(string name, int tall, int weight, int blur, int scanlines, EFontFlags flags)
        {
            var result = CreateFont(Address);
            Log.Debug(
                $"Font {name} status: {SetFontGlyphSet(result, name, tall, weight, blur, scanlines, (int) flags)}");
            return result;
        }


        public static Dictionary<EItemDefinitionIndex, string> WeaponIconDictionary =
            new Dictionary<EItemDefinitionIndex, string>()
            {
                {EItemDefinitionIndex.DEAGLE, ""},
                {EItemDefinitionIndex.ELITE, "p"},
                {EItemDefinitionIndex.FIVESEVEN, "s"},
                {EItemDefinitionIndex.GLOCK, "i"},
                {EItemDefinitionIndex.AK47, "q"},
                {EItemDefinitionIndex.AUG, "w"},
                {EItemDefinitionIndex.AWP, "e"},
                {EItemDefinitionIndex.FAMAS, "a"},
                {EItemDefinitionIndex.G3SG1, "f"},
                {EItemDefinitionIndex.GALILAR, "g"},
                {EItemDefinitionIndex.M249, "Y"},
                {EItemDefinitionIndex.M4A1, "R"},
                {EItemDefinitionIndex.MAC10, "U"},
                {EItemDefinitionIndex.P90, "F"},
                {EItemDefinitionIndex.MP5_SD, ""},
                {EItemDefinitionIndex.UMP45, "B"},
                {EItemDefinitionIndex.XM1014, "M"},
                {EItemDefinitionIndex.BIZON, "t"},
                {EItemDefinitionIndex.MAG7, "I"},
                {EItemDefinitionIndex.NEGEV, "S"},
                {EItemDefinitionIndex.SAWEDOFF, "J"},
                {EItemDefinitionIndex.TEC9, "V"},
                {EItemDefinitionIndex.TASER, "C"},
                {EItemDefinitionIndex.HKP2000, "k"},
                {EItemDefinitionIndex.MP7, "P"},
                {EItemDefinitionIndex.MP9, ""},
                {EItemDefinitionIndex.NOVA, "D"},
                {EItemDefinitionIndex.P250, "G"},
                {EItemDefinitionIndex.SCAR20, "K"},
                {EItemDefinitionIndex.SG553, "L"},
                {EItemDefinitionIndex.SSG08, ""},
                {EItemDefinitionIndex.KNIFE, "z"},
                {EItemDefinitionIndex.FLASHBANG, "o"},
                {EItemDefinitionIndex.HEGRENADE, "j"},
                {EItemDefinitionIndex.SMOKEGRENADE, "Z"},
                {EItemDefinitionIndex.MOLOTOV, "O"},
                {EItemDefinitionIndex.DECOY, "d"},
                {EItemDefinitionIndex.INCGRENADE, "l"},
                {EItemDefinitionIndex.C4, "y"},
                {EItemDefinitionIndex._T_, "W"},
                {EItemDefinitionIndex.M4A1_SILENCER, "T"},
                {EItemDefinitionIndex.USP_SILENCER, "N"},
                {EItemDefinitionIndex.CZ75A, "u"},
                {EItemDefinitionIndex.REVOLVER, "H"},
                {EItemDefinitionIndex.BAYONET, "r"},
                {EItemDefinitionIndex.FLIP, "v"},
                {EItemDefinitionIndex.GUT, "b"},
                {EItemDefinitionIndex.KARAMBIT, "n"},
                {EItemDefinitionIndex.M9_BAYONET, "m"},
                {EItemDefinitionIndex.TACTICAL, "E"},
                {EItemDefinitionIndex.FALCHION, "c"},
                {EItemDefinitionIndex.SURVIVAL_BOWIE, ""},
                {EItemDefinitionIndex.BUTTERFLY, "x"},
                {EItemDefinitionIndex.PUSH, "Q"},
                {EItemDefinitionIndex.URSUS, ""},
                {EItemDefinitionIndex.NAVAJA, ""},
                {EItemDefinitionIndex.STILETTO, ""},
                {EItemDefinitionIndex.WIDOWMAKER, ""},
                {EItemDefinitionIndex.CLASSIC, ""},
                {EItemDefinitionIndex.SKELETON, ""},
                {EItemDefinitionIndex.SURVIVAL, ""},
                {EItemDefinitionIndex.NOMAD, ""},
                {EItemDefinitionIndex.PARACORD, ""},
            };

        public void DrawOutlinedCircle(int x, int y, int r, int seg = 240)
        {
            _DrawOutlinedCircle(Address, x, y, r, seg);
        }

        public void UnlockCursor()
        {
            _UnlockCursor(Address);
        }

        public void LockCursor()
        {
            _LockCursor(Address);
        }

        public void SetDrawColor(ByteColor color)
        {
            _SetDrawColor(Address, color.R, color.G, color.B, color.A);
        }

        public void DrawFilledRect(int x0, int y0, int x1, int y1)
        {
            _DrawFilledRect(Address, x0, y0, x1, y1);
        }

        public void DrawOutlinedRect(int x0, int y0, int x1, int y1)
        {
            _DrawOutlinedRect(Address, x0, y0, x1, y1);
        }


        public void DrawTexturedPolyLine(ref Vertex vertex, int count)
        {
            _DrawTexturedPolyLine(Address, ref vertex, count);
        }

        public void DrawPolygon(int count, ref Vertex pVertex, ByteColor color)
        {
            int id = SDK.Surface.CreateNewTextureID(true);
            SDK.Surface.SetTexture(id);
            SDK.Surface.SetDrawColor(color);
            SDK.Surface.DrawTexturedPolygon(count, ref pVertex);
            SDK.Surface.DeleteTextureByID(id);
        }

        public void DrawTexturedPolygon(int count, ref Vertex pVertex, bool bClipVertices = true)
        {
            _DrawTexturedPolygon(Address, count, ref pVertex, (byte) (bClipVertices ? 1 : 0));
        }


        public void SetTexture(int id)
        {
            _SetTexture(Address, id);
        }


        public int CreateNewTextureID(bool procedural = false)
        {
            return _CreateNewTextureID(Address, (byte) (procedural ? 1 : 0));
        }

        public void DeleteTextureByID(int id)
        {
            _DeleteTextureByID(Address, id);
        }

        public void SetDrawColor(Color color)
        {
            _SetDrawColor(Address, color.R, color.G, color.B, color.A);
        }

        public void SetDrawColor(Color color, byte opacity)
        {
            _SetDrawColor(Address, color.R, color.G, color.B, opacity);
        }

        public void SetDrawColor(int r, int g, int b, int a)
        {
            _SetDrawColor(Address, r, g, b, a);
        }

        public void SetDrawColor(float r, float g, float b, float a)
        {
            _SetDrawColor(Address, (int) r, (int) g, (int) b, (int) a);
        }

        public void DrawLine(int x0, int y0, int x1, int y1)
        {
            _DrawLine(Address, x0, y0, x1, y1);
        }

        public void DrawLine(float x0, float y0, float x1, float y1)
        {
            _DrawLine(Address, (int) x0, (int) y0, (int) x1, (int) y1);
        }

        public void SetTextFont(uint font)
        {
            _SetTextFont(Address, font);
        }

        public void SetTextColor(ByteColor color)
        {
            _SetTextColor(Address, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }

        public void SetTextColor(int r, int g, int b, int a)
        {
            _SetTextColor(Address, r, g, b, a);
        }

        public void SetTextColor(Color color)
        {
            _SetTextColor(Address, (int) color.R, (int) color.G, (int) color.B, (int) color.A);
        }

        public void SetTextPosition(int x, int y)
        {
            _SetTextPosition(Address, x, y);
        }

        public void PrintText(string text)
        {
            _PrintText(Address, Encoding.Unicode.GetBytes(text), text.Length, 0);
        }

        public void PrintText(byte[] raw)
        {
            _PrintText(Address, raw, raw.Length, 0);
        }

        public int[] GetScreenSize()
        {
            int width = 0;
            int height = 0;
            _GetScreenSize(Address, &width, &height);
            return new int[] {width, height};
        }

        public int[] GetTextSize(uint font, string text)
        {
            int width = 0;
            int height = 0;
            _GetTextSize(Address, font, Encoding.Unicode.GetBytes(text), &width, &height);
            return new int[] {width, height};
        }

        public byte SetFontGlyphSet(uint font, string fontName, int tall, int weight, int blur, int scanlines,
            int flags, int rangeMin = 0, int rangeMax = 0)
        {
            return _SetFontGlyphSet(Address, font, Encoding.UTF8.GetBytes(fontName), tall, weight, blur, scanlines,
                flags, rangeMin, rangeMax);
        }

        public void DrawOutlinedRect(float x0, float y0, float x1, float y1)
        {
            DrawOutlinedRect((int)x0, (int)y0,(int)x1,(int)y1);
        }
    }

    public enum AlignStyle
    {
        TOP_LEFT,
        LEFT,
        BOTTOM_LEFT,
        BOTTOM,
        BOTTOM_RIGHT,
        RIGHT,
        TOP_RIGHT,
        TOP,
        CENTER
    };

    [Flags]
    public enum EFontFlags
    {
        FONTFLAG_NONE,
        FONTFLAG_ITALIC = 0x001,
        FONTFLAG_UNDERLINE = 0x002,
        FONTFLAG_STRIKEOUT = 0x004,
        FONTFLAG_SYMBOL = 0x008,
        FONTFLAG_ANTIALIAS = 0x010,
        FONTFLAG_GAUSSIANBLUR = 0x020,
        FONTFLAG_ROTARY = 0x040,
        FONTFLAG_DROPSHADOW = 0x080,
        FONTFLAG_ADDITIVE = 0x100,
        FONTFLAG_OUTLINE = 0x200,
        FONTFLAG_CUSTOM = 0x400
    };
}