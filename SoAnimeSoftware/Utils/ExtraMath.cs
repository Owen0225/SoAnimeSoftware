using SoAnimeSoftware.CSGO.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoAnimeSoftware.Utils
{
    static class ExtraMath
    {
        public static Random rnd = new Random();
        public static readonly float PI = 3.1415926f;

        public static float r2d(float radians)
        {
            return radians * 180f / (float) Math.PI;
        }

        public static float d2r(float degrees)
        {
            return degrees * (float) Math.PI / 180f;
        }

        public static void AngleVectors(Vector angles, out Vector forward, out Vector right, out Vector up)
        {
            float sr, sp, sy, cr, cp, cy;

            sp = (float) Math.Sin(d2r(angles.X));
            cp = (float) Math.Cos(d2r(angles.X));
            sy = (float) Math.Sin(d2r(angles.Y));
            cy = (float) Math.Cos(d2r(angles.Y));
            sr = (float) Math.Sin(d2r(angles.Z));
            cr = (float) Math.Cos(d2r(angles.Z));

            forward.X = (cp * cy);
            forward.Y = (cp * sy);
            forward.Z = (-sp);
            right.X = (-1 * sr * sp * cy + -1 * cr * -sy);
            right.Y = (-1 * sr * sp * sy + -1 * cr * cy);
            right.Z = (-1 * sr * cp);
            up.X = (cr * sp * cy + -sr * -sy);
            up.Y = (cr * sp * sy + -sr * cy);
            up.Z = (cr * cp);
        }

        public static void AngleVectors(Vector angles, ref Vector forward)
        {
            float sr, sp, sy, cr, cp, cy;

            sp = (float) Math.Sin(d2r(angles.X));
            cp = (float) Math.Cos(d2r(angles.X));
            sy = (float) Math.Sin(d2r(angles.Y));
            cy = (float) Math.Cos(d2r(angles.Y));

            forward.X = (cp * cy);
            forward.Y = (cp * sy);
            forward.Z = (-sp);
        }

        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;
            else if (value.CompareTo(max) > 0)
                return max;
            else
                return value;
        }

        public static float NextFloat(float min, float max)
        {
            return (float) rnd.NextDouble() * (max - min) + min;
        }

        public static Vector GetBonePosition(Matrix3x4[] bone_matrices, int index)
        {
            return new Vector(bone_matrices[index]._14, bone_matrices[index]._24, bone_matrices[index]._34);
        }

        public static Vector GetBonePosition(ref Matrix3x4[] bone_matrices, int index)
        {
            return new Vector(bone_matrices[index]._14, bone_matrices[index]._24, bone_matrices[index]._34);
        }

        public static unsafe bool WorldToScreen(Vector src, ref Vector dst)
        {
            Matrix4x4* mat = CSGO.SDK.Engine.WorldToScreenMatrix();
            float w = mat->_41 * src.X + mat->_42 * src.Y + mat->_43 * src.Z + mat->_44;

            if (w <= 0.001f)
                return false;

            var size = CSGO.SDK.Surface.GetScreenSize();
            dst.X = size[0] / 2 * (1 + (mat->_11 * src.X + mat->_12 * src.Y + mat->_13 * src.Z + mat->_14) / w);
            dst.Y = size[1] / 2 * (1 - (mat->_21 * src.X + mat->_22 * src.Y + mat->_23 * src.Z + mat->_24) / w);
            dst.Z = 0f;
            return true;
        }
    }
}