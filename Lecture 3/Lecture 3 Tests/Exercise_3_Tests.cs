using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        TestFactory factory = new TestFactory("Lecture_3");

        /* Exercise 3A */
        [TestMethod("a. Figure is abstract class"), TestCategory("Exercise 3A")]
        public void FigureIsAbstractClass() => throw new NotImplementedException();

        [TestMethod("b. Figure.CalculateArea() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureCalculateAreaIsAbstractMethod() => throw new NotImplementedException();

        [TestMethod("c. Figure.Contains() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureContainsIsAbstractMethod() => throw new NotImplementedException();

        /* Exercise 3B */
        [TestMethod("a. Circle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void CircleIsSubclassOfFigure() => throw new NotImplementedException();

        [TestMethod("b. Rectangle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void RectangleIsSubclassOfFigure() => throw new NotImplementedException();

        /* Exercise 3C */
        [TestMethod("a. Circle.Center is public Point property"), TestCategory("Exercise 3C")]
        public void CenterIsPublicPointProperty() => throw new NotImplementedException();

        [TestMethod("b. Circle.Radius is public double property"), TestCategory("Exercise 3C")]
        public void RadiusIsPublicDoubleProperty() => throw new NotImplementedException();
        /*
        [TestMethod("c. Circle(Point center, double radius) ignores center = null"), TestCategory("3C")]
        public void CenterIgnoresAssigmentOfNull() => Assignment.Ignored(CreateCircle(), circleCenter, null);

        [TestMethod("d. Circle(Point center, double radius) ignores radius = -1.0"), TestCategory("3C")]
        public void RadiusIgnoresAssigmentOfMinusOne() => Assignment.Ignored(CreateCircle(), circleRadius, -1.0);
        */
        /* Exercise 3D */
        [TestMethod("a. Rectangle.P1 is public Point property"), TestCategory("Exercise 3D")]
        public void P1IsPublicPointProperty() => throw new NotImplementedException();

        [TestMethod("b. Regtangle.P2 is public Point property"), TestCategory("Exercise 3D")]
        public void P2IsPublicPointProperty() => throw new NotImplementedException();

        [TestMethod("c. Rectangle(Point p1, Point p2) ignores p1 = null"), TestCategory("Exercise 3D")]
        public void RectangleConstructorIgnoresP1ValueNull() => throw new NotImplementedException();

        [TestMethod("d. Rectangle(Point p1, Point p2) ignores p2 = null"), TestCategory("Exercise 3D")]
        public void RegtangleConstructorIgnoresP1ValueNull() => throw new NotImplementedException();

        /* Exercise 3E */
        [TestMethod("a. Circle.CalculateArea() returns expected output"), TestCategory("Exercise 3E")]
        public void CircleCalculateAreaReturnsExpectedOutput()
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();
            double r = 42.3;
            double expectedArea = Math.Pow(r, 2) * Math.PI;

            test.Arrange(circle, () => new Circle(new Point(0, 0), r));
            test.AssertApproximate(circle, c => c.CalculateArea() == expectedArea);

            test.Execute();
        }

        [TestMethod("b. Circle.Contains(Point p) returns true for point within circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnTrueForPointWithinCircle()
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();

            test.Arrange(circle, () => new Circle(new Point(2, 3), 1));
            test.Assert(circle, c => c.Contains(new Point(2.5, 3)));

            test.Execute();
        }

        [TestMethod("c. Circle.Contains(Point p) returns true for point on perimeter of circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnTrueForPointOnPerimeterOfCircle()
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();

            test.Arrange(circle, () => new Circle(new Point(2, 3), 1));
            test.Assert(circle, c => c.Contains(new Point(3, 3)));

            test.Execute();
        }
        
        [TestMethod("d. Circle.Contains(Point p) returns false for point outside of circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnFalseForPointOutsideOfCircle()
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();

            test.Arrange(circle, () => new Circle(new Point(2, 3), 1));
            test.Assert(circle, c => !c.Contains(new Point(4, 3)));

            test.Execute();
        }

        [TestMethod("e. Rectangle.CalculateArea() returns expected output"), TestCategory("Exercise 3E")]
        public void RectangleCalculateAreaReturnsExpectedOutput()
        {
            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(new Point(0, 0), new Point(2, 3)));
            test.Assert(rectangle, r => r.CalculateArea() == 6);

            test.Execute();
        }

        [TestMethod("f. Rectangle.Contains(Point p) returns true for point within rectangle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnTrueForPointWithinRectangle()
        {
            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(new Point(2, 3), new Point(3, 5)));
            test.Assert(rectangle, r => r.Contains(new Point(2.5, 3)));

            test.Execute();
        }

        [TestMethod("g. Rectangle.Contains(Point p) returns true for point on perimeter of rectangle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnTrueForPointOnPerimeterOfRectangle()
        {

            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(new Point(2, 3), new Point(3, 5)));
            test.Assert(rectangle, r => r.Contains(new Point(3, 3)));

            test.Execute();
        }

        [TestMethod("h. Rectangle.Contains(Point p) returns false for point outside of circle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnFalseForPointOutsideOfRectangle()
        {
            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(new Point(2, 3), new Point(3, 5)));
            test.Assert(rectangle, r => !r.Contains(new Point(4, 3)));

            test.Execute();
        }
    }
}
