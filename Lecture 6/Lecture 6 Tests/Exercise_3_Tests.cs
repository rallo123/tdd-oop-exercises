using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
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
            StructureTest test = Factory.CreateStructureTest();
            test.AssertInterface<IRandom>();
            test.Execute();
        }

        [TestMethod("b. IRandom.Next() is a method"), TestCategory("3A")]
        public void IRandomNextOverloadTakesNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int>(r => r.Next());
            test.Execute();
        }

        [TestMethod("c. IRandom.Next(max) is a method"), TestCategory("3A")]
        public void IRandomNextOverloadTakesInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int>((r, max) => r.Next(max));
            test.Execute();
        }

        [TestMethod("d. IRandom.Next(min, max) is a method"), TestCategory("3A")]
        public void IRandomNextOverlaodTakes2Ints()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int, int>((r, min, max) => r.Next(min, max));
            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("a. MyRandom implements IRandom"), TestCategory("3B")]
        public void MyRandomImplementsIRandom()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<MyRandom>(t => t.GetInterface("IRandom") != null);
            test.Execute();
        }

        [TestMethod("b. MyRandom.Next() does not return the same value twice (may fail sometimes)"), TestCategory("3B")]
        public void MyRandomNextReturnsRandomNumber()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> random = test.CreateVariable<MyRandom>();

            random.Arrange(() => new MyRandom());
            random.Assert.IsFalse(r => r.Next() == r.Next());

            test.Execute();
        }

        [TestMethod("c. MyRandom.Next(6) returns a number lower or equal to 6"), TestCategory("3B")]
        public void MyRandomNextReturnsExpectedResult()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> random = test.CreateVariable<MyRandom>();

            random.Arrange(() => new MyRandom());
            random.Assert.IsTrue(r => r.Next() <= 6);

            test.Execute();
        }

        [TestMethod("d. MyRandom.Next(1, 6) returns a number between 1 and 6"), TestCategory("3B")]
        public void MyRandomNextReturnsExpectedResult2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> random = test.CreateVariable<MyRandom>();
            TestVariable<int> value = test.CreateAnonymousObject<int>();

            random.Arrange(() => new MyRandom());
            value.WithParameters(random).Arrange(r => r.Next(1, 6));
            value.Assert.IsTrue(v => 1 <= v && v <= 6);

            test.Execute();
        }
        #endregion

        #region Exercise 3C
        [TestMethod("a. PredictableRandom implements IRandom"), TestCategory("3C")]
        public void PredictableRandomImplementsIRandom()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<PredictableRandom>(t => t.GetInterface("IRandom") != null);
            test.Execute();
        }

        [TestMethod("b. PredictableRandom.Next() returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4A()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();

            random.Arrange(() => new PredictableRandom(4));
            random.Assert.IsTrue(r => r.Next() == 4);

            test.Execute();
        }

        [TestMethod("c. PredictableRandom.Next(6) returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4B()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();

            random.Arrange(() => new PredictableRandom(4));
            random.Assert.IsTrue(r => r.Next(6) == 4);

            test.Execute();
        }

        [TestMethod("d. PredictableRandom.Next(6) throws ArgumentException if constructed with 7"), TestCategory("3C")]
        public void PredictableRandomNextThrowsOn6()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();

            random.Arrange(() => new PredictableRandom(7));
            random.Assert.ThrowsException<ArgumentException>(r => r.Next(6));

            test.Execute();
        }

        [TestMethod("e. PredictableRandom.Next(1, 6) returns 4 if constructed with 4"), TestCategory("3C")]
        public void PredictableRandomNextReturns4C()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();

            random.Arrange(() => new PredictableRandom(4));
            random.Assert.IsTrue(r => r.Next(1, 6) == 4);

            test.Execute();
        }

        [TestMethod("f. PredictableRandom.Next(1, 6) throws ArgumentException if constructed with 0"), TestCategory("3C")]
        public void PredictableRandomNextThrowsOn1And6()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();

            random.Arrange(() => new PredictableRandom(0));
            random.Assert.ThrowsException<ArgumentException>(r => r.Next(1, 6));

            test.Execute();
        }
        #endregion
    }
}
