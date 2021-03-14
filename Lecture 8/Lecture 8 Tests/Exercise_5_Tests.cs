using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Structure;
using TestTools.Unit;
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
        [TestMethod("a. Customer.ID is a public property"), TestCategory("Exercise 5A")]
        public void CustomerIDIsAPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Customer, int>(c => c.ID);
            test.Execute();
        }

        [TestMethod("b. Customer.FirstName is a public property"), TestCategory("Exercise 5A")]
        public void CustomerFirstNameIsAPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Customer, string>(c => c.FirstName);
            test.Execute();
        }

        [TestMethod("c. Customer.LastName is a public property"), TestCategory("Exercise 5A")]
        public void CustomerLastNameIsAPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<Customer, string>(c => c.LastName);
            test.Execute();
        }
        #endregion

        #region exercise 5B
        [TestMethod("a. Customer.ID emits PropertyChanged event on new value"), TestCategory("Exercise 5B")]
        public void CustomerIDEmitsPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                ID = 0
            };
            DelegateAssert.IsInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler); 

            customer.ID = 1;

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetID(1)));
            test.Execute();
        }

        [TestMethod("b. Customer.ID does not emit PropertyChanged event on same value"), TestCategory("Exercise 5B")]
        public void CustomerIDDoesNotEmitPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                ID = 0
            };
            DelegateAssert.IsNotInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler);

            customer.ID = 0;

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { ID = 0 }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetID(0)));
            test.Execute();
        }

        [TestMethod("c. Customer.FirstName emits PropertyChanged event on new value"), TestCategory("Exercise 5B")]
        public void CustomerFirstNameEmitsPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                FirstName = "abc"
            };
            DelegateAssert.IsInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler);

            customer.FirstName = "bcd";

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetFirstName("bcd")));
            test.Execute();
        }

        [TestMethod("d. Customer.FirstName does not emit PropertyChanged event on same value"), TestCategory("Exercise 5B")]
        public void CustomerFirstNameDoesNotEmitPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                FirstName = "abc"
            };
            DelegateAssert.IsNotInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler);

            customer.FirstName = "abc";
            
            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { FirstName = "abc" }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetFirstName("abc")));
            test.Execute();
        }

        [TestMethod("e. Customer.LastName emits PropertyChanged event on new value"), TestCategory("Exercise 5B")]
        public void CustomerLastNameEmitsPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                LastName = "abc"
            };
            DelegateAssert.IsInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler);

            customer.LastName = "bcd";

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetLastName("bcd")));
            test.Execute();
        }

        [TestMethod("f. Customer.LastName does not emit PropertyChanged event on same value"), TestCategory("Exercise 5B")]
        public void CustomerLastNameDoesNotEmitPropertyChangedEvent()
        {
            // MSTest Extended
            Customer customer = new Customer()
            {
                LastName = "abc"
            };
            DelegateAssert.IsNotInvoked<PropertyChangedEventHandler>(handler => customer.PropertyChanged += handler);

            customer.LastName = "abc";

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<Customer> _customer = test.CreateVariable<Customer>();
            test.Arrange(_customer, Expr(() => new Customer() { LastName = "abc" }));
            test.DelegateAssert.IsNotInvoked(Lambda<PropertyChangedEventHandler>(handler => Expr(_customer, c => c.AddPropertyChanged(handler))));
            test.Act(Expr(_customer, c => c.SetLastName("abc")));
            test.Execute();
        } 
        #endregion
    }
}
