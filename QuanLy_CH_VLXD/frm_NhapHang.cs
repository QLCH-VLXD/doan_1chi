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

        
        private String s;
        private String a;
        private int f;
        private Double sum = 0;
        string m;
        public frm_NhapHang()
        {
            InitializeComponent();
        }
        
        private void frm_NhapHang_Load(object sender, EventArgs e)
        {
            txt_PhieuNhap.Text = "PN" + bLL_NhapHang.Sinh_MaNhapHang_dal();

            cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX();
            cbo_maPNNSX.DisplayMember = "MAPDHNSX";
            cbo_maPNNSX.ValueMember = "MAPDHNSX";

            dataGridView_nhaphang.DataSource = bLL_NhapHang.load_nhaphang();
            dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang();

            lbl_manv.Text = Properties.Settings.Default.user;
        }

        private void cbo_LoaiMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_LoaiMH.SelectedValue.ToString() != String.Empty)
            //{
            //    cbo_TenMH.DataSource = bLL_NhapHang.load_MatHang(cbo_LoaiMH.SelectedValue.ToString());
            //    cbo_TenMH.ValueMember = "MAMATHANG";
            //    cbo_TenMH.DisplayMember = "TENMATHANG";
            //}
        }

        private void cbo_TenMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbo_TenMH.Text.ToString() != String.Empty)
            //{
            //    txt_DonGiaNhap.Text = bLL_NhapHang.Load_dongia(cbo_TenMH.SelectedValue.ToString());
            //    txt_DonViTinh.Text = bLL_NhapHang.Load_donvitinh(cbo_TenMH.SelectedValue.ToString());

            //    cbo_NSX.DataSource = bLL_NhapHang.load_NSX(cbo_TenMH.SelectedValue.ToString());
            //    cbo_NSX.ValueMember = "MANSX";
            //    cbo_NSX.DisplayMember = "TENNSX";
            //}
        }


       
        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbo_maPNNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_maPNNSX.Text.ToString() != String.Empty)
            {
                cbo_chitietPDNSX.DataSource = bLL_NhapHang.load_ChiTietPDNSX(cbo_maPNNSX.SelectedValue.ToString());
                cbo_chitietPDNSX.ValueMember = "MACTPHIEUDATHANG";
                cbo_chitietPDNSX.DisplayMember = "MACTPHIEUDATHANG";
            }
        }

        private void cbo_chitietPDNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_chitietPDNSX.Text.ToString() != String.Empty)
            {
                txt_TenMH.Text = bLL_NhapHang.load_MatHang(cbo_chitietPDNSX.SelectedValue.ToString());
                txt_TenLoaiMH.Text = bLL_NhapHang.load_loaiMatHang(cbo_chitietPDNSX.SelectedValue.ToString());
                txt_SoLuong.Text = bLL_NhapHang.load_SoLuong(cbo_chitietPDNSX.SelectedValue.ToString());
                txt_DonViTinh.Text = bLL_NhapHang.Load_donvitinh(cbo_chitietPDNSX.SelectedValue.ToString());
                txt_NSX.Text = bLL_NhapHang.load_NSX(cbo_chitietPDNSX.SelectedValue.ToString());
                txt_DonGiaNhap.Text = bLL_NhapHang.Load_dongia(cbo_chitietPDNSX.SelectedValue.ToString());


            }
        }

        private void dataGridView_nhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang1(s);
        }

        private void btn_them_Click(object sender, EventArgs e)
        { 
            PHIEUNHAPHANG mh = new PHIEUNHAPHANG();
            mh.MAPN = txt_PhieuNhap.Text;
            mh.MANV = lbl_manv.Text;
            mh.MANSX = bLL_NhapHang.LAYten(txt_NSX.Text.ToString());
            mh.NGAYNHAP = Convert.ToDateTime(dateTimePicker_NhayNhap.Text);
            mh.SOLUONGMATHANG =Convert.ToInt32(txt_SoLuong.Text);
            mh.TONGTIENHANGNHAP = 0;
            mh.TINHTRANG = null;
            if (bLL_NhapHang.KTKC(mh) == true)
            {

                if (bLL_NhapHang.them_PNH(mh) == true)
                {
                    MessageBox.Show("thanh cong");
                    dataGridView_nhaphang.DataSource = bLL_NhapHang.load_nhaphang();
                    dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang();

                }
                else
                {
                    MessageBox.Show("that bai");
                    return;
                }
            }
            else
            {
                CHITIETPHIEUNHAPHANG ct = new CHITIETPHIEUNHAPHANG();
                ct.MACTPN = "CTPN" + bLL_NhapHang.Sinh_MaNhapHang_dal();
                String ma= "CTPN" + bLL_NhapHang.Sinh_MaNhapHang_dal();
                m = ma;
                ct.MAPN = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
                ct.MACTPHIEUDATHANG = cbo_chitietPDNSX.SelectedValue.ToString();
                ct.SOLUONGMH = Convert.ToInt32(txt_SoLuong.Text);
                ct.THANHTIENCTPNH = Convert.ToDecimal(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDecimal(txt_DonGiaNhap.Text));
                
                f += 1;
                sum += Convert.ToDouble(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDouble(txt_DonGiaNhap.Text));
                if (bLL_NhapHang.KTKC_CTPNH(ct) == true)
                {
                    if (bLL_NhapHang.them_CTPNH(ct) == true)
                    {
                        mh.MAPN = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
                        mh.SOLUONGMATHANG = f;
                        mh.TONGTIENHANGNHAP = Convert.ToDecimal(sum);
                        int sl = bLL_NhapHang.laysoluong(ma);
                        if (Convert.ToInt32(txt_SoLuong.Text) <= sl)
                        {
                            text_socon.Text = txt_SoLuong.Text + "/" + sl.ToString();
                        }
                        else
                        {
                            MessageBox.Show("đã vượt mức đặt hàng");
                        }
                        if (bLL_NhapHang.Sua_PNH(mh) == true)
                        {

                            dataGridView_nhaphang.DataSource = bLL_NhapHang.load_nhaphang();
                            dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang();
                            //MessageBox.Show("Thành công"); 

                            dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang1(dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString());
                            
                        }
                        else
                        {
                            MessageBox.Show("xảy ra sự số");

                        }
                        MessageBox.Show("thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("that bai");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ma da ton tai");
                    return;
                }
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_PhieuNhap.Text = "PN" + bLL_NhapHang.Sinh_MaNhapHang_dal();
            cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX();
            cbo_maPNNSX.DisplayMember = "MAPDHNSX";
            cbo_maPNNSX.ValueMember = "MAPDHNSX";
            txt_NSX.Clear();
            txt_TenLoaiMH.Clear();
            txt_TenMH.Clear();
            txt_DonGiaNhap.Clear();
            txt_DonViTinh.Clear();
            txt_SoLuong.Clear();
        }

        private void groupBox_TTCTSanPham_Enter(object sender, EventArgs e)
        {

        }

        private void text_socon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            if(bLL_NhapHang.laysoluong_ctdathang(cbo_chitietPDNSX.Text.ToString())<Convert.ToInt32(txt_SoLuong.Text.ToString()))
            {

                MessageBox.Show("Số lượng hàng nhập đã quá số lượng đặt");
                return;
            }
            for(int i=0;i<bLL_NhapHang.Gomnhom_CTPDH().Count;i++)
            {
                MessageBox.Show(bLL_NhapHang.Gomnhom_CTPDH().Select(p=>p.mactod1).ToString());
            }
        }
    }
}
