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
        string a;
        string b;

        public frm_TTKhachHang()
        {
            InitializeComponent();
        }

        private void frm_TTKhachHang_Load(object sender, EventArgs e)
        {
            txtMaLoaiKH.Text ="LKH" + bll_TTKhachHang.Sinh_Makh_dal();
            txtMaKH.Text ="KH"  + bll_TTKhachHang.Sinh_Makh_dal();
            a = txtMaLoaiKH.Text;
            b = txtMaKH.Text;
           // label1.Text = Properties.Settings.Default.user;
            showDataGridView();
        }

        public void showDataGridView()
        {
            bll_TTKhachHang = new BLL_TTKhachHang();
            datagird_KhachHang.DataSource = bll_TTKhachHang.load_TTKhachHang();
            dataGridView_LoaiKH.DataSource = bll_TTKhachHang.load_LoaiKhachHang();
        }

        private void btn_LamMoiLKH_Click(object sender, EventArgs e)
        {
            txtMaLoaiKH.Text = "LKH" + bll_TTKhachHang.Sinh_Makh_dal();
            txtLoaiKH.Clear();
        }

        private void btn_LamMoiKH_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "KH" + bll_TTKhachHang.Sinh_Makh_dal();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void txtLoaiKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_LoaiKH_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_LoaiKH.SelectedRows != null)
            {
                //MessageBox.Show("sdsd");
                txtMaLoaiKH.Text = dataGridView_LoaiKH.CurrentRow.Cells[0].Value.ToString();
                txtLoaiKH.Text = dataGridView_LoaiKH.CurrentRow.Cells[1].Value.ToString();

            }
        }

        private void btnThem_TTKH_Click(object sender, EventArgs e)
        {
            Them();
        }
        public void Them()
        {
            if (txtMaKH.Text.Length > 0 && txtTenKH.Text.Length > 0 && txtMaLoaiKH.Text.Length > 0 && txtSDT.Text.Length > 0 && txtDiaChi.Text.Length > 0)
            {
                BLL_TTKhachHang service = new BLL_TTKhachHang();
                KHACHHANG kh = new KHACHHANG();

                kh.MAKH = b;
                kh.HOTENKH = txtTenKH.Text;
                kh.MALOAIKH = cboLoaiKH.Text;
                kh.SDT = txtSDT.Text;
                kh.DIACHI = txtDiaChi.Text;


                int result = 0;
                result = service.them_dal(kh);
                if (result == 2)
                {
                    MessageBox.Show("Đã tồn tại", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }

                showDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ dữ liệu");
            }
        }
        private void btnSua_TTKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length > 0 && txtTenKH.Text.Length > 0 && txtMaLoaiKH.Text.Length > 0 && txtSDT.Text.Length > 0 && txtDiaChi.Text.Length > 0)
            {

                BLL_TTKhachHang service = new BLL_TTKhachHang();
                KHACHHANG kh = new KHACHHANG();

                kh.MAKH = txtMaKH.Text;
                kh.HOTENKH = txtTenKH.Text;
                kh.MALOAIKH = cboLoaiKH.Text;
                kh.SDT = txtSDT.Text;
                kh.DIACHI = txtDiaChi.Text;
                int result = 0;

                result = service.Sua_dal(kh);

                if (result == 1)
                {
                    MessageBox.Show("Thành Công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Inofity");
                }



                showDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ dữ liệu");
            }
        }

        private void btnXoa_TTKH_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        public void Xoa()
        {
            if (txtMaKH.Text.Length > 0 && txtTenKH.Text.Length > 0 && txtMaLoaiKH.Text.Length > 0 && txtSDT.Text.Length > 0 && txtDiaChi.Text.Length > 0)
            {
                BLL_TTKhachHang service = new BLL_TTKhachHang();
                KHACHHANG kh = new KHACHHANG();

                kh.MAKH = txtMaKH.Text;
                kh.HOTENKH = txtTenKH.Text;
                kh.MALOAIKH = cboLoaiKH.Text;
                kh.SDT = txtSDT.Text;
                kh.DIACHI = txtDiaChi.Text;

                int result = -1;

                result = service.Xoa_dal(kh);

                if (result == 0)
                {
                    MessageBox.Show("Thành Công", "Thông báo");
                }
                else if (result == 2)
                {
                    MessageBox.Show("Không tìm thấy khóa", "Thông báo");
                }


                showDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ dữ liệu");
            }
        }

        private void btnThem_LoaiKH_Click(object sender, EventArgs e)
        {
            ThemLoaiKH();
        }
        public void ThemLoaiKH()
        {
            BLL_TTKhachHang service = new BLL_TTKhachHang();
            LOAIKHACHHANG lkh = new LOAIKHACHHANG();
            if (txtLoaiKH.Text.Length > 0)
            {
                lkh.MALOAIKH = a;
                lkh.TENLOAIKH = txtLoaiKH.Text;


                int result = 0;
                result = service.themloaiKH_dal(lkh);
                if (result == 2)
                {
                    MessageBox.Show("Đã tồn tại", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập loại khách hàng");

            showDataGridView();
        }

        private void btnSua_LoaiKH_Click(object sender, EventArgs e)
        {
            BLL_TTKhachHang service = new BLL_TTKhachHang();
            LOAIKHACHHANG lkh = new LOAIKHACHHANG();


            lkh.MALOAIKH = txtMaLoaiKH.Text;
            lkh.TENLOAIKH = txtLoaiKH.Text;

            int result = 0;

            result = service.SualoaiKH_dal(lkh);

            if (result == 1)
            {
                MessageBox.Show("Thành Công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Inofity");
            }



            showDataGridView();
        }

        private void btnXoa_LoaiKH_Click(object sender, EventArgs e)
        {
            XoaloaiKH();
        }
        public void XoaloaiKH()
        {
            BLL_TTKhachHang service = new BLL_TTKhachHang();
            LOAIKHACHHANG lkh = new LOAIKHACHHANG();

            lkh.MALOAIKH = txtMaLoaiKH.Text;
            lkh.TENLOAIKH = txtLoaiKH.Text;

            int result = -1;

            result = service.XoaloaiKH_dal(lkh);

            if (result == 0)
            {
                MessageBox.Show("Thành Công", "Thông báo");
            }
            else if (result == 2)
            {
                MessageBox.Show("Không tìm thấy khóa", "Thông báo");
            }


            showDataGridView();

        }

        private void datagird_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show("sdsd");
                txtMaKH.Text = datagird_KhachHang.CurrentRow.Cells[0].Value.ToString();
                cboLoaiKH.Text = datagird_KhachHang.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = datagird_KhachHang.CurrentRow.Cells[2].Value.ToString();
                txtSDT.Text = datagird_KhachHang.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = datagird_KhachHang.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
