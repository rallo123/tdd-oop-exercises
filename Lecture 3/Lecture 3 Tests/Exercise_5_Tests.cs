using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Operation;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;
using System.Linq.Expressions;
using TestTools.Structure;
using static Lecture_3_Tests.TestHelper;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
        public void TestAssignmentOfBankAccontPropertyIgnoresValue<T>(Expression<Func<BankAccount, T>> property, T value)
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount());
            account.Act(Assignment(property, value));
            account.Assert.Unchanged(property);

            test.Execute();
        }


        /* Exercise 5A */
        [TestMethod("a. BankAccount.Balance is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIsDecimalProperty()
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.Balance,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("b. BankAccount.BorrowingRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.BorrowingRate,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("c. BankAccount.SavingsRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIsPublicDecimalProperty() 
        {
            StructureTest test = Factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.SavingsRate,
                new PropertyRequirements()
                {
                    GetMethod = new MethodRequirements() { IsPublic = true },
                    SetMethod = new MethodRequirements() { IsPublic = true }
                });
        }

        [TestMethod("d. BankAccount.Balance ignores assignment of -100001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfMinusOneHundredThousand() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.Balance, -100001M);

        [TestMethod("e. BankAccount.Balance ignores assignment of 250001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfTwoHundredThousand() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.Balance, 250001M);

        [TestMethod("f. BankAccount.BorrowingRate ignores assignment of 0.05M"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIgnoresAssignmentOfFivePercent() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.BorrowingRate, 0.05M);

        [TestMethod("g. BankAccount.SavingsRate ignores assignment of 0.03M"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIgnoresAssignmentOfThreePercent() => TestAssignmentOfBankAccontPropertyIgnoresValue(b => b.SavingsRate, 0.03M);

        /* Exercise 5B */
        [TestMethod("a. BankAccount.Deposit(int amount) adds amount to Balance"), TestCategory("Exercise 5B")]
        public void BankAccountDepositAddsAmountToBalance()
        {
            UnitTest test = Factory.CreateTest();
            UnitTestObject<BankAccount> account = test.CreateObject<BankAccount>();

            account.Arrange(() => new BankAccount() );
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
            account.Assert.Unchanged(a => a.Balance);

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
            account.Assert.Unchanged(a => a.Balance);

            test.Execute();
        }
    }
}
