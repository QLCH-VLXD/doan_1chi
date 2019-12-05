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
    public partial class frm_TTKhachHang : UserControl
    {
        BLL_TTKhachHang bll_TTKhachHang = new BLL_TTKhachHang();

        public frm_TTKhachHang()
        {
            InitializeComponent();
        }

        private void frm_TTKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView_LoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
            txtMaLoaiKH.Text = "LKH" + bll_TTKhachHang.Sinh_MaLoaiKH_dal();

            txtMaKH.Text = "KH" + bll_TTKhachHang.Sinh_MaLoaiKH_dal();
            cboLoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
            cboLoaiKH.ValueMember = "MALOAIKH";
            cboLoaiKH.DisplayMember = "TENLOAIKH";

            datagird_KhachHang.DataSource = bll_TTKhachHang.LoadDL_khachhang();
        }
       

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //if (dataGridView2.SelectedRows != null)
            //{
            //    //MessageBox.Show("sdsd");
            //    txtMaLoaiKH.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //    txtLoaiKH.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            //}
        }

        private void btnThem_TTKH_Click(object sender, EventArgs e)
        {
            KHACHHANG mh = new KHACHHANG();
            mh.MAKH = txtMaKH.Text;
            mh.MALOAIKH = cboLoaiKH.SelectedValue.ToString();
            mh.HOTENKH = txtTenKH.Text;
            mh.SDT = txtSDT.Text;
            mh.DIACHI = txtDiaChi.Text;
            if (bll_TTKhachHang.KTKC_kh(mh) == true)
            {
                bll_TTKhachHang.them_kh(mh);
                MessageBox.Show("thanh cong");
                datagird_KhachHang.DataSource = bll_TTKhachHang.LoadDL_khachhang();
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            KHACHHANG mh = new KHACHHANG();
            mh.MAKH = txtMaKH.Text;
            mh.MALOAIKH = cboLoaiKH.SelectedValue.ToString();
            mh.HOTENKH = txtTenKH.Text;
            mh.SDT = txtSDT.Text;
            mh.DIACHI = txtDiaChi.Text;
            if (bll_TTKhachHang.sua_kh(mh) == true)
            {
                datagird_KhachHang.DataSource = bll_TTKhachHang.LoadDL_khachhang();
                MessageBox.Show("thanh cong");
                
                
            }
            else
            {
                MessageBox.Show("that bai");
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KHACHHANG mh = new KHACHHANG();
            mh.MAKH = datagird_KhachHang.CurrentRow.Cells[0].Value.ToString();
            mh.MALOAIKH = datagird_KhachHang.CurrentRow.Cells[1].Value.ToString();
            mh.HOTENKH = datagird_KhachHang.CurrentRow.Cells[2].Value.ToString();
            mh.SDT = datagird_KhachHang.CurrentRow.Cells[3].Value.ToString();
            mh.DIACHI = datagird_KhachHang.CurrentRow.Cells[4].Value.ToString();
            if (bll_TTKhachHang.KTKC_kh(mh) == false)
            {
                bll_TTKhachHang.xoa_kh(mh);
                MessageBox.Show("thanh cong");
                datagird_KhachHang.DataSource = bll_TTKhachHang.LoadDL_khachhang();
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
        }

        private void btnThem_LoaiKH_Click(object sender, EventArgs e)
        {
            LOAIKHACHHANG mh = new LOAIKHACHHANG();
            mh.MALOAIKH = txtMaLoaiKH.Text;
            mh.TENLOAIKH = txtLoaiKH.Text;
            if (bll_TTKhachHang.KTKC(mh) == true)
            {
                bll_TTKhachHang.them_loaikh(mh);
                MessageBox.Show("thanh cong");
                dataGridView_LoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
        }
        private void btnSua_LoaiKH_Click(object sender, EventArgs e)
        {
            LOAIKHACHHANG mh = new LOAIKHACHHANG();
            mh.MALOAIKH = txtMaLoaiKH.Text;
            mh.TENLOAIKH = txtLoaiKH.Text;
            if (bll_TTKhachHang.sua_loaikh(mh) == true)
            {
                MessageBox.Show("thanh cong");
                dataGridView_LoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
            }
            else
            {
                MessageBox.Show("that bai");
            }
        }
        private void btnXoa_LoaiKH_Click(object sender, EventArgs e)
        {
            LOAIKHACHHANG mh = new LOAIKHACHHANG();
            mh.MALOAIKH = dataGridView_LoaiKH.CurrentRow.Cells[0].Value.ToString();
            mh.TENLOAIKH = dataGridView_LoaiKH.CurrentRow.Cells[1].Value.ToString();
            if (bll_TTKhachHang.KTKC(mh) == false)
            {
                bll_TTKhachHang.xoa_loaikh(mh);
                MessageBox.Show("thanh cong");
                dataGridView_LoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
            }
            else
            {
                MessageBox.Show("that bai");
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKH.Text = datagird_KhachHang.CurrentRow.Cells[0].Value.ToString();
                cboLoaiKH.Text = datagird_KhachHang.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = datagird_KhachHang.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = datagird_KhachHang.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = datagird_KhachHang.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void btn_LamMoiLKH_Click(object sender, EventArgs e)
        {
            txtMaLoaiKH.Clear();
            txtLoaiKH.Clear();
            txtMaLoaiKH.Text = "LKH" + bll_TTKhachHang.Sinh_MaLoaiKH_dal();
        }

        private void btn_LamMoiKH_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMaKH.Text = "KH" + bll_TTKhachHang.Sinh_MaLoaiKH_dal();

        }

        private void dataGridView_LoaiKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaLoaiKH.Text = dataGridView_LoaiKH.CurrentRow.Cells[0].Value.ToString();
            txtLoaiKH.Text = dataGridView_LoaiKH.CurrentRow.Cells[1].Value.ToString();
        }

        private void LoadDL_khachhang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtMaKH.Text = datagird_KhachHang.CurrentRow.Cells[0].Value.ToString();
            cboLoaiKH.Text = datagird_KhachHang.CurrentRow.Cells[1].Value.ToString();
            txtTenKH.Text = datagird_KhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = datagird_KhachHang.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = datagird_KhachHang.CurrentRow.Cells[4].Value.ToString();
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
