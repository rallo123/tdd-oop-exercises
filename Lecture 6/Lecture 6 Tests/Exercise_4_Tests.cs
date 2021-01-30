using Lecture_6_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
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
            TestVariable<PredictableRandom> random = test.CreateVariable<PredictableRandom>();
            TestVariable<Die> die = test.CreateVariable<Die>();

            test.Arrange(random, Expr(() => new PredictableRandom(5)));
            test.Arrange(die, Expr(random, (r) => new Die(r, 6)));
            test.Assert.AreEqual(Expr(die, d => d.Roll()), Const(5));

            test.Execute();
        }

        [TestMethod("b. Die.Roll returns a number between 1 and 6 if constructed with 6 sides and MyRandom"), TestCategory("4C")]
        public void DieRollReturnsANumberBetween1And6()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<MyRandom> random = test.CreateVariable<MyRandom>();
            TestVariable<Die> die = test.CreateVariable<Die>();
            TestVariable<int> value = test.CreateVariable<int>();

            test.Arrange(random, Expr(() => new MyRandom()));
            test.Arrange(die, Expr(random, (r) => new Die(r, 6)));
            test.Arrange(value, Expr(die, d => d.Roll()));
            test.Assert.IsTrue(Expr(value, v => 1 <= v && v <= 6));

            test.Execute();
        }
        #endregion
    }
}
