using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoAnimeSoftware.CSGO.Structs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ByteColor
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public ByteColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public ByteColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public ByteColor(int r, int g, int b, int a)
        {
            R = (byte) r;
            G = (byte) g;
            B = (byte) b;
            A = (byte) a;
        }

        public ByteColor(float r, float g, float b, float a)
        {
            R = (byte) r;
            G = (byte) g;
            B = (byte) b;
            A = (byte) a;
        }

        public static bool operator ==(ByteColor a, ByteColor b)
        {
            return (a.R == b.R && a.G == b.G && a.B == b.B && a.A == b.A);
        }

        public static bool operator !=(ByteColor a, ByteColor b)
        {
            return (a.R != b.R || a.G != b.G || a.B != b.B || a.A != b.A);
        }

        public static ByteColor operator -(ByteColor a, ByteColor b)
        {
            return new ByteColor(a.R - b.R, a.G - b.G, a.B - b.B, a.A - b.A);
        }

        public static ByteColor operator +(ByteColor a, ByteColor b)
        {
            return new ByteColor(a.R + b.R, a.G + b.G, a.B + b.B, a.A + b.A);
        }

        public static ByteColor operator /(ByteColor a, ByteColor b)
        {
            return new ByteColor(a.R / b.R, a.G / b.G, a.B / b.B, a.A / b.A);
        }

        public static ByteColor operator *(ByteColor a, ByteColor b)
        {
            return new ByteColor(a.R * b.R, a.G * b.G, a.B * b.B, a.A * b.A);
        }

        public static ByteColor operator /(ByteColor a, byte b)
        {
            return new ByteColor(a.R / b, a.G / b, a.B / b, a.A / b);
        }

        public static ByteColor operator *(ByteColor a, byte b)
        {
            return new ByteColor(a.R * b, a.G * b, a.B * b, a.A * b);
        }

        public static ByteColor operator /(ByteColor a, float b)
        {
            return new ByteColor(a.R / b, a.G / b, a.B / b, a.A / b);
        }

        public static ByteColor operator *(ByteColor a, float b)
        {
            return new ByteColor(a.R * b, a.G * b, a.B * b, a.A * b);
        }

        public static ByteColor operator +(ByteColor a, byte b)
        {
            return new ByteColor(a.R + b, a.G + b, a.B + b, a.A + b);
        }

        public override string ToString()
        {
            return $"R: {R}, G: {G}, B: {B}, A: {A}";
        }
    }
}