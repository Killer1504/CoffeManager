using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            if(DangNhap(userName, password))
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
            }
            else
            {
                string _msg = "wrong userName or password";
                MessageBox.Show(_msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool DangNhap(string userName, string password)
        {
            return CoffeeManager.DAL.AccountDAL.Instance.Login(userName, password);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exit program?", "Exit", MessageBoxButtons.OKCancel
                ,MessageBoxIcon.Question);

            if(dialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
