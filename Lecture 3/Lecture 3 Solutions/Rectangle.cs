using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_3_Solutions
{
    public class Rectangle : Figure
    {
        Point _bottomRight;
        Point _topLeft;

        public Rectangle(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;

            if (p1 == null)
                P1 = new Point(0, 0);
            if (p2 == null)
                P2 = new Point(0, 0);
        }

        public Point P1 { get; }
        public Point P2 { get; }

        public override double CalculateArea()
        {
            double width = Math.Abs(P2.X - P1.X);
            double height = Math.Abs(P2.Y - P1.Y);
            return width * height;
        }

        public override bool Contains(Point p)
        {
            Point topLeft = new Point(Math.Max(P1.X, P2.X), Math.Max(P1.Y, P2.Y));
            Point bottomRight = new Point(Math.Min(P1.X, P2.X), Math.Min(P1.Y, P2.Y));

            if (p.X <= Math.Max(P1.X, P2.X))
                return false;
            if (p.X >= Math.Min(P1.X, P2.X))
                return false;
            if (p.Y >= Math.Max(P1.Y, P2.Y))
                return false;
            if (p.Y <= Math.Max(P1.Y, P2.Y))
                return false;

            return true;
        }
    }
}
