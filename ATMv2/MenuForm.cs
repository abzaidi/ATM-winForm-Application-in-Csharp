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
    public partial class MenuForm : Form
    {
        private Account account;
        private readonly AccountManager accountManager;


        public MenuForm(Account account, AccountManager accountManager)
        {
            
            InitializeComponent();
            this.account = account;
            this.accountManager = accountManager;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                DepositForm depositForm = new DepositForm(account, accountManager, "deposit");
                depositForm.Show();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal balance = accountManager.GetBalance(account.AccountNumber);
            MessageBox.Show($"Your balance is {balance}", "Balance", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                DepositForm depositForm = new DepositForm(account, accountManager, "withdraw");
                depositForm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Error");
            }
            else
            {
                DepositForm depositForm = new DepositForm(account, accountManager, "changePin");
                depositForm.Show();
            }
        }
    }
}
