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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoiMatKhau));
            this.btnNhapLaiMK = new System.Windows.Forms.Button();
            this.btnNhapMKMoi = new System.Windows.Forms.Button();
            this.txtNhapLaiMK = new System.Windows.Forms.TextBox();
            this.txtMKMoi = new System.Windows.Forms.TextBox();
            this.txtMKHienTai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNhapLaiMK
            // 
            this.btnNhapLaiMK.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapLaiMK.Image")));
            this.btnNhapLaiMK.Location = new System.Drawing.Point(425, 157);
            this.btnNhapLaiMK.Name = "btnNhapLaiMK";
            this.btnNhapLaiMK.Size = new System.Drawing.Size(37, 37);
            this.btnNhapLaiMK.TabIndex = 15;
            this.btnNhapLaiMK.UseVisualStyleBackColor = true;
            this.btnNhapLaiMK.Click += new System.EventHandler(this.btnNhapLaiMK_Click);
            // 
            // btnNhapMKMoi
            // 
            this.btnNhapMKMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnNhapMKMoi.Image")));
            this.btnNhapMKMoi.Location = new System.Drawing.Point(425, 108);
            this.btnNhapMKMoi.Name = "btnNhapMKMoi";
            this.btnNhapMKMoi.Size = new System.Drawing.Size(37, 37);
            this.btnNhapMKMoi.TabIndex = 14;
            this.btnNhapMKMoi.UseVisualStyleBackColor = true;
            this.btnNhapMKMoi.Click += new System.EventHandler(this.btnNhapMKMoi_Click);
            // 
            // txtNhapLaiMK
            // 
            this.txtNhapLaiMK.Location = new System.Drawing.Point(168, 166);
            this.txtNhapLaiMK.Name = "txtNhapLaiMK";
            this.txtNhapLaiMK.Size = new System.Drawing.Size(210, 20);
            this.txtNhapLaiMK.TabIndex = 13;
            this.txtNhapLaiMK.Click += new System.EventHandler(this.txtNhapLaiMK_Click);
            this.txtNhapLaiMK.TextChanged += new System.EventHandler(this.txtNhapLaiMK_TextChanged);
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Location = new System.Drawing.Point(168, 117);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.Size = new System.Drawing.Size(210, 20);
            this.txtMKMoi.TabIndex = 12;
            // 
            // txtMKHienTai
            // 
            this.txtMKHienTai.Location = new System.Drawing.Point(168, 60);
            this.txtMKHienTai.Name = "txtMKHienTai";
            this.txtMKHienTai.Size = new System.Drawing.Size(210, 20);
            this.txtMKHienTai.TabIndex = 11;
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
            this.label1.Location = new System.Drawing.Point(41, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mật khẩu hiện tại";
            // 
            // FrmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 250);
            this.Controls.Add(this.btnNhapLaiMK);
            this.Controls.Add(this.btnNhapMKMoi);
            this.Controls.Add(this.txtNhapLaiMK);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.txtMKHienTai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDoiMatKhau";
            this.Text = "FrmDoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNhapLaiMK;
        private System.Windows.Forms.Button btnNhapMKMoi;
        private System.Windows.Forms.TextBox txtNhapLaiMK;
        private System.Windows.Forms.TextBox txtMKMoi;
        private System.Windows.Forms.TextBox txtMKHienTai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}