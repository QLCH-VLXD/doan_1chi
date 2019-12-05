namespace QuanLy_CH_VLXD
{
    partial class frm_TTKhachHang
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
            this.datagird_KhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSua_TTKH = new System.Windows.Forms.Button();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLoaiKH = new System.Windows.Forms.TextBox();
            this.btnXoa_TTKH = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_LamMoiKH = new System.Windows.Forms.Button();
            this.btnThem_TTKH = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cboLoaiKH = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaLoaiKH = new System.Windows.Forms.TextBox();
            this.dataGridView_LoaiKH = new System.Windows.Forms.DataGridView();
            this.btnSua_LoaiKH = new System.Windows.Forms.Button();
            this.btnXoa_LoaiKH = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_LamMoiLKH = new System.Windows.Forms.Button();
            this.btnThem_LoaiKH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagird_KhachHang)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LoaiKH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagird_KhachHang
            // 
            this.datagird_KhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagird_KhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagird_KhachHang.Location = new System.Drawing.Point(19, 37);
            this.datagird_KhachHang.Name = "datagird_KhachHang";
            this.datagird_KhachHang.Size = new System.Drawing.Size(766, 224);
            this.datagird_KhachHang.TabIndex = 0;
            this.datagird_KhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.datagird_KhachHang.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LoadDL_khachhang_CellMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datagird_KhachHang);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(37, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(804, 476);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách khách hàng";
            // 
            // btnSua_TTKH
            // 
            this.btnSua_TTKH.Location = new System.Drawing.Point(281, 171);
            this.btnSua_TTKH.Name = "btnSua_TTKH";
            this.btnSua_TTKH.Size = new System.Drawing.Size(99, 35);
            this.btnSua_TTKH.TabIndex = 33;
            this.btnSua_TTKH.Text = "Sửa";
            this.btnSua_TTKH.UseVisualStyleBackColor = true;
            this.btnSua_TTKH.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(521, 36);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(240, 27);
            this.txtSDT.TabIndex = 24;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Loại khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã loại khách hàng";
            // 
            // txtLoaiKH
            // 
            this.txtLoaiKH.Location = new System.Drawing.Point(200, 87);
            this.txtLoaiKH.Multiline = true;
            this.txtLoaiKH.Name = "txtLoaiKH";
            this.txtLoaiKH.Size = new System.Drawing.Size(240, 27);
            this.txtLoaiKH.TabIndex = 8;
            // 
            // btnXoa_TTKH
            // 
            this.btnXoa_TTKH.Location = new System.Drawing.Point(398, 171);
            this.btnXoa_TTKH.Name = "btnXoa_TTKH";
            this.btnXoa_TTKH.Size = new System.Drawing.Size(99, 35);
            this.btnXoa_TTKH.TabIndex = 32;
            this.btnXoa_TTKH.Text = "Xóa";
            this.btnXoa_TTKH.UseVisualStyleBackColor = true;
            this.btnXoa_TTKH.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_LamMoiKH);
            this.groupBox2.Controls.Add(this.btnSua_TTKH);
            this.groupBox2.Controls.Add(this.txtSDT);
            this.groupBox2.Controls.Add(this.btnXoa_TTKH);
            this.groupBox2.Controls.Add(this.btnThem_TTKH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.cboLoaiKH);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtMaKH);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTenKH);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(37, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(804, 232);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // btn_LamMoiKH
            // 
            this.btn_LamMoiKH.Location = new System.Drawing.Point(514, 171);
            this.btn_LamMoiKH.Name = "btn_LamMoiKH";
            this.btn_LamMoiKH.Size = new System.Drawing.Size(99, 35);
            this.btn_LamMoiKH.TabIndex = 34;
            this.btn_LamMoiKH.Text = "Làm mới";
            this.btn_LamMoiKH.UseVisualStyleBackColor = true;
            this.btn_LamMoiKH.Click += new System.EventHandler(this.btn_LamMoiKH_Click);
            // 
            // btnThem_TTKH
            // 
            this.btnThem_TTKH.Location = new System.Drawing.Point(163, 171);
            this.btnThem_TTKH.Name = "btnThem_TTKH";
            this.btnThem_TTKH.Size = new System.Drawing.Size(99, 35);
            this.btnThem_TTKH.TabIndex = 31;
            this.btnThem_TTKH.Text = "Thêm";
            this.btnThem_TTKH.UseVisualStyleBackColor = true;
            this.btnThem_TTKH.Click += new System.EventHandler(this.btnThem_TTKH_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Số điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(521, 82);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(240, 27);
            this.txtDiaChi.TabIndex = 21;
            // 
            // cboLoaiKH
            // 
            this.cboLoaiKH.FormattingEnabled = true;
            this.cboLoaiKH.Location = new System.Drawing.Point(139, 128);
            this.cboLoaiKH.Name = "cboLoaiKH";
            this.cboLoaiKH.Size = new System.Drawing.Size(240, 27);
            this.cboLoaiKH.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 19);
            this.label5.TabIndex = 18;
            this.label5.Text = "Loại khách hàng";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(139, 36);
            this.txtMaKH.Multiline = true;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(240, 27);
            this.txtMaKH.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tên khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã khách hàng";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(139, 82);
            this.txtTenKH.Multiline = true;
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(240, 27);
            this.txtTenKH.TabIndex = 13;
            // 
            // txtMaLoaiKH
            // 
            this.txtMaLoaiKH.Enabled = false;
            this.txtMaLoaiKH.Location = new System.Drawing.Point(200, 41);
            this.txtMaLoaiKH.Multiline = true;
            this.txtMaLoaiKH.Name = "txtMaLoaiKH";
            this.txtMaLoaiKH.Size = new System.Drawing.Size(240, 27);
            this.txtMaLoaiKH.TabIndex = 12;
            // 
            // dataGridView_LoaiKH
            // 
            this.dataGridView_LoaiKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_LoaiKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_LoaiKH.Location = new System.Drawing.Point(30, 233);
            this.dataGridView_LoaiKH.Name = "dataGridView_LoaiKH";
            this.dataGridView_LoaiKH.Size = new System.Drawing.Size(448, 183);
            this.dataGridView_LoaiKH.TabIndex = 31;
            this.dataGridView_LoaiKH.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_LoaiKH_CellMouseClick);
            this.dataGridView_LoaiKH.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // btnSua_LoaiKH
            // 
            this.btnSua_LoaiKH.Location = new System.Drawing.Point(146, 171);
            this.btnSua_LoaiKH.Name = "btnSua_LoaiKH";
            this.btnSua_LoaiKH.Size = new System.Drawing.Size(99, 35);
            this.btnSua_LoaiKH.TabIndex = 30;
            this.btnSua_LoaiKH.Text = "Sửa";
            this.btnSua_LoaiKH.UseVisualStyleBackColor = true;
            this.btnSua_LoaiKH.Click += new System.EventHandler(this.btnSua_LoaiKH_Click);
            // 
            // btnXoa_LoaiKH
            // 
            this.btnXoa_LoaiKH.Location = new System.Drawing.Point(262, 171);
            this.btnXoa_LoaiKH.Name = "btnXoa_LoaiKH";
            this.btnXoa_LoaiKH.Size = new System.Drawing.Size(99, 35);
            this.btnXoa_LoaiKH.TabIndex = 29;
            this.btnXoa_LoaiKH.Text = "Xóa";
            this.btnXoa_LoaiKH.UseVisualStyleBackColor = true;
            this.btnXoa_LoaiKH.Click += new System.EventHandler(this.btnXoa_LoaiKH_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_LamMoiLKH);
            this.groupBox1.Controls.Add(this.dataGridView_LoaiKH);
            this.groupBox1.Controls.Add(this.btnSua_LoaiKH);
            this.groupBox1.Controls.Add(this.btnXoa_LoaiKH);
            this.groupBox1.Controls.Add(this.btnThem_LoaiKH);
            this.groupBox1.Controls.Add(this.txtMaLoaiKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLoaiKH);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(847, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 478);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại khách hàng";
            // 
            // btn_LamMoiLKH
            // 
            this.btn_LamMoiLKH.Location = new System.Drawing.Point(379, 171);
            this.btn_LamMoiLKH.Name = "btn_LamMoiLKH";
            this.btn_LamMoiLKH.Size = new System.Drawing.Size(99, 35);
            this.btn_LamMoiLKH.TabIndex = 32;
            this.btn_LamMoiLKH.Text = "Làm mới";
            this.btn_LamMoiLKH.UseVisualStyleBackColor = true;
            this.btn_LamMoiLKH.Click += new System.EventHandler(this.btn_LamMoiLKH_Click);
            // 
            // btnThem_LoaiKH
            // 
            this.btnThem_LoaiKH.Location = new System.Drawing.Point(30, 171);
            this.btnThem_LoaiKH.Name = "btnThem_LoaiKH";
            this.btnThem_LoaiKH.Size = new System.Drawing.Size(99, 35);
            this.btnThem_LoaiKH.TabIndex = 28;
            this.btnThem_LoaiKH.Text = "Thêm";
            this.btnThem_LoaiKH.UseVisualStyleBackColor = true;
            this.btnThem_LoaiKH.Click += new System.EventHandler(this.btnThem_LoaiKH_Click);
            // 
            // frm_TTKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_TTKhachHang";
            this.Size = new System.Drawing.Size(1370, 749);
            this.Load += new System.EventHandler(this.frm_TTKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagird_KhachHang)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LoaiKH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagird_KhachHang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSua_TTKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoaiKH;
        private System.Windows.Forms.Button btnXoa_TTKH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem_TTKH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cboLoaiKH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaLoaiKH;
        private System.Windows.Forms.DataGridView dataGridView_LoaiKH;
        private System.Windows.Forms.Button btnSua_LoaiKH;
        private System.Windows.Forms.Button btnXoa_LoaiKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem_LoaiKH;
        private System.Windows.Forms.Button btn_LamMoiKH;
        private System.Windows.Forms.Button btn_LamMoiLKH;
    }
}