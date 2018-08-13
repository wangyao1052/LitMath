using System;
using System.Collections.Generic;
using System.Text;

namespace LitMath
{
    public class Utils
    {
        public const double EPSILON = 1E-05;
        public const double PI = 3.14159265358979323846;

        public static double Clamp(double value, double minv, double maxv)
        {
            return Math.Max(Math.Min(value, maxv), minv);
        }

        public static double DegreeToRadian(double angle)
        {
            return ((angle * PI) / 180.0);
        }

        public static bool IsEqual(double x, double y, double epsilon = EPSILON)
        {
            return IsEqualZero(x - y, epsilon);
        }

        public static bool IsEqualZero(double x, double epsilon = EPSILON)
        {
            return (Math.Abs(x) < epsilon);
        }

        public static double RadianToDegree(double angle)
        {
            return ((angle * 180.0) / PI);
        }
    }
}
