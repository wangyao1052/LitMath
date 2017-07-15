using System;

namespace LitMath
{
    public struct Circle2
    {
        public Vector2 center;
        public double radius;

        public double diameter
        {
            get { return radius * 2; }
        }

        public Circle2(Vector2 center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override string ToString()
        {
            return string.Format("Circle2(({0}, {1}), {2})",
                this.center.x, this.center.y, this.radius);
        }
    }
}
