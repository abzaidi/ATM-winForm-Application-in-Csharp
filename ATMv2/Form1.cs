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
    public partial class Form1 : Form
    {
        private Account account;
        private AccountManager _accountManager;

        public Form1(Account account, AccountManager accountManager)
        {
            InitializeComponent();
            this.account = account;
            _accountManager = accountManager;
        }
        public void CloseForm()
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_accountManager, account);
            registerForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(account, _accountManager);
            loginForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
