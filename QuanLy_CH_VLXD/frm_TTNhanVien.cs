using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace QuanLy_CH_VLXD
{
    public partial class frm_TTNhanVien : UserControl
    {
        BLL_TTNhanVien bll_TTNhanVien = new BLL_TTNhanVien();
      

        public frm_TTNhanVien()
        {
            InitializeComponent();
        }

        private void frm_TTNhanVien_Load(object sender, EventArgs e)
        {
           
        }
       


        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            //String abc = txtMaNV.Text;
            //if (e.KeyCode == Keys.Enter)
            //{
            //    if (txtMaNV.Text == String.Empty)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        //txtHoTenNV.Text = bll_TTNhanVien.XemTenNhanVien_dal(txtMaNV.Text.ToString());
            //        if (txtHoTenNV.Text == String.Empty)
            //        {
            //            MessageBox.Show("Thêm nhân viên mới");
            //            txtMaNV.Clear();
            //            txtMaNV.Text = abc;
            //            return;
            //        }

            //        txtMaNV.Text.ToString().Trim();
            //        txtMaNV.Clear();
            //        txtMaNV.Text = abc;
            //    }
            //}
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
        }
       

        private void btnSua_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

       
        private void btnThem_ChucVu_Click(object sender, EventArgs e)
        {
        }

        private void btnSua_ChucVu_Click(object sender, EventArgs e)
        {
        }

        private void btnXoa_ChucVu_Click(object sender, EventArgs e)
        {
        }
    }
}
