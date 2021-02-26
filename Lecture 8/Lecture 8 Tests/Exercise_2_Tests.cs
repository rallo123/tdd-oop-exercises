using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_8_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_8_Tests
{
    [TestClass]
    public class Exercise_2_Tests
    {
        #region Exercise 2A
        [TestMethod("BankAccount.Balance is a public read-only Balance"), TestCategory("2A")]
        public void BankAccountBalanceIsAPublicReadonlyBalance()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<BankAccount, decimal>(b => b.Balance);
            test.Execute();
        }

        [TestMethod("BankAccount.Balance is initialized as 0M"), TestCategory("2A")]
        public void BankBalanceIsInitializedAs0M()
        {
            BankAccount account = new BankAccount();
            Assert.AreEqual(account.Balance, 0M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount()));
            test.Assert.AreEqual(Expr(_account, a => a.Balance), Const(0M));
            test.Execute();
        }
        #endregion

        #region Exercise 2B
        [TestMethod("BankAccount.LowBalanceThreshold is a public property")]
        public void BankAccountLowBalanceThresholdsIsAPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<BankAccount, decimal>(b => b.LowBalanceThreshold);
            test.Execute();
        }

        [TestMethod("BankAccount.HighBalanceThreshold is a public property")]
        public void BankAccountHighBalanceThresholdsIsAPublicProperty()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<BankAccount, decimal>(b => b.HighBalanceThreshold);
            test.Execute();
        }

        [TestMethod("BankAccount.LowBalanceThreshold assigned above HighBalanceThreshold throws ArgumentException"), TestCategory("2A")]
        public void BankAccountLowBalanceThresholdBelowHighBalanceThresholdThrowsArgumentException()
        {
            BankAccount account = new BankAccount()
            {
                HighBalanceThreshold = 0
            };
            Assert.ThrowsException<ArgumentException>(() => account.LowBalanceThreshold = 1M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount() { HighBalanceThreshold = 0 }));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_account, a => a.SetLowBalanceThreshold(1M)));
            test.Execute();
        }

        [TestMethod("BankAccount.HighBalanceThreshold assigned below LowBalanceThreshold throws ArgumentException"), TestCategory("2A")]
        public void BankAccountHighBalanceThresholdBelowLowBalanceThresholdThrowsArgumentException()
        {
            BankAccount account = new BankAccount()
            {
                LowBalanceThreshold = 0
            };
            Assert.ThrowsException<ArgumentException>(() => account.HighBalanceThreshold = -1M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount() { LowBalanceThreshold = 0 }));
            test.Assert.ThrowsExceptionOn<ArgumentException>(Expr(_account, a => a.SetHighBalanceThreshold(-1M)));
            test.Execute();
        }
        #endregion

        #region exercise 2C
        [TestMethod("BankAccount.Deposit(decimal amount) is a public method")]
        public void BankAccountDepositIsAPublicMehtod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<BankAccount, decimal>((b, d) => b.Deposit(d));
            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(decimal amount) is a public method")]
        public void BankAccountWithdrawIsAPublicMehtod()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicMethod<BankAccount, decimal>((b, d) => b.Withdraw(d));
            test.Execute();
        }

        [TestMethod("BankAccount.Deposit(50) adds 50 to Balance")]
        public void BankAccountDepositAddsToBalance()
        {
            BankAccount account = new BankAccount();

            account.Deposit(50M);

            Assert.AreEqual(account.Balance, 50M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount()));
            test.Act(Expr(_account, a => a.Deposit(50M)));
            test.Assert.AreEqual(Expr(_account, a => a.Balance), Const(50M));
            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(50) takes 50 from Balance")]
        public void BankAccountWithdrawTakesFromBalance()
        {
            BankAccount account = new BankAccount();

            account.Withdraw(50M);

            Assert.AreEqual(account.Balance, -50M);

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount()));
            test.Act(Expr(_account, a => a.Withdraw(50M)));
            test.Assert.AreEqual(Expr(_account, a => a.Balance), Const(-50M));
            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("BalanceChangedHandler is public delegate")]
        public void BalanceChangeHandlerIsPublicDelegate()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicDelegate<BalanceChangeHandler, Action<decimal>>();
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("a. BankAccount.LowBalance is public event"), TestCategory("2E")]
        public void BankAccountMinEventIsPublicEvent()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent(
                typeof(BankAccount).GetEvent("LowBalance"),
                new MemberAccessLevelVerifier(AccessLevels.Public),
                new EventHandlerTypeVerifier(typeof(BalanceChangeHandler)));
            test.Execute();
        }

        [TestMethod("b. BankAccount.HighBalance is public event"), TestCategory("2E")]
        public void BankAccountHighBalanceMinEvent()
        {
            // TestTools Code
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent(
                typeof(BankAccount).GetEvent("HighBalance"),
                new MemberAccessLevelVerifier(AccessLevels.Public),
                new EventHandlerTypeVerifier(typeof(BalanceChangeHandler)));
            test.Execute();
        }

        [TestMethod("c. BankAccount.Withdraw(decimal amount) emits LowBalance if Balance goes below threshold"), TestCategory("2E")]
        public void BankAccountWithdrawEmitsLowBalance()
        {
            // MSTest Extended
            BankAccount account = new BankAccount()
            {
                LowBalanceThreshold = 0
            };
            DelegateAssert.IsInvoked<BalanceChangeHandler>(handler => account.LowBalance += handler);

            account.Withdraw(50);

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount() { LowBalanceThreshold = 0 }));
            test.DelegateAssert.IsInvoked(Lambda<BalanceChangeHandler>(handler => Expr(_account, a => a.AddLowBalance(handler))));
            test.Act(Expr(_account, a => a.Withdraw(50M)));
            test.Execute();
        }

        [TestMethod("d. BankAccount.Deposit(decimal amount) emits HighBalance if Balance goes below threshold"), TestCategory("2E")]
        public void BankAccountDepositEmitsHighBalance()
        {
            // MSTest Extended
            BankAccount account = new BankAccount()
            {
                HighBalanceThreshold = 0
            };
            DelegateAssert.IsInvoked<BalanceChangeHandler>(handler => account.HighBalance += handler);

            account.Deposit(50);

            DelegateAssert.Verify();

            // TestTools Code
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> _account = test.CreateVariable<BankAccount>();
            test.Arrange(_account, Expr(() => new BankAccount() { HighBalanceThreshold = 0 }));
            test.DelegateAssert.IsInvoked(Lambda<BalanceChangeHandler>(handler => Expr(_account, a => a.AddHighBalance(handler))));
            test.Act(Expr(_account, a => a.Deposit(50)));
            test.Execute();
        }
        #endregion
    }
}
