using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMv2
{
    public partial class LoginForm : Form
    {
        private Account account;
        private AccountManager accountManager;
        public LoginForm(Account account, AccountManager accountManager)
        {
            InitializeComponent();
            this.account = account;
            this.accountManager = accountManager;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountNumber = textBox1.Text;
            int pinCode = int.Parse(textBox2.Text);

            if (accountManager.AuthenticateAccount(accountNumber, pinCode))
            {
                Account account = accountManager.GetAccount(accountNumber);
                MenuForm menuForm = new MenuForm(account, accountManager);

                menuForm.welcome.Text = "Welcome, " + account.CustomerName;
                menuForm.Show();
                Close();
                
            }
            else
            {
                MessageBox.Show("Invalid account number or pin code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
