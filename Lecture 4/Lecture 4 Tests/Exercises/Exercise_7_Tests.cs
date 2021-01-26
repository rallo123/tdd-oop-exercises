using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.StructureTests;
using TestTools.UnitTests;
using TestTools.Structure.Generic;
using static Lecture_4_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_7_Tests
    {
        #region Exercise 7A
        [TestMethod("a. NotOldEnoughException is subclass of Exception"), TestCategory("Exercise 7A")]
        public void NotOldEnoughExceptionIsSubclassOfException()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<NotOldEnoughException>(t => t.BaseType == typeof(Exception));
            test.Execute();
        }
        #endregion

        #region Exercise 7B
        [TestMethod("a. NotOldEnoughException() results in Message = \"Person is too young\""), TestCategory("Exercise 7B")]
        public void ParameterlessPersonConstructorAssignsMessageProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<NotOldEnoughException> exception = test.CreateVariable<NotOldEnoughException>();

            test.Arrange(exception, Expr(() => new NotOldEnoughException()));
            test.Assert.AreEqual(Expr(exception, e => e.Message), Const("Person is too young"));

            test.Execute();
        }
        #endregion

        #region Exercise 7C
        [TestMethod("d. NotOldEnoughException(string activity) results in Message = \"Person is too young to [activity]\""), TestCategory("Exercise 7C")]
        public void PersonConstructorAssignsMessageProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<NotOldEnoughException> exception = test.CreateVariable<NotOldEnoughException>();

            test.Arrange(exception, Expr(() => new NotOldEnoughException("do something")));
            test.Assert.AreEqual(Expr(exception, e => e.Message), Const("Person is too do something"));

            test.Execute();
        }
        #endregion

        #region Exercise 7D
        [TestMethod("a. Person.Age is public int property"), TestCategory("Exercise 7D")]
        public void PersonAgeIsPublicIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, int>(p => p.Age, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Person.CalculateBMI() throws NotOldEnoughException for Age = 15"), TestCategory("Exercise 7D")]
        public void PersonCalculateBMIThrowsNotOldEnoughException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>();

            test.Arrange(person, Expr(() => new Person("abc") {  Age = 15 }));
            test.Assert.ThrowsExceptionOn<NotOldEnoughException>(Expr(person, p => p.CalculateBMI()));

            test.Execute();
        }
        #endregion
    }
}
