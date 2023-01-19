using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMv2
{
    public partial class DepositForm : Form
    {
        private string transactionType;
        private Account account;
        private AccountManager accountManager;
        public DepositForm(Account account, AccountManager accountManager, string transactionType)
        {
            InitializeComponent();
            this.account = account;
            this.accountManager = accountManager;
            this.transactionType = transactionType;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(textBox1.Text, out amount))
            {
                textBox1.BackColor = Color.Red;
            }
            else
            {
                textBox1.BackColor = SystemColors.Window;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (transactionType == "deposit")
            { 
            decimal amount = decimal.Parse(textBox1.Text);
            accountManager.Deposit(account.AccountNumber, amount);
            MessageBox.Show("Deposit successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (transactionType == "withdraw")
            {
                decimal amount = decimal.Parse(textBox1.Text);
                accountManager.Withdraw(account.AccountNumber, amount);
                
            }
            else if (transactionType == "changePin")
            {
                int newPin = int.Parse(textBox1.Text);
                accountManager.ChangePinCode(account.AccountNumber, account.PinCode, newPin);
                MessageBox.Show("Pin Code Changed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {
            if (transactionType == "withdraw")
            {
                label1.Text = "Withdraw Amount";
                button1.Text = "Withdraw";
            }
            else if (transactionType == "changePin")
            {
                label1.Text = "Change Pin";
                label2.Text = "Enter New Pin: ";
                button1.Text = "Change";
            }
            
        }
    }
}
