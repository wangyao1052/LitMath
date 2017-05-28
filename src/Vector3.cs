using System;

namespace Canvas.LiteMath
{
    public struct Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x = 0.0, double y = 0.0, double z = 0.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Set(double newX, double newY, double newZ)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
        }

        public override string ToString()
        {
            return string.Format("Vector3({0}, {1}, {2})", this.x, this.y, this.z);
        }

        public double length
        {
            get
            {
                return Math.Sqrt(((this.x * this.x) + (this.y * this.y)) + (this.z * this.z));
            }
        }

        public double lengthSqrd
        {
            get
            {
                return (((this.x * this.x) + (this.y * this.y)) + (this.z * this.z));
            }
        }

        public void Normalize()
        {
            double length = this.length;
            if (length != 0.0)
            {
                this.x /= length;
                this.y /= length;
                this.z /= length;
            }
        }

        public Vector3 normalized
        {
            get
            {
                double length = this.length;
                if (length != 0.0)
                {
                    return new Vector3(this.x / length, this.y / length, this.z / length);
                }
                return this;
            }
        }

        public static double Dot(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                (a.y * b.z) - (a.z * b.y),
                (a.z * b.x) - (a.x * b.z),
                (a.x * b.y) - (a.y * b.x));
        }

        public static double Angle(Vector3 a, Vector3 b)
        {
            return Utils.RadianToDegree(AngleInRadian(a, b));
        }

        public static double AngleInRadian(Vector3 a, Vector3 b)
        {
            double num = a.length * b.length;
            if (num == 0.0)
            {
                return 0.0;
            }
            double num2 = Dot(a, b) / num;
            return Math.Acos(Utils.Clamp(num2, -1.0, 1.0));
        }

        public static double Distance(Vector3 a, Vector3 b)
        {
            return (b - a).length;
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public static Vector3 operator *(Vector3 v, double d)
        {
            return new Vector3(v.x * d, v.y * d, v.z * d);
        }

        public static Vector3 operator *(double d, Vector3 v)
        {
            return new Vector3(v.x * d, v.y * d, v.z * d);
        }

        public static Vector3 operator /(Vector3 v, double d)
        {
            return new Vector3(v.x / d, v.y / d, v.z / d);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return Utils.IsEqual(lhs.x, rhs.x) 
                && Utils.IsEqual(lhs.y, rhs.y)
                && Utils.IsEqual(lhs.z, rhs.z);
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }
    }
}
