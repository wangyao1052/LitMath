using System;

namespace LitMath
{
    public struct Quaternion
    {
        public double x;
        public double y;
        public double z;
        public double w;

        public Quaternion(double x = 0.0, double y = 0.0, double z = 0.0, double w = 1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void Set(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void SetIdentity()
        {
            Set(0.0, 0.0, 0.0, 1.0);
        }

        public override string ToString()
        {
            return string.Format("Quaternion({0}, {1}, {2}, {3})",
                x, y, z, w);
        }

        public double length
        {
            get
            {
                return Math.Sqrt(x*x + y*y + z*z + w*w);
            }
        }

        public void Normalize()
        {
            double len = this.length;
            if (len != 0.0)
            {
                this.x /= len;
                this.y /= len;
                this.z /= len;
                this.w /= len;  
            }
        }

        public Quaternion normalized
        {
            get
            {
                double len = this.length;
                if (len != 0.0)
                {
                    return new Quaternion(this.x / len, this.y / len, this.z / len, this.w / len);
                }
                return new Quaternion(this.x, this.y, this.z, this.w);
            }
        }

        public void Invert()
        {
            x = -x;
            y = -y;
            z = -z;
        }

        public Quaternion inverse
        {
            get
            {
                return new Quaternion(-x, -y, -z, w);
            }
        }

        public Matrix4 ToMatrix4()
        {
            Matrix4 matrix = new Matrix4();
            matrix.m11 = 1.0-2.0*(y*y+z*z);
            matrix.m12 = 2.0*(x*y-z*w);
            matrix.m13 = 2.0*(x*z+y*w);
            matrix.m14 = 0.0;
    
            matrix.m21 = 2.0*(x*y+z*w);
            matrix.m22 = 1.0-2.0*(x*x+z*z);
            matrix.m23 = 2.0*(y*z-x*w);
            matrix.m24 = 0.0;
    
            matrix.m31 = 2.0*(x*z-y*w);
            matrix.m32 = 2.0*(y*z+x*w);
            matrix.m33 = 1.0-2.0*(x*x+y*y);
            matrix.m34 = 0.0;
    
            matrix.m41 = 0.0;
            matrix.m42 = 0.0;
            matrix.m43 = 0.0;
            matrix.m44 = 1.0;

            return matrix;
        }

        public static Quaternion identity
        {
            get
            {
                return new Quaternion(0.0, 0.0, 0.0, 1.0);
            }
        }

        public static Quaternion AngleAxis(double angle, Vector3 axis)
        {
            return AngleAxisInRadian(Utils.DegreeToRadian(angle), axis);
        }

        public static Quaternion AngleAxisInRadian(double angle, Vector3 axis)
        {
            axis = axis.normalized;
            double scale = Math.Sin(angle / 2);
            
            Quaternion quat = new Quaternion();
            quat.w = Math.Cos(angle / 2);
            quat.x = axis.x * scale;
            quat.y = axis.y * scale;
            quat.z = axis.z * scale;

            return quat;
        }

        public static Quaternion FromToRotation(Vector3 from, Vector3 to)
        {
            Vector3 u = from.normalized;
            Vector3 v = to.normalized;
            double dot = Vector3.Dot(u, v);
            Vector3 w = Vector3.Cross(u, v);
            
            if (w.length == 0.0)
            {
                if (dot >= 0.0)
                {
                    return Quaternion.identity;
                }
                else
                {
                    Vector3 t = Vector3.Cross(u, new Vector3(1.0, 0.0, 0.0));
                    if (Utils.IsEqualZero(t.length))
                    {
                        t = Vector3.Cross(u, new Vector3(0.0, 1.0, 0.0));
                    }
                    return new Quaternion(t.x, t.y, t.z, 0.0);
                }
            }
            else
            {
                double angleInRad = Math.Acos(dot);
                return Quaternion.AngleAxisInRadian(angleInRad, w);
            }
        }

        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            return new Quaternion(
                a.w * b.x + a.x * b.w + a.y * b.z - a.z * b.y,
                a.w * b.y - a.x * b.z + a.y * b.w + a.z * b.x,
                a.w * b.z + a.x * b.y - a.y * b.x + a.z * b.w,
                a.w * b.w - a.x * b.x - a.y * b.y - a.z * b.z);
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {
            double x  = q.x;
            double y  = q.y;
            double z  = q.z;
            double w  = q.w;
            double x2 = q.x * q.x;
            double y2 = q.y * q.y;
            double z2 = q.z * q.z;
            double w2 = q.w * q.w;
            
            return new Vector3(
                (x2 + w2 - y2 - z2) * v.x + 2.0 * (x * y - z * w) * v.y + 2.0 * (x * z + y * w) * v.z,
                2.0 * (x * y + z * w) * v.x + (w2 - x2 + y2 - z2) * v.y + 2.0 * (y * z - x * w) * v.z,
                2.0 * (x * z - y * w) * v.x + 2.0 * (x * w + y * z) * v.y + (w2 - x2 - y2 + z2) * v.z);
        }
    }
}
