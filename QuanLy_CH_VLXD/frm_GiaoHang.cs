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
                txt_SoLuong.Text = bLL_GiaoHang.load_SoLuong(cbo_CTHoaDon.SelectedValue.ToString());
                txt_DonGia.Text = bLL_GiaoHang.Load_dongia(cbo_CTHoaDon.SelectedValue.ToString());


            }
        }

        private void dataGridView_GiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(s);
        }

        private void btn_them_Click(object sender, EventArgs e)
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
                    MessageBox.Show("thanh cong");
                    dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                    dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();

                }
                else
                {
                    MessageBox.Show("that bai");
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
                {
                    if (bLL_GiaoHang.Them_CTGiaoHang(ct) == true)
                    {
                        
                        mh.MAGIAOHANG = dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString();
                        mh.SOLUONGGIAO = f;
                        mh.TONGTIENHANGGIAO = Convert.ToDecimal(sum);
                        //-----------------------------------------------sai
                        int sl = bLL_GiaoHang.laysoluong(ma);
                        if (Convert.ToInt32(txt_SoLuong.Text) <= sl)
                        {
                            txt_SoHangGiao.Text = txt_SoLuong.Text + "/" + sl.ToString();
                        }
                        else
                        {
                            MessageBox.Show("đã vượt mức đặt hàng");
                        }
                        if (bLL_GiaoHang.Sua_GH(mh) == true)
                        {

                            dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
                            //MessageBox.Show("Thành công"); 

                            dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString());

                        }
                        else
                        {
                            MessageBox.Show("xảy ra sự số");

                        }

                        MessageBox.Show("thanh cong");
                        dataGridView_GiaoHang.DataSource = bLL_GiaoHang.load_giaophang();
                        //dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang();
                        //MessageBox.Show("Thành công"); 

                        dataGridView_CTGiaoHang.DataSource = bLL_GiaoHang.load_CTgiaohang1(dataGridView_GiaoHang.CurrentRow.Cells[0].Value.ToString());

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
    }
}
