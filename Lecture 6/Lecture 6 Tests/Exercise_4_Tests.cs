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
        [TestMethod("IRandom is an interface"), TestCategory("4A")]
        public void IRandomIsAnInterface()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertInterface<IRandom>();
            test.Execute();
        }

        [TestMethod("IRandom.Next() is a method"), TestCategory("4A")]
        public void IRandomNextOverloadTakesNothing()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int>(r => r.Next());
            test.Execute();
        }

        [TestMethod("IRandom.Next(max) is a method"), TestCategory("4A")]
        public void IRandomNextOverloadTakesInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int>((r, max) => r.Next(max));
            test.Execute();
        }

        [TestMethod("IRandom.Next(min, max) is a method"), TestCategory("4A")]
        public void IRandomNextOverlaodTakes2Ints()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<IRandom, int, int, int>((r, min, max) => r.Next(min, max));
            test.Execute();
        }
        #endregion

        #region Exercise 4B
        [TestMethod("MyRandom implements IRandom"), TestCategory("4B")]
        public void MyRandomImplementsIRandom()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<MyRandom>(t => t.GetInterface("IRandom") != null);
            test.Execute();
        }
        #endregion

        #region Exercise 4C
        [TestMethod("Die constructor takes IRandom"), TestCategory("4C")]
        public void DieConstructorTakesIRandom()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<IRandom, Die>(r => new Die(r), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        #region Exercise 4D
        [TestMethod("Die constructor takes IRandom and int"), TestCategory("4D")]
        public void DieConstructorTakesIRandomAndInt()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertConstructor<IRandom, int, Die>((r, s) => new Die(r, s), IsPublicConstructor);
            test.Execute();
        }
        #endregion

        // TODO add tests for exercise 4E
    }
}
