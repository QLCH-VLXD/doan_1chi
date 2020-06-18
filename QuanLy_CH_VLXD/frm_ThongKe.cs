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
    public partial class frm_ThongKe : UserControl
    {
        private String s;

        BLL_ThongKe bLL_ThongKe = new BLL_ThongKe();
        BLL_GiaoHang bLL_GiaoHang = new BLL_GiaoHang();
        BLL_NhapHang bLL_NhapHang = new BLL_NhapHang();
        BLL_BanHang bLL_BanHang = new BLL_BanHang();
        BLL_DanhMucSanPham bll_DanhMucSanPham = new BLL_DanhMucSanPham();
        public frm_ThongKe()
        {
            InitializeComponent();
        }
        int i = 0;
        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            dataGridView_TK_SapHet.DataSource = bLL_ThongKe.load_TKSapHet();
            dataGridView_SH.DataSource = bLL_ThongKe.load_TKsaphet();

            dataGridView_TKTonKho.DataSource = bLL_ThongKe.load_TKTonKho();
            dataGridView_TK.DataSource = bLL_ThongKe.load_TKtonkho();

            dataGridView_CT_GiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
            dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();

            dataGridview_BanHang.DataSource = bLL_BanHang.load_HDB();
            dataGridview_CT_BanHang.DataSource = bLL_BanHang.load_CTHDB();

            dataGridview_nhapHang.DataSource = bLL_NhapHang.load_nhaphang();
            dataGridview_CT_NhapHang.DataSource = bLL_NhapHang.load_CTnhaphang();

            dataGridView_MatHang.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {

            THONGKE tk = new THONGKE();
            if (bLL_ThongKe.Test(DateTime.Today) == "0" || bLL_ThongKe.Test(DateTime.Today) == null)
            {
                bLL_ThongKe.Them_tk();

            }
            TKHANGSAPHET tksh = new TKHANGSAPHET();
            int i;

            for (i = 0; i < dataGridView_TK_SapHet.RowCount; i++)
            {

                tksh.MATK = (bLL_ThongKe.Test(DateTime.Today));
                tksh.MAMATHANG = dataGridView_TK_SapHet.Rows[i].Cells[2].Value.ToString();

                tksh.SOLUONGSAPHET = Convert.ToInt32(dataGridView_TK_SapHet.Rows[i].Cells[5].Value.ToString());


                if (bLL_ThongKe.Luu_TK_saphet_tksh(tksh) == true)
                {
                    dataGridView_TK_SapHet.DataSource = bLL_ThongKe.load_TKSapHet();
                    MessageBox.Show("Lưu thành công");
                    tksh = new TKHANGSAPHET();
                    dataGridView_SH.DataSource = bLL_ThongKe.load_TKsaphet();
                }


            }
        }



        private void dateTimePicker_TKSapHet_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker_TKSapHet.Text.Length > 0)
                {
                    dataGridView_SH.DataSource = bLL_ThongKe.search_TKSH(dateTimePicker_TKSapHet.Value);
                }
                else
                {
                    dataGridView_SH.DataSource = bLL_ThongKe.load_TKsaphet();
                }
            }
            catch (Exception)
            {

                //}
            }
        }

        private void btnLuu_TKTonKho_Click(object sender, EventArgs e)
        {
            THONGKE tk = new THONGKE();
            if (bLL_ThongKe.Test(DateTime.Today) == "0" || bLL_ThongKe.Test(DateTime.Today) == null)
            {
                bLL_ThongKe.Them_tk();
            }
            TKHANGTONKHO tktk = new TKHANGTONKHO();
            int i;
            int n = 0;
            for (i = 0; i < dataGridView_TKTonKho.RowCount; i++)
            {
                tktk.MATK = (bLL_ThongKe.Test(DateTime.Today));
                tktk.MAMATHANG = dataGridView_TKTonKho.Rows[i].Cells[0].Value.ToString();
                tktk.SOLUONGTONKHO = Convert.ToInt32(dataGridView_TKTonKho.Rows[i].Cells[3].Value.ToString());
                if (bLL_ThongKe.Luu_TK_tonkho_tktk(tktk) == true)
                {
                    n = 1;
                    dataGridView_TKTonKho.DataSource = bLL_ThongKe.load_TKTonKho();

                    tktk = new TKHANGTONKHO();
                    dataGridView_TK.DataSource = bLL_ThongKe.load_TKtonkho();
                }
                else
                    n = 0;
            }
            if (n == 1)
            {
                MessageBox.Show("Lưu thành công");
            }
            else
            {
                MessageBox.Show("Lỗi !!!!!!!");
            }
        }

        private void dateTimePicker_Tonkho_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateTimePicker_Tonkho.Text.Length > 0)
                {
                    dataGridView_TK.DataSource = bLL_ThongKe.search_TKTK(dateTimePicker_Tonkho.Value);
                }
                else
                {
                    dataGridView_TK.DataSource = bLL_ThongKe.load_TKtonkho();
                }
            }
            catch (Exception)
            {

            }
        }
        
        private void dataGridview_nhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridview_nhapHang.CurrentRow.Cells[0].Value.ToString();
            dataGridview_CT_NhapHang.DataSource = bLL_NhapHang.load_CTnhaphang1(s);
        }

        private void dataGridview_BanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridview_BanHang.CurrentRow.Cells[0].Value.ToString();
            dataGridview_CT_BanHang.DataSource = bLL_BanHang.load_CTHDB1(s);
        }

        private void dataGridView_GiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CT_GiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(s);
        }
    }
}

