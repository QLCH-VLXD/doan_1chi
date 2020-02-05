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
        BLL_DatHangNSX bLL_DatHangNSX = new BLL_DatHangNSX();


        private String s;
        private String a;
        private int f;
        private int t = 0;
        private Double sum = 0;
        string m;
        public frm_NhapHang()
        {
            InitializeComponent();
        }
        
        private void frm_NhapHang_Load(object sender, EventArgs e)
        {
            

            cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX1();
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
                cbo_chitietPDNSX.ValueMember = "MAPDHNSX";
                cbo_chitietPDNSX.DisplayMember = "MACTPHIEUDATHANG";
               
            }
        }

        private void cbo_chitietPDNSX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_chitietPDNSX.Text.ToString() != String.Empty)
            {
                txt_TenMH.Text = bLL_NhapHang.load_MatHang(cbo_chitietPDNSX.Text.ToString());
                txt_TenLoaiMH.Text = bLL_NhapHang.load_loaiMatHang(cbo_chitietPDNSX.Text.ToString());
               // txt_SoLuong.Text = bLL_NhapHang.load_SoLuong(cbo_chitietPDNSX.Text.ToString());
                txt_DonViTinh.Text = bLL_NhapHang.Load_donvitinh(cbo_chitietPDNSX.Text.ToString());
                txt_NSX.Text = bLL_NhapHang.load_NSX(cbo_chitietPDNSX.Text.ToString());
                //txt_DonGiaNhap.Text = bLL_NhapHang.Load_dongia(cbo_chitietPDNSX.Text.ToString());


            }
        }

        private void dataGridView_nhaphang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang1(s);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_DonGiaNhap.Text.Length > 0 && txt_SoLuong.Text.Length>0)
            {
                PHIEUNHAPHANG mh = new PHIEUNHAPHANG();
                mh.MAPN = txt_PhieuNhap.Text;
                mh.MANV = lbl_manv.Text;
                mh.MANSX = bLL_NhapHang.LAYten(txt_NSX.Text.ToString());
                mh.NGAYNHAP = Convert.ToDateTime(dateTimePicker_NhayNhap.Text);
                mh.SOLUONGMATHANG = 0;
                mh.TONGTIENHANGNHAP = 0;
                mh.TINHTRANG = null;
                if (bLL_NhapHang.KTKC(mh) == true)
                {

                    if (bLL_NhapHang.them_PNH(mh) == true)
                    {
                        MessageBox.Show("Thành công");
                        dataGridView_nhaphang.DataSource = bLL_NhapHang.load_nhaphang();
                        dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang();

                    }
                    else
                    {
                        MessageBox.Show("Thất bại");
                        return;
                    }
                }
                else
                {
                    CHITIETPHIEUNHAPHANG ct = new CHITIETPHIEUNHAPHANG();
                    ct.MACTPN = "CTPN" + bLL_NhapHang.Sinh_MaNhapHang_dal();
                    String ma = "CTPN" + bLL_NhapHang.Sinh_MaNhapHang_dal();
                    m = ma;
                    ct.MAPN = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
                    ct.MACTPHIEUDATHANG = cbo_chitietPDNSX.Text.ToString();
                    ct.SOLUONGMH = Convert.ToInt32(txt_SoLuong.Text);
                    ct.THANHTIENCTPNH = Convert.ToDecimal(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDecimal(txt_DonGiaNhap.Text));

                    f += 1;
                    sum += Convert.ToDouble(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDouble(txt_DonGiaNhap.Text));
                    if (bLL_NhapHang.KTKC_CTPNH(ct) == true)
                    {
                        // ///////////
                        txt_SoLuong_TextChanged(sender, e);
                        int sl = bLL_NhapHang.laysoluong_ctdathang(cbo_chitietPDNSX.SelectedValue.ToString());
                        int slc = Convert.ToInt32(bLL_NhapHang.load_SoLuong(cbo_chitietPDNSX.Text.ToString()));
                        if (Convert.ToInt32(txt_SoLuong.Text) <= (sl - slc))
                        {
                            text_socon.Text = txt_SoLuong.Text + "/" + sl.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Đã vượt mức đặt hàng");
                            return;
                        }

                        if (bLL_NhapHang.them_CTPNH(ct) == true)
                        {
                            mh.MAPN = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
                            txt_SoLuong.Text = bLL_NhapHang.load_SoLuong(cbo_chitietPDNSX.Text.ToString());
                            mh.SOLUONGMATHANG = f;
                            mh.TONGTIENHANGNHAP = Convert.ToDecimal(sum);

                            if (bLL_NhapHang.Sua_PNH(mh) == true)
                            {

                                dataGridView_nhaphang.DataSource = bLL_NhapHang.load_nhaphang();
                                dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang();
                                //MessageBox.Show("Thành công"); 

                                dataGridView_CTnhaphang.DataSource = bLL_NhapHang.load_CTnhaphang1(dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString());

                            }
                            else
                            {
                                MessageBox.Show("Xảy ra sự số");

                            }
                            ///// ////
                            //int sl1 = bLL_NhapHang.laysoluong_ctdathang(cbo_chitietPDNSX.SelectedValue.ToString());
                            //int slc1 = Convert.ToInt32(bLL_DatHangNSX.loasl1(cbo_chitietPDNSX.Text.ToString()));
                            //try
                            //{
                            //    PHIEUDATHANGNSX h = new PHIEUDATHANGNSX();
                            //    h.MAPDHNSX = cbo_maPNNSX.Text.ToString();
                            //    if (sl1 == slc1)
                            //    {
                            //        h.HOANTAT = true;
                            //    }
                            //    else
                            //        h.HOANTAT = false;
                            //    if (bLL_DatHangNSX.Sua_PDHNSX1(h)==true)
                            //    {
                            //        t = 1;
                            //        MessageBox.Show("tc");
                            //        cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX1();
                            //        cbo_maPNNSX.DisplayMember = "MAPDHNSX";
                            //        cbo_maPNNSX.ValueMember = "MAPDHNSX";
                            //        txt_SoLuong.Clear();
                            //    }
                            //}
                            //catch
                            //{
                            //    t = 0;
                            //    return;
                            //}

                            MessageBox.Show("Thành công");
                            t = 0;
                        }
                        else
                        {
                            MessageBox.Show("Thất bại");
                            t = 0;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã đã tồn tại");
                        t = 0;
                        return;
                    }
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
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

       

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (t == 0)
                {
                    if (bLL_NhapHang.laysoluong_ctdathang(cbo_chitietPDNSX.SelectedValue.ToString()) < Convert.ToInt32(txt_SoLuong.Text.ToString()))
                    {

                        MessageBox.Show("Số lượng hàng nhập đã quá số lượng đặt");
                        return;
                    }
                    else
                    {
                       
                    }
                }
                //for(int i=0;i<bLL_NhapHang.Gomnhom_CTPDH().Count;i++)
                //{
                //    MessageBox.Show(bLL_NhapHang.Gomnhom_CTPDH().Select(p=>p.mactod1).ToString());
                //}
            }
           catch
            {
                return;
            }
        }

        private void cbo_chitietPDNSX_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cbo_chitietPDNSX.SelectedValue!=null)
            {
                int sl = bLL_NhapHang.laysoluong_ctdathang(cbo_chitietPDNSX.SelectedValue.ToString());
                
                    text_socon.Text = bLL_NhapHang.load_SoLuong(cbo_chitietPDNSX.Text.ToString()) + "/" + sl.ToString();

               
            }
        }

        private void dataGridView_nhaphang_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_nhaphang.CurrentRow != null)
            {
                txt_PhieuNhap.Text = dataGridView_nhaphang.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void text_socon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_DonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
