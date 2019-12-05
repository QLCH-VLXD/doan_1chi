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
    public partial class frm_GiaoHang : UserControl
    {

        BLL_GiaoHang bLL_GiaoHang = new BLL_GiaoHang();

        public frm_GiaoHang()
        {
            InitializeComponent();
        }

        private void frm_GiaoHang_Load(object sender, EventArgs e)
        {
            txt_MaGiaoHang.Text = "GH" + bLL_GiaoHang.Sinh_MaHoaDon_dal();
            lbl_Manv.Text = Properties.Settings.Default.user;
        }

        private void txt_SDT_KeyPress(object sender, KeyEventArgs e)
        {
            String abc = txt_SDT.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_SDT.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    txt_TenKH.Text = bLL_GiaoHang.XemTenKhachHang_dal(txt_SDT.Text.ToString());
                    if (txt_TenKH.Text == String.Empty)
                    {
                        MessageBox.Show("Thêm khách hàng mới");
                        txt_SDT.Clear();
                        txt_SDT.Text = abc;
                        return;
                    }

                    txt_SDT.Text.ToString().Trim();
                    txt_SDT.Clear();
                    txt_SDT.Text = abc;
                }
            }
        }
    }
}
