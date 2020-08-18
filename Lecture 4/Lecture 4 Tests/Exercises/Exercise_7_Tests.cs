using Lecture_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_4_Tests
{
    [TestClass]
    public class Exercise_7_Tests
    {
#pragma warning disable IDE1006 // Naming Styles
        private ClassElement<NotOldEnoughException> notOldEnoughException => new ClassElement<NotOldEnoughException>(new ClassOptions() { BaseType = typeof(Exception) });
        private PropertyElement<NotOldEnoughException, string> notOldEnoughExceptionMessage => notOldEnoughException.Property<string>("Message", get: new AccessorOptions() { AccessLevel = AccessLevel.Public });

        private ClassElement<Person> person => new ClassElement<Person>();
        private PropertyElement<Person, double> personHeight => person.Property<double>("Height", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, double> personWeight => person.Property<double>("Weight", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private PropertyElement<Person, int> personAge => person.Property<int>("Age", get: new AccessorOptions() { AccessLevel = AccessLevel.Public }, set: new AccessorOptions() { AccessLevel = AccessLevel.Public });
        private FuncMethodElement<Person, double> personCalculateBMI => person.FuncMethod<double>("CalculateBMI", new MethodOptions() { AccessLevel = AccessLevel.Public });


        private Person CreatePerson(string name = "Allan", double? height = null, double? weight = null, int? age = null)
        {
            Person instance = person.Constructor<string>().Invoke(name);

            if (height != null)
                personHeight.Set(instance, height);
            if (weight != null)
                personWeight.Set(instance, weight);
            if (age != null)
                personAge.Set(instance, age);

            return instance;
        }

        private void DoNothing(object par) { }
#pragma warning restore IDE1006 // Naming Styles

        /* Exercise 7A */
        [TestMethod("a. NotOldEnoughException is subclass of Exception"), TestCategory("Exercise 7A")]
        public void NotOldEnoughExceptionIsSubclassOfException() => DoNothing(notOldEnoughException);

        /* Exercise 7B */
        [TestMethod("a. NotOldEnoughException() results in Message = \"Person is too young\""), TestCategory("Exercise 7B")]
        public void ParameterlessPersonConstructorAssignsMessageProperty()
        {
            NotOldEnoughException exception = notOldEnoughException.Constructor().Invoke();

            string expected = "Person is too young";
            string actual = notOldEnoughExceptionMessage.Get(exception);

            if (actual != expected)
            {
                string message = string.Format(
                    "NotOldEnoughException.Message is \"{0}\" instead of \"{1}\" after construction by NotOldEnoughException()",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        /* Exercise 7C */
        [TestMethod("d. NotOldEnoughException(string activity) results in Message = \"Person is too young to [activity]\""), TestCategory("Exercise 7C")]
        public void PersonConstructorAssignsMessageProperty()
        {
            NotOldEnoughException exception = notOldEnoughException.Constructor<string>().Invoke("do something");

            string expected = "Person is too young to do something";
            string actual = notOldEnoughExceptionMessage.Get(exception);

            if (actual != expected)
            {
                string message = string.Format(
                    "NotOldEnoughException.Message is \"{0}\" instead of \"{1}\" after construction by NotOldEnoughException(\"do activity\")",
                    actual,
                    expected
                );
                throw new AssertFailedException(message);
            }
        }

        /* Exercise 7D */
        [TestMethod("a. Person.Age is public int property"), TestCategory("Exercise 7D")]
        public void PersonAgeIsPublicIntProperty() => DoNothing(personAge);

        [TestMethod("b. Person.CalculateBMI() throws NotOldEnoughException for Height = 1.80, Weight = 80.0 & Age = 15"), TestCategory("Exercise 7D")]
        public void PersonCalculateBMIThrowsNotOldEnoughException()
        {
            Person person = CreatePerson(height: 1.80, weight: 80.0, age: 15);

            try
            {
                personCalculateBMI.Invoke(person);
                throw new AssertFailedException("Person.CalculateBMI() does not throw on Height = 1.80, Weight = 80.0 & Age = 15");
            }
            catch (AssertFailedException ex)
            {
                if (ex.InnerException == null)
                    throw ex;
                if (ex.InnerException.GetType() != typeof(NotOldEnoughException))
                {
                    string message = string.Format(
                        "Person.CalculateBMI() does not throws {0} instead of {1} on Height = 1.80, Weight = 80.0 & Age = 15",
                        ex.InnerException.GetType().Name,
                        "NotOldEnoughException"
                    );
                }
            }
        }
    }
}
