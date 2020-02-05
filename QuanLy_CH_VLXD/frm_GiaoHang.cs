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
        private String s;
        private String a;
        private int f;
        private Double sum = 0;

        BLL_GiaoHang bLL_GiaoHang = new BLL_GiaoHang();
        BLL_BanHang bLL_BanHang = new BLL_BanHang();

        public frm_GiaoHang()
        {
            InitializeComponent();
        }

        private void frm_GiaoHang_Load(object sender, EventArgs e)
        {
            txt_MaGiaoHang.Text = "GH" + bLL_GiaoHang.Sinh_MaHoaDon_dal();
            cbo_NVGiaoHang.DataSource = bLL_GiaoHang.load_MaMV();
            cbo_NVGiaoHang.ValueMember = "MANV";
            cbo_NVGiaoHang.DisplayMember = "MANV";

            cbo_HDB.DataSource = bLL_GiaoHang.load_HDB();
            cbo_HDB.ValueMember = "MAHDB";
            cbo_HDB.DisplayMember = "MAHDB";

            dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
            lbl_Manv.Text = Properties.Settings.Default.user;

            
           
        }

        private void txt_SDT_KeyPress(object sender, KeyEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_HDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_HDB.Text.ToString() != String.Empty)
            {
                cbo_CTHoaDon.DataSource = bLL_GiaoHang.load_CTHDB1(cbo_HDB.SelectedValue.ToString());
                cbo_CTHoaDon.ValueMember = "MACTHDB";
                cbo_CTHoaDon.DisplayMember = "MACTHDB";

             

            }


        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void cbo_CTHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_CTHoaDon.Text.ToString() != String.Empty)
            {
                txt_TenMH.Text = bLL_GiaoHang.load_MatHang(cbo_CTHoaDon.SelectedValue.ToString());
                txt_TenLoaiMH.Text = bLL_GiaoHang.load_loaiMatHang(cbo_CTHoaDon.SelectedValue.ToString());
                //txt_SoLuong.Text = bLL_GiaoHang.load_SoLuong(cbo_CTHoaDon.SelectedValue.ToString());
                txt_DonGia.Text = bLL_GiaoHang.Load_dongia(cbo_CTHoaDon.SelectedValue.ToString());

                int sl = bLL_GiaoHang.laysoluong_ctdathang2(cbo_CTHoaDon.Text.ToString());

                txt_SoHangGiao.Text = bLL_GiaoHang.load_SoLuong2(cbo_CTHoaDon.Text.ToString()) + "/" + sl.ToString();

            }
        }

        private void dataGridView_GiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
           
            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(s);

            //binding
            if (dataGridView_GiaoHang.CurrentRow != null)
            {
                txt_MaGiaoHang.Text = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
                cbo_NVGiaoHang.Text = dataGridView_GiaoHang.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_SoLuong.Text.Length > 0 && cbo_CTHoaDon.SelectedValue != null)
            {
                GIAOHANG mh = new GIAOHANG();
                mh.MAGIAOHANG = txt_MaGiaoHang.Text;
                mh.MANVGIAOHANG = cbo_NVGiaoHang.Text;
                mh.NGAYGIOGIAOHANG = DateTime.Parse(dateTimePicker2.Text);
                mh.SOLUONGGIAO = Convert.ToInt32(txt_SoLuong.Text);
                mh.TONGTIENHANGGIAO = 0;
                mh.TINHTRANG = null;
                if (bLL_GiaoHang.Ktkc(mh) == true)
                {

                    if (bLL_GiaoHang.Them_GiaoHang(mh) == true)
                    {
                        MessageBox.Show("Thành công");
                        dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                        dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();

                    }
                    else
                    {
                        MessageBox.Show("Thất bại");
                        return;
                    }
                }
                else
                {
                    CHITIETGIAOHANG ct = new CHITIETGIAOHANG();
                    ct.MACTGIAOHNAG = "CTGH" + bLL_GiaoHang.Sinh_MaHoaDon_dal();
                    String ma = "CTGH" + bLL_GiaoHang.Sinh_MaHoaDon_dal();
                    ct.MAGIAOHANG = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
                    ct.MACTHDB = cbo_CTHoaDon.SelectedValue.ToString();
                    ct.SOLUONGMH = Convert.ToInt32(txt_SoLuong.Text);
                    ct.THANHTIEN = Convert.ToDecimal(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDecimal(txt_DonGia.Text));

                    f += 1;
                    sum += Convert.ToDouble(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDouble(txt_DonGia.Text));
                    if (bLL_GiaoHang.Ktkc_ctpnh(ct) == true)
                    {   //////////////
                        txt_SoLuong_TextChanged(sender, e);
                        int sl = bLL_GiaoHang.laysoluong_ctdathang1(cbo_CTHoaDon.SelectedValue.ToString());
                        int slc = Convert.ToInt32(bLL_GiaoHang.load_SoLuong2(cbo_CTHoaDon.Text.ToString()));
                        if (Convert.ToInt32(txt_SoLuong.Text) <= (sl-slc))
                        {
                            txt_SoHangGiao.Text = txt_SoLuong.Text + "/" + sl.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Đã vượt mức đặt hàng");
                            return;
                        }
                        if (bLL_GiaoHang.Them_CTGiaoHang(ct) == true)
                        {

                            mh.MAGIAOHANG = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
                            mh.SOLUONGGIAO = f;
                            mh.TONGTIENHANGGIAO = Convert.ToDecimal(sum);

                            if (bLL_GiaoHang.Sua_GH(mh) == true)
                            {

                                dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                                dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
                                //MessageBox.Show("Thành công"); 

                                dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString());

                            }
                            else
                            {
                                MessageBox.Show("Xảy ra sự số");

                            }
                            // /////
                            //int sl1 = bLL_GiaoHang.laysoluong_ctdathang(cbo_CTHoaDon.SelectedValue.ToString());
                            //int slc1 = Convert.ToInt32(bLL_BanHang.loasl1(cbo_CTHoaDon.Text.ToString()));
                            //if (sl1 == slc1)
                            //{
                            //    //HOADONBAN h = new HOADONBAN();
                            //    //h.MAHDB = cbo_HDB.Text.ToString();
                            //    //h.HOANTAT = true;
                            //    //if (bLL_BanHang.Sua_HDB(h) == true)
                            //    //{
                            //    //    MessageBox.Show("tc");
                            //    //    cbo_maPNNSX.DataSource = bLL_NhapHang.load_maPNHNSX1();
                            //    //    cbo_maPNNSX.DisplayMember = "MAPDHNSX";
                            //    //    cbo_maPNNSX.ValueMember = "MAPDHNSX";
                            //    //}
                            //}
                            MessageBox.Show("Thành công");
                            dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                            //dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
                            //MessageBox.Show("Thành công"); 

                            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString());

                        }
                        else
                        {
                            MessageBox.Show("Thất bại");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã đã tồn tại");
                        return;
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập số lượng");
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaGiaoHang.Text = "GH" + bLL_GiaoHang.Sinh_MaHoaDon_dal();
            cbo_NVGiaoHang.DataSource = bLL_GiaoHang.load_MaMV();
            cbo_NVGiaoHang.ValueMember = "MANV";
            cbo_NVGiaoHang.DisplayMember = "MANV";

            cbo_HDB.DataSource = bLL_GiaoHang.load_HDB();
            cbo_HDB.ValueMember = "MAHDB";
            cbo_HDB.DisplayMember = "MAHDB";

            txt_TenLoaiMH.Clear();
            txt_TenMH.Clear();
            txt_SoLuong.Clear();
            txt_DonGia.Clear();

        }

        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (bLL_GiaoHang.laysoluong_ctdathang1(cbo_CTHoaDon.SelectedValue.ToString()) < Convert.ToInt32(txt_SoLuong.Text.ToString()))
                {
                    txt_SoLuong.Clear();
                    MessageBox.Show("Số lượng hàng nhập đã quá số lượng đặt");
                    return;
                }
                else
                {

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

        private void lbl_Manv_Click(object sender, EventArgs e)
        {

        }

        private void txt_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_SoHangGiao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
