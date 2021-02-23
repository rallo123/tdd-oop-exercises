using Lecture_4_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Structure;
using TestTools.Unit;
using static TestTools.Unit.TestExpression;
using static Lecture_4_Tests.TestHelper;
using TestTools.Structure;
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
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, string>(p => p.Name);
            test.Execute();
        }

        [TestMethod("b. Person.Height is public double property"), TestCategory("Exercise 2A")]
        public void PersonHeightIsPublicDoubleProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, double>(p => p.Height);
            test.Execute();
        }

        [TestMethod("c. Person.Weight is public double property"), TestCategory("Exercise 2A")]
        public void PersonWeightIsPublicDoubleProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Person, double>(p => p.Weight);
            test.Execute();
        }

        [TestMethod("d. Person(string name) assigns Name property"), TestCategory("Exercise 2A")]
        public void PersonConstructorAssignsNameProperty()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc")));
            test.Assert.AreEqual(Expr(person, p => p.Name), Const("abc"));

            test.Execute();
        }

        [TestMethod("e. Person.Height ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonHeightIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc")));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, double>(Expr(person, p => p.Height), Const(-1.0));

            test.Execute();
        }
            

        [TestMethod("f. Person.Weight ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonWeightIgnoresAssignmentOfMinusOne()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc")));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, double>(Expr(person, p => p.Weight), Const(-1.0));

            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("a. Person.CalculateBMI() returns expected output"), TestCategory("Exercise 2B")]
        public void PersonCalculateBMIReturnsExpectedOutput()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            Person originalPerson = new Person("abc") { Height = 1.80, Weight = 80 };
            test.Arrange(person, Expr(() => new Person("abc") { Height = 1.80, Weight = 80 }));
            test.Assert.AreEqual(Expr(person, p => p.CalculateBMI()), Const(originalPerson.CalculateBMI()), 0.001);

            test.Execute();
        }
        #endregion

        #region Exercise 2C
        [TestMethod("Person.GetClassification() returns \"under-weight\" for Height = 1.64 & Weight = 47.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsUnderWeight()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc") { Height = 1.64, Weight = 47.0 }));
            test.Assert.AreEqual(Expr(person, p => p.GetClassification()), Const("under-weight"));

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"normal weight\" for Height = 1.73 & Weight = 58.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsNormalWeight()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc") { Height = 1.73, Weight = 58.0 }));
            test.Assert.AreEqual(Expr(person, p => p.GetClassification()), Const("normal weight"));

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"over-weight\" for Height = 1.70 & Weight = 74.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsOverWeight()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc") { Height = 1.70, Weight = 74.0 }));
            test.Assert.AreEqual(Expr(person, p => p.GetClassification()), Const("over-weight"));

            test.Execute();
        }

        [TestMethod("Person.GetClassification() returns \"obese\" for Height = 1.85 & Weight = 120.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsObese()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Person> person = test.CreateVariable<Person>(nameof(person));

            test.Arrange(person, Expr(() => new Person("abc") { Height = 1.85, Weight = 120.0 }));
            test.Assert.AreEqual(Expr(person, p => p.GetClassification()), Const("obese"));

            test.Execute();
        }
        #endregion
    }
}
