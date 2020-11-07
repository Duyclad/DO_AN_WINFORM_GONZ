using QUANLYQUANTRASUA.DAO;
using QUANLYQUANTRASUA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }
        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPass.Text;
            string reenterPass = txbReEnterPass.Text;
            string userName = txbUserName.Text;
            string StrNull = "";


            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newpass);
            byte[] temp2 = ASCIIEncoding.ASCII.GetBytes(reenterPass);
            byte[] temp3 = ASCIIEncoding.ASCII.GetBytes(StrNull);

            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            byte[] hasData1 = new MD5CryptoServiceProvider().ComputeHash(temp1);
            byte[] hasData2 = new MD5CryptoServiceProvider().ComputeHash(temp2);
            byte[] hasData3 = new MD5CryptoServiceProvider().ComputeHash(temp3);

            //var list = hasData.ToString();
            //list.Reverse();

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string hasPass1 = "";

            foreach (byte item in hasData1)
            {
                hasPass1 += item;
            }

            string hasPass2 = "";

            foreach (byte item in hasData2)
            {
                hasPass2 += item;
            }

            string hasPass3 = "";

            foreach (byte item in hasData3)
            {
                hasPass3 += item;
            }


            if (!hasPass1.Equals(hasPass2))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (hasPass1==hasPass3)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                    return;
                }
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, hasPass, hasPass1))
                {
                    MessageBox.Show("Cập nhật thành công");
                    //if (updateAccount != null)
                     //   updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }






        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txbPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txbNewPass.UseSystemPasswordChar = false;
            }
            else
            {
                txbNewPass.UseSystemPasswordChar = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txbReEnterPass.UseSystemPasswordChar = false;
            }
            else
            {
                txbReEnterPass.UseSystemPasswordChar = true;
            }
        }
    }
}
