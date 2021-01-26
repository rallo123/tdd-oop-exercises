using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.StructureTests;
using TestTools.UnitTests;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_3_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        #region Exercise 3A
        [TestMethod("a. Figure is abstract class"), TestCategory("Exercise 3A")]
        public void FigureIsAbstractClass()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Figure>(t => t.IsAbstract);
            test.Execute();
        }

        [TestMethod("b. Figure.CalculateArea() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureCalculateAreaIsAbstractMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Figure, double>(f => f.CalculateArea(), IsAbstractMethod);
            test.Execute();
        }

        [TestMethod("c. Figure.Contains() is abstract method"), TestCategory("Exercise 3A")]
        public void FigureContainsIsAbstractMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<Figure, Point, bool>((f, p) => f.Contains(p), IsAbstractMethod);
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. Circle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void CircleIsSubclassOfFigure() {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Circle>(t => t.BaseType == typeof(Figure));
            test.Execute();
        }

        [TestMethod("b. Rectangle is subclass of Figure"), TestCategory("Exercise 3B")]
        public void RectangleIsSubclassOfFigure()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<Rectangle>(t => t.BaseType == typeof(Figure));
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. Circle.Center is public read-only Point property"), TestCategory("Exercise 3C")]
        public void CenterIsPublicPointProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Circle, Point>(c => c.Center, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Circle.Radius is public read-only double property"), TestCategory("Exercise 3C")]
        public void RadiusIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Circle, double>(c => c.Radius, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("c. Circle(Point center, double radius) ignores center = null"), TestCategory("3C")]
        public void CenterIgnoresAssigmentOfNull() 
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            test.Arrange(circle, Expr(() => new Circle(null, 1.0)));
            test.Assert.IsNotNull(Expr(circle, c => c.Center));

            test.Execute();
        }

        [TestMethod("d. Circle(Point center, double radius) ignores radius = -1.0"), TestCategory("3C")]
        public void RadiusIgnoresAssigmentOfMinusOne() 
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            test.Arrange(circle, Expr(() => new Circle(new Point(0, 0), -1.0)));
            test.Assert.AreNotEqual(Expr(circle, c => c.Radius), Const(-1.0));

            test.Execute();
        }
        #endregion

        #region Exercise 3D
        [TestMethod("a. Rectangle.P1 is public read-only Point property"), TestCategory("Exercise 3D")]
        public void P1IsPublicPointProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Rectangle, Point>(r => r.P1, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. Regtangle.P2 is public read-only Point property"), TestCategory("Exercise 3D")]
        public void P2IsPublicPointProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Rectangle, Point>(r => r.P2, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("c. Rectangle(Point p1, Point p2) ignores p1 = null"), TestCategory("Exercise 3D")]
        public void RectangleConstructorIgnoresP1ValueNull()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(null, new Point(1, 1))));
            test.Assert.IsNotNull(Expr(rectangle, r => r.P1));

            test.Execute();
        }

        [TestMethod("d. Rectangle(Point p1, Point p2) ignores p2 = null"), TestCategory("Exercise 3D")]
        public void RegtangleConstructorIgnoresP2ValueNull() 
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(new Point(0, 0), null)));
            test.Assert.IsNotNull(Expr(rectangle, r => r.P2));

            test.Execute();
        }
        #endregion

        #region Exercise 3E
        [TestMethod("a. Circle.CalculateArea() returns expected output"), TestCategory("Exercise 3E")]
        public void CircleCalculateAreaReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            Circle orignalCircle = new Circle(new Point(0, 0), 42.3);
            test.Arrange(circle, Expr(() => new Circle(new Point(0, 0), 42.3)));
            test.Assert.AreEqual(Expr(circle, c => c.CalculateArea()), Const(orignalCircle.CalculateArea()));

            test.Execute();
        }

        [TestMethod("b. Circle.Contains(Point p) returns true for point within circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnTrueForPointWithinCircle()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            test.Arrange(circle, Expr(() => new Circle(new Point(2, 3), 1)));
            test.Assert.IsTrue(Expr(circle, c => c.Contains(new Point(2.5, 3))));

            test.Execute();
        }

        [TestMethod("c. Circle.Contains(Point p) returns true for point on perimeter of circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnTrueForPointOnPerimeterOfCircle()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            test.Arrange(circle, Expr(() => new Circle(new Point(2, 3), 1)));
            test.Assert.IsTrue(Expr(circle, c => c.Contains(new Point(3, 3))));

            test.Execute();
        }
        
        [TestMethod("d. Circle.Contains(Point p) returns false for point outside of circle"), TestCategory("Exercise 3E")]
        public void CircleContainsReturnFalseForPointOutsideOfCircle()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Circle> circle = test.CreateVariable<Circle>(nameof(circle));

            test.Arrange(circle, Expr(() => new Circle(new Point(2, 3), 1)));
            test.Assert.IsFalse(Expr(circle, c => c.Contains(new Point(4, 3))));

            test.Execute();
        }

        [TestMethod("e. Rectangle.CalculateArea() returns expected output"), TestCategory("Exercise 3E")]
        public void RectangleCalculateAreaReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(new Point(0, 0), new Point(2, 3))));
            test.Assert.AreEqual(Expr(rectangle, r => r.CalculateArea()), Const(6.0));

            test.Execute();
        }

        [TestMethod("f. Rectangle.Contains(Point p) returns true for point within rectangle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnTrueForPointWithinRectangle()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(new Point(2, 3), new Point(3, 5))));
            test.Assert.IsTrue(Expr(rectangle, r => r.Contains(new Point(2.5, 3))));

            test.Execute();
        }

        [TestMethod("g. Rectangle.Contains(Point p) returns true for point on perimeter of rectangle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnTrueForPointOnPerimeterOfRectangle()
        {

            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(new Point(2, 3), new Point(3, 5))));
            test.Assert.IsTrue(Expr(rectangle, r => r.Contains(new Point(3, 3))));

            test.Execute();
        }

        [TestMethod("h. Rectangle.Contains(Point p) returns false for point outside of circle"), TestCategory("Exercise 3E")]
        public void RectangleContainsReturnFalseForPointOutsideOfRectangle()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Rectangle> rectangle = test.CreateVariable<Rectangle>(nameof(rectangle));

            test.Arrange(rectangle, Expr(() => new Rectangle(new Point(2, 3), new Point(3, 5))));
            test.Assert.IsFalse(Expr(rectangle, r => r.Contains(new Point(4, 3))));

            test.Execute();
        }
        #endregion
    }
}
