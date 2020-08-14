using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools;
using TestTools.Structure;
using TestTools.Structure.Generic;
using Lecture_3_Solutions;
using TestTools.Operation;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
#pragma warning disable IDE1006 // Naming Stylesw
        private ClassElement<Point> point => new ClassElement<Point>();
        private PropertyElement<Point, double> pointX => point.Property<double>("X", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Point, double> pointY => point.Property<double>("Y", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private Point CreatePoint(double x, double y)
        {
            return point.Constructor<double, double>().Invoke(x, y);
        }

        private ClassElement<Figure> figure => new ClassElement<Figure>(new ClassOptions() { IsAbstract = true });
        private FuncMethodElement<Figure, double> figureCalculateArea => figure.FuncMethod<double>("CalculateArea", new MethodOptions() { AccessLevel = AccessLevel.Public, IsAbstract = true });
        private FuncMethodElement<Figure, Point, bool> figureContains => figure.FuncMethod<Point, bool>("Contains", new MethodOptions() { AccessLevel = AccessLevel.Public, IsAbstract = true });

        private ClassElement<Circle> circle => new ClassElement<Circle>(new ClassOptions() { BaseType = typeof(Figure) });
        private PropertyElement<Circle, Point> circleCenter => circle.Property<Point>("Center", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Circle, double> circleRadius => circle.Property<double>("Radius", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Circle, double> circleCalculateArea => circle.FuncMethod<double>("CalculateArea", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Circle, Point, bool> circleContains => circle.FuncMethod<Point, bool>("Contains", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private Circle CreateCircle(Point center = null, double? radius = null)
        {
            return circle.Constructor<Point, double>().Invoke(center ?? new Point(0, 0), radius ?? 1);
        } 

        private ClassElement<Rectangle> rectangle => new ClassElement<Rectangle>(new ClassOptions() { BaseType = typeof(Figure) });
        private PropertyElement<Rectangle, Point> rectangleP1 => rectangle.Property<Point>("P1", new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Rectangle, Point> rectangleP2 => rectangle.Property<Point>("P2", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Rectangle, double> rectangleCalculateArea => rectangle.FuncMethod<double>("CalculateArea", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Rectangle, Point, bool> rectangleContains => rectangle.FuncMethod<Point, bool>("Contains", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private Rectangle CreateRectangle(Point p1 = null, Point p2 = null)
        {
            return rectangle.Constructor<Point, Point>().Invoke(p1 ?? new Point(0, 0), p2 ?? new Point(0, 0));
        }
        private void DoNothing(object par) { }
#pragma warning restore IDE1006 // Naming Styles

        /* Exercise 3A */
        [TestMethod("a. Figure is abstract class"), TestCategory("Exercise 3A")]
        public void FigureIsAbstractClass() => DoNothing(figure);

        [TestMethod("b. Figure.CalculateArea() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureCalculateAreaIsAbstractMethod() => DoNothing(figureCalculateArea);

        [TestMethod("c. Figure.Contains() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureContainsIsAbstractMethod() => DoNothing(figureContains);

        /* Exercise 3B */
        [TestMethod("a. Circle is subclass of Figure"), TestCategory("3B")]
        public void CircleIsSubclassOfFigure() => DoNothing(circle);

        [TestMethod("b. Rectangle is subclass of Figure"), TestCategory("3B")]
        public void RectangleIsSubclassOfFigure() => DoNothing(rectangle);

        /* Exercise 3C */
        [TestMethod("a. Circle.Center is public Point property"), TestCategory("3C")]
        public void CenterIsPublicPointProperty() => DoNothing(circleCenter);

        [TestMethod("b. Circle.Radius is public double property"), TestCategory("3C")]
        public void RadiusIsPublicDoubleProperty() => DoNothing(circleRadius);
        /*
        [TestMethod("c. Circle(Point center, double radius) ignores center = null"), TestCategory("3C")]
        public void CenterIgnoresAssigmentOfNull() => Assignment.Ignored(CreateCircle(), circleCenter, null);

        [TestMethod("d. Circle(Point center, double radius) ignores radius = -1.0"), TestCategory("3C")]
        public void RadiusIgnoresAssigmentOfMinusOne() => Assignment.Ignored(CreateCircle(), circleRadius, -1.0);
        */
        /* Exercise 3D */
        [TestMethod("a. Rectangle.P1 is public Point property"), TestCategory("3D")]
        public void P1IsPublicPointProperty() => DoNothing(rectangleP1);

        [TestMethod("b. Regtangle.P2 is public Point property"), TestCategory("3D")]
        public void P2IsPublicPointProperty() => DoNothing(rectangleP2);
        
        [TestMethod("c. Rectangle(Point p1, Point p2) ignores p1 = null"), TestCategory("3D")]
        public void RectangleConstructorIgnoresP1ValueNull() => DoNothing(rectangleP1);

        [TestMethod("d. Rectangle(Point p1, Point p2) ignores p2 = null"), TestCategory("3D")]
        public void RegtangleConstructorIgnoresP1ValueNull() => DoNothing(rectangleP2);

        /* Exercise 3E */
        [TestMethod("a. Circle.CalculateArea() returns expected output"), TestCategory("3E")]
        public void CircleCalculateAreaReturnsExpectedOutput()
        {
            double r = 42.3;
            Circle instance = CreateCircle(radius: r);
            double actualArea = circleCalculateArea.Invoke(instance);
            double expectedArea = Math.Pow(r, 2) * Math.PI;

            if (Math.Abs(actualArea - expectedArea) > 0.3)
            {
                string message = string.Format(
                    "Circle.CalculateArea() returns {0} instead of {1} for Radius = {2}",
                    actualArea,
                    expectedArea,
                    r
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("b. Circle.Contains(Point p) returns true for point within circle"), TestCategory("3E")]
        public void CircleContainsReturnTrueForPointWithinCircle()
        {
            Circle circle = CreateCircle(CreatePoint(2, 3), 1);

            if (!circleContains.Invoke(circle, CreatePoint(2.5, 3)))
            {
                string message = string.Format(
                    "Circle.Contains(Point p) returns false instead if true for Center = (2, 3), Radius = 1 & p = (2.5, 3)"
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("c. Circle.Contains(Point p) returns true for point on perimeter of circle"), TestCategory("3E")]
        public void CircleContainsReturnTrueForPointOnPerimeterOfCircle()
        {
            Circle circle = CreateCircle(CreatePoint(2, 3), 1);

            if (!circleContains.Invoke(circle, CreatePoint(3, 3)))
            {
                string message = string.Format(
                    "Circle.Contains(Point p) returns false instead if true for Center = (2, 3), Radius = 1 & p = (3, 3)"
                );
                throw new AssertFailedException(message);
            }
        }
        
        [TestMethod("d. Circle.Contains(Point p) returns false for point outside of circle"), TestCategory("3E")]
        public void CircleContainsReturnFalseForPointOutsideOfCircle()
        {
            Circle circle = CreateCircle(CreatePoint(2, 3), 1);

            if (circleContains.Invoke(circle, CreatePoint(4, 3)))
            {
                string message = string.Format(
                    "Circle.Contains(Point p) returns false instead if true for Center = (2, 3), Radius = 1 & p = (4, 3)"
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("e. Rectangle.CalculateArea() returns expected output"), TestCategory("3E")]
        public void RectangleCalculateAreaReturnsExpectedOutput()
        {
            Rectangle instance = CreateRectangle(CreatePoint(0, 0), CreatePoint(2, 3));
            double actualArea = rectangleCalculateArea.Invoke(instance);
            double expectedArea = 2 * 3;

            if (actualArea != expectedArea)
            {
                string message = string.Format(
                    "Rectangle.CalculateArea() returns {0} instead of {1} for P1 = (0, 0) & P2 = (2, 3)",
                    actualArea,
                    expectedArea
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("f. Rectangle.Contains(Point p) returns true for point within rectangle"), TestCategory("3E")]
        public void RectangleContainsReturnTrueForPointWithinRectangle()
        {
            Rectangle rect = CreateRectangle(CreatePoint(2, 3), CreatePoint(3, 5));

            if (!rectangleContains.Invoke(rect, CreatePoint(2.5, 3)))
            {
                string message = string.Format(
                    "Rectangle.Contains(Point p) returns false instead if true for P1 = (2, 3), P2 = (3, 5) & p = (2.5, 3)"
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("g. Rectangle.Contains(Point p) returns true for point on perimeter of rectangle"), TestCategory("3E")]
        public void RectangleContainsReturnTrueForPointOnPerimeterOfRectangle()
        {
            Rectangle rect = CreateRectangle(CreatePoint(2, 3), CreatePoint(3, 5));

            if (!rectangleContains.Invoke(rect, CreatePoint(3, 3)))
            {
                string message = string.Format(
                    "Rectangle.Contains(Point p) returns false instead if true for P1 = (2, 3), P2 = (3, 5) & p = (3, 3)"
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("h. Rectangle.Contains(Point p) returns false for point outside of circle"), TestCategory("3E")]
        public void RectangleContainsReturnFalseForPointOutsideOfRectangle()
        {
            Rectangle rect = CreateRectangle(CreatePoint(2, 3), CreatePoint(3, 5));

            if (rectangleContains.Invoke(rect, CreatePoint(4, 3)))
            {
                string message = string.Format(
                    "Circle.Contains(Point p) returns false instead if true for P1 = (2, 3), P2 = (3, 5) & p = (4, 3)"
                );
                throw new AssertFailedException(message);
            }
        }
    }
}
