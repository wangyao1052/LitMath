using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //LitMath.Vector2 v1 = new LitMath.Vector2(1, 3);
            //Console.WriteLine(v1.ToString());

            LitMath.Line2 line1 = new LitMath.Line2(
                new LitMath.Vector2(0, 0),
                new LitMath.Vector2(10, 0));
            line1.startPoint.x = 10;
            LitMath.Line2 line2 = new LitMath.Line2(
                new LitMath.Vector2(5, 0),
                new LitMath.Vector2(5, 10));

            LitMath.Vector2 intersection = new LitMath.Vector2();
            if (LitMath.Line2.Intersect(line1, line2, ref intersection))
            {
                Console.WriteLine("相交: " + intersection.ToString());
            }

            LitMath.Rectangle2 rect = new LitMath.Rectangle2(new LitMath.Vector2(10, 10), 10, 20);
            Console.WriteLine(rect.ToString());
            Console.WriteLine(rect.leftBottom.ToString());
            Console.WriteLine(rect.leftTop.ToString());
            Console.WriteLine(rect.rightTop.ToString());
            Console.WriteLine(rect.rightBottom.ToString());

            LitMath.Circle2 circle = new LitMath.Circle2(new LitMath.Vector2(25, 25), 10);
            Console.WriteLine(circle.ToString());
            Console.WriteLine(circle.diameter.ToString());
        }
    }

}
