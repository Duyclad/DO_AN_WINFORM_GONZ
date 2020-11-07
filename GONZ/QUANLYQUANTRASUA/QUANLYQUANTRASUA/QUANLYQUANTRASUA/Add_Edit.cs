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

namespace QUANLYQUANTRASUA
{
    public partial class Add_Edit : Form
    {
        public Add_Edit(string s, string username, string name, string cbbox, int nm)
        {
            x = s;
            InitializeComponent();
            if (s == "AddCategory")
            {
                AddCategory();
                
            }
            if (s == "AddFood")
            {
                AddFood();
                loadcombo(cbStatus);
            }
            if (s == "AddTable")
            {
                AddTable();
                cbStatus.Enabled = false;
            }
            if (s == "AddAccount")
            {
                AddAccountcontrol();
                txbFoodID.Enabled = true;
                txbFoodID.Text = "";
                nmPrice.Maximum = 1;
            }
            if (s == "EditAccount")
            {
                userid = username;
                nameid = name;
                nmid = nm;
                EditAccountcontrol();
                txbFoodID.Enabled = true;
                txbFoodID.Text = username;
                txbFoodName.Text = name;
                nmPrice.Value = nm;
                nmPrice.Maximum = 1;
            }
            if (s == "EditTable")
            {
                userid = username;
                nameid = name;
                EditTable();
                txbFoodID.Text = username;
                txbFoodName.Text = name;
                cbStatus.Enabled = false;

            }
            if (s == "EditCategory")
            {
                userid = username;
                nameid = name;
                EditCategory();
                txbFoodID.Text = username;
                txbFoodName.Text = name;

            }
            if (s == "EditFood")
            {
                EditFood();
                loadcombo(cbStatus);
                userid = username;
                nameid = name;
                cbid = cbbox;
                nmid = nm;
                txbFoodID.Text = username;
                txbFoodName.Text = name;
                cbStatus.Text = cbbox;
                nmPrice.Value = nm;
            }

        }

        string x = "";

        string userid = "";

        string nameid = "";

        string cbid = "";

        int nmid = 0;

        void AddCategory()
        {
            Label.Text = "THÊM DANH MỤC";
            lbName.Text = "Tên danh mục:";
            lbPrice.Text = "";
            lbStatus.Text = "";
            cbStatus.Width = 0;
            nmPrice.Width = 0;
            //this.Controls.RemoveAt(nmPrice.);
        }
        void AddFood()
        {
            Label.Text = "THÊM ĐỒ UỐNG";
            lbName.Text = "Tên đồ uống:";
            lbPrice.Text = "Giá tiền:";
            lbStatus.Text = "Danh mục:";
            //cbStatus.Width = 0;
            //nmPrice.Width = 0;
            //this.Controls.RemoveAt(nmPrice.);
        }

        void AddTable()
        {
            Label.Text = "THÊM BÀN MỚI";
            lbName.Text = "Tên bàn:";
            lbPrice.Text = "";
            lbStatus.Text = "Trạng thái:";
          //  cbStatus.Width = 0;
            nmPrice.Width = 0;
            
        }

        void AddAccountcontrol()
        {
            Label.Text = "THÊM TÀI KHOẢN";
            lbID.Text = "Tên đăng nhập:";
            lbName.Text = "Tên hiển thị:";
            lbPrice.Text = "Loại tài khoản:";
            lbStatus.Text = "";
              cbStatus.Width = 0;
            //nmPrice.Width = 0;

            
        }
        void EditAccountcontrol()
        {
            Label.Text = "SỬA TÀI KHOẢN";
            lbID.Text = "Tên đăng nhập:";
            lbName.Text = "Tên hiển thị:";
            lbPrice.Text = "Loại tài khoản:";
            lbStatus.Text = "";
            cbStatus.Width = 0;
            //nmPrice.Width = 0;

        }

        void EditTable()
        {
            Label.Text = "SỬA TÊN BÀN";
            lbName.Text = "Tên bàn:";
            lbStatus.Text = "Trạng thái:";
            lbPrice.Text = "";
            nmPrice.Width = 0;
        }
        void EditCategory()
        {
            Label.Text = "SỬA DANH MỤC";
            lbName.Text = "Tên danh mục:";
            lbPrice.Text = "";
            lbStatus.Text = "";
            cbStatus.Width = 0;
            nmPrice.Width = 0;
            //this.Controls.RemoveAt(nmPrice.);

        }

