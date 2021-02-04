using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using TestTools.Structure;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        #region Exercise 1B
        [TestMethod("a. ArrayHelper is an static class"), TestCategory("1B")]
        public void ArrayHelperIsAnStaticClass()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass(typeof(ArrayHelper), IsStaticClass);
            test.Execute();
        }

        [TestMethod("b. ArrayHelper.Filter is a public method"), TestCategory("1B")]
        public void ArrayHelperFilterIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, int[]>((array, p) => ArrayHelper.Filter(array, p), IsPublicMethod);
            test.AssertStaticMethod<double[], Predicate<double>, double[]>((array, p) => ArrayHelper.Filter(array, p), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("c. ArrayHelper.Map is a public method"), TestCategory("1B")]
        public void ArrayHelperMapIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Func<int, double>, double[]>((array, f) => ArrayHelper.Map(array, f), IsPublicMethod);
            test.AssertStaticMethod<double[], Func<double, int>, int[]>((array, f) => ArrayHelper.Map(array, f), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("d. ArrayHelper.Sort is a public method"), TestCategory("1B")]
        public void ArrayHelperSortIsPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<string[], Func<string, string, int>>((array, c) => ArrayHelper.Sort(array, c), IsPublicMethod);
            test.AssertStaticMethod<double[], Func<double, double, int>>((array, c) => ArrayHelper.Sort(array, c), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("e. ArrayHelper.Find is a public method"), TestCategory("1B")]
        public void ArrayHelperFindIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, int>((array, p) => ArrayHelper.Find(array, p), IsPublicMethod);
            test.AssertStaticMethod<double[], Predicate<double>, double>((array, p) => ArrayHelper.Find(array, p), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("f. ArrayHelper.Contains is a public method"), TestCategory("1B")]
        public void ArrayContainsIsAPublicMethod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, bool>((array, c) => ArrayHelper.Contains(array, c), IsPublicMethod);
            test.AssertStaticMethod<double[], Predicate<double>, bool>((array, c) => ArrayHelper.Contains(array, c), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("g. ArrayHelper.Filter can filter out negative numbers"), TestCategory("1B")]
        public void ArrayFilterReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> input = test.CreateVariable<int[]>();
            TestVariable<int[]> output = test.CreateVariable<int[]>();
            
            test.Arrange(input, Expr(() => new[] { -2, -1, 0, 1, 2}));
            test.Arrange(output, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsTrue(Expr(input, output, (i, o) => ArrayHelper.Filter(i, x => x >= 0).SequenceEqual(o)));

            test.Execute();
        }

        [TestMethod("h. ArrayHelper.Map can convert multiply number by 2"), TestCategory("1B")]
        public void ArrayMapReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> input = test.CreateVariable<int[]>();
            TestVariable<int[]> output = test.CreateVariable<int[]>();

            test.Arrange(input, Expr(() => new[] { 0, 1, 2 }));
            test.Arrange(output, Expr(() => new[] { 0, 2, 4 }));
            test.Assert.IsTrue(Expr(input, output, (i, o) => ArrayHelper.Map(i, x => 2*x).SequenceEqual(o)));

            test.Execute();
        }

        [TestMethod("i. ArrayHelper.Sort can sort array of numbers"), TestCategory("1B")]
        public void ArraySortReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> array = test.CreateVariable<int[]>();
            TestVariable<int[]> sortedArray = test.CreateVariable<int[]>();

            test.Arrange(array, Expr(() => new[] { 0, 5, 4, 1, 3, 2 }));
            test.Arrange(sortedArray, Expr(() => new[] { 0, 1, 2, 3, 4, 5 }));
            test.Act(Expr(array, a => ArrayHelper.Sort(a, (x, y) => x - y)));
            test.Assert.IsTrue(Expr(array, sortedArray, (i, o) => i.SequenceEqual(o)));

            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Find can a number"), TestCategory("1B")]
        public void ArrayFindReturnsCorrectly()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> array = test.CreateVariable<int[]>();

            test.Arrange(array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.AreEqual(Expr(array, a => ArrayHelper.Find(a, x => x == 1)), Const(1));

            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Contains returns true if predicate equals true"), TestCategory("1B")]
        public void ArrayContainsReturnsTrue()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> array = test.CreateVariable<int[]>();

            test.Arrange(array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsTrue(Expr(array, a => ArrayHelper.Contains(a, x => x == 1)));

            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Contains returns false if predicate equals false"), TestCategory("1B")]
        public void ArrayContainsReturnsFalse()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> array = test.CreateVariable<int[]>();

            test.Arrange(array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsFalse(Expr(array, a => ArrayHelper.Contains(a, x => x == 3)));

            test.Execute();
        }
        #endregion
    }
}
