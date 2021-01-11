using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Integrated;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_7_Tests
    {
        TestFactory factory = new TestFactory("Lecture_4");

        /* Exercise 7A */
        [TestMethod("a. NotOldEnoughException is subclass of Exception"), TestCategory("Exercise 7A")]
        public void NotOldEnoughExceptionIsSubclassOfException()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertClass<NotOldEnoughException>(new ClassOptions() { BaseType = typeof(Exception) });
        }

        /* Exercise 7B */
        [TestMethod("a. NotOldEnoughException() results in Message = \"Person is too young\""), TestCategory("Exercise 7B")]
        public void ParameterlessPersonConstructorAssignsMessageProperty()
        {
            Test test = factory.CreateTest();
            TestObject<NotOldEnoughException> exception = test.Create<NotOldEnoughException>();

            test.Arrange(exception, () => new NotOldEnoughException());
            test.Assert(exception, e => e.Message == "Person is too young");
            // Alternative syntax: test.Assert.That(exception, e => e.Message).Equals("Person is too young");

            test.Execute();
        }

        /* Exercise 7C */
        [TestMethod("d. NotOldEnoughException(string activity) results in Message = \"Person is too young to [activity]\""), TestCategory("Exercise 7C")]
        public void PersonConstructorAssignsMessageProperty()
        {
            Test test = factory.CreateTest();
            TestObject<NotOldEnoughException> exception = test.Create<NotOldEnoughException>();

            test.Arrange(exception, () => new NotOldEnoughException("do something"));
            test.Assert(exception, e => e.Message == "Person is too do something");
            // Alternative syntax: test.Assert.That(exception, e => e.Message).Equals("Person is too young to do something");

            test.Execute();
        }

        /* Exercise 7D */
        [TestMethod("a. Person.Age is public int property"), TestCategory("Exercise 7D")]
        public void PersonAgeIsPublicIntProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Person, int>(
                p => p.Age,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true },
                    SetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("b. Person.CalculateBMI() throws NotOldEnoughException for Height = 1.80, Weight = 80.0 & Age = 15"), TestCategory("Exercise 7D")]
        public void PersonCalculateBMIThrowsNotOldEnoughException()
        {
            Test test = factory.CreateTest();
            TestObject<Person> person = test.Create<Person>();

            test.Arrange(person, () => new Person("abc") { Height = 1.80, Weight = 80.0, Age = 15 });
            test.AssertThrows<NotOldEnoughException, Person>(person, p => p.CalculateBMI());
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Throws<NotOldEnough>():

            test.Execute();
        }
    }
}
