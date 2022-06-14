namespace qqqqqqqq
{
    partial class report
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
            this.vi_hoadonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._CAFE_netDataSet = new qqqqqqqq._CAFE_netDataSet();
            this.vi_hoadonTableAdapter = new qqqqqqqq._CAFE_netDataSetTableAdapters.vi_hoadonTableAdapter();
            this.pr_reportHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pr_reportHDTableAdapter = new qqqqqqqq._CAFE_netDataSetTableAdapters.pr_reportHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vi_hoadonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._CAFE_netDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_reportHDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.pr_reportHDBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "qqqqqqqq.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(504, 420);
            this.reportViewer1.TabIndex = 0;
            // 
            // vi_hoadonBindingSource
            // 
            this.vi_hoadonBindingSource.DataMember = "vi_hoadon";
            this.vi_hoadonBindingSource.DataSource = this._CAFE_netDataSet;
            // 
            // _CAFE_netDataSet
            // 
            this._CAFE_netDataSet.DataSetName = "_CAFE_netDataSet";
            this._CAFE_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vi_hoadonTableAdapter
            // 
            this.vi_hoadonTableAdapter.ClearBeforeFill = true;
            // 
            // pr_reportHDBindingSource
            // 
            this.pr_reportHDBindingSource.DataMember = "pr_reportHD";
            this.pr_reportHDBindingSource.DataSource = this._CAFE_netDataSet;
            // 
            // pr_reportHDTableAdapter
            // 
            this.pr_reportHDTableAdapter.ClearBeforeFill = true;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 420);
            this.Controls.Add(this.reportViewer1);
            this.Name = "report";
            this.Text = "report";
            this.Load += new System.EventHandler(this.report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vi_hoadonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._CAFE_netDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_reportHDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource vi_hoadonBindingSource;
        private _CAFE_netDataSet _CAFE_netDataSet;
        private _CAFE_netDataSetTableAdapters.vi_hoadonTableAdapter vi_hoadonTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pr_reportHDBindingSource;
        private _CAFE_netDataSetTableAdapters.pr_reportHDTableAdapter pr_reportHDTableAdapter;
    }
}