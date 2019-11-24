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
    public partial class frm_BanHang : UserControl
    {
        BLL_BanHang bll_BanHang = new BLL_BanHang();

        private String lay_dl;


        public frm_BanHang()
        {
            InitializeComponent();
        }

        private void frm_BanHang_Load(object sender, EventArgs e)
        {
            txt_MaHDB.Text ="HDB"+ bll_BanHang.Sinh_MaHoaDon_dal();
            cbo_LoaiMatHang.DataSource = bll_BanHang.load_loaiMatHang();
            cbo_LoaiMatHang.ValueMember = "MALOAIMATHANG";
            cbo_LoaiMatHang.DisplayMember = "TENLOAIMATHANG";

            dataGridView_HoaDonBan.DataSource = bll_BanHang.load_HDB();
            dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB();
            dataGridView1.DataSource= bll_BanHang.load_HDB(); 
            lbl_Manv.Text = Lay_DL;

           

        }
        
        private void groupBox_TTCTSanPham_Enter(object sender, EventArgs e)
        {

        }


        private void txt_SDT_KeyDown(object sender, KeyEventArgs e)
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
                    txt_Tenkh.Text = bll_BanHang.XemTenKhachHang_dal(txt_SDT.Text.ToString());
                    if (txt_Tenkh.Text == String.Empty)
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
                }

            }
        }

        // lấy dữ liệu 
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

        private void dataGridView_HoaDonBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_HoaDonBan.CurrentRow.Cells[2].Value.ToString();
        }
        
        private void btn_Them_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView_HoaDonBan.ColumnCount.ToString());
            //dataGridView_HoaDonBan.AllowUserToAddRows = false;
            DataGridViewRow dt = (DataGridViewRow)dataGridView_HoaDonBan.Rows[0].Clone();

            dt.Cells[2].Value = txt_MaHDB.Text;
            dt.Cells[3].Value = lbl_Manv.Text;
            dt.Cells[0].Value = txt_Tenkh.Text;
            dt.Cells[1].Value = "113";
            //dt.Cells[5].Value = "10/10/2010";
            dt.Cells[6].Value = "19";
            //dt.Cells[7].Value = lbl_Tongtien.Text;
            dataGridView_HoaDonBan.Rows.Add(dt);


            dataGridView_HoaDonBan.DataSource = dt;


        }
    }
}
