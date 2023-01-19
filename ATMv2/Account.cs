using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMv2
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string CustomerName { get; set; }
        public int PinCode { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string customerName, int pinCode, decimal balance)
        {
            AccountNumber = accountNumber;
            CustomerName = customerName;
            PinCode = pinCode;
            Balance = balance;
        }
        public virtual void Deposit(decimal amount, bool calculateInterest = true)
        {
            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                MessageBox.Show("Insufficient balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Balance -= amount;
            MessageBox.Show("Withdrawl successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
