namespace QUANLYQUANTRASUA
{
    partial class frmTraSua
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GetListBillByDateReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyQuanTraSuaDataSet = new QUANLYQUANTRASUA.QuanLyQuanTraSuaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetListBillByDateReportTableAdapter = new QUANLYQUANTRASUA.QuanLyQuanTraSuaDataSetTableAdapters.USP_GetListBillByDateReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateReportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanTraSuaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateReportBindingSource
            // 
            this.USP_GetListBillByDateReportBindingSource.DataMember = "USP_GetListBillByDateReport";
            this.USP_GetListBillByDateReportBindingSource.DataSource = this.QuanLyQuanTraSuaDataSet;
            // 
            // QuanLyQuanTraSuaDataSet
            // 
            this.QuanLyQuanTraSuaDataSet.DataSetName = "QuanLyQuanTraSuaDataSet";
            this.QuanLyQuanTraSuaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.USP_GetListBillByDateReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QUANLYQUANTRASUA.QuanLyQuanTraSua.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1064, 453);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_GetListBillByDateReportTableAdapter
            // 
            this.USP_GetListBillByDateReportTableAdapter.ClearBeforeFill = true;
            // 
            // frmTraSua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 453);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTraSua";
            this.Text = "BÁO CÁO";
            this.Load += new System.EventHandler(this.frmTraSua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateReportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanTraSuaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateReportBindingSource;
        private QuanLyQuanTraSuaDataSet QuanLyQuanTraSuaDataSet;
        private QuanLyQuanTraSuaDataSetTableAdapters.USP_GetListBillByDateReportTableAdapter USP_GetListBillByDateReportTableAdapter;
    }
}