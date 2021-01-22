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
    public class Exercise_4_Tests 
    {
        #region Exercise 4A
        [TestMethod("a. Die constructor takes IRandom"), TestCategory("4A")]
        public void DieConstructorTakesIRandom()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<IRandom, Die>(r => new Die(r), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("a. Die constructor takes IRandom and int"), TestCategory("4B")]
        public void DieConstructorTakesIRandomAndInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<IRandom, int, Die>((r, s) => new Die(r, s), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 4C
        [TestMethod("a. Die.Roll returns 5 if constructed PredictablyRandom(5)"), TestCategory("4C")]
        public void DieRollReturns5()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<PredictableRandom> random = test.CreateObject<PredictableRandom>();
            UnitTestObject<Die> die = test.CreateObject<Die>();

            random.Arrange(() => new PredictableRandom(5));
            die.WithParameters(random).Arrange((r) => new Die(r, 6));
            die.Assert.IsTrue(d => d.Roll() == 5);

            test.Execute();
        }

        [TestMethod("b. Die.Roll returns a number between 1 and 6 if constructed with 6 sides and MyRandom"), TestCategory("4C")]
        public void DieRollReturnsANumberBetween1And6()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<MyRandom> random = test.CreateObject<MyRandom>();
            UnitTestObject<Die> die = test.CreateObject<Die>();
            UnitTestObject<int> value = test.CreateAnonymousObject<int>();

            random.Arrange(() => new MyRandom());
            die.WithParameters(random).Arrange((r) => new Die(r, 6));
            value.WithParameters(die).Arrange(d => d.Roll());
            value.Assert.IsTrue(v => 1 <= v && v <= 6);

            test.Execute();
        }
        #endregion
    }
}
