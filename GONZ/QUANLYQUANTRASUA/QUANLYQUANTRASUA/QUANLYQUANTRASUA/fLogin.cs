using QUANLYQUANTRASUA.DAO;
using QUANLYQUANTRASUA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace QUANLYQUANTRASUA
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            DataProvider.Instance.connect();
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (Login(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fTableManager f = new fTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        

        private void FLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = false;
        }

       /* private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = true;
        }*/

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = true;
        }


        /*private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txbPassWord.UseSystemPasswordChar = false;
        }*/
    }
}
