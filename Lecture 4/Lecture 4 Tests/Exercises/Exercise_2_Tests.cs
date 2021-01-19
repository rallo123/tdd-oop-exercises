using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Operation;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;
using TestTools.Structure;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        TestFactory factory = new TestFactory("Lecture_4");

        /* Exercise 2A */
        [TestMethod("a. Person.Name is public string property"), TestCategory("Exercise 2A")]
        public void PersonNameIsStringProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Person, string>(
                p => p.Name,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("b. Person.Height is public double property"), TestCategory("Exercise 2A")]
        public void PersonHeightIsPublicDoubleProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Person, double>(
                p => p.Height,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("c. Person.Weight is public double property"), TestCategory("Exercise 2A")]
        public void PersonWeightIsPublicDoubleProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<Person, double>(
                p => p.Weight,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("d. Person(string name) assigns Name property"), TestCategory("Exercise 2A")]
        public void PersonConstructorAssignsNameProperty()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc"));
            person.Assert.IsTrue(p => p.Name == "abc");
            // Alternative syntax: test.Assert.That(person, p => p.Name).Equals("abc");

            test.Execute();
        }

        [TestMethod("e. Person.Height ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonHeightIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc"));
            person.Assert.ThrowsException<ArgumentException>(Assignment<Person, double>(p => p.Height, -1.0));
            // Alternative syntax: test.Assert.That(person, Assignment<Person, double>(p => p.Height, -1.0)).Throws<ArgumentException>();
            // Alternative syntax: test.Assert.Assignment(person, p => p.Height, -1.0).Throws<ArgumentException>();

            test.Execute();
        }
            

        [TestMethod("f. Person.Weight ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonWeightIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc"));
            person.Assert.ThrowsException<ArgumentException>(Assignment<Person, double>(p => p.Weight, -1.0));
            // Alternative syntax: test.Assert.That(person, Assignment<Person, double>(p => p.Weight, -1.0)).Throws<ArgumentException>();
            // Alternative syntax: test.Assert.Assignment(person, p => p.Weight, -1.0).Throws<ArgumentException>();

            test.Execute();
        }
        
        /* Exercise 2B */
        [TestMethod("a. Person.CalculateBMI() returns expected output"), TestCategory("Exercise 2B")]
        public void PersonCalculateBMIReturnsExpectedOutput()
        {
            UnitTest test = factory.CreateTest();
            DualUnitTestObject<Person> person = test.CreateDual<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.80, Weight = 80 });
            person.Assert.EqualToDual(p => p.CalculateBMI());
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Equals.Dual();

            test.Execute();
        }

        /* Exercise 2C */
        [TestMethod("Person.GetClassification() returns \"under-weight\" for Height = 1.64 & Weight = 47.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsUnderWeight()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.64, Weight = 47.0 });
            person.Assert.IsTrue(p => p.GetClassification() == "under-weight");
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Equals("under-weight");

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"normal weight\" for Height = 1.73 & Weight = 58.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsNormalWeight()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.73, Weight = 58.0 });
            person.Assert.IsTrue(p => p.GetClassification() == "normal weight");
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Equals("normal weight");

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"over-weight\" for Height = 1.70 & Weight = 74.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsOverWeight()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.70, Weight = 74.0 });
            person.Assert.IsTrue(p => p.GetClassification() == "over-weight");
            // Alternative syntax: test.Assert.That(person, p => p.CalculateBMI()).Equals("over weight");

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"obese\" for Height = 1.85 & Weight = 120.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsObese()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<Person> person = test.Create<Person>();

            person.Arrange(() => new Person("abc") { Height = 1.85, Weight = 120.0 });
            person.Assert.IsTrue(p => p.GetClassification() == "obese");
            // Alternative syntax: test.Assert.That(person, p.CalculateBMI()).To.Equal("obese");

            test.Execute();
        }
    }
}
