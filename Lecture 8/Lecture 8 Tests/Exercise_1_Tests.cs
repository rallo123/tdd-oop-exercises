﻿using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_1_Tests
    {
        #region Exercise 1B
        [TestMethod("a. ArrayHelper is an static class"), TestCategory("Exercise 1B")]
        public void ArrayHelperIsAnStaticClass()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertType(typeof(ArrayHelper), new TypeIsStaticVerifier());
            test.Execute();
        }

        [TestMethod("b. ArrayHelper.Filter is a public method"), TestCategory("Exercise 1B")]
        public void ArrayHelperFilterIsAPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, int[]>(
                (array, p) => ArrayHelper.Filter(array, p), 
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.AssertStaticMethod<double[], Predicate<double>, double[]>((array, p) => ArrayHelper.Filter(array, p));
            test.Execute();
        }

        [TestMethod("c. ArrayHelper.Map is a public method"), TestCategory("Exercise 1B")]
        public void ArrayHelperMapIsAPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Func<int, double>, double[]>(
                (array, f) => ArrayHelper.Map(array, f), 
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.AssertStaticMethod<double[], Func<double, int>, int[]>((array, f) => ArrayHelper.Map(array, f));
            test.Execute();
        }

        [TestMethod("d. ArrayHelper.Sort is a public method"), TestCategory("Exercise 1B")]
        public void ArrayHelperSortIsPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<string[], Func<string, string, int>>(
                (array, c) => ArrayHelper.Sort(array, c), 
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.AssertStaticMethod<double[], Func<double, double, int>>((array, c) => ArrayHelper.Sort(array, c));
            test.Execute();
        }

        [TestMethod("e. ArrayHelper.Find is a public method"), TestCategory("Exercise 1B")]
        public void ArrayHelperFindIsAPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, int>(
                (array, p) => ArrayHelper.Find(array, p), 
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.AssertStaticMethod<double[], Predicate<double>, double>((array, p) => ArrayHelper.Find(array, p));
            test.Execute();
        }

        [TestMethod("f. ArrayHelper.Contains is a public method"), TestCategory("Exercise 1B")]
        public void ArrayContainsIsAPublicMethod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertStaticMethod<int[], Predicate<int>, bool>(
                (array, c) => ArrayHelper.Contains(array, c),
                new MemberAccessLevelVerifier(AccessLevels.Public));
            test.AssertStaticMethod<double[], Predicate<double>, bool>((array, c) => ArrayHelper.Contains(array, c));
            test.Execute();
        }

        [TestMethod("g. ArrayHelper.Filter can filter out negative numbers"), TestCategory("Exercise 1B")]
        public void ArrayFilterReturnsCorrectly()
        {
            int[] input = new int[] { -2, -1, 0, 1, 2 };

            int[] expectedOutput = new int[] { 0, 1, 2 };
            int[] actualOutput = ArrayHelper.Filter(input, x => x >= 0);

            Assert.IsTrue(actualOutput.SequenceEqual(expectedOutput));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _input = test.CreateVariable<int[]>();
            TestVariable<int[]> _output = test.CreateVariable<int[]>();
            test.Arrange(_input, Expr(() => new[] { -2, -1, 0, 1, 2}));
            test.Arrange(_output, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsTrue(Expr(_input, _output, (i, o) => ArrayHelper.Filter(i, x => x >= 0).SequenceEqual(o)));
            test.Execute();
        }

        [TestMethod("h. ArrayHelper.Map can convert multiply number by 2"), TestCategory("Exercise 1B")]
        public void ArrayMapReturnsCorrectly()
        {
            int[] input = new int[] { 0, 1, 2 };

            int[] expectedOutput = new int[] { 0, 2, 4 };
            int[] actualOutput = ArrayHelper.Map(input, x => 2*x);

            Assert.IsTrue(actualOutput.SequenceEqual(expectedOutput));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _input = test.CreateVariable<int[]>();
            TestVariable<int[]> _output = test.CreateVariable<int[]>();
            test.Arrange(_input, Expr(() => new[] { 0, 1, 2 }));
            test.Arrange(_output, Expr(() => new[] { 0, 2, 4 }));
            test.Assert.IsTrue(Expr(_input, _output, (i, o) => ArrayHelper.Map(i, x => 2*x).SequenceEqual(o)));
            test.Execute();
        }

        [TestMethod("i. ArrayHelper.Sort can sort array of numbers"), TestCategory("Exercise 1B")]
        public void ArraySortReturnsCorrectly()
        {
            int[] input = new int[] { 0, 5, 4, 1, 3, 2 };

            int[] expectedOutput = new int[] { 0, 1, 2, 3, 4, 5 };
            ArrayHelper.Sort(input, (x, y) => y - x);

            Assert.IsTrue(input.SequenceEqual(expectedOutput));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _array = test.CreateVariable<int[]>();
            TestVariable<int[]> _sortedArray = test.CreateVariable<int[]>();
            test.Arrange(_array, Expr(() => new[] { 0, 5, 4, 1, 3, 2 }));
            test.Arrange(_sortedArray, Expr(() => new[] { 0, 1, 2, 3, 4, 5 }));
            test.Act(Expr(_array, a => ArrayHelper.Sort(a, (x, y) => y - x)));
            test.Assert.IsTrue(Expr(_array, _sortedArray, (i, o) => i.SequenceEqual(o)));
            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Find can a number"), TestCategory("Exercise 1B")]
        public void ArrayFindReturnsCorrectly()
        {
            int[] array = new int[] { 0, 1, 2 };
            Assert.AreEqual(1, ArrayHelper.Find(array, x => x == 1));
 
            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _array = test.CreateVariable<int[]>();
            test.Arrange(_array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.AreEqual(Const(1), Expr(_array, a => ArrayHelper.Find(a, x => x == 1)));
            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Contains returns true if predicate equals true"), TestCategory("Exercise 1B")]
        public void ArrayContainsReturnsTrue()
        {
            int[] array = new int[] { 0, 1, 2 };
            Assert.IsTrue(ArrayHelper.Contains(array, x => x == 1));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _array = test.CreateVariable<int[]>();
            test.Arrange(_array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsTrue(Expr(_array, a => ArrayHelper.Contains(a, x => x == 1)));
            test.Execute();
        }

        [TestMethod("j. ArrayHelper.Contains returns false if predicate equals false"), TestCategory("Exercise 1B")]
        public void ArrayContainsReturnsFalse()
        {
            int[] array = new int[] { 0, 1, 2 };
            Assert.IsFalse(ArrayHelper.Contains(array, x => x == 3));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<int[]> _array = test.CreateVariable<int[]>();
            test.Arrange(_array, Expr(() => new[] { 0, 1, 2 }));
            test.Assert.IsFalse(Expr(_array, a => ArrayHelper.Contains(a, x => x == 3)));
            test.Execute();
        }
        #endregion
    }
}
