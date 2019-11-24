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
            txtNhapLaiMK.PasswordChar = '*';
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnNhapMKMoi_Click(object sender, EventArgs e)
        {
            if (txtMKMoi.PasswordChar.ToString().CompareTo("*") == 0)
            {
                txtMKMoi.PasswordChar = '\0';
            }
            else
            {
                txtMKMoi.PasswordChar = '*';
            }
        }

        private void txtNhapLaiMK_Click(object sender, EventArgs e)
        {
            if (txtNhapLaiMK.PasswordChar.ToString().CompareTo("*") == 0)
            {
                txtNhapLaiMK.PasswordChar = '\0';
            }
            else
            {
                txtNhapLaiMK.PasswordChar = '*';
            }
        }

        private void txtNhapLaiMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhapLaiMK_Click(object sender, EventArgs e)
        {

        }
    }
}
