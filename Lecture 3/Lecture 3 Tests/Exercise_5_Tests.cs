using Lecture_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTools.Operation;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace Lecture_3_Tests
{
    [TestClass]
    public class Exercise_5_Tests
    {
#pragma warning disable IDE1006 // Naming Stylesw
        private ClassElement<BankAccount> bankAccount => new ClassElement<BankAccount>();
        private PropertyElement<BankAccount, decimal> bankAccountBalance => bankAccount.Property<decimal>("Balance", get: new AccessorOptions() { IsPublic = true }, set: new AccessorOptions());
        private PropertyElement<BankAccount, decimal> bankAccountBorrowingRate => bankAccount.Property<decimal>("BorrowingRate", get: new AccessorOptions() { IsPublic = true }, set: new AccessorOptions() { IsPublic = true });
        private PropertyElement<BankAccount, decimal> bankAccountSavingsRate => bankAccount.Property<decimal>("SavingsRate", get: new AccessorOptions() { IsPublic = true }, set: new AccessorOptions() { IsPublic = true });
        private ActionMethodElement<BankAccount, decimal> bankAccountDeposit => bankAccount.ActionMethod<decimal>("Deposit", new MethodOptions() { IsPublic = true });
        private ActionMethodElement<BankAccount, decimal> bankAccountWithdraw => bankAccount.ActionMethod<decimal>("Withdraw", new MethodOptions() { IsPublic = true });
        private ActionMethodElement<BankAccount, decimal> bankAccountAccrueOrChargeInterest => bankAccount.ActionMethod<decimal>("AccrueOrChargeInterest", new MethodOptions() { IsPublic = true });
        private BankAccount CreateBankAccount(decimal? balance = null, decimal? borrowingRate = null, decimal? savingsRate = null)
        {
            BankAccount instance = bankAccount.Constructor().Invoke();

            if (balance != null)
                bankAccountBalance.Set(instance, balance);
            if (borrowingRate != null)
                bankAccountBorrowingRate.Set(instance, borrowingRate);
            if (savingsRate != null)
                bankAccountSavingsRate.Set(instance, savingsRate);

            return instance;
        }
        private void DoNothing(object par) { }

        /* Exercise 5A */
        [TestMethod("a. BankAccount.Balance is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIsDecimalProperty() => DoNothing(bankAccountBalance);

        [TestMethod("b. BankAccount.BorrowingRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIsPublicDecimalProperty() => DoNothing(bankAccountBorrowingRate);

        [TestMethod("c. BankAccount.SavingsRate is public decimal property"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIsPublicDecimalProperty() => DoNothing(bankAccountSavingsRate);

        [TestMethod("d. BankAccount.Balance ignores assignment of -100001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfMinusOneHundredThousand() => Assignment.Ignored(CreateBankAccount(), bankAccountBalance, -100001M);

        [TestMethod("e. BankAccount.Balance ignores assignment of 250001M"), TestCategory("Exercise 5A")]
        public void BankAccountBalanceIgnoresAssignmentOfTwoHundredThousand() => Assignment.Ignored(CreateBankAccount(), bankAccountBalance, 250001M);

        [TestMethod("f. BankAccount.BorrowingRate ignores assignment of 0.05M"), TestCategory("Exercise 5A")]
        public void BankAccountBorrowingRateIgnoresAssignmentOfFivePercent() => Assignment.Ignored(CreateBankAccount(), bankAccountBorrowingRate, 0.05M);

        [TestMethod("g. BankAccount.SavingsRate ignores assignment of 0.03M"), TestCategory("Exercise 5A")]
        public void BankAccountSavingsRateIgnoresAssignmentOfThreePercent() => Assignment.Ignored(CreateBankAccount(), bankAccountSavingsRate, 0.03M);
#pragma warning restore IDE1006 // Naming Styles

        /* Exercise 5B */
        [TestMethod("a. BankAccount.Deposit(int amount) adds amount to Balance"), TestCategory("Exercise 5B")]
        public void BankAccountDepositAddsAmountToBalance()
        {
            BankAccount account = CreateBankAccount();
            decimal expected = bankAccountBalance.Get(account) + 50;

            bankAccountDeposit.Invoke(account, 50M);

            decimal actual = bankAccountBalance.Get(account);
            if (actual != expected)
                throw new AssertFailedException($"BankAccount.Balance is {actual} instead of {expected} after BankAccount.Deposit(50)");
        }

        [TestMethod("b. BankAccount.Deposit(int amount) does not change balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountDepositDoesNotChangeBalanceOnNegativeAmount()
        {
            BankAccount account = CreateBankAccount();
            decimal expected = bankAccountBalance.Get(account);

            bankAccountDeposit.Invoke(account, -1M);

            decimal actual = bankAccountBalance.Get(account);
            if (actual != expected)
                throw new AssertFailedException($"BankAccount.Balance is {actual} instead of {expected} after BankAccount.Deposit(-1)");
        }

        [TestMethod("c. BankAccount.Withdraw(int amount) subtracts amount of Balance"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawSubtractsAmountOfBalance()
        {
            BankAccount account = CreateBankAccount();
            decimal expected = bankAccountBalance.Get(account) - 50;

            bankAccountWithdraw.Invoke(account, 50M);

            decimal actual = bankAccountBalance.Get(account);
            if (actual != expected)
                throw new AssertFailedException($"BankAccount.Balance is {actual} instead of {expected} after BankAccount.Withdraw(50)");
        }

        [TestMethod("b. BankAccount.Withdraw(int amount) does not change Balance on negative amount"), TestCategory("Exercise 5B")]
        public void BankAccountWithdrawDoesNotChangeBalanceOnNegativeAmount()
        {
            BankAccount account = CreateBankAccount();
            decimal expected = bankAccountBalance.Get(account);

            bankAccountDeposit.Invoke(account, -1M);

            decimal actual = bankAccountBalance.Get(account);
            if (actual != expected)
                throw new AssertFailedException($"BankAccount.Balance is {actual} instead of {expected} after BankAccount.Withdraw(-1)");
        }
    }
}
