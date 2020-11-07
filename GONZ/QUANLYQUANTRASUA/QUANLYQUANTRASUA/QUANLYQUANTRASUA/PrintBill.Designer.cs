namespace QUANLYQUANTRASUA
{
    partial class PrintBill
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyQuanTraSuaDataSet1 = new QUANLYQUANTRASUA.QuanLyQuanTraSuaDataSet1();
            this.USP_PrintBillReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_PrintBillReportTableAdapter = new QUANLYQUANTRASUA.QuanLyQuanTraSuaDataSet1TableAdapters.USP_PrintBillReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanTraSuaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_PrintBillReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_PrintBillReportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QUANLYQUANTRASUA.PrintBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 480);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyQuanTraSuaDataSet1
            // 
            this.QuanLyQuanTraSuaDataSet1.DataSetName = "QuanLyQuanTraSuaDataSet1";
            this.QuanLyQuanTraSuaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_PrintBillReportBindingSource
            // 
            this.USP_PrintBillReportBindingSource.DataMember = "USP_PrintBillReport";
            this.USP_PrintBillReportBindingSource.DataSource = this.QuanLyQuanTraSuaDataSet1;
            // 
            // USP_PrintBillReportTableAdapter
            // 
            this.USP_PrintBillReportTableAdapter.ClearBeforeFill = true;
            // 
            // PrintBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintBill";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.PrintBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyQuanTraSuaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_PrintBillReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_PrintBillReportBindingSource;
        private QuanLyQuanTraSuaDataSet1 QuanLyQuanTraSuaDataSet1;
        private QuanLyQuanTraSuaDataSet1TableAdapters.USP_PrintBillReportTableAdapter USP_PrintBillReportTableAdapter;
    }
}