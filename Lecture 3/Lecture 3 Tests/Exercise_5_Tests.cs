using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Unit;
using TestTools.Structure;
using static TestTools.Unit.TestExpression;
using static Lecture_3_Tests.TestHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
        #region Exercise 5A
        [TestMethod("a. BankAccount.Balance is public read-only decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIsDecimalProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicReadonlyProperty<BankAccount, decimal>(b => b.Balance);
            test.Execute();
        }

        [TestMethod("b. BankAccount.BorrowingRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<BankAccount, decimal>(b => b.BorrowingRate);
            test.Execute();
        }

        [TestMethod("c. BankAccount.SavingsRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertPublicProperty<BankAccount, decimal>(b => b.SavingsRate);
            test.Execute();
        }

        [TestMethod("d. BankAccount.Balance is initalized as 0M"), TestCategory("Exercise 5A")]
        public void BalanceIsInitilizedAs0()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(0M));

            test.Execute();
        }

        [TestMethod("e. BankAccount.BorrowingRate is initalized as 0.6M"), TestCategory("Exercise 5A")]
        public void BorrowingRateIsInitilizedAs0Point6()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Assert.AreEqual(Expr(account, a => a.BorrowingRate), Const(0.06M));

            test.Execute();
        }

        [TestMethod("f. BankAccount.SavingsRate is initalized as 0.02M"), TestCategory("Exercise 5A")]
        public void SavingsRateIsInitilizedAs0Point2()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Assert.AreEqual(Expr(account, a => a.SavingsRate), Const(0.02M));

            test.Execute();
        }

        [TestMethod("g. BankAccount.BorrowingRate ignores assignment of 0.05M"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIgnoresAssignmentOfFivePercent() {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.SetBorrowingRate(0.05M)));
            test.Assert.AreEqual(Expr(account, a => a.BorrowingRate), Const(0.06M));

            test.Execute();
        }

        [TestMethod("h. BankAccount.SavingsRate ignores assignment of 0.03M"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIgnoresAssignmentOfThreePercent()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.SetSavingsRate(0.03M)));
            test.Assert.AreEqual(Expr(account, a => a.BorrowingRate), Const(0.02M));

            test.Execute();
        }
        #endregion

        #region Exercise 5B
        [TestMethod("a. BankAccount.Deposit(int amount) adds amount to Balance"), TestCategory("Exercise 5B")]
        public void BankAccountDepositAddsAmountToBalance()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Deposit(50M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(50M));

            test.Execute();
        }

        [TestMethod("b. BankAccount.Deposit(int amount) does not change balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountDepositDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Deposit(-1M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(0M));

            test.Execute();
        }

        [TestMethod("c. BankAccount.Withdraw(int amount) subtracts amount of Balance"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawSubtractsAmountOfBalance()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Withdraw(50M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(-50M));

            test.Execute();
        }

        [TestMethod("d. BankAccount.Withdraw(int amount) does not change Balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = Factory.CreateTest();
            TestVariable<BankAccount> account = test.CreateVariable<BankAccount>(nameof(account));

            test.Arrange(account, Expr(() => new BankAccount()));
            test.Act(Expr(account, a => a.Withdraw(-1M)));
            test.Assert.AreEqual(Expr(account, a => a.Balance), Const(0M));

            test.Execute();
        }
        #endregion
    }
}
