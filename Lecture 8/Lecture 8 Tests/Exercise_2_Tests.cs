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
using static TestTools.Helpers.ExpressionHelper;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_3_Tests
    {
        #region Exercise 3A
        [TestMethod("BankAccount.Balance is a public read-only Balance"), TestCategory("3A")]
        public void BankAccountBalanceIsAPublicReadonlyBalance()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.Balance, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("BankAccount.Balance is initialized as 0M"), TestCategory("3A")]
        public void BankBalanceIsInitializedAs0M()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Assert.IsTrue(a => a.Balance == 0);

            test.Execute();
        }
        #endregion

        #region Exercise 3B
        [TestMethod("BankAccount.LowBalanceThreshold is a public property")]
        public void BankAccountLowBalanceThresholdsIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.LowBalanceThreshold, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("BankAccount.HighBalanceThreshold is a public property")]
        public void BankAccountHighBalanceThresholdsIsAPublicProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.HighBalanceThreshold, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("BankAccount.LowBalanceThreshold assigned above HighBalanceThreshold throws ArgumentException"), TestCategory("3A")]
        public void BankAccountLowBalanceThresholdBelowHighBalanceThresholdThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount() { HighBalanceThreshold = 0 });
            account.Assert.ThrowsException<ArgumentException>(Assignment<BankAccount, decimal>(a => a.LowBalanceThreshold, 1));

            test.Execute();
        }

        [TestMethod("BankAccount.HighBalanceThreshold assigned below LowBalanceThreshold throws ArgumentException"), TestCategory("3A")]
        public void BankAccountHighBalanceThresholdBelowLowBalanceThresholdThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount() { LowBalanceThreshold = 0 });
            account.Assert.ThrowsException<ArgumentException>(Assignment<BankAccount, decimal>(a => a.HighBalanceThreshold, -1));

            test.Execute();
        }
        #endregion

        #region exercise 3C
        [TestMethod("BankAccount.Deposit(decimal amount) is a public method")]
        public void BankAccountDepositIsAPublicMehtod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<BankAccount, decimal>((b, d) => b.Deposit(d), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(decimal amount) is a public method")]
        public void BankAccountWithdrawIsAPublicMehtod()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertMethod<BankAccount, decimal>((b, d) => b.Withdraw(d), IsPublicMethod);
            test.Execute();
        }

        [TestMethod("BankAccount.Deposit(50) adds 50 to Balance")]
        public void BankAccountDepositAddsToBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> bankAccount = test.CreateObject<BankAccount>();

            bankAccount.Arrange(() => new BankAccount());
            bankAccount.Act(b => b.Deposit(50M));
            bankAccount.Assert.IsTrue(b => b.Balance == 50M);

            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(50) takes 50 from Balance")]
        public void BankAccountWithdrawTakesFromBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> bankAccount = test.CreateObject<BankAccount>();

            bankAccount.Arrange(() => new BankAccount());
            bankAccount.Act(b => b.Withdraw(50M));
            bankAccount.Assert.IsTrue(b => b.Balance == -50M);

            test.Execute();
        }
        #endregion

        #region 3D
        [TestMethod("BalanceChangedHandler is public delegate")]
        public void BalanceChangeHandlerIsPublicDelegate()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertDelegate<BalanceChangeHandler, Action<decimal>>(IsPublicDelegate);
            test.Execute();
        }
        #endregion

        #region Exercise 3E
        [TestMethod("BankAccount.LowBalance is public event")]
        public void BankAccountMinEventIsPublicEvent()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent<BankAccount, BalanceChangeHandler>(GetEventInfo<BankAccount>("LowBalance"), IsPublicEvent);
            test.Execute();
        }

        [TestMethod("BankAccount.HighBalance is public event")]
        public void BankAccountHighBalanceMinEvent()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent<BankAccount, BalanceChangeHandler>(GetEventInfo<BankAccount>("HighBalance"), IsPublicEvent);
            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(decimal amount) emits LowBalance if Balance goes below threshold")]
        public void BankAccount()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> bankAccount = test.CreateObject<BankAccount>();
            UnitTestEventTracker<BalanceChangeHandler> tracker = test.CreateEventTracker<BalanceChangeHandler>();

            bankAccount.Arrange(() => new BankAccount() { LowBalanceThreshold = 0 });
            bankAccount.WithParameters(tracker).Act(Subscribe<BankAccount, BalanceChangeHandler>("LowBalance"));
            bankAccount.Act(b => b.Withdraw(50M));
            tracker.Assert.IsTrue<decimal>((currentBalance) => currentBalance == -50);

            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(decimal amount) emits LowBalance if Balance goes below threshold")]
        public void BankAccountWithdrawEmitsLowBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> bankAccount = test.CreateObject<BankAccount>();
            UnitTestEventTracker<BalanceChangeHandler> tracker = test.CreateEventTracker<BalanceChangeHandler>();

            bankAccount.Arrange(() => new BankAccount() { LowBalanceThreshold = 0 });
            bankAccount.WithParameters(tracker).Act(Subscribe<BankAccount, BalanceChangeHandler>("LowBalance"));
            bankAccount.Act(b => b.Withdraw(50M));
            tracker.Assert.IsTrue<decimal>((currentBalance) => currentBalance == -50);

            test.Execute();
        }

        [TestMethod("BankAccount.Deposit(decimal amount) emits HighBalance if Balance goes below threshold")]
        public void BankAccountDepositEmitsHighBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> bankAccount = test.CreateObject<BankAccount>();
            UnitTestEventTracker<BalanceChangeHandler> tracker = test.CreateEventTracker<BalanceChangeHandler>();

            bankAccount.Arrange(() => new BankAccount() { HighBalanceThreshold = 0 });
            bankAccount.WithParameters(tracker).Act(Subscribe<BankAccount, BalanceChangeHandler>("HighBalance"));
            bankAccount.Act(b => b.Deposit(50M));
            tracker.Assert.IsTrue<decimal>((currentBalance) => currentBalance == -50);

            test.Execute();
        }
        #endregion
    }
}
