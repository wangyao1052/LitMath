using System;

namespace LitMath
{
    public struct Line2
    {
        public Vector2 startPoint;
        public Vector2 endPoint;

        public Line2(Vector2 startPnt, Vector2 endPnt)
        {
            this.startPoint = startPnt;
            this.endPoint = endPnt;
        }

        public Vector2 centerPoint
        {
            get
            {
                return new Vector2(
                    (this.startPoint.x + this.endPoint.x) / 2.0,
                    (this.startPoint.y + this.endPoint.y) / 2.0);
            }
        }

        public Vector2 direction
        {
            get
            {
                Vector2 vector = this.endPoint - this.startPoint;
                return vector.normalized;
            }
        }

        public double length
        {
            get
            {
                Vector2 vector = this.endPoint - this.startPoint;
                return vector.length;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Line2(({0}, {1}), ({2}, {3})",
                this.startPoint.x,
                this.startPoint.y,
                this.endPoint.x,
                this.endPoint.y);
        }

        /// <summary>
        /// 求线段的交点
        /// </summary>
        /// <param name="line1st">线段1</param>
        /// <param name="line2nd">线段2</param>
        /// <param name="intersection">交点</param>
        /// <returns>
        ///     true  --- 相交
        ///     false --- 不相交
        /// </returns>
        public static bool Intersect(Line2 line1st, Line2 line2nd, ref Vector2 intersection,
            double tolerance = 1e-10)
        {
            Vector2 p = line1st.startPoint;
            Vector2 r = line1st.endPoint - line1st.startPoint;
            Vector2 q = line2nd.startPoint;
            Vector2 s = line2nd.endPoint - line2nd.startPoint;
            double rxs = Vector2.Cross(r, s);
            if (!Utils.IsEqualZero(rxs, tolerance))
            {
                double t = Vector2.Cross(q - p, s) / rxs;
                double u = Vector2.Cross(q - p, r) / rxs;
                if (t >= (0.0-tolerance) && t <= (1.0+tolerance)
                    && u >= (0.0-tolerance) && u <= (1.0+tolerance))
                {
                    intersection = p + t * r;
                    return true;
                }
            }
            return false;
        }
    }
}
