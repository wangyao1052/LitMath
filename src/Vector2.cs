using System;

namespace LitMath
{
    public struct Vector2
    {
        public double x;
        public double y;

        public Vector2(double x = 0.0, double y = 0.0)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(double newX, double newY)
        {
            this.x = newX;
            this.y = newY;
        }

        public override string ToString()
        {
            return string.Format("Vector2({0}, {1})", this.x, this.y);
        }

        public double length
        {
            get
            {
                return Math.Sqrt((this.x * this.x) + (this.y * this.y));
            }
        }

        public double lengthSqrd
        {
            get
            {
                return ((this.x * this.x) + (this.y * this.y));
            }
        }

        public void Normalize()
        {
            double length = this.length;
            if (length != 0.0)
            {
                this.x /= length;
                this.y /= length;
            }
        }

        public Vector2 normalized
        {
            get
            {
                double length = this.length;
                if (length != 0.0)
                {
                    return new Vector2(this.x / length, this.y / length);
                }
                return this;
            }
        }

        public void Rotate(double angle)
        {
            double rad = Utils.DegreeToRadian(angle);
            this.RotateInRadian(rad);
        }

        public void RotateInRadian(double rad)
        {
            double xx = (this.x * Math.Cos(rad)) - (this.y * Math.Sin(rad));
            double yy = (this.x * Math.Sin(rad)) + (this.y * Math.Cos(rad));
            this.x = xx;
            this.y = yy;
        }

        public static double Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static double Cross(Vector2 a, Vector2 b)
        {
            return ((a.x * b.y) - (a.y * b.x));
        }

        public static double Angle(Vector2 a, Vector2 b)
        {
            return Utils.RadianToDegree(AngleInRadian(a, b));
        }

        public static double AngleInRadian(Vector2 a, Vector2 b)
        {
            double num = a.length * b.length;
            if (num == 0.0)
            {
                return 0.0;
            }
            double num2 = Dot(a, b) / num;
            return Math.Acos(Utils.Clamp(num2, -1.0, 1.0));
        }

        public static double Distance(Vector2 a, Vector2 b)
        {
            Vector2 vector = b - a;
            return vector.length;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }

        public static Vector2 operator *(Vector2 a, double d)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator *(double d, Vector2 a)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator /(Vector2 a, double d)
        {
            return new Vector2(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return (Utils.IsEqual(lhs.x, rhs.x) && Utils.IsEqual(lhs.y, rhs.y));
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }
    }
}
