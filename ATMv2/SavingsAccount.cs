using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMv2
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string accountNumber, string customerName, int pinCode, decimal balance, decimal interestRate)
            : base(accountNumber, customerName, pinCode, balance)
        {
            InterestRate = interestRate;
        }

        public void CalculateInterest()
        {
            decimal interest = Balance * (InterestRate / 100);
            Deposit(interest, false);
        }
        public override void Deposit(decimal amount, bool calculateInterest = true)
        {
            base.Deposit(amount);
            if (calculateInterest)
            {
                CalculateInterest();
            }
        }
    }
}
