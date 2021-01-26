using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.StructureTests;
using TestTools.UnitTests;
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

            test.Arrange(customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.ID), Const(1));

            test.Execute();
        }

        [TestMethod("b. Customer.ID does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerIDDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsNotInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.ID), Const(0));

            test.Execute();
        }

        [TestMethod("c. Customer.FirstName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerFirstNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.FirstName), Const("bcd"));

            test.Execute();
        }

        [TestMethod("d. Customer.FirstName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerFirstNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsNotInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.FirstName), Const("abc"));

            test.Execute();
        }

        [TestMethod("e. Customer.LastName emits PropertyChanged event on new value"), TestCategory("5B")]
        public void CustomerLastNameEmitsPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.LastName), Const("bcd"));

            test.Execute();
        }

        [TestMethod("f. Customer.LastName does not emit PropertyChanged event on same value"), TestCategory("5B")]
        public void CustomerLastNameDoesNotEmitPropertyChangedEvent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> customer = test.CreateVariable<Customer>();

            test.Arrange(customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsNotInvoked(LambdaSubscribe<Customer, PropertyChangedEventHandler>("PropertyChanged"));
            test.Assign(Expr(customer, c => c.LastName), Const("abc"));

            test.Execute();
        }
        #endregion
    }
}
