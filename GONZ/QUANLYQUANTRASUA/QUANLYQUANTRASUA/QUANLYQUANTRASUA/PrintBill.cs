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
    public partial class PrintBill : Form
    {
        public PrintBill(int s)
        {
            InitializeComponent();
            x = s;
        }
        int x;
        private void PrintBill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLyQuanTraSuaDataSet1.USP_PrintBillReport' table. You can move, or remove it, as needed.
            this.USP_PrintBillReportTableAdapter.Fill(this.QuanLyQuanTraSuaDataSet1.USP_PrintBillReport,x);

            this.reportViewer1.RefreshReport();
        }
    }
}
