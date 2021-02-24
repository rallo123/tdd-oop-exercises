using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
using TestTools.Structure;
using System.ComponentModel;
using static TestTools.Unit.TestExpression;
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
            test.AssertPublicProperty<Customer, int>(c => c.ID);
            test.Execute();
        }

        [TestMethod("b. Customer.FirstName is a public property"), TestCategory("5A")]
        public void CustomerFirstNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Customer, string>(c => c.FirstName);
            test.Execute();
        }

        [TestMethod("c. Customer.LastName is a public property"), TestCategory("5A")]
        public void CustomerLastNameIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Customer, string>(c => c.LastName);
            test.Execute();
        }
        #endregion

        #region exercise 5B
        [TestMethod("a. Customer.ID emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerIDEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetID(1)));

            test.Execute();
        }

        [TestMethod("b. Customer.ID does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerIDDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetID(0)));

            test.Execute();
        }

        [TestMethod("c. Customer.FirstName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerFirstNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetFirstName("bcd")));

            test.Execute();
        }

        [TestMethod("d. Customer.FirstName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerFirstNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetFirstName("abc")));

            test.Execute();
        }

        [TestMethod("e. Customer.LastName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerLastNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetLastName("bcd")));

            test.Execute();
        }

        [TestMethod("f. Customer.LastName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerLastNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(customer, c => c.SetLastName("abc")));

            test.Execute();
        }
        #endregion
    }
}
