using System;
using System.Collections.Generic;
using System.Text;

namespace Canvas.LiteMath
{
    public class Utils
    {
        public const double EPSILON = 1E-05;
        public const double PI = 3.1415926;

        public static double Clamp(double value, double minv, double maxv)
        {
            return Math.Max(Math.Min(value, maxv), minv);
        }

        public static double DegreeToRadian(double angle)
        {
            return ((angle * PI) / 180.0);
        }

        public static bool IsEqual(double x, double y)
        {
            return IsEqualZero(x - y);
        }

        public static bool IsEqualZero(double x)
        {
            return (Math.Abs(x) < EPSILON);
        }

        public static double RadianToDegree(double angle)
        {
            return ((angle * 180.0) / PI);
        }
    }
}
