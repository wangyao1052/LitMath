using System;
using System.Collections.Generic;
using System.Text;

namespace LitMath
{
    public class ViewUtils
    {
        public static Matrix4 ViewMatrix(Vector3 pos, Vector3 xAxis, Vector3 yAxis)
        {
            Vector3 xDir = xAxis.normalized;
            Vector3 yDir = yAxis.normalized;
            Vector3 zDir = Vector3.Cross(xDir, yDir).normalized;

            Matrix4 mRot = new Matrix4(
                 xDir.x, xDir.y, xDir.z, 0,
                 yDir.x, yDir.y, yDir.z, 0,
                 zDir.x, zDir.y, zDir.z, 0,
                 0,      0,      0,      1);

            Matrix4 mPos = new Matrix4(
                1, 0, 0, -pos.x,
                0, 1, 0, -pos.y,
                0, 0, 1, -pos.z,
                0, 0, 0, 1);

            return mRot * mPos;
        }
    }
}
