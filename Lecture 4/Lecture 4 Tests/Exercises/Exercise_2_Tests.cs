using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
using static Lecture_4_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        #region Exercise 2A
        [TestMethod("a. Person.Name is public string property"), TestCategory("Exercise 2A")]
        public void PersonNameIsStringProperty() 
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, string>(p => p.Name);
            test.Execute();
        }

        [TestMethod("b. Person.Height is public double property"), TestCategory("Exercise 2A")]
        public void PersonHeightIsPublicDoubleProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, double>(p => p.Height);
            test.Execute();
        }

        [TestMethod("c. Person.Weight is public double property"), TestCategory("Exercise 2A")]
        public void PersonWeightIsPublicDoubleProperty() 
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, double>(p => p.Weight);
            test.Execute();
        }

        [TestMethod("d. Person(string name) assigns Name property"), TestCategory("Exercise 2A")]
        public void PersonConstructorAssignsNameProperty()
        {
            Person person = new Person("abc");
            Assert.AreEqual(person.Name, "abc");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc")));
            test.Assert.AreEqual(Expr(_person, p => p.Name), Const("abc"));
            test.Execute();
        }

        [TestMethod("e. Person.Height throws ArgumentException on assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonHeightIgnoresAssignmentOfMinusOne()
        {
            Person person = new Person("abc");
            Assert.ThrowsException<ArgumentException>(() => person.Height = -0.1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc")));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_person, p => p.SetHeight(-1.0)));// TestTools Code
            test.Execute();
        }
            

        [TestMethod("f. Person.Weight throws ArgumentException on assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonWeightIgnoresAssignmentOfMinusOne()
        {
            Person person = new Person("abc");
            Assert.ThrowsException<ArgumentException>(() => person.Weight = -0.1);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc")));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_person, p => p.SetWeight(-1.0)));// TestTools Code
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Person.CalculateBMI() returns expected output"), TestCategory("Exercise 2B")]
        public void PersonCalculateBMIReturnsExpectedOutput()
        {
            double expectedBMI = 80 / (1.80 * 1.80);

            Person person = new Person("abc")
            {
                Height = 1.80,
                Weight = 80
            };
            Assert.AreEqual(person.CalculateBMI(), expectedBMI, 0.001);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc") { Height = 1.80, Weight = 80 }));
            test.Assert.AreEqual(Expr(_person, p => p.CalculateBMI()), Const(expectedBMI), 0.001);
            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("Person.GetClassification() returns \"under-weight\" for Height = 1.64 & Weight = 47.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsUnderWeight()
        {
            Person person = new Person("abc")
            {
                Height = 1.64,
                Weight = 47.0
            };
            Assert.AreEqual(person.GetClassification(), "under-weight");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc") { Height = 1.64, Weight = 47.0 }));
            test.Assert.AreEqual(Expr(_person, p => p.GetClassification()), Const("under-weight"));
            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"normal weight\" for Height = 1.73 & Weight = 58.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsNormalWeight()
        {
            Person person = new Person("abc")
            {
                Height = 1.73,
                Weight = 58.0
            };
            Assert.AreEqual(person.GetClassification(), "normal weight");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc") { Height = 1.73, Weight = 58.0 }));
            test.Assert.AreEqual(Expr(_person, p => p.GetClassification()), Const("normal weight"));
            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"over-weight\" for Height = 1.70 & Weight = 74.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsOverWeight()
        {
            Person person = new Person("abc")
            {
                Height = 1.70,
                Weight = 74
            };
            Assert.AreEqual(person.GetClassification(), "over-weight");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc") { Height = 1.70, Weight = 74.0 }));
            test.Assert.AreEqual(Expr(_person, p => p.GetClassification()), Const("over-weight"));
            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"obese\" for Height = 1.85 & Weight = 120.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsObese()
        {
            Person person = new Person("abc")
            {
                Height = 1.85,
                Weight = 120.0
            };
            Assert.AreEqual(person.GetClassification(), "obese");

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> _person = test.CreateVariable<Person>(nameof(_person));
            test.Arrange(_person, Expr(() => new Person("abc") { Height = 1.85, Weight = 120.0 }));
            test.Assert.AreEqual(Expr(_person, p => p.GetClassification()), Const("obese"));
            test.Execute();
        }
        #endregion
    }
}
