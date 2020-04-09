using System;
using System.Drawing;

namespace GraphWinForms
{
    public class VisVertex:ICloneable
    {
        public string Name { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public VisVertex(string name, int x, int y)
        {
            Name = name;
            PositionX = x;
            PositionY = y;
        }

        public VisVertex(string name, Point point)
        {
            Name = name;
            PositionX = point.X;
            PositionY = point.Y;
        }

        public Point GetPoint => new Point(PositionX, PositionY);

        public void SetPoint(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        public void SetPoint(Point point)
        {
            PositionX = point.X;
            PositionY = point.Y;
        }

        public object Clone()
        {
            return new VisVertex((string)Name.Clone(), PositionX, PositionY);
        }
    }
}
