using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Integrated;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;
using System.ComponentModel;
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
        #region Exercise 5A
        [TestMethod("a. Customer.ID is a public property"), TestCategory("5A")]
        public void CustomerIDIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Customer, int>(c => c.ID, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("b. Customer.FirstName is a public property"), TestCategory("5A")]
        public void CustomerFirstNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Customer, string>(c => c.FirstName, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. Customer.LastName is a public property"), TestCategory("5A")]
        public void CustomerLastNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<Customer, string>(c => c.LastName, IsPublicProperty);
            test.Execute();
        }
        #endregion

        #region exercise 5B
        [TestMethod("a. Customer.ID emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerIDEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { ID = 0 });
            customer.DelegateAssert.IsInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, int>(c => c.ID, 1));

            test.Execute();
        }

        [TestMethod("b. Customer.ID does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerIDDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { ID = 0 });
            customer.DelegateAssert.IsNotInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, int>(c => c.ID, 0));

            test.Execute();
        }

        [TestMethod("c. Customer.FirstName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerFirstNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { FirstName = "abc" });
            customer.DelegateAssert.IsInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, string>(c => c.FirstName, "bcd"));

            test.Execute();
        }

        [TestMethod("d. Customer.FirstName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerFirstNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { FirstName = "abc" });
            customer.DelegateAssert.IsNotInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, string>(c => c.FirstName, "abc"));

            test.Execute();
        }

        [TestMethod("e. Customer.LastName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerLastNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { LastName = "abc" });
            customer.DelegateAssert.IsInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, string>(c => c.LastName, "bcd"));

            test.Execute();
        }

        [TestMethod("f. Customer.LastName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerLastNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            customer.Arrange(() => new Customer() { LastName = "abc" });
            customer.DelegateAssert.IsNotInvoked(Subscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            customer.Act(Assignment<Customer, string>(c => c.LastName, "abc"));

            test.Execute();
        }
        #endregion
    }
}
