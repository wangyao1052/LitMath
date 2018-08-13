using System;

namespace LitMath
{
    /// <summary>
    /// 二维线段
    /// </summary>
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
        /// https://stackoverflow.com/questions/563198/how-do-you-detect-where-two-line-segments-intersect
        /// <param name="line1st">线段1</param>
        /// <param name="line2nd">线段2</param>
        /// <param name="intersection">交点</param>
        /// <returns>
        ///     true  --- 相交
        ///     false --- 不相交
        /// </returns>
        public static bool Intersect(
            Line2 line1st, Line2 line2nd,
            ref Vector2 intersection,
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

        /// <summary>
        /// 求线段与射线的交点
        /// </summary>
        /// https://stackoverflow.com/questions/14307158/how-do-you-check-for-intersection-between-a-line-segment-and-a-line-ray-emanatin
        /// <param name="line"></param>
        /// <param name="rayPnt"></param>
        /// <param name="rayDir"></param>
        /// <param name="intersection"></param>
        /// <param name="tol"></param>
        /// <returns></returns>
        public static bool Intersect(
            Line2 line, Vector2 rayPnt, Vector2 rayDir,
            ref Vector2 intersection,
            double tol = 1e-10)
        {
            Vector2 p = line.startPoint;
            Vector2 r = line.endPoint - line.startPoint;
            Vector2 q = rayPnt;
            Vector2 s = rayDir;
            double rxs = Vector2.Cross(r, s);
            if (!Utils.IsEqualZero(rxs, tol))
            {
                double t = Vector2.Cross(q - p, s) / rxs;
                double u = Vector2.Cross(q - p, r) / rxs;
                if (t >= (0.0 - tol) && t <= (1.0 + tol)
                    && u >= (0.0 - tol))
                {
                    intersection = p + t * r;
                    return true;
                }
            }
            return false;
        }
    }
}
