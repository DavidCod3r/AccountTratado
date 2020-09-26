using BancoExce.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BancoExce.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double initialDeposit, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Deposit(initialDeposit);
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("Withdraw error: The exceeds withdraw limit.");
            }
            if(amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }

            Balance -= amount;
        }

        public override string ToString()
        {
            return $"{Balance.ToString("F2", CultureInfo.InvariantCulture)}";
        }

    }
}
