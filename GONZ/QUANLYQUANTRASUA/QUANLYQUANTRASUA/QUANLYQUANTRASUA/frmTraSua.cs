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
    public partial class frmTraSua : Form
    {
        public frmTraSua()
        {
            InitializeComponent();
        }

        private void frmTraSua_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanTraSuaDataSet.USP_GetListBillByDateReport' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateReportTableAdapter.Fill(this.QuanLyQuanTraSuaDataSet.USP_GetListBillByDateReport);

            this.reportViewer1.RefreshReport();
        }
    }
}
