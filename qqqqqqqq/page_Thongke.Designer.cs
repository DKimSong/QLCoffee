using System.Drawing;
using System.IO;
namespace qqqqqqqq
{
    partial class page_Thongke
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource9 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.pr_hoadonngayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._CAFE_netDataSet = new qqqqqqqq._CAFE_netDataSet();
            this.pr_doanhthuHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pr_chartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.btnxem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.pr_hoadonngayTableAdapter = new qqqqqqqq._CAFE_netDataSetTableAdapters.pr_hoadonngayTableAdapter();
            this.pr_doanhthuHangTableAdapter = new qqqqqqqq._CAFE_netDataSetTableAdapters.pr_doanhthuHangTableAdapter();
            this.pr_chartTableAdapter = new qqqqqqqq._CAFE_netDataSetTableAdapters.pr_chartTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pr_hoadonngayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._CAFE_netDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_doanhthuHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_chartBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            this.tabNavigationPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pr_hoadonngayBindingSource
            // 
            this.pr_hoadonngayBindingSource.DataMember = "pr_hoadonngay";
            this.pr_hoadonngayBindingSource.DataSource = this._CAFE_netDataSet;
            // 
            // _CAFE_netDataSet
            // 
            this._CAFE_netDataSet.DataSetName = "_CAFE_netDataSet";
            this._CAFE_netDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pr_doanhthuHangBindingSource
            // 
            this.pr_doanhthuHangBindingSource.DataMember = "pr_doanhthuHang";
            this.pr_doanhthuHangBindingSource.DataSource = this._CAFE_netDataSet;
            // 
            // pr_chartBindingSource
            // 
            this.pr_chartBindingSource.DataMember = "pr_chart";
            this.pr_chartBindingSource.DataSource = this._CAFE_netDataSet;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.tabPane1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 411);
            this.panel1.TabIndex = 0;
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage2);
            this.tabPane1.Controls.Add(this.tabNavigationPage3);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2,
            this.tabNavigationPage3});
            this.tabPane1.RegularSize = new System.Drawing.Size(652, 411);
            this.tabPane1.SelectedPage = this.tabNavigationPage2;
            this.tabPane1.Size = new System.Drawing.Size(652, 411);
            this.tabPane1.TabIndex = 0;
            this.tabPane1.Text = "tabPane1";
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.BackgroundPadding = new System.Windows.Forms.Padding(0);
            this.tabNavigationPage1.Caption = "Thống kê theo ngày";
            this.tabNavigationPage1.Controls.Add(this.btnxem);
            this.tabNavigationPage1.Controls.Add(this.dateTimePicker1);
            this.tabNavigationPage1.Controls.Add(this.reportViewer1);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(650, 382);
            // 
            // btnxem
            // 
            this.btnxem.Activecolor = System.Drawing.Color.Green;
            this.btnxem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnxem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnxem.BorderRadius = 0;
            this.btnxem.ButtonText = "        Xem";
            this.btnxem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxem.DisabledColor = System.Drawing.Color.Gray;
            this.btnxem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxem.Iconcolor = System.Drawing.Color.Transparent;
            this.btnxem.Iconimage = global::qqqqqqqq.Properties.Resources.xemtheothang;
            this.btnxem.Iconimage_right = null;
            this.btnxem.Iconimage_right_Selected = null;
            this.btnxem.Iconimage_Selected = null;
            this.btnxem.IconMarginLeft = 0;
            this.btnxem.IconMarginRight = 0;
            this.btnxem.IconRightVisible = false;
            this.btnxem.IconRightZoom = 0D;
            this.btnxem.IconVisible = false;
            this.btnxem.IconZoom = 30D;
            this.btnxem.IsTab = false;
            this.btnxem.Location = new System.Drawing.Point(215, 21);
            this.btnxem.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnxem.Name = "btnxem";
            this.btnxem.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnxem.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnxem.OnHoverTextColor = System.Drawing.Color.White;
            this.btnxem.selected = false;
            this.btnxem.Size = new System.Drawing.Size(75, 21);
            this.btnxem.TabIndex = 18;
            this.btnxem.Text = "        Xem";
            this.btnxem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxem.Textcolor = System.Drawing.Color.White;
            this.btnxem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AllowDrop = true;
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.Value = new System.DateTime(2018, 6, 11, 0, 0, 0, 0);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.pr_hoadonngayBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "qqqqqqqq.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 48);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(651, 334);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.BackgroundPadding = new System.Windows.Forms.Padding(0);
            this.tabNavigationPage2.Caption = "Thống Kê mặt hàng";
            this.tabNavigationPage2.Controls.Add(this.radioButton2);
            this.tabNavigationPage2.Controls.Add(this.radioButton1);
            this.tabNavigationPage2.Controls.Add(this.reportViewer2);
            this.tabNavigationPage2.Controls.Add(this.bunifuFlatButton1);
            this.tabNavigationPage2.Controls.Add(this.dateTimePicker2);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(650, 382);
            this.tabNavigationPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabNavigationPage2_Paint);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(82, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.Text = "Tháng";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 43);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 17);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ngày";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource9.Name = "DataSet1";
            reportDataSource9.Value = this.pr_doanhthuHangBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource9);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "qqqqqqqq.Report4.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(3, 78);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(647, 304);
            this.reportViewer2.TabIndex = 21;
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.Green;
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "        Xem";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = global::qqqqqqqq.Properties.Resources.xemtheothang;
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = false;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = false;
            this.bunifuFlatButton1.IconZoom = 30D;
            this.bunifuFlatButton1.IsTab = false;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(206, 17);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton1.selected = false;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(75, 21);
            this.bunifuFlatButton1.TabIndex = 20;
            this.bunifuFlatButton1.Text = "        Xem";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.AllowDrop = true;
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(3, 17);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker2.TabIndex = 19;
            this.dateTimePicker2.Value = new System.DateTime(2018, 6, 11, 0, 0, 0, 0);
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.BackgroundPadding = new System.Windows.Forms.Padding(0);
            this.tabNavigationPage3.Caption = "Doanh Thu Tháng";
            this.tabNavigationPage3.Controls.Add(this.reportViewer3);
            this.tabNavigationPage3.Controls.Add(this.bunifuFlatButton2);
            this.tabNavigationPage3.Controls.Add(this.dateTimePicker3);
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(650, 382);
            // 
            // reportViewer3
            // 
            this.reportViewer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.pr_chartBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "qqqqqqqq.Report7.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(3, 41);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(647, 341);
            this.reportViewer3.TabIndex = 23;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.Green;
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "        Xem";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = global::qqqqqqqq.Properties.Resources.xemtheothang;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = false;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = false;
            this.bunifuFlatButton2.IconZoom = 30D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(218, 14);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(75, 21);
            this.bunifuFlatButton2.TabIndex = 22;
            this.bunifuFlatButton2.Text = "        Xem";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.AllowDrop = true;
            this.dateTimePicker3.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(15, 14);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(181, 20);
            this.dateTimePicker3.TabIndex = 21;
            this.dateTimePicker3.Value = new System.DateTime(2018, 6, 11, 0, 0, 0, 0);
            // 
            // pr_hoadonngayTableAdapter
            // 
            this.pr_hoadonngayTableAdapter.ClearBeforeFill = true;
            // 
            // pr_doanhthuHangTableAdapter
            // 
            this.pr_doanhthuHangTableAdapter.ClearBeforeFill = true;
            // 
            // pr_chartTableAdapter
            // 
            this.pr_chartTableAdapter.ClearBeforeFill = true;
            // 
            // page_Thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "page_Thongke";
            this.Size = new System.Drawing.Size(652, 411);
            ((System.ComponentModel.ISupportInitialize)(this.pr_hoadonngayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._CAFE_netDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_doanhthuHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pr_chartBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            this.tabNavigationPage2.PerformLayout();
            this.tabNavigationPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Bunifu.Framework.UI.BunifuFlatButton btnxem;
        private System.Windows.Forms.BindingSource pr_hoadonngayBindingSource;
        private _CAFE_netDataSet _CAFE_netDataSet;
        private _CAFE_netDataSetTableAdapters.pr_hoadonngayTableAdapter pr_hoadonngayTableAdapter;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource pr_doanhthuHangBindingSource;
        private _CAFE_netDataSetTableAdapters.pr_doanhthuHangTableAdapter pr_doanhthuHangTableAdapter;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.BindingSource pr_chartBindingSource;
        private _CAFE_netDataSetTableAdapters.pr_chartTableAdapter pr_chartTableAdapter;
    }
}
