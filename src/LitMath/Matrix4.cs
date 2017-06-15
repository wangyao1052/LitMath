using System;

namespace LitMath
{
    public struct Matrix4
    {
        public double m11;
        public double m12;
        public double m13;
        public double m14;
        public double m21;
        public double m22;
        public double m23;
        public double m24;
        public double m31;
        public double m32;
        public double m33;
        public double m34;
        public double m41;
        public double m42;
        public double m43;
        public double m44;

        public Matrix4(
            double m11 = 0.0, double m12 = 0.0, double m13 = 0.0, double m14 = 0.0,
            double m21 = 0.0, double m22 = 0.0, double m23 = 0.0, double m24 = 0.0,
            double m31 = 0.0, double m32 = 0.0, double m33 = 0.0, double m34 = 0.0,
            double m41 = 0.0, double m42 = 0.0, double m43 = 0.0, double m44 = 0.0)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;

            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;

            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;

            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
        }

        public void Set(
            double m11 = 0.0, double m12 = 0.0, double m13 = 0.0, double m14 = 0.0,
            double m21 = 0.0, double m22 = 0.0, double m23 = 0.0, double m24 = 0.0,
            double m31 = 0.0, double m32 = 0.0, double m33 = 0.0, double m34 = 0.0,
            double m41 = 0.0, double m42 = 0.0, double m43 = 0.0, double m44 = 0.0)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;

            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;

            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;

            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
        }

        public override string ToString()
        {
            return string.Format(@"Matrix4(
{0,10:0.00}, {1,10:0.00}, {2,10:0.00}, {3,10:0.00},
{4,10:0.00}, {5,10:0.00}, {6,10:0.00}, {7,10:0.00},
{8,10:0.00}, {9,10:0.00}, {10,10:0.00}, {11,10:0.00},
{12,10:0.00}, {13,10:0.00}, {14,10:0.00}, {15,10:0.00}  )",
            m11, m12, m13, m14,
            m21, m22, m23, m24,
            m31, m32, m33, m34,
            m41, m42, m43, m44);
        }

        public double determinant
        {
            get
            {
                double A0 = m11 * m22 - m12 * m21;
                double A1 = m11 * m23 - m13 * m21;
                double A2 = m11 * m24 - m14 * m21;
                double A3 = m12 * m23 - m13 * m22;
                double A4 = m12 * m24 - m14 * m22;
                double A5 = m13 * m24 - m14 * m23;
                double B0 = m31 * m42 - m32 * m41;
                double B1 = m31 * m43 - m33 * m41;
                double B2 = m31 * m44 - m34 * m41;
                double B3 = m32 * m43 - m33 * m42;
                double B4 = m32 * m44 - m34 * m42;
                double B5 = m33 * m44 - m34 * m43;
        
                return A0*B5 - A1*B4 + A2*B3 + A3*B2 - A4*B1 + A5*B0;
            }
        }

        public Matrix4 inverse
        {
            get
            {
                double d = this.determinant;
                if (d == 0.0)
                    return Matrix4.identity;
        
                Matrix4 M = new Matrix4();
                M.m11 = (m23*m34*m42 - m24*m33*m42 + m24*m32*m43 -
                         m22*m34*m43 - m23*m32*m44 + m22*m33*m44) / d;
                M.m12 = (m14*m33*m42 - m13*m34*m42 - m14*m32*m43 +
                         m12*m34*m43 + m13*m32*m44 - m12*m33*m44) / d;
                M.m13 = (m13*m24*m42 - m14*m23*m42 + m14*m22*m43 -
                         m12*m24*m43 - m13*m22*m44 + m12*m23*m44) / d;
                M.m14 = (m14*m23*m32 - m13*m24*m32 - m14*m22*m33 +
                         m12*m24*m33 + m13*m22*m34 - m12*m23*m34) / d;
                M.m21 = (m24*m33*m41 - m23*m34*m41 - m24*m31*m43 +
                         m21*m34*m43 + m23*m31*m44 - m21*m33*m44) / d;
                M.m22 = (m13*m34*m41 - m14*m33*m41 + m14*m31*m43 -
                         m11*m34*m43 - m13*m31*m44 + m11*m33*m44) / d;
                M.m23 = (m14*m23*m41 - m13*m24*m41 - m14*m21*m43 +
                         m11*m24*m43 + m13*m21*m44 - m11*m23*m44) / d;
                M.m24 = (m13*m24*m31 - m14*m23*m31 + m14*m21*m33 -
                         m11*m24*m33 - m13*m21*m34 + m11*m23*m34) / d;
                M.m31 = (m22*m34*m41 - m24*m32*m41 + m24*m31*m42 -
                         m21*m34*m42 - m22*m31*m44 + m21*m32*m44) / d;
                M.m32 = (m14*m32*m41 - m12*m34*m41 - m14*m31*m42 +
                         m11*m34*m42 + m12*m31*m44 - m11*m32*m44) / d;
                M.m33 = (m12*m24*m41 - m14*m22*m41 + m14*m21*m42 -
                         m11*m24*m42 - m12*m21*m44 + m11*m22*m44) / d;
                M.m34 = (m14*m22*m31 - m12*m24*m31 - m14*m21*m32 +
                         m11*m24*m32 + m12*m21*m34 - m11*m22*m34) / d;
                M.m41 = (m23*m32*m41 - m22*m33*m41 - m23*m31*m42 +
                         m21*m33*m42 + m22*m31*m43 - m21*m32*m43) / d;
                M.m42 = (m12*m33*m41 - m13*m32*m41 + m13*m31*m42 -
                         m11*m33*m42 - m12*m31*m43 + m11*m32*m43) / d;
                M.m43 = (m13*m22*m41 - m12*m23*m41 - m13*m21*m42 +
                         m11*m23*m42 + m12*m21*m43 - m11*m22*m43) / d;
                M.m44 = (m12*m23*m31 - m13*m22*m31 + m13*m21*m32 -
                         m11*m23*m32 - m12*m21*m33 + m11*m22*m33) / d;
                return M;
            }
        }

        public Matrix4 transpose
        {
            get
            {
                return new Matrix4(
                    m11, m21, m31, m41,
                    m12, m22, m32, m42,
                    m13, m23, m33, m43,
                    m14, m24, m34, m44);
            }
        }

        public Vector3 MultiplyPoint(Vector3 v)
        {
            return new Vector3(
                m11 * v.x + m12 * v.y + m13 * v.z + m14,
                m21 * v.x + m22 * v.y + m23 * v.z + m24,
                m31 * v.x + m32 * v.y + m33 * v.z + m34);
        }

        public Vector3 MultiplyVector(Vector3 v)
        {
            return new Vector3(
                m11 * v.x + m12 * v.y + m13 * v.z,
                m21 * v.x + m22 * v.y + m23 * v.z,
                m31 * v.x + m32 * v.y + m33 * v.z);
        }

        public static Matrix4 identity
        {
            get
            {
                return new Matrix4(
                    1.0, 0.0, 0.0, 0.0,
                    0.0, 1.0, 0.0, 0.0,
                    0.0, 0.0, 1.0, 0.0,
                    0.0, 0.0, 0.0, 1.0);
            }
        }

        public static Matrix4 zero
        {
            get
            {
                return new Matrix4(
                    0.0, 0.0, 0.0, 0.0,
                    0.0, 0.0, 0.0, 0.0,
                    0.0, 0.0, 0.0, 0.0,
                    0.0, 0.0, 0.0, 0.0);
            }
        }

        public static Matrix4 Translate(Vector3 v)
        {
            return new Matrix4(
                1.0, 0.0, 0.0, v.x,
                0.0, 1.0, 0.0, v.y,
                0.0, 0.0, 1.0, v.z,
                0.0, 0.0, 0.0, 1.0);
        }

        public static Matrix4 RotateX(double angle)
        {
            return RotateXInRadian(Utils.DegreeToRadian(angle));
        }

        public static Matrix4 RotateXInRadian(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix4(
                1.0, 0.0,  0.0, 0.0,
                0.0, cos, -sin, 0.0,
                0.0, sin,  cos, 0.0,
                0.0, 0.0,  0.0, 1.0);
        }

        public static Matrix4 RotateY(double angle)
        {
            return RotateYInRadian(Utils.DegreeToRadian(angle));
        }

        public static Matrix4 RotateYInRadian(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix4(
                cos, 0.0, sin, 0.0,
                0.0, 1.0, 0.0, 0.0,
               -sin, 0.0, cos, 0.0,
                0.0, 0.0, 0.0, 1.0);
        }

        public static Matrix4 RotateZ(double angle)
        {
            return RotateZInRadian(Utils.DegreeToRadian(angle));
        }

        public static Matrix4 RotateZInRadian(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Matrix4(
                cos, -sin, 0.0, 0.0,
                sin,  cos, 0.0, 0.0,
                0.0,  0.0, 1.0, 0.0,
                0.0,  0.0, 0.0, 1.0);
        }

        public static Matrix4 Scale(Vector3 v)
        {
            return new Matrix4(
                v.x, 0.0, 0.0, 0.0,
                0.0, v.y, 0.0, 0.0,
                0.0, 0.0, v.z, 0.0,
                0.0, 0.0, 0.0, 1.0);
        }

        public static Matrix4 AngleAxis(double angle, Vector3 axis)
        {
            return AngleAxisInRadian(Utils.DegreeToRadian(angle), axis);
        }

        public static Matrix4 AngleAxisInRadian(double angle, Vector3 axis)
        {
            Vector3 n = axis.normalized;
            double x = n.x;
            double y = n.y;
            double z = n.z;
            double sin = Math.Sin(angle);
            double cos = Math.Cos(angle);
            double l_cos = 1.0 - cos;
            
            Matrix4 M = new Matrix4();
            M.m11 = x * x * l_cos + cos;
            M.m12 = x * y * l_cos - z * sin;
            M.m13 = x * z * l_cos + y * sin;
            M.m21 = y * x * l_cos + z * sin;
            M.m22 = y * y * l_cos + cos;
            M.m23 = y * z * l_cos - x * sin;
            M.m31 = x * z * l_cos - y * sin;
            M.m32 = y * z * l_cos + x * sin;
            M.m33 = z * z * l_cos + cos;
            return M;
        }

        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 M = new Matrix4();

            M.m11 = a.m11 * b.m11 + a.m12 * b.m21 + a.m13 * b.m31 + a.m14 * b.m41;
            M.m12 = a.m11 * b.m12 + a.m12 * b.m22 + a.m13 * b.m32 + a.m14 * b.m42;
            M.m13 = a.m11 * b.m13 + a.m12 * b.m23 + a.m13 * b.m33 + a.m14 * b.m43;
            M.m14 = a.m11 * b.m14 + a.m12 * b.m24 + a.m13 * b.m34 + a.m14 * b.m44;

            M.m21 = a.m21 * b.m11 + a.m22 * b.m21 + a.m23 * b.m31 + a.m24 * b.m41;
            M.m22 = a.m21 * b.m12 + a.m22 * b.m22 + a.m23 * b.m32 + a.m24 * b.m42;
            M.m23 = a.m21 * b.m13 + a.m22 * b.m23 + a.m23 * b.m33 + a.m24 * b.m43;
            M.m24 = a.m21 * b.m14 + a.m22 * b.m24 + a.m23 * b.m34 + a.m24 * b.m44;

            M.m31 = a.m31 * b.m11 + a.m32 * b.m21 + a.m33 * b.m31 + a.m34 * b.m41;
            M.m32 = a.m31 * b.m12 + a.m32 * b.m22 + a.m33 * b.m32 + a.m34 * b.m42;
            M.m33 = a.m31 * b.m13 + a.m32 * b.m23 + a.m33 * b.m33 + a.m34 * b.m43;
            M.m34 = a.m31 * b.m14 + a.m32 * b.m24 + a.m33 * b.m34 + a.m34 * b.m44;

            M.m41 = a.m41 * b.m11 + a.m42 * b.m21 + a.m43 * b.m31 + a.m44 * b.m41;
            M.m42 = a.m41 * b.m12 + a.m42 * b.m22 + a.m43 * b.m32 + a.m44 * b.m42;
            M.m43 = a.m41 * b.m13 + a.m42 * b.m23 + a.m43 * b.m33 + a.m44 * b.m43;
            M.m44 = a.m41 * b.m14 + a.m42 * b.m24 + a.m43 * b.m34 + a.m44 * b.m44;

            return M;
        }

        public static Vector3 operator *(Matrix4 m, Vector3 v)
        {
            return new Vector3(
                m.m11 * v.x + m.m12 * v.y + m.m13 * v.z + m.m14,
                m.m21 * v.x + m.m22 * v.y + m.m23 * v.z + m.m24,
                m.m31 * v.x + m.m32 * v.y + m.m33 * v.z + m.m34);
        }
    }
}
