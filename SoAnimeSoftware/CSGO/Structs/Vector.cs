using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using SoAnimeSoftware.Utils;

namespace SoAnimeSoftware.CSGO.Structs
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector
    {
        public float X;
        public float Y;
        public float Z;

        public Vector(float x = 0, float y = 0, float z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static bool operator ==(Vector a, Vector b)
        {
            return (a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }

        public static bool operator !=(Vector a, Vector b)
        {
            return (a.X != b.X || a.Y != b.Y || a.Z != b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator /(Vector a, Vector b)
        {
            return new Vector(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Vector operator *(Vector a, Vector b)
        {
            return new Vector(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Vector operator /(Vector a, int b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator *(Vector a, int b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator /(Vector a, float b)
        {
            return new Vector(a.X / b, a.Y / b, a.Z / b);
        }

        public static Vector operator *(Vector a, float b)
        {
            return new Vector(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector operator +(Vector a, float b)
        {
            return new Vector(a.X + b, a.Y + b, a.Z * b);
        }

        public bool IsZero()
        {
            return X == 0f && Y == 0f && Z == 0f;
        }

        public Vector ToAngle()
        {
            float yaw, pitch;

            if (X == 0 && Y == 0)
            {
                yaw = 0;
                pitch = Z > 0 ? 270 : 90;
            }
            else
            {
                yaw = (float) Math.Atan2(Y, X) * 180 / 3.141592654f;
                if (yaw < 0)
                    yaw += 360;

                pitch = (float) Math.Atan2(-Z, Length2D) * 180 / 3.141592654f;
                if (pitch < 0)
                    pitch += 360;
            }

            return new Vector(pitch, yaw, 0);
        }

        public Vector ToVector()
        {
            float yaw_sin, pitch_sin, yaw_cos, pitch_cos;
            pitch_sin = (float) Math.Sin(X * 0.017453292512f);
            pitch_cos = (float) Math.Cos(X * 0.017453292512f);
            yaw_sin = (float) Math.Sin(Y * 0.017453292512f);
            yaw_cos = (float) Math.Cos(Y * 0.017453292512f);

            return new Vector(pitch_cos * yaw_cos, pitch_cos * yaw_sin, -pitch_sin);
        }

        public float DotProduct(float x, float y, float z)
        {
            return X * x + Y * y + Z * z;
        }

        public unsafe Vector Transform(Matrix3x4* mat)
        {
            return new Vector()
            {
                X = DotProduct(mat->_11, mat->_12, mat->_13) + mat->_14,
                Y = DotProduct(mat->_21, mat->_22, mat->_23) + mat->_24,
                Z = DotProduct(mat->_31, mat->_32, mat->_33) + mat->_34,
            };
        }

        public unsafe Vector Transform(Matrix3x4 mat)
        {
            return new Vector()
            {
                X = DotProduct(mat._11, mat._12, mat._13) + mat._14,
                Y = DotProduct(mat._21, mat._22, mat._23) + mat._24,
                Z = DotProduct(mat._31, mat._32, mat._33) + mat._34,
            };
        }

        public float Length
        {
            get { return (float) Math.Sqrt((X * X) + (Y * Y) + (Z * Z)); }
        }

        public float Length2D
        {
            get { return (float) Math.Sqrt((X * X) + (Y * Y)); }
        }

        public void NormalizeAngle()
        {
            X = ExtraMath.Clamp(X, -89, 89);

            while (Y < -180)
            {
                Y += 360;
            }

            while (Y > 180)
            {
                Y -= 360;
            }
        }

        public void Clamp()
        {
            X = ExtraMath.Clamp(X, -89, 89);
            Y = ExtraMath.Clamp(Y, -180, 180);
            Z = 0;
        }
        
        

        public void Normalize()
        {
            var len = Length;
            len = len == 0.0f ? 0.01f : len;
            X /= len;
            Y /= len;
            Z /= len;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VectorAligned
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public VectorAligned(float x = 0, float y = 0, float z = 0, float w = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

        public static implicit operator VectorAligned(Vector v) => new VectorAligned(v.X, v.Y, v.Z, 0);

        public static bool operator ==(VectorAligned a, VectorAligned b)
        {
            return (a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }

        public static bool operator !=(VectorAligned a, VectorAligned b)
        {
            return (a.X != b.X || a.Y != b.Y || a.Z != b.Z);
        }

        public static VectorAligned operator -(VectorAligned a, VectorAligned b)
        {
            return new VectorAligned(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static VectorAligned operator +(VectorAligned a, VectorAligned b)
        {
            return new VectorAligned(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static VectorAligned operator /(VectorAligned a, VectorAligned b)
        {
            return new VectorAligned(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static VectorAligned operator *(VectorAligned a, VectorAligned b)
        {
            return new VectorAligned(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static VectorAligned operator /(VectorAligned a, int b)
        {
            return new VectorAligned(a.X / b, a.Y / b, a.Z / b);
        }

        public static VectorAligned operator *(VectorAligned a, int b)
        {
            return new VectorAligned(a.X * b, a.Y * b, a.Z * b);
        }

        public static VectorAligned operator /(VectorAligned a, float b)
        {
            return new VectorAligned(a.X / b, a.Y / b, a.Z / b);
        }

        public static VectorAligned operator *(VectorAligned a, float b)
        {
            return new VectorAligned(a.X * b, a.Y * b, a.Z * b);
        }

        public float DotProduct(float x, float y, float z)
        {
            return X * x + Y * y + Z * z;
        }

        public unsafe VectorAligned Transform(Matrix3x4* mat)
        {
            return new VectorAligned()
            {
                X = DotProduct(mat->_11, mat->_12, mat->_13) + mat->_14,
                Y = DotProduct(mat->_21, mat->_22, mat->_23) + mat->_24,
                Z = DotProduct(mat->_31, mat->_32, mat->_33) + mat->_34,
            };
        }

        public unsafe VectorAligned Transform(Matrix3x4 mat)
        {
            return new VectorAligned()
            {
                X = DotProduct(mat._11, mat._12, mat._13) + mat._14,
                Y = DotProduct(mat._21, mat._22, mat._23) + mat._24,
                Z = DotProduct(mat._31, mat._32, mat._33) + mat._34,
            };
        }

        public float Length
        {
            get { return (float) Math.Sqrt((X * X) + (Y * Y) + (Z * Z)); }
        }

        public float Length2D
        {
            get { return (float) Math.Sqrt((X * X) + (Y * Y)); }
        }

        public void Normalize()
        {
            while (Y > 180)
            {
                Y -= 360;
            }

            while (Y < -180)
            {
                Y += 360;
            }

            while (X > 89)
            {
                X -= 180;
            }

            while (X < -89)
            {
                X += 180;
            }
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}