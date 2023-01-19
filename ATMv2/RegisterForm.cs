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
    public partial class RegisterForm : Form
    {
        private Account account;
        private readonly AccountManager accountManager;

        public RegisterForm(AccountManager accountManager, Account account)
        {
            InitializeComponent();
            this.account = account;
            this.accountManager = accountManager;
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label7.Text = "Enter Interest Rate: ";
                textBox4.Visible= true;
                textBox5.Visible= false;
            }
            else
            {
                label7.Text = "Enter OverDraft Limit: ";
                textBox4.Visible = false;
                textBox5.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string accountNumber = textBox1.Text;
            string customerName = textBox2.Text;
            int pinCode = int.Parse(textBox3.Text);

                if (radioButton1.Checked)
                {
                    decimal interestRate = decimal.Parse(textBox4.Text);
                    account = new SavingsAccount(accountNumber, customerName, pinCode, 0, interestRate);
                    accountManager.AddAccount(account);
                }
                else
                {
                    decimal overdraftLimit = decimal.Parse(textBox5.Text);
                    account = new CheckingAccount(accountNumber, customerName, pinCode, 0, overdraftLimit);
                    accountManager.AddAccount(account);
                }
                
                MessageBox.Show("Account registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            
        }
    }
}
