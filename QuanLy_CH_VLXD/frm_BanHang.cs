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
using System.Text.RegularExpressions;

namespace QuanLy_CH_VLXD
{
    public partial class frm_BanHang : UserControl
    {
        BLL_BanHang bll_BanHang = new BLL_BanHang();
        private String abc;
        private String lay_dl;
        private String s, s2;
        private int tlsp = 0, k=0;
        private double tt=0;
        private int f = 0;
        private Double sum = 0;

        public frm_BanHang()
        {
            InitializeComponent();
        }

        List<BangGhep_HoaDonBan> lst;
        List<CHITIET_HOADON> lsb;
        private void frm_BanHang_Load(object sender, EventArgs e)
        {
            txt_MaHDB.Text ="HDB"+ bll_BanHang.Sinh_MaHoaDon_dal();
            cbo_LoaiMatHang.DataSource = bll_BanHang.load_loaiMatHang();
            cbo_LoaiMatHang.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMatHang.DisplayMember = "TENLOAIMATHANG";
            lst=bll_BanHang.load_HDB();
            lsb = bll_BanHang.load_CTHDB();
            dataGridView_HDB.DataSource= bll_BanHang.load_HDB();
            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB(); 
            lbl_Manv.Text = Properties.Settings.Default.user;
            k = 0;
        }
        
        private void groupBox_TTCTSanPham_Enter(object sender, EventArgs e)
        {

        }


