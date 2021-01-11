using Lecture_3_Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestTools.Operation;
using TestTools.Integrated;
using static TestTools.Helpers.ExpressionHelper;
using System.Linq.Expressions;
using TestTools.Structure;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
        TestFactory factory = new TestFactory("Lecture_3");

        public void TestAssignmentOfBankAccontPropertyIgnoresValue<T>(Expression<Func<BankAccount, T>> property, T value)
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<BankAccount> account = test.Create<BankAccount>();

            test.Arrange(account, () => new BankAccount());
            test.Act(account, Assignment(property, value));
            test.AssertUnchanged(account, property);

            test.Execute();
        }


        /* Exercise 5A */
        [TestMethod("a. BankAccount.Balance is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIsDecimalProperty()
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.Balance,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("b. BankAccount.BorrowingRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIsPublicDecimalProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.BorrowingRate,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true },
                    SetMethod = new MethodOptions() { IsPublic = true }
                });
        }

        [TestMethod("c. BankAccount.SavingsRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIsPublicDecimalProperty() 
        {
            StructureTest test = factory.CreateStructureTest();
            test.AssertProperty<BankAccount, decimal>(
                b => b.SavingsRate,
                new PropertyOptions()
                {
                    GetMethod = new MethodOptions() { IsPublic = true },
                    SetMethod = new MethodOptions() { IsPublic = true }
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
            UnitTest test = factory.CreateTest();
            UnitTestObject<BankAccount> account = test.Create<BankAccount>();

            test.Arrange(account, () => new BankAccount() );
            test.Act(account, a => a.Deposit(50));
            test.Assert(account, a => a.Balance == 50M);

            test.Execute();
        }

        [TestMethod("b. BankAccount.Deposit(int amount) does not change balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountDepositDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<BankAccount> account = test.Create<BankAccount>();

            test.Arrange(account, () => new BankAccount());
            test.Act(account, a => a.Deposit(-1M));
            test.AssertUnchanged(account, a => a.Balance);

            test.Execute();
        }

        [TestMethod("c. BankAccount.Withdraw(int amount) subtracts amount of Balance"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawSubtractsAmountOfBalance()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<BankAccount> account = test.Create<BankAccount>();

            test.Arrange(account, () => new BankAccount());
            test.Act(account, a => a.Withdraw(50));
            test.Assert(account, a => a.Balance == -50M);

            test.Execute();
        }

        [TestMethod("d. BankAccount.Withdraw(int amount) does not change Balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawDoesNotChangeBalanceOnNegativeAmount()
        {
            UnitTest test = factory.CreateTest();
            UnitTestObject<BankAccount> account = test.Create<BankAccount>();

            test.Arrange(account, () => new BankAccount());
            test.Act(account, a => a.Withdraw(-1M));
            test.AssertUnchanged(account, a => a.Balance);

            test.Execute();
        }
    }
}
