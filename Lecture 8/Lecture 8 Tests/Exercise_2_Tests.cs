using Lecture_8_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TestTools.Unit;
using TestTools.Structure;
using TestTools.Structure;
using TestTools.Structure.Generic;
using static TestTools.Helpers.ExpressionHelper;
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
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.Balance, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("BankAccount.Balance is initialized as 0M"), TestCategory("2A")]
        public void BankBalanceIsInitializedAs0M()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(0M));

            test.Execute();
        }
        #endregion

        #region Exercise 2B
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

        [TestMethod("BankAccount.LowBalanceThreshold assigned above HighBalanceThreshold throws ArgumentException"), TestCategory("2A")]
        public void BankAccountLowBalanceThresholdBelowHighBalanceThresholdThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount() { HighBalanceThreshold = 0 }));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, decimal>(Expr(account, a => a.Balance), Const(1M));

            test.Execute();
        }

        [TestMethod("BankAccount.HighBalanceThreshold assigned below LowBalanceThreshold throws ArgumentException"), TestCategory("2A")]
        public void BankAccountHighBalanceThresholdBelowLowBalanceThresholdThrowsArgumentException()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount() { LowBalanceThreshold = 0 }));
            test.Assert.ThrowsExceptionOnAssignment<ArgumentException, decimal>(Expr(account, a => a.Balance), Const(-1M));

            test.Execute();
        }
        #endregion

        #region exercise 2C
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
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Deposit(50M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(50M));

            test.Execute();
        }

        [TestMethod("BankAccount.Withdraw(50) takes 50 from Balance")]
        public void BankAccountWithdrawTakesFromBalance()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Withdraw(50M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(-50M));

            test.Execute();
        }
        #endregion

        #region Exercise 2D
        [TestMethod("BalanceChangedHandler is public delegate")]
        public void BalanceChangeHandlerIsPublicDelegate()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertDelegate<BalanceChangeHandler, Action<decimal>>(IsPublicDelegate);
            test.Execute();
        }
        #endregion

        #region Exercise 2E
        [TestMethod("a. BankAccount.LowBalance is public event"), TestCategory("2E")]
        public void BankAccountMinEventIsPublicEvent()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent<BankAccount, BalanceChangeHandler>(GetEventInfo<BankAccount>("LowBalance"), IsPublicEvent);
            test.Execute();
        }

        [TestMethod("b. BankAccount.HighBalance is public event"), TestCategory("2E")]
        public void BankAccountHighBalanceMinEvent()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertEvent<BankAccount, BalanceChangeHandler>(GetEventInfo<BankAccount>("HighBalance"), IsPublicEvent);
            test.Execute();
        }

        [TestMethod("c. BankAccount.Withdraw(decimal amount) emits LowBalance if Balance goes below threshold"), TestCategory("2E")]
        public void BankAccountWithdrawEmitsLowBalance()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();
            
            test.Arrange(account, Expr(() => new BankAccount() { LowBalanceThreshold = 0 }));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<BankAccount, BalanceChangeHandler>("HighBalance"));
            test.Act(Expr(account, a => a.Withdraw(50M)));
            test.Execute();
        }

        [TestMethod("d. BankAccount.Deposit(decimal amount) emits HighBalance if Balance goes below threshold"), TestCategory("2E")]
        public void BankAccountDepositEmitsHighBalance()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>();

            test.Arrange(account, Expr(() => new BankAccount() { HighBalanceThreshold = 0 }));
            test.DelegateAssert.IsInvoked(LambdaSubscribe<BankAccount, BalanceChangeHandler>("HighBalance"));
            test.Act(Expr(account, a => a.Deposit(50)));
            test.Execute();
        }
        #endregion
    }
}