        private void txt_SDT_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cbo_LoaiMatHang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_LoaiMatHang.SelectedValue.ToString() != String.Empty)
            {
                cbo_TenMatHang.DataSource = bll_BanHang.load_MatHang(cbo_LoaiMatHang.SelectedValue.ToString());
                cbo_TenMatHang.ValueMember = "MAMATHANG";
                cbo_TenMatHang.DisplayMember = "TENMATHANG";
            }
        }

       

        private void cbo_TenMatHang_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbo_TenMatHang.Text.ToString() != String.Empty)
            {
                txt_DonGia.Text = bll_BanHang.Load_dongia(cbo_TenMatHang.SelectedValue.ToString());
                txt_DonViTinh.Text = bll_BanHang.Load_donvitinh(cbo_TenMatHang.SelectedValue.ToString());

                cbo_NSX.DataSource = bll_BanHang.load_NSX(cbo_TenMatHang.SelectedValue.ToString());
                cbo_NSX.ValueMember = "MANSX";
                cbo_NSX.DisplayMember = "TENNSX";
                txt_TinhTrang.Text = bll_BanHang.Load_TinhtrangMH(cbo_TenMatHang.SelectedValue.ToString());
                if(txt_TinhTrang.Text != String.Empty)
                {
                    if(txt_TinhTrang.Text.Equals("hết hàng"))
                    {
                        lbl_SoLuong.Visible = lbl_NgayLap.Visible = lbl_tTien.Visible =lbl_vnd.Visible=lbl_Tongtien.Visible=txt_SoLuong.Visible= dateTimePicker2 .Visible= false;
                    }
                    else
                    {
                        lbl_SoLuong.Visible = lbl_NgayLap.Visible = lbl_tTien.Visible = lbl_vnd.Visible = lbl_Tongtien.Visible = txt_SoLuong.Visible = dateTimePicker2.Visible = true;

                    }
                }

            }
        }

        /////// lấy dữ liệu 
        public string Lay_DL
        {
            get { return lay_dl; }
            set { lay_dl = value; }
        }

        private void cbo_TenMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_TenMatHang_TextChanged(object sender, EventArgs e)
        {
        }



        private void btn_Them_Click(object sender, EventArgs e)
        {
           
            HOADONBAN mh = new HOADONBAN();
            mh.MAHDB = txt_MaHDB.Text;
            mh.MANV = lbl_Manv.Text;
            mh.MAKH =bll_BanHang.LAYMA(txt_SDT.Text.ToString());
            mh.NGAYLAP =Convert.ToDateTime (dateTimePicker2.Text);
            mh.TONGSLSANPHAM = 0;
            mh.TONGTIEN = Convert.ToDecimal(tt);          
            if (bll_BanHang.KTKC(mh) == true)
            {

                if (bll_BanHang.them_HDB(mh) == true)
                {
                    MessageBox.Show("thanh cong");
                    dataGridView_HDB.DataSource = bll_BanHang.load_HDB();
                    dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB();
                    
                }
                else
                {
                    MessageBox.Show("that bai");
                    return;
                }
            }
            else
            {
                CHITIETHOADONBAN ct = new CHITIETHOADONBAN();
                ct.MACTHDB = "CTHDB" + bll_BanHang.Sinh_MaHoaDon_dal();
                ct.MAHDB = dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
                ct.MAMATHANG = cbo_TenMatHang.SelectedValue.ToString();
                ct.SOLUONGBAN = Convert.ToInt32(txt_SoLuong.Text);
                ct.THANHTIEN = Convert.ToDecimal(Convert.ToInt32(txt_SoLuong.Text)*Convert.ToDecimal(txt_DonGia.Text));
                f += 1;
                sum += Convert.ToDouble(Convert.ToInt32(txt_SoLuong.Text) * Convert.ToDouble(txt_DonGia.Text));
                if (bll_BanHang.KTKC_cthdb(ct) == true)
                {
                    if (bll_BanHang.them_CTHDB(ct) == true)
                    {
                        mh.MAHDB = dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
                        mh.TONGSLSANPHAM = f;
                        mh.TONGTIEN = Convert.ToDecimal(sum);

                        if (bll_BanHang.Sua_HDB(mh) == true)
                        {

                            dataGridView_HDB.DataSource = bll_BanHang.load_HDB();
                            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB();
                            //MessageBox.Show("Thành công"); 
                            
                            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(dataGridView_HDB.CurrentRow.Cells[0].Value.ToString());
                            lbl_Tongtien.Text = dataGridView_HDB.CurrentRow.Cells[6].Value.ToString();
                        }
                        else
                        {
                            MessageBox.Show("xảy ra sự số");
                            // return;

                        }
                       // dataGridView_HDB.DataSource = bll_BanHang.load_HDB();
                        //dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(dataGridView_HDB.CurrentRow.Cells[0].Value.ToString());
                        MessageBox.Show("thanh cong");
                    }
                    else
                    {
                        MessageBox.Show("that bai");
                       // dataGridView_HDB.DataSource = bll_BanHang.load_HDB();
                       // dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(dataGridView_HDB.CurrentRow.Cells[0].Value.ToString());
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
         
        private void dataGridView_HDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            s=dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(s);
        }

        private void txt_SDT_TextChanged(object sender, EventArgs e)
        {
            abc = txt_SDT.Text;
                if (txt_SDT.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    if (abc.Length >= 10)
                    {
                        txt_Tenkh.Text = bll_BanHang.XemTenKhachHang_dal(txt_SDT.Text.ToString());
                        if (txt_Tenkh.Text == String.Empty)
                        {
                            MessageBox.Show("Thêm khách hàng mới");
                            return;
                        }
                        txt_SDT.Text.ToString().Trim();
                    }
                    else
                    {
                        return;
                    }
                }
        }

        private void dataGridView_HDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            s = dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
            dataGridView_HDB.DataSource = bll_BanHang.load_CTHDB1(s);
        }

        private void dataGridView_HDB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_MaHDB.Enabled = txt_SDT.Enabled = txt_Tenkh.Enabled = false;
            txt_MaHDB.Text = dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
            txt_SDT.Text = dataGridView_HDB.CurrentRow.Cells[2].Value.ToString();
            txt_Tenkh.Text = dataGridView_HDB.CurrentRow.Cells[3].Value.ToString();
            lbl_Tongtien.Text = dataGridView_HDB.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView_CTHoaDonBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txt_MaHDB.Enabled = txt_SDT.Enabled = txt_Tenkh.Enabled = false;
            txt_MaHDB.Text = dataGridView_HDB.CurrentRow.Cells[0].Value.ToString();
            txt_SDT.Text = dataGridView_HDB.CurrentRow.Cells[2].Value.ToString();
            txt_Tenkh.Text = dataGridView_HDB.CurrentRow.Cells[3].Value.ToString();
            
            cbo_TenMatHang.Text = dataGridView_CTHoaDonBan.CurrentRow.Cells[1].Value.ToString();
            txt_SoLuong.Text = dataGridView_CTHoaDonBan.CurrentRow.Cells[2].Value.ToString();
            txt_DonGia.Text = dataGridView_CTHoaDonBan.CurrentRow.Cells[3].Value.ToString();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            CHITIETHOADONBAN ct = new CHITIETHOADONBAN();
            ct.MACTHDB = dataGridView_CTHoaDonBan.CurrentRow.Cells[0].Value.ToString();
            ct.MAMATHANG = cbo_TenMatHang.SelectedValue.ToString();
            ct.SOLUONGBAN =Convert.ToInt32( txt_SoLuong.Text);
            if (  bll_BanHang.Sua_CTHDB(ct)==true)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("that bai");
                   // return;
            }
            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(dataGridView_HDB.CurrentRow.Cells[0].Value.ToString());
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txt_MaHDB.Enabled = txt_SDT.Enabled = txt_Tenkh.Enabled = true;
            txt_MaHDB.Text = "HDB" + bll_BanHang.Sinh_MaHoaDon_dal();
            cbo_LoaiMatHang.DataSource = bll_BanHang.load_loaiMatHang();
            cbo_LoaiMatHang.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMatHang.DisplayMember = "TENLOAIMATHANG";
            txt_SoLuong.Clear();
            txt_SDT.Clear();
            txt_Tenkh.Clear();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            CHITIETHOADONBAN ct = new CHITIETHOADONBAN();
            if (MessageBox.Show("Ban muon xoa khong?", "Thong bao", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            ct.MACTHDB = dataGridView_CTHoaDonBan.CurrentRow.Cells[0].Value.ToString();
            //ct.MAMATHANG = dataGridView_CTHoaDonBan.CurrentRow.Cells[1].Value.ToString();
             ct.SOLUONGBAN = Convert.ToInt32(dataGridView_CTHoaDonBan.CurrentRow.Cells[2].Value.ToString());
             ct.THANHTIEN = Convert.ToDecimal(dataGridView_CTHoaDonBan.CurrentRow.Cells[4].Value.ToString());
            if (bll_BanHang.Xoa_CTHDB(ct) == true)
            {
                MessageBox.Show("thanh cong");
                dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB1(dataGridView_HDB.CurrentRow.Cells[0].Value.ToString());
               
               
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
            
        }

        private void btn_themKH_Click(object sender, EventArgs e)
        {
            frm_TTKhachHang frm = new frm_TTKhachHang();
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView_HDB_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
