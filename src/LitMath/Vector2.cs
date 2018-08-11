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

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2))
                return false;

            return Equals((Vector2)obj);
        }

        public bool Equals(Vector2 rhs)
        {
            return (Utils.IsEqual(x, rhs.x) && Utils.IsEqual(y, rhs.y));
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
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

        public static double Dot(Vector2 a, Vector2 b)
        {
            return a.x * b.x + a.y * b.y;
        }

        public static double Cross(Vector2 a, Vector2 b)
        {
            return ((a.x * b.y) - (a.y * b.x));
        }

        /// <summary>
        /// Returns the unsigned angle in degrees between a and b.
        /// The smaller of the two possible angles between the two vectors is used.
        /// The result value range: [0, 180]
        /// </summary>
        public static double Angle(Vector2 a, Vector2 b)
        {
            return Utils.RadianToDegree(AngleInRadian(a, b));
        }

        /// <summary>
        /// Returns the unsigned angle in radians between a and b.
        /// The smaller of the two possible angles between the two vectors is used.
        /// The result value range: [0, PI]
        /// </summary>
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

        /// <summary>
        /// Returns the signed acute clockwise angle in degrees between from and to.
        /// The result value range: [-180, 180]
        /// </summary>
        public static double SignedAngle(Vector2 from, Vector2 to)
        {
            return Utils.RadianToDegree(SignedAngleInRadian(from, to));
        }

        /// <summary>
        /// Returns the signed acute clockwise angle in radians between from and to.
        /// The result value range: [-PI, PI]
        /// </summary>
        public static double SignedAngleInRadian(Vector2 from, Vector2 to)
        {
            double rad = AngleInRadian(from, to);
            if (Cross(from, to) < 0)
            {
                rad = -rad;
            }
            return rad;
        }

        public static double Distance(Vector2 a, Vector2 b)
        {
            Vector2 vector = b - a;
            return vector.length;
        }

        public static Vector2 Rotate(Vector2 v, double angle)
        {
            return RotateInRadian(v, Utils.DegreeToRadian(angle));
        }

        public static Vector2 Rotate(Vector2 point, Vector2 basePoint, double angle)
        {
            return RotateInRadian(point, basePoint, Utils.DegreeToRadian(angle));
        }

        public static Vector2 RotateInRadian(Vector2 v, double rad)
        {
            double x = v.x * Math.Cos(rad) - v.y * Math.Sin(rad);
            double y = v.x * Math.Sin(rad) + v.y * Math.Cos(rad);
            return new Vector2(x, y);
        }

        public static Vector2 RotateInRadian(Vector2 point, Vector2 basePoint, double rad)
        {
            double cos = Math.Cos(rad);
            double sin = Math.Sin(rad);
            double x = point.x * cos - point.y * sin + basePoint.x * (1 - cos) + basePoint.y * sin;
            double y = point.x * sin + point.y * cos + basePoint.y * (1 - cos) + basePoint.x * sin;

            return new Vector2(x, y);
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
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }
    }
}
