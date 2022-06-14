namespace qqqqqqqq
{
    partial class page_phache
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbphache = new System.Windows.Forms.ComboBox();
            this.dgvchebien = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvchebien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbphache);
            this.panel1.Controls.Add(this.dgvchebien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 523);
            this.panel1.TabIndex = 0;
            // 
            // cbphache
            // 
            this.cbphache.BackColor = System.Drawing.Color.MediumAquamarine;
            this.cbphache.DropDownHeight = 200;
            this.cbphache.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbphache.DropDownWidth = 180;
            this.cbphache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbphache.FormattingEnabled = true;
            this.cbphache.IntegralHeight = false;
            this.cbphache.Items.AddRange(new object[] {
            "Chưa pha chế",
            "Đã pha chế",
            "Tất cả"});
            this.cbphache.Location = new System.Drawing.Point(6, 7);
            this.cbphache.Name = "cbphache";
            this.cbphache.Size = new System.Drawing.Size(183, 21);
            this.cbphache.TabIndex = 2;
            this.cbphache.SelectedIndexChanged += new System.EventHandler(this.cbphache_SelectedIndexChanged);
            this.cbphache.SelectedValueChanged += new System.EventHandler(this.cbphache_SelectedValueChanged);
            // 
            // dgvchebien
            // 
            this.dgvchebien.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvchebien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvchebien.BackgroundColor = System.Drawing.Color.White;
            this.dgvchebien.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvchebien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvchebien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvchebien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvchebien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column6});
            this.dgvchebien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvchebien.DoubleBuffered = true;
            this.dgvchebien.EnableHeadersVisualStyles = false;
            this.dgvchebien.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvchebien.HeaderForeColor = System.Drawing.Color.White;
            this.dgvchebien.Location = new System.Drawing.Point(0, 66);
            this.dgvchebien.Name = "dgvchebien";
            this.dgvchebien.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvchebien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvchebien.RowTemplate.Height = 40;
            this.dgvchebien.RowTemplate.ReadOnly = true;
            this.dgvchebien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvchebien.Size = new System.Drawing.Size(994, 457);
            this.dgvchebien.TabIndex = 0;
            this.dgvchebien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvchebien_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tentd";
            this.Column1.HeaderText = "Tên thực đơn";
            this.Column1.Name = "Column1";
            this.Column1.Width = 265;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "soluong";
            this.Column2.HeaderText = "Số Lượng";
            this.Column2.Name = "Column2";
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ghichu";
            this.Column3.HeaderText = "Ghi Chú";
            this.Column3.Name = "Column3";
            this.Column3.Width = 300;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "thoigian";
            this.Column5.HeaderText = "Thời gian";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Image = global::qqqqqqqq.Properties.Resources.next;
            this.Column4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "id";
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::qqqqqqqq.Properties.Resources.next;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // page_phache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "page_phache";
            this.Size = new System.Drawing.Size(994, 523);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvchebien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvchebien;
        private System.Windows.Forms.ComboBox cbphache;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Timer timer1;
    }
}
