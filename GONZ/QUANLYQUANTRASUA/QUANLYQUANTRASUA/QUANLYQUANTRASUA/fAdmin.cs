using QUANLYQUANTRASUA.DAO;
using QUANLYQUANTRASUA.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYQUANTRASUA
{
    public partial class fAdmin : Form
    {

        BindingSource foodList = new BindingSource();

        BindingSource accountList = new BindingSource();

        BindingSource categoryList = new BindingSource();

        BindingSource tableList = new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();

            LoadMain();


        }




        #region methods
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }



        void LoadMain()
        {

            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            dtgvCategory.DataSource = categoryList;
            dtgvTable.DataSource = tableList;
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadDateTimePickerBill();
            LoadListFood();
            LoadAccount();
            AddFoodBinding();
            AddAccountBinding();
            LoadCategoryIntoCombobox(cbFoodCategory);
            LoadListTable();
            LoadListCategory();
            AddCategoryBinding();
            AddTableBinding();
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
            /*for (int i = 0; i < dtgvFood.Rows.Count; i++)
            {
                dtgvFood.Rows[i].Cells[3].Value = i + 1;
            }*/
        }


        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadListCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        #endregion

        #region events
        /*void AddAccount(string UserName, string DisplayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(UserName, DisplayName, type))
            {
                LoadAccount();
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            

        }*/
        /*void EditAccount(string UserName, string DisplayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(UserName, DisplayName, type))
            {
                LoadAccount();
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("cập nhật tài khoản thất bại");
            }
            

        }*/
        void DeleteAccount(string UserName)
        {
            if (loginAccount.UserName.Equals(UserName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn!!!");
                return;

            }
            if (AccountDAO.Instance.DeleteAccount(UserName))
            { 
                LoadAccount();
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

           
        }
        void Resetpassword(string UserName)
        {
            if (AccountDAO.Instance.ResetPassWord(UserName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }


        }

        /*private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            AddAccount(UserName, DisplayName, type);
        }*/

        /*private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            EditAccount(UserName, DisplayName, type);
        }*/
        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;
            Resetpassword(UserName);
        }
        /*private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string UserName = txbUserName.Text;

            DeleteAccount(UserName);
        }*/
        /*private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }*/
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        /*private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }*/


        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
            //numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        /*private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }
        }*/


        /*private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }
        }*/


        /*private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }*/


        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }


        private event EventHandler insertCategory;
        public event EventHandler InsertCatgory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }


        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }



        /*private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }
        */

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }
        /*private void btnSearchFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }*/


        void AddCategoryBinding()
        {
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));

        }

        void AddTableBinding()
        {
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }





        #endregion

       /* private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    //int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                    //string indexRow = txbFoodID.Text;


                   // int index = Convert.ToInt32(txbFoodID.Text);

                    //  string id1 = dtgvFood.Rows[indexRow].Cells[1].Value.ToString();
                    int rowSelected = dtgvFood.CurrentCell.RowIndex;
                    //int id = Convert.ToInt32(id1);
                    string id1 = dtgvFood.Rows[rowSelected].Cells[1].Value.ToString().Trim();
                    int id = Convert.ToInt32(id1);
                    
                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }*/

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txbPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            int lastPage = sumRecord / 10;
            if (sumRecord % 10 != 0)
                lastPage++;
            txbPageBill.Text = lastPage.ToString();
        }

        private void txbPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value, Convert.ToInt32(txbPageBill.Text));
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            if (page > 1)
                page--;
            txbPageBill.Text = page.ToString();

        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txbPageBill.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpkFromDate.Value, dtpkToDate.Value);
            if (page < sumRecord)
                page++;
            txbPageBill.Text = page.ToString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmTraSua frm = new frmTraSua();
            frm.Show();
        }

        /*private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
            //AddCategoryBinding();
        }*/

        /*private void btnShowTable_Click_1(object sender, EventArgs e)
        {
            LoadListTable();
            //AddTableBinding();
        }*/

        private void btnAddCategory_Click_1(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công");
                LoadListCategory();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
                //AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }

        /*private void btnAddTable_Click_1(object sender, EventArgs e)
        {
            string name = txbTableName.Text;

            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn mới thành công");
                LoadListTable();
                //AddTableBinding();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn mới");
            }
        }*/

        /*private void btnEditCategory_Click_1(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadListCategory();
                //AddTableBinding();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
                //AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục");
            }
        }

        private void btnDeleteCategory_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListFood();
                
                LoadListCategory();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
               // AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }*/

        /*private void btnEditTable_Click_1(object sender, EventArgs e)
        {
            string name = txbTableName.Text;


            int id = Convert.ToInt32(txbTableID.Text);

            string status = txbTableStatus.Text;

            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }*/

       /* private void btnDeleteTable_Click_1(object sender, EventArgs e)
        {

            

            if (txbTableStatus.Text == "Có người")
            {
                MessageBox.Show("Bàn đang có người!!!");
                return;
            }
            //{
            int id = Convert.ToInt32(txbTableID.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa bàn thành công");
                LoadListTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
            //}
            // else
            //{
            //    MessageBox.Show("Bàn đang có người!!!");
            // }
        }
        */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string s = "AddCategory";

            Add_Edit f = new Add_Edit(s,"","","",0);

            f.ShowDialog();

            LoadListCategory();

            /*string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                
                LoadListCategory();
                MessageBox.Show("Thêm danh mục thành công");

                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
                //AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            string s = "EditCategory";

            string iddmuc = txbCategoryID.Text;
            string tenmuc = txbCategoryName.Text;
            //int type = (int)numericUpDown1.Value;
            //string cb = "";

            Add_Edit f = new Add_Edit(s, iddmuc, tenmuc, "", 0);

            f.ShowDialog();

            LoadListCategory();
            /*string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                
                LoadListCategory();
                MessageBox.Show("Sửa danh mục thành công");
                //AddTableBinding();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
                //AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa danh mục");
            }*/
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                
                LoadListCategory();
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
                // AddCategoryBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadListCategory();
            //AddCategoryBinding();
        }

        private void ptbAddFood_Click(object sender, EventArgs e)
        {
            string s = "AddFood";

            Add_Edit f = new Add_Edit(s,"","","",0);

            f.ShowDialog();

            LoadListFood();
            /*string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                
                LoadListFood();
                MessageBox.Show("Thêm món thành công");
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm thức ăn");
            }*/
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            string s = "EditFood";

            string idmon = txbFoodID.Text;
            string tenmon = txbFoodName.Text;
            int giamon = (int)nmFoodPrice.Value;
            string cbmon = cbFoodCategory.Text;

            Add_Edit f = new Add_Edit(s, idmon, tenmon, cbmon, giamon);

            f.ShowDialog();

            LoadListFood();

            /*string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                
                LoadListFood();
                MessageBox.Show("Sửa món thành công");
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thức ăn");
            }*/
        }

        private void ptbDeleteFood_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa??","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                
                LoadListFood();
                MessageBox.Show("Xóa món thành công");

                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa thức ăn");
            }
        }

        private void ptbShow_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            string s = "AddTable";

            Add_Edit f = new Add_Edit(s,"","","",0);

            f.ShowDialog();

            LoadListTable();
            /*string name = txbTableName.Text;

            if (TableDAO.Instance.InsertTable(name))
            {
                
                LoadListTable();
                MessageBox.Show("Thêm bàn mới thành công");
                //AddTableBinding();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn mới");
            }*/
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (txbTableStatus.Text == "Có người")
            {
                MessageBox.Show("Bàn đang có người!!!");
                return;
            }
            //{
            int id = Convert.ToInt32(txbTableID.Text);
            if (TableDAO.Instance.DeleteTable(id))
            {
                LoadListTable();
                MessageBox.Show("Xóa bàn thành công");
                
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
            //}
            // else
            //{
            //    MessageBox.Show("Bàn đang có người!!!");
            // }
        }

        private void pictureBox9_Click(object sender, EventArgs e)

        {

            if (txbTableStatus.Text == "Có người")
            {
                MessageBox.Show("Bàn đang có người, bạn không thể sửa!!!");
                return;
            }

            string s = "EditTable";

            string idban = txbTableID.Text;
            string tenban = txbTableName.Text;
            //int type = (int)numericUpDown1.Value;
            //string cb = "";

            Add_Edit f = new Add_Edit(s, idban, tenban, "", 0);

            f.ShowDialog();

            LoadListTable();
            /*
            if (txbTableStatus.Text == "Có người")
            {
                MessageBox.Show("Bàn đang có người, bạn không thể sửa!!!");
                return;
            }
            string name = txbTableName.Text;


            int id = Convert.ToInt32(txbTableID.Text);

            string status = txbTableStatus.Text;

            if (TableDAO.Instance.UpdateTable(id, name, status))
            {
                
                LoadListTable();
                MessageBox.Show("Sửa bàn thành công");
                if (updateTable != null)
                    updateTable(this, new EventArgs());
                //AddTableBinding();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }*/
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LoadListTable();
            //AddTableBinding();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            string s = "AddAccount";
            
            Add_Edit f = new Add_Edit(s,"","","",0);

            f.ShowDialog();

            LoadAccount();

            
            /*
            string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            AddAccount(UserName, DisplayName, type);
           */

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            string s = "EditAccount";

            string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            string cb = "";

            Add_Edit f = new Add_Edit(s,UserName,DisplayName,cb,type);

            f.ShowDialog();

            LoadAccount();
            /*string UserName = txbUserName.Text;
            string DisplayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;
            EditAccount(UserName, DisplayName, type);
            */
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa??", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            string UserName = txbUserName.Text;
            
            DeleteAccount(UserName);

            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void dtgvFood_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    //int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                    //string indexRow = txbFoodID.Text;


                    // int index = Convert.ToInt32(txbFoodID.Text);

                    //  string id1 = dtgvFood.Rows[indexRow].Cells[1].Value.ToString();
                    int rowSelected = dtgvFood.CurrentCell.RowIndex;
                    //int id = Convert.ToInt32(id1);
                    string id1 = dtgvFood.Rows[rowSelected].Cells[1].Value.ToString().Trim();
                    int id = Convert.ToInt32(id1);

                    Category cateogory = CategoryDAO.Instance.GetCategoryByID(id);

                    cbFoodCategory.SelectedItem = cateogory;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == cateogory.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }

        private void txbSearchFoodName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foodList.DataSource = SearchFoodByName(txbSearchFoodName.Text);
            }
        }
    }
}
