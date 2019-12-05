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
    public partial class frm_DatHangNSX : UserControl
    {
        BLL_DatHangNSX bLL_DatHangNSX = new BLL_DatHangNSX();

        private String lay_dl;
        private String s;
        private Double sum = 0;
        private double tt = 0;

        public frm_DatHangNSX()
        {
            InitializeComponent();
        }
        /////// lấy dữ liệu 
        public string Lay_DL
        {
            get { return lay_dl; }
            set { lay_dl = value; }
        }

        private void groupBox_TTCTSanPham_Enter(object sender, EventArgs e)
        {

        }

        private void frm_DatHangNSX_Load(object sender, EventArgs e)
        {
            txt_MaPDNSX.Text = "DHNSX" + bLL_DatHangNSX.Sinh_MaCTDHNSX_dal();
            lbl_MaNV.Text = Lay_DL;
            cbo_LoaiMH.DataSource = bLL_DatHangNSX.load_loaiMatHang();
            cbo_LoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMH.DisplayMember = "TENLOAIMATHANG";

            dataGridView_DatHangNSX.DataSource = bLL_DatHangNSX.load_dathangnsx();
            dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX1();
            lbl_MaNV.Text = Properties.Settings.Default.user;
        }

        private void cbo_LoaiMH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_LoaiMH.SelectedValue.ToString() != String.Empty)
            {
                cbo_MaMH.DataSource= bLL_DatHangNSX.load_MatHang(cbo_LoaiMH.SelectedValue.ToString());
                cbo_MaMH.ValueMember = "MAMATHANG";
                cbo_MaMH.DisplayMember = "TENMATHANG";
            }
        }

        private void cbo_MaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_MaMH.Text.ToString() != String.Empty)
            {
                txt_DonGia.Text = bLL_DatHangNSX.Load_donGia(cbo_MaMH.SelectedValue.ToString());
                txt_DonViTinh.Text = bLL_DatHangNSX.Load_donvitinh(cbo_MaMH.SelectedValue.ToString());

                cbo_NhaSanXuat.DataSource = bLL_DatHangNSX.load_NSX(cbo_MaMH.SelectedValue.ToString());
                cbo_NhaSanXuat.ValueMember = "MANSX";
                cbo_NhaSanXuat.DisplayMember = "TENNSX";
                txt_TinhTrang.Text = bLL_DatHangNSX.Load_tinhtrang(cbo_MaMH.SelectedValue.ToString());
                if (txt_TinhTrang.Text != String.Empty)
                {
                    if (txt_TinhTrang.Text.Equals("hết hàng"))
                    {
                        lbl_SoLuong.Visible = txt_SoLuong.Visible = lbl_Ngaylap.Visible = dateTimePicker2.Visible = false;
                        lbl_TongTien.Visible = lbl_TienTraTruoc.Visible = lbl_TienConLai.Visible = false;
                        lbl_TongtienSo.Visible = lbl_TienTraTruocSo.Visible = lbl_TienConLaiSo.Visible = false;
                        lbl_VND.Visible=lbl_VNDD.Visible=lbl_VNDDD.Visible= false;
                    }
                    else
                    {
                        lbl_SoLuong.Visible = txt_SoLuong.Visible = lbl_Ngaylap.Visible = dateTimePicker2.Visible = true;
                        lbl_TongTien.Visible = lbl_TienTraTruoc.Visible = lbl_TienConLai.Visible = true;
                        lbl_TongtienSo.Visible = lbl_TienTraTruocSo.Visible = lbl_TienConLaiSo.Visible = true;
                        lbl_VND.Visible = lbl_VNDD.Visible = lbl_VNDDD.Visible = true;
                    }
                }

            }
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            PHIEUDATHANGNSX mh = new PHIEUDATHANGNSX();
            mh.MAPDHNSX = txt_MaPDNSX.Text;
            mh.MANV = "NV01";
            mh.MANSX = bLL_DatHangNSX.LAYMA(cbo_NhaSanXuat.Text.ToString());
            mh.NGAYLAP = Convert.ToDateTime(dateTimePicker2.Text);
            mh.TONGTIENHANGDAT = Convert.ToDecimal(tt);
            //chay ik
            mh.SOTIENTRATRUOC = 0;
            if (bLL_DatHangNSX.KTKC(mh) == true)
            {

                if (bLL_DatHangNSX.them_PDHNSX(mh) == true)
                {
                    MessageBox.Show("thanh cong");
                    dataGridView_DatHangNSX.DataSource = bLL_DatHangNSX.load_dathangnsx();
                }
                else
                {
                    MessageBox.Show("that bai");
                    return;
                }
            }
            else
            {
                CTPHIEUDATHANGNSX ct = new CTPHIEUDATHANGNSX();
                ct.MACTPHIEUDATHANG = "CTPDH" + bLL_DatHangNSX.Sinh_MaHoaDon_dal();
                ct.MAPDHNSX = dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString();
                ct.MAMATHANG = cbo_MaMH.SelectedValue.ToString();
                ct.SOLUONG = Convert.ToInt32(txt_SoLuong.Text);
                ct.THANHTIEN = Convert.ToDecimal(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDecimal(txt_DonGia.Text));

                sum =Convert.ToDouble(dataGridView_DatHangNSX.CurrentRow.Cells[4].Value.ToString())+ Convert.ToDouble(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDouble(txt_DonGia.Text));
                if (bLL_DatHangNSX.KTKC_ctCTPDHNSX(ct) == true)
                {
                    if (bLL_DatHangNSX.them_CTDHNSX(ct) == true)
                    {
                        mh.MAPDHNSX = dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString();
                        mh.TONGTIENHANGDAT = Convert.ToDecimal(sum);

                        if (bLL_DatHangNSX.Sua_PDHNSX(mh) == true)
                        {
                            //MessageBox.Show("Thành công");
                            dataGridView_DatHangNSX.DataSource = bLL_DatHangNSX.load_dathangnsx();
                            dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX1();
                            dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString());
                            lbl_TongtienSo.Text = dataGridView_DatHangNSX.CurrentRow.Cells[4].Value.ToString();
                        }
                        else
                        {
                            MessageBox.Show("xảy ra sự số");

                        }
                       // dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString());

                        MessageBox.Show("thanh cong");
                       // dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX1();
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
                //dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString());

            }
        }

        private void dataGridView_DatHangNSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(s);
        }

        private void dataGridView_DatHangNSX_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_MaPDNSX.Enabled =cbo_NhaSanXuat.Enabled= false;
            txt_MaPDNSX.Text = dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString();
            cbo_NhaSanXuat.Text = dataGridView_DatHangNSX.CurrentRow.Cells[2].Value.ToString();
            lbl_TongtienSo.Text = dataGridView_DatHangNSX.CurrentRow.Cells[4].Value.ToString();
            lbl_TienTraTruocSo.Text = dataGridView_DatHangNSX.CurrentRow.Cells[5].Value.ToString();
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            CTPHIEUDATHANGNSX ct = new CTPHIEUDATHANGNSX();
            ct.MACTPHIEUDATHANG = dataGridView_CTDatHangNSX.CurrentRow.Cells[0].Value.ToString();
            ct.MAMATHANG = cbo_MaMH.SelectedValue.ToString();
            ct.SOLUONG = Convert.ToInt32(txt_SoLuong.Text);
            if (bLL_DatHangNSX.Sua_CTDHNSX(ct) == true)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("that bai");
                // return;
            }
            dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString());

        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaPDNSX.Enabled =  true;
            txt_MaPDNSX.Text = "DHNSX" + bLL_DatHangNSX.Sinh_MaCTDHNSX_dal();
            cbo_LoaiMH.DataSource = bLL_DatHangNSX.load_loaiMatHang();
            cbo_LoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMH.DisplayMember = "TENLOAIMATHANG";
            txt_SoLuong.Clear();
        }

        private void dataGridView_CTDatHangNSX_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_MaPDNSX.Enabled = cbo_NhaSanXuat.Enabled = false;
            txt_MaPDNSX.Text = dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString();
            cbo_NhaSanXuat.Text = dataGridView_DatHangNSX.CurrentRow.Cells[2].Value.ToString();

            cbo_MaMH.Text = dataGridView_CTDatHangNSX.CurrentRow.Cells[1].Value.ToString();
            txt_SoLuong.Text = dataGridView_CTDatHangNSX.CurrentRow.Cells[2].Value.ToString();
            txt_DonGia.Text = dataGridView_CTDatHangNSX.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            CTPHIEUDATHANGNSX ct = new CTPHIEUDATHANGNSX();
            if (MessageBox.Show("Ban muon xoa khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            ct.MACTPHIEUDATHANG = dataGridView_CTDatHangNSX.CurrentRow.Cells[0].Value.ToString();
            //ct.MAMATHANG = dataGridView_CTDatHangNSX.CurrentRow.Cells[1].Value.ToString();
            ct.SOLUONG = Convert.ToInt32(dataGridView_CTDatHangNSX.CurrentRow.Cells[2].Value.ToString());
            ct.GIA = Convert.ToDecimal(dataGridView_CTDatHangNSX.CurrentRow.Cells[3].Value.ToString());
            ct.THANHTIEN = Convert.ToDecimal(dataGridView_CTDatHangNSX.CurrentRow.Cells[4].Value.ToString());
            if (bLL_DatHangNSX.Xoa_CTDHNSX(ct) == true)
            {
                MessageBox.Show("thanh cong");
                dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX(dataGridView_DatHangNSX.CurrentRow.Cells[0].Value.ToString());
                
                //dataGridView_CTDatHangNSX.DataSource = bLL_DatHangNSX.load_CTDHNSX1();
               
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
        }
    }
}
