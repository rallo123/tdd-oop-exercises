﻿using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
using static Lecture_6_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_6_Tests
{
    [TestClass]
    public class Exercise_3_Tests 
    {
        #region Exercise 3A
        [TestMethod("a. IRandom is an interface"), TestCategory("3A")]
        public void IRandomIsAnInterface()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertInterface<IRandom>();
            test.Execute();
        }

        [TestMethod("b. IRandom.Next() is a method"), TestCategory("3A")]
        public void IRandomNextOverloadTakesNothing()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int>(r => r.Next());
            test.Execute();
        }

        [TestMethod("c. IRandom.Next(max) is a method"), TestCategory("3A")]
        public void IRandomNextOverloadTakesInt()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int>((r, max) => r.Next(max));
            test.Execute();
        }

        [TestMethod("d. IRandom.Next(min, max) is a method"), TestCategory("3A")]
        public void IRandomNextOverlaodTakes2Ints()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int, int>((r, min, max) => r.Next(min, max));
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. MyRandom implements IRandom"), TestCategory("3B")]
        public void MyRandomImplementsIRandom()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<MyRandom>(new TypeIsSubclassOfVerifier(typeof(IRandom)));
            test.Execute();
        }

        [TestMethod("b. MyRandom.Next() does not return the same value twice (may randomly fail)"), TestCategory("3B")]
        public void MyRandomNextReturnsRandomNumber()
        {
            MyRandom random = new MyRandom();
            Assert.AreNotEqual(random.Next(), random.Next());

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> _random = test.CreateVariable<MyRandom>();
            test.Arrange(_random, Expr(() => new MyRandom()));
            test.Assert.AreNotEqual(Expr(_random, r => r.Next()), Expr(_random, r => r.Next()));
            test.Execute();
        }

        [TestMethod("c. MyRandom.Next(6) returns a number lower or equal to 6"), TestCategory("3B")]
        public void MyRandomNextReturnsExpectedResult()
        {
            MyRandom random = new MyRandom();
            Assert.IsTrue(random.Next(6) <= 6);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> _random = test.CreateVariable<MyRandom>();
            test.Arrange(_random, Expr(() => new MyRandom()));
            test.Assert.IsTrue(Expr(_random, r => r.Next(6) <= 6));
            test.Execute();
        }

        [TestMethod("d. MyRandom.Next(1, 6) returns a number between 1 and 6"), TestCategory("3B")]
        public void MyRandomNextReturnsExpectedResult2()
        {
            MyRandom random = new MyRandom();

            int value = random.Next(1, 6);

            Assert.IsTrue(1 <= value && value <= 6);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> _random = test.CreateVariable<MyRandom>();
            TestVariable<int> _value = test.CreateVariable<int>();
            test.Arrange(_random, Expr(() => new MyRandom()));
            test.Arrange(_value, Expr(_random, r => r.Next(1, 6)));
            test.Assert.IsTrue(Expr(_value, v => 1 <= v && v <= 6));
            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. PredictableRandom implements IRandom"), TestCategory("3C")]
        public void PredictableRandomImplementsIRandom()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<PredictableRandom>(new TypeIsSubclassOfVerifier(typeof(IRandom)));
            test.Execute();
        }

        [TestMethod("b. PredictableRandom.Next() returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4A()
        {
            PredictableRandom random = new PredictableRandom(4);
            Assert.AreEqual(4, random.Next());

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> _random = test.CreateVariable<PredictableRandom>();
            test.Arrange(_random, Expr(() => new PredictableRandom(4)));
            test.Assert.AreEqual(Const(4), Expr(_random, r => r.Next()));
            test.Execute();
        }

        [TestMethod("c. PredictableRandom.Next(6) returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4B()
        {
            PredictableRandom random = new PredictableRandom(4);
            Assert.AreEqual(4, random.Next(6));

            //TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> _random = test.CreateVariable<PredictableRandom>();
            test.Arrange(_random, Expr(() => new PredictableRandom(4)));
            test.Assert.AreEqual(Const(4), Expr(_random, r => r.Next(6)));
            test.Execute();
        }

        [TestMethod("d. PredictableRandom.Next(6) throws ArgumentException if constructed with 7"), TestCategory("3C")]
        public void PredictableRandomNextThrowsOn6()
        {
            PredictableRandom random = new PredictableRandom(7);
            Assert.ThrowsException<ArgumentException>(() => random.Next(6));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> _random = test.CreateVariable<PredictableRandom>();
            test.Arrange(_random, Expr(() => new PredictableRandom(7)));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_random, r => r.Next(6)));
            test.Execute();
        }

        [TestMethod("e. PredictableRandom.Next(1, 6) returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4C()
        {
            PredictableRandom random = new PredictableRandom(4);
            Assert.AreEqual(4, random.Next(1, 6));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> _random = test.CreateVariable<PredictableRandom>();
            test.Arrange(_random, Expr(() => new PredictableRandom(4)));
            test.Assert.AreEqual(Const(4), Expr(_random, r => r.Next(1, 6)));
            test.Execute();
        }

        [TestMethod("f. PredictableRandom.Next(1, 6) throws ArgumentException if constructed with 0"), TestCategory("3C")]
        public void PredictableRandomNextThrowsOn1And6()
        {
            PredictableRandom random = new PredictableRandom(0);
            Assert.ThrowsException<ArgumentException>(() => random.Next(1, 6));

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> _random = test.CreateVariable<PredictableRandom>();
            test.Arrange(_random, Expr(() => new PredictableRandom(0)));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_random, r => r.Next(1, 6)));
            test.Execute();
        }
        #endregion
    }
}
