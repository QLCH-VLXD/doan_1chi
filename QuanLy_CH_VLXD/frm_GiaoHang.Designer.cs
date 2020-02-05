namespace QuanLy_CH_VLXD
{
    partial class frm_GiaoHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_CTGiaoHang = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_GiaoHang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_TTCTSanPham = new System.Windows.Forms.GroupBox();
            this.cbo_NVGiaoHang = new System.Windows.Forms.ComboBox();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.txt_SoLuong = new System.Windows.Forms.TextBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_DonGia = new System.Windows.Forms.TextBox();
            this.txt_TenMH = new System.Windows.Forms.TextBox();
            this.txt_TenLoaiMH = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_thanhtien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_CTHoaDon = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_HDB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SoHangGiao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MaGiaoHang = new System.Windows.Forms.TextBox();
            this.lbl_Manv = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTGiaoHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GiaoHang)).BeginInit();
            this.groupBox_TTCTSanPham.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_CTGiaoHang);
            this.groupBox1.Controls.Add(this.dataGridView_GiaoHang);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1320, 246);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách mặt hàng";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView_CTGiaoHang
            // 
            this.dataGridView_CTGiaoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_CTGiaoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CTGiaoHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView_CTGiaoHang.Location = new System.Drawing.Point(662, 21);
            this.dataGridView_CTGiaoHang.Name = "dataGridView_CTGiaoHang";
            this.dataGridView_CTGiaoHang.Size = new System.Drawing.Size(655, 216);
            this.dataGridView_CTGiaoHang.TabIndex = 1;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "MACTGIAOHNAG1";
            this.Column6.HeaderText = "Mã CTGH";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "MAGIAOHANG1";
            this.Column7.HeaderText = "Mã giao hàng";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "MACTHDB1";
            this.Column8.HeaderText = "Mã CTHDB";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "SOLUONGMH1";
            this.Column9.HeaderText = "Số lượng";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "THANHTIEN1";
            this.Column10.HeaderText = "Thành tiền";
            this.Column10.Name = "Column10";
            // 
            // dataGridView_GiaoHang
            // 
            this.dataGridView_GiaoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_GiaoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GiaoHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView_GiaoHang.Location = new System.Drawing.Point(3, 21);
            this.dataGridView_GiaoHang.Name = "dataGridView_GiaoHang";
            this.dataGridView_GiaoHang.Size = new System.Drawing.Size(636, 216);
            this.dataGridView_GiaoHang.TabIndex = 0;
            this.dataGridView_GiaoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_GiaoHang_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MAGIAOHANG1";
            this.Column1.HeaderText = "Mã giao hàng";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MANVGIAOHANG1";
            this.Column2.HeaderText = "Mã nv";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NGAYGIOGIAOHANG1";
            this.Column3.HeaderText = "Ngày giao hàng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "SOLUONGGIAO1";
            this.Column4.HeaderText = "Số lượng";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TONGTIENHANGGIAO1";
            this.Column5.HeaderText = "Tổng tiền";
            this.Column5.Name = "Column5";
            // 
            // groupBox_TTCTSanPham
            // 
            this.groupBox_TTCTSanPham.Controls.Add(this.cbo_NVGiaoHang);
            this.groupBox_TTCTSanPham.Controls.Add(this.lbl_SoLuong);
            this.groupBox_TTCTSanPham.Controls.Add(this.btn_LamMoi);
            this.groupBox_TTCTSanPham.Controls.Add(this.lbl_thanhtien);
            this.groupBox_TTCTSanPham.Controls.Add(this.label16);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_SoLuong);
            this.groupBox_TTCTSanPham.Controls.Add(this.btn_them);
            this.groupBox_TTCTSanPham.Controls.Add(this.label12);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_DonGia);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_TenMH);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_TenLoaiMH);
            this.groupBox_TTCTSanPham.Controls.Add(this.label10);
            this.groupBox_TTCTSanPham.Controls.Add(this.label11);
            this.groupBox_TTCTSanPham.Controls.Add(this.dateTimePicker2);
            this.groupBox_TTCTSanPham.Controls.Add(this.label7);
            this.groupBox_TTCTSanPham.Controls.Add(this.label2);
            this.groupBox_TTCTSanPham.Controls.Add(this.cbo_CTHoaDon);
            this.groupBox_TTCTSanPham.Controls.Add(this.label9);
            this.groupBox_TTCTSanPham.Controls.Add(this.cbo_HDB);
            this.groupBox_TTCTSanPham.Controls.Add(this.label6);
            this.groupBox_TTCTSanPham.Controls.Add(this.label4);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_SoHangGiao);
            this.groupBox_TTCTSanPham.Controls.Add(this.label3);
            this.groupBox_TTCTSanPham.Controls.Add(this.txt_MaGiaoHang);
            this.groupBox_TTCTSanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_TTCTSanPham.Location = new System.Drawing.Point(25, 49);
            this.groupBox_TTCTSanPham.Name = "groupBox_TTCTSanPham";
            this.groupBox_TTCTSanPham.Size = new System.Drawing.Size(1320, 220);
            this.groupBox_TTCTSanPham.TabIndex = 4;
            this.groupBox_TTCTSanPham.TabStop = false;
            this.groupBox_TTCTSanPham.Text = "Thông tin chi tiết mặt hàng";
            // 
            // cbo_NVGiaoHang
            // 
            this.cbo_NVGiaoHang.FormattingEnabled = true;
            this.cbo_NVGiaoHang.Location = new System.Drawing.Point(148, 76);
            this.cbo_NVGiaoHang.Name = "cbo_NVGiaoHang";
            this.cbo_NVGiaoHang.Size = new System.Drawing.Size(230, 27);
            this.cbo_NVGiaoHang.TabIndex = 96;
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.AutoSize = true;
            this.lbl_SoLuong.Location = new System.Drawing.Point(825, 42);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(64, 19);
            this.lbl_SoLuong.TabIndex = 95;
            this.lbl_SoLuong.Text = "Số lượng";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(1026, 176);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(99, 35);
            this.btn_LamMoi.TabIndex = 79;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.Location = new System.Drawing.Point(930, 34);
            this.txt_SoLuong.Multiline = true;
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(230, 27);
            this.txt_SoLuong.TabIndex = 94;
            this.txt_SoLuong.TextChanged += new System.EventHandler(this.txt_SoLuong_TextChanged);
            this.txt_SoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SoLuong_KeyPress);
            // 
            // btn_them
            // 
            this.btn_them.Location = new System.Drawing.Point(866, 175);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(99, 35);
            this.btn_them.TabIndex = 78;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.TabIndex = 93;
            this.label12.Text = "Đơn giá";
            // 
            // txt_DonGia
            // 
            this.txt_DonGia.Enabled = false;
            this.txt_DonGia.Location = new System.Drawing.Point(540, 168);
            this.txt_DonGia.Multiline = true;
            this.txt_DonGia.Name = "txt_DonGia";
            this.txt_DonGia.Size = new System.Drawing.Size(230, 27);
            this.txt_DonGia.TabIndex = 92;
            this.txt_DonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DonGia_KeyPress);
            // 
            // txt_TenMH
            // 
            this.txt_TenMH.Enabled = false;
            this.txt_TenMH.Location = new System.Drawing.Point(540, 121);
            this.txt_TenMH.Multiline = true;
            this.txt_TenMH.Name = "txt_TenMH";
            this.txt_TenMH.Size = new System.Drawing.Size(230, 27);
            this.txt_TenMH.TabIndex = 91;
            // 
            // txt_TenLoaiMH
            // 
            this.txt_TenLoaiMH.Enabled = false;
            this.txt_TenLoaiMH.Location = new System.Drawing.Point(540, 76);
            this.txt_TenLoaiMH.Multiline = true;
            this.txt_TenLoaiMH.Name = "txt_TenLoaiMH";
            this.txt_TenLoaiMH.Size = new System.Drawing.Size(230, 27);
            this.txt_TenLoaiMH.TabIndex = 90;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(419, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 19);
            this.label10.TabIndex = 89;
            this.label10.Text = "Tên loại mặt hàng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 19);
            this.label11.TabIndex = 88;
            this.label11.Text = "Tên mặt hàng";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(540, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(230, 26);
            this.dateTimePicker2.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 65;
            this.label7.Text = "Ngày giao hàng";
            // 
            // lbl_thanhtien
            // 
            this.lbl_thanhtien.AutoSize = true;
            this.lbl_thanhtien.Location = new System.Drawing.Point(994, 151);
            this.lbl_thanhtien.Name = "lbl_thanhtien";
            this.lbl_thanhtien.Size = new System.Drawing.Size(89, 19);
            this.lbl_thanhtien.TabIndex = 83;
            this.lbl_thanhtien.Text = "1000000000";
            this.lbl_thanhtien.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 85;
            this.label2.Text = "Nhân viên GH";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbo_CTHoaDon
            // 
            this.cbo_CTHoaDon.FormattingEnabled = true;
            this.cbo_CTHoaDon.Location = new System.Drawing.Point(148, 168);
            this.cbo_CTHoaDon.Name = "cbo_CTHoaDon";
            this.cbo_CTHoaDon.Size = new System.Drawing.Size(230, 27);
            this.cbo_CTHoaDon.TabIndex = 87;
            this.cbo_CTHoaDon.SelectedIndexChanged += new System.EventHandler(this.cbo_CTHoaDon_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1181, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 19);
            this.label16.TabIndex = 77;
            this.label16.Text = "VND";
            this.label16.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 19);
            this.label9.TabIndex = 86;
            this.label9.Text = " CT Hóa đơn ";
            // 
            // cbo_HDB
            // 
            this.cbo_HDB.FormattingEnabled = true;
            this.cbo_HDB.Location = new System.Drawing.Point(148, 121);
            this.cbo_HDB.Name = "cbo_HDB";
            this.cbo_HDB.Size = new System.Drawing.Size(230, 27);
            this.cbo_HDB.TabIndex = 82;
            this.cbo_HDB.SelectedIndexChanged += new System.EventHandler(this.cbo_HDB_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 19);
            this.label6.TabIndex = 81;
            this.label6.Text = "Hóa đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(825, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 76;
            this.label4.Text = "Số hàng giao";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_SoHangGiao
            // 
            this.txt_SoHangGiao.Enabled = false;
            this.txt_SoHangGiao.Location = new System.Drawing.Point(930, 76);
            this.txt_SoHangGiao.Multiline = true;
            this.txt_SoHangGiao.Name = "txt_SoHangGiao";
            this.txt_SoHangGiao.Size = new System.Drawing.Size(230, 27);
            this.txt_SoHangGiao.TabIndex = 75;
            this.txt_SoHangGiao.TextChanged += new System.EventHandler(this.txt_SoHangGiao_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 19);
            this.label3.TabIndex = 52;
            this.label3.Text = "Mã giao hàng";
            // 
            // txt_MaGiaoHang
            // 
            this.txt_MaGiaoHang.Enabled = false;
            this.txt_MaGiaoHang.Location = new System.Drawing.Point(148, 32);
            this.txt_MaGiaoHang.Multiline = true;
            this.txt_MaGiaoHang.Name = "txt_MaGiaoHang";
            this.txt_MaGiaoHang.Size = new System.Drawing.Size(230, 27);
            this.txt_MaGiaoHang.TabIndex = 51;
            // 
            // lbl_Manv
            // 
            this.lbl_Manv.AutoSize = true;
            this.lbl_Manv.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Manv.Location = new System.Drawing.Point(3, 0);
            this.lbl_Manv.Name = "lbl_Manv";
            this.lbl_Manv.Size = new System.Drawing.Size(101, 19);
            this.lbl_Manv.TabIndex = 54;
            this.lbl_Manv.Text = "Mã nhân viên";
            this.lbl_Manv.Click += new System.EventHandler(this.lbl_Manv_Click);
            // 
            // frm_GiaoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_TTCTSanPham);
            this.Controls.Add(this.lbl_Manv);
            this.Name = "frm_GiaoHang";
            this.Size = new System.Drawing.Size(1419, 753);
            this.Load += new System.EventHandler(this.frm_GiaoHang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CTGiaoHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GiaoHang)).EndInit();
            this.groupBox_TTCTSanPham.ResumeLayout(false);
            this.groupBox_TTCTSanPham.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_TTCTSanPham;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_Manv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MaGiaoHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SoHangGiao;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.DataGridView dataGridView_GiaoHang;
        private System.Windows.Forms.Label lbl_thanhtien;
        private System.Windows.Forms.ComboBox cbo_HDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_CTHoaDon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TenMH;
        private System.Windows.Forms.TextBox txt_TenLoaiMH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_DonGia;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.TextBox txt_SoLuong;
        private System.Windows.Forms.ComboBox cbo_NVGiaoHang;
        private System.Windows.Forms.DataGridView dataGridView_CTGiaoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}