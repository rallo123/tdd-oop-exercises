using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Syntax;

namespace Lecture_8_Solutions
{
    public delegate void BalanceChangeHandler(decimal currentBalance);

    public class BankAccount
    {
        decimal _balance;
        decimal _lowBalanceThreshold;
        decimal _highBalanceThreshold;

        public event BalanceChangeHandler LowBalance;
        public event BalanceChangeHandler HighBalance;

        public decimal Balance
        {
            get { return _balance; }
            private set 
            {
                _balance = value;

                if (value <= LowBalanceThreshold)
                    LowBalance?.Invoke(value);
                if (value >= HighBalanceThreshold)
                    HighBalance?.Invoke(value);
            }
        }

        public decimal LowBalanceThreshold
        {
            get { return _lowBalanceThreshold; }
            set
            {
                if (value > HighBalanceThreshold)
                    throw new ArgumentException();
                _lowBalanceThreshold = value;
            }
        }

        public decimal HighBalanceThreshold
        {
            get { return _highBalanceThreshold; }
            set
            {
                if (value < LowBalanceThreshold)
                    throw new ArgumentException();
                _highBalanceThreshold = value;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException();
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException();
            Balance -= amount;
        }

        // TestTools Code
        [PropertySet("LowBalanceThreshold")]
        public void SetLowBalanceThreshold(decimal value) => LowBalanceThreshold = value;

        [PropertySet("HighBalanceThreshold")]
        public void SetHighBalanceThreshold(decimal value) => HighBalanceThreshold = value;

        [EventAdd("LowBalance")]
        public void AddLowBalance(BalanceChangeHandler value) => LowBalance += value;

        [EventAdd("HighBalance")]
        public void AddHighBalance(BalanceChangeHandler value) => HighBalance += value;
    }
}
