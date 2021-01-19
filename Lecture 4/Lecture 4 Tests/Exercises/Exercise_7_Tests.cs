using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static Lecture_4_Tests.TestHelper;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_7_Tests
    {
        /* Exercise 7A */
        [TestMethod("a. NotOldEnoughException is subclass of Exception"), TestCategory("Exercise 7A")]
        public void NotOldEnoughExceptionIsSubclassOfException()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertClass<NotOldEnoughException>(new ClassRequirements() { BaseType = typeof(Exception) });
        }

        /* Exercise 7B */
        [TestMethod("a. NotOldEnoughException() results in Message = \"Person is too young\""), TestCategory("Exercise 7B")]
        public void ParameterlessPersonConstructorAssignsMessageProperty()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<NotOldEnoughException> exception = test.Create<NotOldEnoughException>();

            exception.Arrange(() => new NotOldEnoughException());
            exception.Assert.IsTrue(e => e.Message == "Person is too young");
            // Alternative syntax: test.Assert.That(exception, e => e.Message).Equals("Person is too young");

            test.Execute();
        }

        /* Exercise 7C */
        [TestMethod("d. NotOldEnoughException(string activity) results in Message = \"Person is too young to [activity]\""), TestCategory("Exercise 7C")]
        public void PersonConstructorAssignsMessageProperty()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<NotOldEnoughException> exception = test.Create<NotOldEnoughException>();

            exception.Arrange(() => new NotOldEnoughException("do something"));
            exception.Assert.IsTrue(e => e.Message == "Person is too do something");
            // Alternative syntax: test.Assert.That(exception, e => e.Message).Equals("Person is too young to do something");

            test.Execute();
        }

        /* Exercise 7D */
        [TestMethod("a. Person.Age is public int property"), TestCategory("Exercise 7D")]
        public void PersonAgeIsPublicIntProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Person, int>(
                p => p.Age,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("b. Person.CalculateBMI() throws NotOldEnoughException for Height = 1.80, Weight = 80.0 & Age = 15"), TestCategory("Exercise 7D")]
        public void PersonCalculateBMIThrowsNotOldEnoughException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.80, Weight = 80.0, Age = 15 });
            person.Assert.ThrowsException<NotOldEnoughException>(p => p.CalculateBMI());
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Throws<NotOldEnough>():

            test.Execute();
        }
    }
}
