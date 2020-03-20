using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWinForms
{
    public class Geometry
    {
        public static double GetDistanse(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double GetDistanse(Point p1, Point p2)
        {
            return GetDistanse(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static double GetDistanseToLine(int x1, int y1, int x2, int y2, int x0, int y0)
        {
            return Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1) /
                GetDistanse(x1, y1, x2, y2);
        }

        public static double GetDistanseToLine(Point p1, Point p2, Point p0)
        {
            return GetDistanseToLine(p1.X, p1.Y, p2.X, p2.Y, p0.X, p0.Y);
        }

        public static Point GetMidle(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }
    }
}