        void EditFood()
        {
            Label.Text = "SỬA ĐỒ UỐNG";
            lbName.Text = "Tên đồ uống:";
            lbPrice.Text = "Giá tiền:";
            lbStatus.Text = "Danh mục:";
            //cbStatus.Width = 0;
            //nmPrice.Width = 0;
            //this.Controls.RemoveAt(nmPrice.);
        }
        void enable()
        {
            if (x == "AddAccount")
            {
                if (txbFoodName.Text != "" && txbFoodID.Text!="")
                {
                    btnSave.Enabled = true;
                    btnDontSave.Enabled = true;
                    btnSave.BackColor = Color.Orange;
                    btnDontSave.BackColor = Color.Orange;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnDontSave.Enabled = false;
                    btnDontSave.BackColor = Color.DarkGray;
                    btnSave.BackColor = Color.DarkGray;
                }
            }
            else if(x == "EditAccount" )
            {
                if ((userid!=txbFoodID.Text || nameid!=txbFoodName.Text || nmid != (int)nmPrice.Value) && txbFoodID.Text !="" && txbFoodName.Text !="")
                {
                   
                    btnSave.Enabled = true;
                    btnDontSave.Enabled = true;
                    btnSave.BackColor = Color.Orange;
                    btnDontSave.BackColor = Color.Orange;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnDontSave.Enabled = false;
                    btnDontSave.BackColor = Color.DarkGray;
                    btnSave.BackColor = Color.DarkGray;
                }
            }
            else if (x == "EditTable" || x=="EditCategory")
            {
                if (nameid != txbFoodName.Text && txbFoodName.Text!="")
                {
                    btnSave.Enabled = true;
                    btnDontSave.Enabled = true;
                    btnSave.BackColor = Color.Orange;
                    btnDontSave.BackColor = Color.Orange;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnDontSave.Enabled = false;
                    btnDontSave.BackColor = Color.DarkGray;
                    btnSave.BackColor = Color.DarkGray;
                }
            }
            else if (x == "EditFood")
            {
                if ((nameid != txbFoodName.Text || cbStatus.Text != cbid || nmPrice.Value !=nmid) && txbFoodName.Text != "")
                {
                    btnSave.Enabled = true;
                    btnDontSave.Enabled = true;
                    btnSave.BackColor = Color.Orange;
                    btnDontSave.BackColor = Color.Orange;
                }
                else {
                    btnSave.Enabled = false;
                    btnDontSave.Enabled = false;
                    btnDontSave.BackColor = Color.DarkGray;
                    btnSave.BackColor = Color.DarkGray;
                }
            }
            else
            {
                if (txbFoodName.Text != "")
                {
                    btnSave.Enabled = true;
                    btnDontSave.Enabled = true;
                    btnSave.BackColor = Color.Orange;
                    btnDontSave.BackColor = Color.Orange;
            }
                 else {
                    btnSave.Enabled = false;
                    btnDontSave.Enabled = false;
                    btnDontSave.BackColor = Color.DarkGray;
                     btnSave.BackColor = Color.DarkGray;
                    }
            }


            
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            /*if(btnSave.Enabled == true)
            {
                if(MessageBox.Show("Bạn có muốn lưu lại thay đổi?","THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    btnSave.PerformClick();
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }*/
            this.Close();
        }

        private void txbFoodName_TextChanged(object sender, EventArgs e)
        {
            
            enable();
        }

        private void btnDontSave_Click(object sender, EventArgs e)
        {
            if (x == "EditAccount")
            {
                txbFoodID.Text = userid;
                txbFoodName.Text = nameid;
                nmPrice.Value = nmid;
            }
            else if (x == "EditTable" || x=="EditCategory")
            {
                txbFoodName.Text = nameid;
            }
            else if (x == "EditFood")
            {
                txbFoodName.Text = nameid;
                cbStatus.Text = cbid;
                nmPrice.Value = nmid;
            }
            else
            {
                controlreset();
            }
            
        }

        void controlreset()
        {
            
                 txbFoodName.Text = "";
            if (x == "AddFood")
            {
                loadcombo(cbStatus);
            }
                
                nmPrice.Value = 0;
            if (x == "AddAccount" || x=="EditAccount")
            {
                txbFoodID.Text = "";
            }
            
           
        }

