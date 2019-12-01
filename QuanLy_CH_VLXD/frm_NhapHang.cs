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
    public partial class frm_NhapHang : UserControl
    {
        BLL_NhapHang bLL_NhapHang = new BLL_NhapHang();

        private String lay_dl;
        private String s;

        public frm_NhapHang()
        {
            InitializeComponent();
        }
        
        private void frm_NhapHang_Load(object sender, EventArgs e)
        {
            txt_PhieuNhap.Text = "PH" + bLL_NhapHang.Sinh_MaNhapHang_dal();
            cbo_LoaiMH.DataSource = bLL_NhapHang.load_loaiMatHang();
            cbo_LoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMH.DisplayMember = "TENLOAIMATHANG";
            cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX();
            cbo_maPNNSX.DisplayMember = "MAPDHNSX";


            lbl_manv.Text = Lay_DL;
        }

        private void cbo_LoaiMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_LoaiMH.SelectedValue.ToString() != String.Empty)
            {
                cbo_TenMH.DataSource = bLL_NhapHang.load_MatHang(cbo_LoaiMH.SelectedValue.ToString());
                cbo_TenMH.ValueMember = "MAMATHANG";
                cbo_TenMH.DisplayMember = "TENMATHANG";
            }
        }

        private void cbo_TenMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_TenMH.Text.ToString() != String.Empty)
            {
                txt_DonGiaNhap.Text = bLL_NhapHang.Load_dongia(cbo_TenMH.SelectedValue.ToString());
                txt_DonViTinh.Text = bLL_NhapHang.Load_donvitinh(cbo_TenMH.SelectedValue.ToString());
                cbo_NSX.DataSource = bLL_NhapHang.load_NSX(cbo_TenMH.SelectedValue.ToString());
                cbo_NSX.ValueMember = "MANSX";
                cbo_NSX.DisplayMember = "TENNSX";
                

            }
        }


        /////// lấy dữ liệu 
        public string Lay_DL
        {
            get { return lay_dl; }
            set { lay_dl = value; }
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
