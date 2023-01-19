using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMv2
{
    public class AccountManager
    {
        private readonly List<Account> accounts;
        public string LoggedInAccountNumber { get; set; }
        public AccountManager() 
        {
            accounts = new List<Account>();
        }
        public void AddAccount(Account account) 
        {
            accounts.Add(account);
        }
        public Account GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
        public decimal GetBalance(string accountNumber)
        {
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new Exception("Invalid account number.");
            }
            return account.Balance;
        }
        public bool AuthenticateAccount(string accountNumber, int pinCode)
        {
            foreach (Account account in accounts)
            {
                if (account.AccountNumber == accountNumber && account.PinCode == pinCode)
                {
                    LoggedInAccountNumber = accountNumber;
                    return true;
                }
            }

            return false;
        }
        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new Exception("Invalid account number.");
            }
            account.Deposit(amount);
        }
        public bool Withdraw(string accountNumber, decimal amount)
        {
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new Exception("Invalid account number.");
            }
            return account.Withdraw(amount);
        }
        public bool ChangePinCode(string accountNumber, int oldPinCode, int newPinCode)
        {
            Account account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return false;
            }

            if (account.PinCode == oldPinCode)
            {
                account.PinCode = newPinCode;
                return true;
            }

            return false;
        }

    }
}
