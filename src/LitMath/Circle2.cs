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

        /// <summary>
        /// 求通过3点的圆
        /// http://blog.csdn.net/liyuanbhu/article/details/52891868
        /// </summary>
        public static Circle2 From3Points(Vector2 pnt1, Vector2 pnt2, Vector2 pnt3)
        {
            Circle2 circle = new Circle2();

            double a = pnt1.x - pnt2.x;
            double b = pnt1.y - pnt2.y;
            double c = pnt1.x - pnt3.x;
            double d = pnt1.y - pnt3.y;
            double e = (pnt1.x * pnt1.x - pnt2.x * pnt2.x + pnt1.y * pnt1.y - pnt2.y * pnt2.y) / 2.0;
            double f = (pnt1.x * pnt1.x - pnt3.x * pnt3.x + pnt1.y * pnt1.y - pnt3.y * pnt3.y) / 2.0;
            double det = b * c - a * d;

            if (Math.Abs(det) < Utils.EPSILON)
            {
                circle.center = new Vector2(0, 0);
                circle.radius = -1;
            }

            circle.center.x = -(d * e - b * f) / det;
            circle.center.y = -(a * f - c * e) / det;
            circle.radius = Math.Sqrt(
                (pnt1.x - circle.center.x) * (pnt1.x - circle.center.x)
                + (pnt1.y - circle.center.y) * (pnt1.y - circle.center.y));

            return circle;
        }
    }
}
