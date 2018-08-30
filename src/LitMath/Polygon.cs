using System;
using System.Collections.Generic;

namespace LitMath
{
    /// <summary>
    /// 多边形
    /// </summary>
    public struct Polygon2
    {
        /// <summary>
        /// 点集合
        /// </summary>
        private List<Vector2> _pnts;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Polygon2(List<Vector2> pnts)
        {
            _pnts = new List<Vector2>(pnts.Count);
            _pnts.AddRange(pnts);
        }

        /// <summary>
        /// 判断点是否在多边形内
        /// 使用Winding Number(卷绕数)来判断
        /// https://en.wikipedia.org/wiki/Winding_number
        /// 适用于凸多边形
        /// </summary>
        public PointContainment IsContainsPoint(Vector2 pnt)
        {
            int count = _pnts.Count;
            double angle = 0.0;
            for (int i = 0,j = count - 1; i < count; j = i++)
            {
                angle += Vector2.SignedAngleInRadian(_pnts[j] - pnt, _pnts[i] - pnt);
            }
            if (angle < 0)
            {
                angle = -angle;
            }

            if (Utils.IsEqualZero(angle, 1e-5))
            {
                return PointContainment.Outside;
            }
            else if (Utils.IsEqualZero(angle - Utils.PI*2, 1e-5))
            {
                return PointContainment.Inside;
            }
            else
            {
                return PointContainment.Boundary;
            }

            #region
            //int crossing = 0;
            //int count = _pnts.Count;
            //Vector2 intersection = new Vector2(double.MaxValue, double.MaxValue);
            //Vector2 preInter = new Vector2();

            //for (int i = 0, j = count-1; i < count; j=i++)
            //{
            //    preInter = intersection;
            //    Line2 line = new Line2(_pnts[j], _pnts[i]);
            //    //if (LitMath.Line2.Intersect(line, pnt, new Vector2(1, 1), ref intersection))
            //    //{
            //    //    if (!preInter.Equals(intersection))
            //    //    {
            //    //        crossing++;
            //    //    }
            //    //}
            //    {
            //        Vector2 p = line.startPoint;
            //        Vector2 r = line.endPoint - line.startPoint;
            //        Vector2 q = pnt;
            //        Vector2 s = new Vector2(1, 1);
            //        double rxs = Vector2.Cross(r, s);
            //        if (!Utils.IsEqualZero(rxs, tol))
            //        {
            //            double t = Vector2.Cross(q - p, s) / rxs;
            //            double u = Vector2.Cross(q - p, r) / rxs;
            //            if (t >= (0.0 - tol) && t <= (1.0 + tol)
            //                && u >= (0.0 - tol))
            //            {
            //                intersection = p + t * r;
            //                crossing++;
            //            }
            //        }
            //        else if ()
            //        {

            //        }
            //    }
            //}

            //return (crossing % 2 != 0);
            #endregion
        }
    }

    public enum PointContainment
    {
        Inside = 0,
        Outside = 1,
        Boundary = 2,
    }
}
