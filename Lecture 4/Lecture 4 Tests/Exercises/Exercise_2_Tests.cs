using Lecture_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
#pragma warning disable IDE1006 // Naming Styles
        private ClassElement<Person> person => new ClassElement<Person>();
        private PropertyElement<Person, string> personName => person.Property<string>("Name", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, double> personHeight => person.Property<double>("Height", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, double> personWeight => person.Property<double>("Weight", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, int> personAge => person.Property<int>("Age", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Person, double> personCalculateBMI => person.FuncMethod<double>("CalculateBMI", new MethodOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Person, string> personGetClassification => person.FuncMethod<string>("GetClassification", new MethodOptions() { AccessLevel = AccessLevel.Public });

        private Person CreatePerson(string name = "Allan", double? height = null, double? weight = null)
        {
            Person instance = person.Constructor<string>().Invoke(name);

            if (height != null)
                personHeight.Set(instance, height);
            if (weight != null)
                personWeight.Set(instance, weight);

            //After Exercise 7, CalculateBMI() and GetClassification() will throw an Exception if age < 16
            try { personAge.Set(instance, 16); }
            catch (Exception) { }

            return instance;
        }
        private void DoNothing(object par) { }

#pragma warning restore IDE1006 // Naming Styles

        /* Exercise 2A */
        [TestMethod("a. Person.Name is public string property"), TestCategory("Exercise 2A")]
        public void PersonNameIsStringProperty() => DoNothing(personName);

        [TestMethod("b. Person.Height is public string property"), TestCategory("Exercise 2A")]
        public void PersonHeightIsPublicStringProperty() => DoNothing(personHeight);

        [TestMethod("c. Person.Weight is public string property"), TestCategory("Exercise 2A")]
        public void PersonWeightIsPublicStringProperty() => DoNothing(personWeight);

        [TestMethod("d. Person(string name) assigns Name property"), TestCategory("Exercise 2A")]
        public void PersonConstructorAssignsNameProperty()
        {
            string expected = "abc";
            Person person = CreatePerson(expected);

            string actual = personName.Get(person);
            if (actual != expected)
            {
                string message = string.Format(
                    "Person.Name is {0} instead of {1} after construction by Person({1})",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("e. Person.Height ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonHeightIgnoresAssignmentOfMinusOne() => Assignment.Invalid<ArgumentException>(CreatePerson(), personHeight, -1.0);

        [TestMethod("f. Person.Weight ignores assignment of -1.0"), TestCategory("Exercise 2A")]
        public void PersonWeightIgnoresAssignmentOfMinusOne() => Assignment.Invalid<ArgumentException>(CreatePerson(), personWeight, -1.0);

        /* Exercise 2B */
        [TestMethod("a. Person.CalculateBMI() returns expected output"), TestCategory("Exercise 2B")]
        public void PersonCalculateBMIReturnsExpectedOutput()
        {
            Person person = CreatePerson(height: 1.80, weight: 80);
            
            double expected = 80.0 / Math.Pow(1.80, 2);
            double actual = personCalculateBMI.Invoke(person);

            if (actual != expected)
            {
                string message = string.Format(
                    "Person.CalculateBMI() returns {0} instead of {1} for Height = 1.80 & Weight = 80.0",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        /* Exercise 2C */
        [TestMethod("Person.GetClassification() returns \"under-weight\" for Height = 1.64 & Weight = 47.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsUnderWeight()
        {
            Person person = CreatePerson(height: 1.64, weight: 47.0);

            string expected = "under-weight";
            string actual = personGetClassification.Invoke(person);

            if (actual != expected)
            {
                string message = string.Format(
                    "Person.GetClassification() returns \"{0}\" instead of \"{1}\" for Height 1.64 & Weight = 47.0",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("Person.GetClassification() returns \"normal weight\" for Height = 1.73 & Weight = 58.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsNormalWeight()
        {
            Person person = CreatePerson(height: 1.73, weight: 58.0);

            string expected = "normal weight";
            string actual = personGetClassification.Invoke(person);

            if (actual != expected)
            {
                string message = string.Format(
                    "Person.GetClassification() returns \"{0}\" instead of \"{1}\" for Height 1.73 & Weight = 58.0",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("Person.GetClassification() returns \"over-weight\" for Height = 1.70 & Weight = 74.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsOverWeight()
        {
            Person person = CreatePerson(height: 1.70, weight: 74.0);

            string expected = "over-weight";
            string actual = personGetClassification.Invoke(person);

            if (actual != expected)
            {
                string message = string.Format(
                    "Person.GetClassification() returns \"{0}\" instead of \"{1}\" for Height = 1.70 & Weight = 74.0",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        [TestMethod("Person.GetClassification() returns \"obese\" for Height = 1.85 & Weight = 120.0"), TestCategory("Exercise 2C")]
        public void PersonGetClassificationReturnsObese()
        {
            Person person = CreatePerson(height: 1.85, weight: 120.0);

            string expected = "obese";
            string actual = personGetClassification.Invoke(person);

            if (actual != expected)
            {
                string message = string.Format(
                    "Person.GetClassification() returns \"{0}\" instead of \"{1}\" for Height = 1.85 & Weight = 120.0",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }
    }
}
