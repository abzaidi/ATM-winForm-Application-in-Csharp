using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMv2
{
    public class CheckingAccount : Account
    {
        public decimal OverdraftLimit { get; set; }

        public CheckingAccount(string accountNumber, string customerName, int pinCode, decimal balance, decimal overdraftLimit)
            : base(accountNumber, customerName, pinCode, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            if (amount > Balance + OverdraftLimit)
            {
                MessageBox.Show("Insufficient balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            MessageBox.Show("Withdrawl successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Balance -= amount;
            return true;
        }
    }
}
