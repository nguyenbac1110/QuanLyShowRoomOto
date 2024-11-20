namespace QuanLyShowRoomOto
{
    partial class frmOrder
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
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxmakhachhang = new System.Windows.Forms.ComboBox();
            this.cbxmanhanvien = new System.Windows.Forms.ComboBox();
            this.txtyeucau = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpngaytao = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmadonhang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnxoa = new System.Windows.Forms.Button();
            this.txttenxe = new System.Windows.Forms.TextBox();
            this.btnin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnhuy = new System.Windows.Forms.Button();
            this.btnluu = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.txtgiatien = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtsl = new System.Windows.Forms.TextBox();
            this.cbxmaxe = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxmadonhang = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(131, 45);
            this.label11.TabIndex = 82;
            this.label11.Text = "ORDER";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxmakhachhang);
            this.groupBox1.Controls.Add(this.cbxmanhanvien);
            this.groupBox1.Controls.Add(this.txtyeucau);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpngaytao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtmadonhang);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(979, 160);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // cbxmakhachhang
            // 
            this.cbxmakhachhang.FormattingEnabled = true;
            this.cbxmakhachhang.Location = new System.Drawing.Point(645, 21);
            this.cbxmakhachhang.Name = "cbxmakhachhang";
            this.cbxmakhachhang.Size = new System.Drawing.Size(153, 24);
            this.cbxmakhachhang.TabIndex = 19;
            // 
            // cbxmanhanvien
            // 
            this.cbxmanhanvien.FormattingEnabled = true;
            this.cbxmanhanvien.Location = new System.Drawing.Point(130, 117);
            this.cbxmanhanvien.Name = "cbxmanhanvien";
            this.cbxmanhanvien.Size = new System.Drawing.Size(153, 24);
            this.cbxmanhanvien.TabIndex = 18;
            // 
            // txtyeucau
            // 
            this.txtyeucau.Location = new System.Drawing.Point(645, 72);
            this.txtyeucau.Name = "txtyeucau";
            this.txtyeucau.Size = new System.Drawing.Size(153, 22);
            this.txtyeucau.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Yêu cầu của khách hàng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Mã nhân viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ngày tạo";
            // 
            // dtpngaytao
            // 
            this.dtpngaytao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaytao.Location = new System.Drawing.Point(130, 73);
            this.dtpngaytao.Name = "dtpngaytao";
            this.dtpngaytao.Size = new System.Drawing.Size(153, 22);
            this.dtpngaytao.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã khách hàng";
            // 
            // txtmadonhang
            // 
            this.txtmadonhang.Location = new System.Drawing.Point(130, 33);
            this.txtmadonhang.Name = "txtmadonhang";
            this.txtmadonhang.Size = new System.Drawing.Size(153, 22);
            this.txtmadonhang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đơn hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxmadonhang);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnxoa);
            this.groupBox2.Controls.Add(this.txttenxe);
            this.groupBox2.Controls.Add(this.btnin);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnhuy);
            this.groupBox2.Controls.Add(this.btnluu);
            this.groupBox2.Controls.Add(this.btnthem);
            this.groupBox2.Controls.Add(this.txttongtien);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.dgv);
            this.groupBox2.Controls.Add(this.txtgiatien);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtsl);
            this.groupBox2.Controls.Add(this.cbxmaxe);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(13, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(978, 477);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin chi tiết";
            // 
            // btnxoa
            // 
            this.btnxoa.Location = new System.Drawing.Point(518, 407);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(93, 31);
            this.btnxoa.TabIndex = 34;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // txttenxe
            // 
            this.txttenxe.Enabled = false;
            this.txttenxe.Location = new System.Drawing.Point(309, 27);
            this.txttenxe.Name = "txttenxe";
            this.txttenxe.Size = new System.Drawing.Size(153, 22);
            this.txttenxe.TabIndex = 21;
            // 
            // btnin
            // 
            this.btnin.Location = new System.Drawing.Point(467, 354);
            this.btnin.Name = "btnin";
            this.btnin.Size = new System.Drawing.Size(93, 31);
            this.btnin.TabIndex = 33;
            this.btnin.Text = "In";
            this.btnin.UseVisualStyleBackColor = true;
            this.btnin.Click += new System.EventHandler(this.btnin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tên xe";
            // 
            // btnhuy
            // 
            this.btnhuy.Location = new System.Drawing.Point(327, 354);
            this.btnhuy.Name = "btnhuy";
            this.btnhuy.Size = new System.Drawing.Size(93, 31);
            this.btnhuy.TabIndex = 32;
            this.btnhuy.Text = "Hủy";
            this.btnhuy.UseVisualStyleBackColor = true;
            this.btnhuy.Click += new System.EventHandler(this.btnhuy_Click);
            // 
            // btnluu
            // 
            this.btnluu.Enabled = false;
            this.btnluu.Location = new System.Drawing.Point(164, 354);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(93, 31);
            this.btnluu.TabIndex = 31;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(8, 354);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(93, 31);
            this.btnthem.TabIndex = 30;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // txttongtien
            // 
            this.txttongtien.Location = new System.Drawing.Point(813, 354);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.Size = new System.Drawing.Size(153, 22);
            this.txttongtien.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(728, 354);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 16);
            this.label14.TabIndex = 28;
            this.label14.Text = "Tổng tiền";
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(24, 71);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(915, 243);
            this.dgv.TabIndex = 27;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // txtgiatien
            // 
            this.txtgiatien.Enabled = false;
            this.txtgiatien.Location = new System.Drawing.Point(806, 24);
            this.txtgiatien.Name = "txtgiatien";
            this.txtgiatien.Size = new System.Drawing.Size(153, 22);
            this.txtgiatien.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(727, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "Giá tiền";
            // 
            // txtsl
            // 
            this.txtsl.Location = new System.Drawing.Point(551, 26);
            this.txtsl.Name = "txtsl";
            this.txtsl.Size = new System.Drawing.Size(153, 22);
            this.txtsl.TabIndex = 21;
            // 
            // cbxmaxe
            // 
            this.cbxmaxe.FormattingEnabled = true;
            this.cbxmaxe.Location = new System.Drawing.Point(70, 24);
            this.cbxmaxe.Name = "cbxmaxe";
            this.cbxmaxe.Size = new System.Drawing.Size(153, 24);
            this.cbxmaxe.TabIndex = 21;
            this.cbxmaxe.SelectedIndexChanged += new System.EventHandler(this.cbxmaxe_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(485, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Số lượng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Mã xe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Chọn mã đơn hàng cần xóa";
            // 
            // cbxmadonhang
            // 
            this.cbxmadonhang.FormattingEnabled = true;
            this.cbxmadonhang.Location = new System.Drawing.Point(278, 410);
            this.cbxmadonhang.Name = "cbxmadonhang";
            this.cbxmadonhang.Size = new System.Drawing.Size(203, 24);
            this.cbxmadonhang.TabIndex = 36;
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 742);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOrder";
            this.Text = "frmOrder";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmadonhang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyeucau;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpngaytao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxmakhachhang;
        private System.Windows.Forms.ComboBox cbxmanhanvien;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxmaxe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtsl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtgiatien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnin;
        private System.Windows.Forms.Button btnhuy;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txttenxe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.ComboBox cbxmadonhang;
        private System.Windows.Forms.Label label4;
    }
}