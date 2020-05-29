namespace QuanLy_CH_VLXD
{
    partial class FrmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiMatKhau));
            this.btn_NhapLaiMatKhau = new System.Windows.Forms.Button();
            this.btn_MatKhauMoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNV = new System.Windows.Forms.Label();
            this.btn_DoiMK = new System.Windows.Forms.Button();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.txt_NhapMatKhau = new System.Windows.Forms.TextBox();
            this.txt_NhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.dataSet1 = new QuanLy_CH_VLXD.DataSet1();
            this.tAIKHOANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tAIKHOANTableAdapter = new QuanLy_CH_VLXD.DataSet1TableAdapters.TAIKHOANTableAdapter();
            this.tableAdapterManager = new QuanLy_CH_VLXD.DataSet1TableAdapters.TableAdapterManager();
            this.nHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nHANVIENTableAdapter = new QuanLy_CH_VLXD.DataSet1TableAdapters.NHANVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAIKHOANBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_NhapLaiMatKhau
            // 
            this.btn_NhapLaiMatKhau.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhapLaiMatKhau.Image")));
            this.btn_NhapLaiMatKhau.Location = new System.Drawing.Point(425, 157);
            this.btn_NhapLaiMatKhau.Name = "btn_NhapLaiMatKhau";
            this.btn_NhapLaiMatKhau.Size = new System.Drawing.Size(37, 37);
            this.btn_NhapLaiMatKhau.TabIndex = 15;
            this.btn_NhapLaiMatKhau.UseVisualStyleBackColor = true;
            this.btn_NhapLaiMatKhau.Click += new System.EventHandler(this.btnNhapLaiMK_Click);
            // 
            // btn_MatKhauMoi
            // 
            this.btn_MatKhauMoi.Image = ((System.Drawing.Image)(resources.GetObject("btn_MatKhauMoi.Image")));
            this.btn_MatKhauMoi.Location = new System.Drawing.Point(425, 108);
            this.btn_MatKhauMoi.Name = "btn_MatKhauMoi";
            this.btn_MatKhauMoi.Size = new System.Drawing.Size(37, 37);
            this.btn_MatKhauMoi.TabIndex = 14;
            this.btn_MatKhauMoi.UseVisualStyleBackColor = true;
            this.btn_MatKhauMoi.Click += new System.EventHandler(this.btn_MatKhauMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // labelNV
            // 
            this.labelNV.AutoSize = true;
            this.labelNV.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNV.Location = new System.Drawing.Point(126, 19);
            this.labelNV.Name = "labelNV";
            this.labelNV.Size = new System.Drawing.Size(252, 28);
            this.labelNV.TabIndex = 16;
            this.labelNV.Text = "Đổi mật khẩu nhân viên";
            // 
            // btn_DoiMK
            // 
            this.btn_DoiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMK.Location = new System.Drawing.Point(155, 208);
            this.btn_DoiMK.Name = "btn_DoiMK";
            this.btn_DoiMK.Size = new System.Drawing.Size(223, 30);
            this.btn_DoiMK.TabIndex = 17;
            this.btn_DoiMK.Text = "Đổi Mật Khẩu";
            this.btn_DoiMK.UseVisualStyleBackColor = true;
            this.btn_DoiMK.Click += new System.EventHandler(this.btn_DoiMK_Click);
            // 
            // txt_MK
            // 
            this.txt_MK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MK.Location = new System.Drawing.Point(155, 70);
            this.txt_MK.Multiline = true;
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.Size = new System.Drawing.Size(223, 27);
            this.txt_MK.TabIndex = 18;
            // 
            // txt_NhapMatKhau
            // 
            this.txt_NhapMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhapMatKhau.Location = new System.Drawing.Point(155, 112);
            this.txt_NhapMatKhau.Multiline = true;
            this.txt_NhapMatKhau.Name = "txt_NhapMatKhau";
            this.txt_NhapMatKhau.Size = new System.Drawing.Size(223, 27);
            this.txt_NhapMatKhau.TabIndex = 19;
            // 
            // txt_NhapLaiMatKhau
            // 
            this.txt_NhapLaiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhapLaiMatKhau.Location = new System.Drawing.Point(155, 152);
            this.txt_NhapLaiMatKhau.Multiline = true;
            this.txt_NhapLaiMatKhau.Name = "txt_NhapLaiMatKhau";
            this.txt_NhapLaiMatKhau.Size = new System.Drawing.Size(223, 27);
            this.txt_NhapLaiMatKhau.TabIndex = 20;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tAIKHOANBindingSource
            // 
            this.tAIKHOANBindingSource.DataMember = "TAIKHOAN";
            this.tAIKHOANBindingSource.DataSource = this.dataSet1;
            // 
            // tAIKHOANTableAdapter
            // 
            this.tAIKHOANTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHITIETGIAOHANGTableAdapter = null;
            this.tableAdapterManager.CHITIETHOADONBANTableAdapter = null;
            this.tableAdapterManager.CHITIETMATHANGTableAdapter = null;
            this.tableAdapterManager.CHITIETNHASANXUATTableAdapter = null;
            this.tableAdapterManager.CHITIETPHIEUNHAPHANGTableAdapter = null;
            this.tableAdapterManager.CHUCVUTableAdapter = null;
            this.tableAdapterManager.CTPHIEUDATHANGNSXTableAdapter = null;
            this.tableAdapterManager.DONGIATableAdapter = null;
            this.tableAdapterManager.DONVITINHTableAdapter = null;
            this.tableAdapterManager.GIAOHANGTableAdapter = null;
            this.tableAdapterManager.HOADONBANTableAdapter = null;
            this.tableAdapterManager.KHACHHANGTableAdapter = null;
            this.tableAdapterManager.LOAIKHACHHANGTableAdapter = null;
            this.tableAdapterManager.LOAIMATHANGTableAdapter = null;
            this.tableAdapterManager.MANHINHTableAdapter = null;
            this.tableAdapterManager.MATHANGTableAdapter = null;
            this.tableAdapterManager.NGUOIDUNGNHOMNGUOIDUNGTableAdapter = null;
            this.tableAdapterManager.NHANVIENTableAdapter = this.nHANVIENTableAdapter;
            this.tableAdapterManager.NHASANXUATTableAdapter = null;
            this.tableAdapterManager.NHOMNGUOIDUNGTableAdapter = null;
            this.tableAdapterManager.PHANQUYENTableAdapter = null;
            this.tableAdapterManager.PHIEUDATHANGNSXTableAdapter = null;
            this.tableAdapterManager.PHIEUNHAPHANGTableAdapter = null;
            this.tableAdapterManager.TAIKHOANTableAdapter = this.tAIKHOANTableAdapter;
            this.tableAdapterManager.UpdateOrder = QuanLy_CH_VLXD.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nHANVIENBindingSource
            // 
            this.nHANVIENBindingSource.DataMember = "NHANVIEN";
            this.nHANVIENBindingSource.DataSource = this.dataSet1;
            // 
            // nHANVIENTableAdapter
            // 
            this.nHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // FrmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 476);
            this.Controls.Add(this.txt_NhapLaiMatKhau);
            this.Controls.Add(this.txt_NhapMatKhau);
            this.Controls.Add(this.txt_MK);
            this.Controls.Add(this.btn_DoiMK);
            this.Controls.Add(this.labelNV);
            this.Controls.Add(this.btn_NhapLaiMatKhau);
            this.Controls.Add(this.btn_MatKhauMoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoiMatKhau";
            this.Text = "FrmDoiMatKhau";
            this.Load += new System.EventHandler(this.FrmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tAIKHOANBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHANVIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_NhapLaiMatKhau;
        private System.Windows.Forms.Button btn_MatKhauMoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelNV;
        private System.Windows.Forms.Button btn_DoiMK;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.TextBox txt_NhapMatKhau;
        private System.Windows.Forms.TextBox txt_NhapLaiMatKhau;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource tAIKHOANBindingSource;
        private DataSet1TableAdapters.TAIKHOANTableAdapter tAIKHOANTableAdapter;
        private DataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private DataSet1TableAdapters.NHANVIENTableAdapter nHANVIENTableAdapter;
        private System.Windows.Forms.BindingSource nHANVIENBindingSource;
    }
}