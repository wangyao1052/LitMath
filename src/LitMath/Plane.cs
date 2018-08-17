using System;

namespace LitMath
{
    /// <summary>
    /// 平面
    /// </summary>
    public struct Plane
    {
        private Vector3 _pointOnPlane;
        private Vector3 _normal;

        public Vector3 pointOnPlane
        {
            get { return _pointOnPlane; }
        }

        public Vector3 normal
        {
            get { return _normal; }
        }

        public Plane(Vector3 pntOnPlane, Vector3 normal)
        {
            _pointOnPlane = pntOnPlane;
            _normal = normal;
        }
    }
}
