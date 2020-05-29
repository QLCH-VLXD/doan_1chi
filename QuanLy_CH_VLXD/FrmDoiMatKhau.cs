using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_CH_VLXD
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
            txt_NhapLaiMatKhau.PasswordChar = '*';
        }



        private void txtNhapLaiMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapLaiMK_Click(object sender, EventArgs e)
        {
            if (txt_NhapLaiMatKhau.PasswordChar.ToString().CompareTo("*") == 0)
            {
                txt_NhapLaiMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_NhapLaiMatKhau.PasswordChar = '*';
            }
        }

        //private void FrmDoiMatKhau_Load_1(object sender, EventArgs e)
        //{
        //    txt_NhapLaiMatKhau.PasswordChar = '*';
        //    txt_NhapMatKhau.PasswordChar = '*';
        //    nHANVIENTableAdapter.Fill(dataSetQLNS.NHANVIEN);
        //}

        private void btn_MatKhauMoi_Click(object sender, EventArgs e)
        {
            if (txt_NhapMatKhau.PasswordChar.ToString().CompareTo("*") == 0)
            {
                txt_NhapMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_NhapMatKhau.PasswordChar = '*';
            }
        }

        private void tAIKHOANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tAIKHOANBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.NHANVIEN' table. You can move, or remove it, as needed.
            this.nHANVIENTableAdapter.Fill(this.dataSet1.NHANVIEN);
            // TODO: This line of code loads data into the 'dataSet1.TAIKHOAN' table. You can move, or remove it, as needed.
            this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);

            txt_NhapLaiMatKhau.PasswordChar = '*';
            txt_NhapMatKhau.PasswordChar = '*';
            nHANVIENTableAdapter.Fill(dataSet1.NHANVIEN);

        }

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            DoiMatKhau();

        }

        private void DoiMatKhau()
        {
            if (txt_MK.Text.Length > 0 && txt_NhapMatKhau.Text.Length > 0 && txt_NhapLaiMatKhau.Text.Length > 0)
            {
                if (txt_NhapLaiMatKhau.Text.Trim().ToString() == txt_NhapMatKhau.Text.Trim().ToString())
                {
                    try
                    {

                        if (Properties.Settings.Default.pass.Trim().ToString() != txt_MK.Text.Trim().ToString())
                        {
                            MessageBox.Show("Sai mật khẩu");
                        }
                        else
                        {
                            tAIKHOANTableAdapter.Fill(dataSet1.TAIKHOAN);
                            DataSet1.TAIKHOANRow data = dataSet1.TAIKHOAN.FindByMANV(Properties.Settings.Default.user);
                            data.MATKHAU = txt_NhapMatKhau.Text.Trim().ToString();
                            tAIKHOANTableAdapter.Update(this.dataSet1.TAIKHOAN);
                            Properties.Settings.Default.pass = txt_NhapMatKhau.Text.Trim().ToString();
                            MessageBox.Show("Thành công");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Thất bại");
                    }

                }
                else
                {
                    txt_NhapMatKhau.Clear();
                    txt_NhapLaiMatKhau.Clear();
                    MessageBox.Show("Mật khẩu mới không trùng nhau");
                }
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu");
            }
        }

        //private void tAIKHOANBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        //{
        //    this.Validate();
        //    this.tAIKHOANBindingSource.EndEdit();
        //    this.tableAdapterManager.UpdateAll(this.dataSet1);
        //}
    }
}
