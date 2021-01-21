using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Operation;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;
using System.Linq.Expressions;
using TestTools.Structure;
using static Lecture_3_Tests.TestHelper;
using static TestTools.Helpers.StructureHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
        public void TestAssignmentOfBankAccontPropertyIgnoresValue<T>(Expression<Func<BankAccount, T>> property, T value, T defaultValue)
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(Assignment(property, value));
            account.Assert.IsTrue(Equality(property, defaultValue));

            test.Execute();
        }


        /* Exercise 5A */
        [TestMethod("a. BankAccount.Balance is public read-only decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIsDecimalProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.Balance, IsPublicReadonlyProperty);
            test.Execute();
        }

        [TestMethod("b. BankAccount.BorrowingRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.BorrowingRate, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("c. BankAccount.SavingsRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(b => b.SavingsRate, IsPublicProperty);
            test.Execute();
        }

        [TestMethod("d. BankAccount.Balance is initalized as 0M"), TestCategory("Exercise 5A")]
        public void BalanceIsInitilizedAs0()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Assert.IsTrue(b => b.Balance == 0M);

            test.Execute();
        }

        [TestMethod("e. BankAccount.BorrowingRate is initalized as 0.6M"), TestCategory("Exercise 5A")]
        public void BorrowingRateIsInitilizedAs0Point6()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Assert.IsTrue(b => b.BorrowingRate == 0.06M);

            test.Execute();
        }

        [TestMethod("f. BankAccount.SavingsRate is initalized as 0.02M"), TestCategory("Exercise 5A")]
        public void SavingsRateIsInitilizedAs0Point2()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Assert.IsTrue(b => b.SavingsRate == 0.02M);

            test.Execute();
        }

        [TestMethod("g. BankAccount.Balance ignores assignment of -100001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfMinusOneHundredThousand() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.Balance, -100001M, 0M);

        [TestMethod("h. BankAccount.Balance ignores assignment of 250001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfTwoHundredThousand() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.Balance, 250001M, 0);

        [TestMethod("i. BankAccount.BorrowingRate ignores assignment of 0.05M"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIgnoresAssignmentOfFivePercent() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.BorrowingRate, 0.05M, 0.06M);

        [TestMethod("j. BankAccount.SavingsRate ignores assignment of 0.03M"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIgnoresAssignmentOfThreePercent() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.SavingsRate, 0.03M, 0.02M);

        /* Exercise 5B */
        [TestMethod("a. BankAccount.Deposit(int amount) adds amount to Balance"), TestCategory("Exercise 5B")]
        public void BankAccountDepositAddsAmountToBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(a => a.Deposit(50));
            account.Assert.IsTrue(a => a.Balance == 50M);

            test.Execute();
        }

        [TestMethod("b. BankAccount.Deposit(int amount) does not change balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountDepositDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(a => a.Deposit(-1M));
            account.Assert.IsTrue(a => a.Balance == 0M);

            test.Execute();
        }

        [TestMethod("c. BankAccount.Withdraw(int amount) subtracts amount of Balance"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawSubtractsAmountOfBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(a => a.Withdraw(50));
            account.Assert.IsTrue(a => a.Balance == -50M);

            test.Execute();
        }

        [TestMethod("d. BankAccount.Withdraw(int amount) does not change Balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(a => a.Withdraw(-1M));
            account.Assert.IsTrue(a => a.Balance == 0M);

            test.Execute();
        }
    }
}
