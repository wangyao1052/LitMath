using System;

namespace LitMath
{
    public struct Rectangle2
    {
        /// <summary>
        /// 位置,也就是矩形的左下角坐标
        /// </summary>
        public Vector2 location;

        /// <summary>
        /// 宽、高
        /// </summary>
        public double width;
        public double height;

        public Vector2 leftBottom
        {
            get { return location; }
        }

        public Vector2 leftTop
        {
            get
            {
                return new Vector2(this.location.x, this.location.y + height);
            }
        }

        public Vector2 rightTop
        {
            get
            {
                return new Vector2(this.location.x + this.width,
                    this.location.y + this.height);
            }
        }

        public Vector2 rightBottom
        {
            get
            {
                return new Vector2(this.location.x + this.width, this.location.y);
            }
        }

        public Rectangle2(Vector2 location, double width, double height)
        {
            this.location = location;
            this.width = width;
            this.height = height;
        }

        public Rectangle2(Vector2 point1, Vector2 point2)
        {
            double minX = point1.x < point2.x ? point1.x : point2.x;
            double minY = point1.y < point2.y ? point1.y : point2.y;
            this.location = new Vector2(minX, minY);
            this.width = Math.Abs(point2.x - point1.x);
            this.height = Math.Abs(point2.y - point1.y);
        }

        public override string ToString()
        {
            return string.Format("Rectangle2(({0}, {1}), {2}, {3})",
                this.location.x,
                this.location.y,
                this.width,
                this.height);
        }
    }
}
