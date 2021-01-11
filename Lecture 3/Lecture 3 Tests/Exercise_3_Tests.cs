using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;
using TestTools.Structure;
using static TestTools.Helpers.ExpressionHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        TestFactory factory = new TestFactory("Lecture_3");

        /* Exercise 3A */
        [TestMethod("a. Figure is abstract class"), TestCategory("Exercise 3A")]
        public void FigureIsAbstractClass()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertClass<Figure>(
                new ClassOptions()
                {
                    IsAbstract = true
                });
        }

        [TestMethod("b. Figure.CalculateArea() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureCalculateAreaIsAbstractMethod()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertMethod<Figure, double>(
                f => f.CalculateArea(),
                new MethodOptions()
                {
                    IsAbstract = true
                });
        }

        [TestMethod("c. Figure.Contains() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureContainsIsAbstractMethod()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertMethod<Figure, Point, bool>(
                (f, p) => f.Contains(p),
                new MethodOptions()
                {
                    IsAbstract = true
                });
        }

        /* Exercise 3B */
        [TestMethod("a. Circle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void CircleIsSubclassOfFigure() {
            StructureTest test = factory.CreateStructureTest();
            test.AssertClass<Circle>(
                new ClassOptions()
                {
                    BaseType = typeof(Figure)
                });
        }

        [TestMethod("b. Rectangle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void RectangleIsSubclassOfFigure()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertClass<Rectangle>(
                new ClassOptions()
                {
                    BaseType = typeof(Figure)
                });
        }

        /* Exercise 3C */
        [TestMethod("a. Circle.Center is public Point property"), TestCategory("Exercise 3C")]
        public void CenterIsPublicPointProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Circle, Point>(
                c => c.Center,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("b. Circle.Radius is public double property"), TestCategory("Exercise 3C")]
        public void RadiusIsPublicDoubleProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Circle, double>(
                c => c.Radius,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("c. Circle(Point center, double radius) ignores center = null"), TestCategory("3C")]
        public void CenterIgnoresAssigmentOfNull() 
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();

            test.Arrange(circle, () => new Circle(null, 1.0));
            test.Assert(circle, c => c.Center != null);

            test.Execute();
        }

        [TestMethod("d. Circle(Point center, double radius) ignores radius = -1.0"), TestCategory("3C")]
        public void RadiusIgnoresAssigmentOfMinusOne() 
        {
            Test test = factory.CreateTest();
            TestObject<Circle> circle = test.Create<Circle>();

            test.Arrange(circle, () => new Circle(new Point(0, 0), -1.0));
            test.Assert(circle, c => c.Radius != -1);

            test.Execute();
        }
        
        /* Exercise 3D */
        [TestMethod("a. Rectangle.P1 is public Point property"), TestCategory("Exercise 3D")]
        public void P1IsPublicPointProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Rectangle, Point>(
                r => r.P1,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("b. Regtangle.P2 is public Point property"), TestCategory("Exercise 3D")]
        public void P2IsPublicPointProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Rectangle, Point>(
                r => r.P2,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("c. Rectangle(Point p1, Point p2) ignores p1 = null"), TestCategory("Exercise 3D")]
        public void RectangleConstructorIgnoresP1ValueNull()
        {
            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(null, new Point(1, 1)));
            test.Assert(rectangle, r => r.P1 != null);

            test.Execute();
        }

        [TestMethod("d. Rectangle(Point p1, Point p2) ignores p2 = null"), TestCategory("Exercise 3D")]
        public void RegtangleConstructorIgnoresP2ValueNull() 
        {
            Test test = factory.CreateTest();
            TestObject<Rectangle> rectangle = test.Create<Rectangle>();

            test.Arrange(rectangle, () => new Rectangle(new Point(0, 0), null));
            test.Assert(rectangle, r => r.P2 != null);

            test.Execute();
        }

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
