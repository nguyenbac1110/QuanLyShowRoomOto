﻿namespace QuanLyShowRoomOto
{
    partial class frmTimKiem_e
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
            this.txtnhap = new System.Windows.Forms.TextBox();
            this.cbxdl = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.btnkq = new System.Windows.Forms.Button();
            this.cbxcot = new System.Windows.Forms.ComboBox();
            this.cbxbang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtnhap
            // 
            this.txtnhap.Location = new System.Drawing.Point(396, 144);
            this.txtnhap.Name = "txtnhap";
            this.txtnhap.Size = new System.Drawing.Size(187, 22);
            this.txtnhap.TabIndex = 32;
            // 
            // cbxdl
            // 
            this.cbxdl.FormattingEnabled = true;
            this.cbxdl.Location = new System.Drawing.Point(155, 192);
            this.cbxdl.Name = "cbxdl";
            this.cbxdl.Size = new System.Drawing.Size(209, 24);
            this.cbxdl.TabIndex = 31;
            this.cbxdl.SelectedIndexChanged += new System.EventHandler(this.cbxdl_SelectedIndexChanged);
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(65, 235);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(798, 285);
            this.dgv.TabIndex = 30;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(809, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 37);
            this.button2.TabIndex = 29;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnkq
            // 
            this.btnkq.Location = new System.Drawing.Point(659, 129);
            this.btnkq.Name = "btnkq";
            this.btnkq.Size = new System.Drawing.Size(124, 37);
            this.btnkq.TabIndex = 28;
            this.btnkq.Text = "Xem kết quả";
            this.btnkq.UseVisualStyleBackColor = true;
            this.btnkq.Click += new System.EventHandler(this.btnkq_Click);
            // 
            // cbxcot
            // 
            this.cbxcot.FormattingEnabled = true;
            this.cbxcot.Location = new System.Drawing.Point(155, 142);
            this.cbxcot.Name = "cbxcot";
            this.cbxcot.Size = new System.Drawing.Size(209, 24);
            this.cbxcot.TabIndex = 27;
            this.cbxcot.SelectedIndexChanged += new System.EventHandler(this.cbxcot_SelectedIndexChanged);
            // 
            // cbxbang
            // 
            this.cbxbang.FormattingEnabled = true;
            this.cbxbang.Items.AddRange(new object[] {
            "Car",
            "Customer",
            "Manufactory",
            "Order",
            "OrderDetails",
            "Service ",
            "ServiceDetails"});
            this.cbxbang.Location = new System.Drawing.Point(155, 88);
            this.cbxbang.Name = "cbxbang";
            this.cbxbang.Size = new System.Drawing.Size(209, 24);
            this.cbxbang.TabIndex = 26;
            this.cbxbang.SelectedIndexChanged += new System.EventHandler(this.cbxbang_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Chọn khóa tìm kiếm";
            // 
            // frmTimKiem_e
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 662);
            this.Controls.Add(this.txtnhap);
            this.Controls.Add(this.cbxdl);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnkq);
            this.Controls.Add(this.cbxcot);
            this.Controls.Add(this.cbxbang);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimKiem_e";
            this.Text = "frmTimKiem_e";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtnhap;
        private System.Windows.Forms.ComboBox cbxdl;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnkq;
        private System.Windows.Forms.ComboBox cbxcot;
        private System.Windows.Forms.ComboBox cbxbang;
        private System.Windows.Forms.Label label2;
    }
}