        void loadcombo(ComboBox cb)
        {
            
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        private event EventHandler insertCategory;
        public event EventHandler InsertCatgory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }



        

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }



        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }


        

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }

        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        void AddAccount(string UserName, string DisplayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(UserName, DisplayName, type))
            {
                
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }


        }
        void EditAccount(string UserName, string newuser,string DisplayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(UserName, newuser, DisplayName, type))
            {
               
                MessageBox.Show("Cập nhật tài khoản thành công");
                userid = txbFoodID.Text;
                nameid = DisplayName;
                nmid = type;
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (x == "AddCategory")
            {
                string name = txbFoodName.Text;

                if (CategoryDAO.Instance.InsertCategory(name))
                {

                    //LoadListCategory();
                    MessageBox.Show("Thêm danh mục thành công");

                    if (insertCategory != null)
                        insertCategory(this, new EventArgs());
                    //AddCategoryBinding();
                    controlreset();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm danh mục");
                }
            }
            if (x == "AddFood")
            {
                string name = txbFoodName.Text;
                int categoryID = (cbStatus.SelectedItem as Category).ID;
                float price = (float)nmPrice.Value;

                if (FoodDAO.Instance.InsertFood(name, categoryID, price))
                {

                    
                    MessageBox.Show("Thêm món thành công");
                    if (insertFood != null)
                        insertFood(this, new EventArgs());
                    controlreset();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm thức ăn");
                }
            }
            if (x == "AddTable")
            {
                string name = txbFoodName.Text;

                if (TableDAO.Instance.InsertTable(name))
                {

                    
                    MessageBox.Show("Thêm bàn mới thành công");
                    //AddTableBinding();
                    if (insertTable != null)
                        insertTable(this, new EventArgs());
                    //AddTableBinding();
                    controlreset();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm bàn mới");
                }
                
            }
            if (x == "AddAccount")
            {
                string UserName = txbFoodID.Text;
                string DisplayName = txbFoodName.Text;
                int type = (int)nmPrice.Value;
                AddAccount(UserName, DisplayName, type);
                controlreset();
            }
            if (x== "EditAccount")
            {
                string UserName = userid;
                string DisplayName = txbFoodName.Text;
                int type = (int)nmPrice.Value;
                string newusername = txbFoodID.Text;
                EditAccount(UserName, newusername,DisplayName, type);
                
                enable();
            }
            if (x == "EditTable")
            {
                string name = txbFoodName.Text;


                int id = Convert.ToInt32(txbFoodID.Text);

                string status = "TRỐNG";

                if (TableDAO.Instance.UpdateTable(id, name, status))
                {

                    nameid = txbFoodName.Text;
                    MessageBox.Show("Sửa bàn thành công");
                    if (updateTable != null)
                        updateTable(this, new EventArgs());
                    //AddTableBinding();
                    enable();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa bàn");
                }
            }
            if (x == "EditCategory")
            {
                string name = txbFoodName.Text;
                int id = Convert.ToInt32(txbFoodID.Text);

                if (CategoryDAO.Instance.UpdateCategory(id, name))
                {
                    nameid = name;
                    
                    MessageBox.Show("Sửa danh mục thành công");
                    //AddTableBinding();
                    if (updateCategory != null)
                        updateCategory(this, new EventArgs());
                    //AddCategoryBinding();
                    enable();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa danh mục");
                }
            }
            if (x == "EditFood")
            {
                string name = txbFoodName.Text;
                int categoryID = (cbStatus.SelectedItem as Category).ID;
                float price = (float)nmPrice.Value;
                int id = Convert.ToInt32(txbFoodID.Text);

                if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
                {
                    nameid = txbFoodName.Text;
                    cbid = cbStatus.Text;
                    nmid = (int)nmPrice.Value;
                    
                    MessageBox.Show("Sửa món thành công");
                    if (updateFood != null)
                        updateFood(this, new EventArgs());
                    enable();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa thức ăn");
                }
            }
        }

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            enable();
        }

        private void nmPrice_ValueChanged(object sender, EventArgs e)
        {
            enable();
        }

        private void Add_Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (MessageBox.Show("Bạn có muốn lưu lại thay đổi?", "THÔNG BÁO", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //e.Cancel = false;
                    btnSave.PerformClick();
                    btnExit.PerformClick();
                }
                
            }
            
        }
    }
}
