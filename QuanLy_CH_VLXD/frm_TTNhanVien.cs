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
    public partial class frm_TTNhanVien : UserControl
    {
        BLL_TTNhanVien bll_TTNhanVien = new BLL_TTNhanVien();
        NHANVIEN nv = new NHANVIEN();
        string a;
        string b;


        public frm_TTNhanVien()
        {
            InitializeComponent();
        }

        private void frm_TTNhanVien_Load(object sender, EventArgs e)
        {
            txtMaChucVu.Text = "CV" + bll_TTNhanVien.Sinh_Manv_dal();
            txtMaNV.Text = "NV" + bll_TTNhanVien.Sinh_Manv_dal();
             a = txtMaNV.Text;
             b = txtMaChucVu.Text;
            showDataGridView();
            //label1.Text = Properties.Settings.Default.user;
        }

        public void showDataGridView()
        {
            bll_TTNhanVien = new BLL_TTNhanVien();
            dataGridView1.DataSource = bll_TTNhanVien.load_NhanVien();
            dataGridView2.DataSource = bll_TTNhanVien.load_ChucVu();
        }

        private void txtMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            String abc = txtMaNV.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMaNV.Text == String.Empty)
                {
                    return;
                }
                else
                {
                    txtHoTenNV.Text = bll_TTNhanVien.XemTenNhanVien_dal(txtMaNV.Text.ToString());
                    if (txtHoTenNV.Text == String.Empty)
                    {
                        MessageBox.Show("Thêm nhân viên mới");
                        txtMaNV.Clear();
                        txtMaNV.Text = abc;
                        return;
                    }

                    txtMaNV.Text.ToString().Trim();
                    txtMaNV.Clear();
                    txtMaNV.Text = abc;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                //MessageBox.Show("sdsd");
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cboChucVu.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                dateTimePicker_NgaySinh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtGioiTinh.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtCMND.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtTinhTrang.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                dateTimePicker_NgayVaoLam.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
            {
                txtMaChucVu.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtChucVu.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();

            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
        }

        public void Them()
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            NHANVIEN nv = new NHANVIEN();
            if (txtHoTenNV.Text.Length > 0 && txtGioiTinh.Text.Length > 0 && txtCMND.Text.Length > 0 && txtSDT.Text.Length > 0 && txtDiaChi.Text.Length > 0 && txtEmail.Text.Length > 0 && txtTinhTrang.Text.Length > 0)
            {
                // nv.MANV = txtMaNV.Text;
                nv.MANV = a;
                nv.HOTENNV = txtHoTenNV.Text;
                nv.MACHUCVU = cboChucVu.Text;
                nv.NGAYSINH = Convert.ToDateTime(dateTimePicker_NgaySinh.Text);
                nv.GIOITINH = txtGioiTinh.Text;
                nv.SOCMND = txtCMND.Text;
                nv.SDT = txtSDT.Text;
                nv.EMAIL = txtEmail.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.TINHTRANG = txtTinhTrang.Text;
                nv.NGAYVAOLAM = Convert.ToDateTime(dateTimePicker_NgayVaoLam.Text);

                int result = 0;
                result = service.them_dal(nv);
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
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            showDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            NHANVIEN nv = new NHANVIEN();

            nv.MANV = txtMaNV.Text;
            nv.HOTENNV = txtHoTenNV.Text;
            nv.MACHUCVU = cboChucVu.Text;
            nv.NGAYSINH = Convert.ToDateTime(dateTimePicker_NgaySinh.Text);
            nv.GIOITINH = txtGioiTinh.Text;
            nv.SOCMND = txtCMND.Text;
            nv.SDT = txtSDT.Text;
            nv.EMAIL = txtEmail.Text;
            nv.DIACHI = txtDiaChi.Text;
            nv.TINHTRANG = txtTinhTrang.Text;
            nv.NGAYVAOLAM = Convert.ToDateTime(dateTimePicker_NgayVaoLam.Text);

            int result = 0;

            result = service.Sua_dal(nv);

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        public void Xoa()
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            NHANVIEN nv = new NHANVIEN();

            nv.MANV = txtMaNV.Text;
            nv.HOTENNV = txtHoTenNV.Text;
            nv.MACHUCVU = cboChucVu.Text;
            nv.NGAYSINH = Convert.ToDateTime(dateTimePicker_NgaySinh.Text);
            nv.GIOITINH = txtGioiTinh.Text;
            nv.SOCMND = txtCMND.Text;
            nv.SDT = txtSDT.Text;
            nv.EMAIL = txtEmail.Text;
            nv.DIACHI = txtDiaChi.Text;
            nv.TINHTRANG = txtTinhTrang.Text;
            nv.NGAYVAOLAM = Convert.ToDateTime(dateTimePicker_NgayVaoLam.Text);

            int result = -1;

            result = service.Xoa_dal(nv);

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

        private void btnThem_ChucVu_Click(object sender, EventArgs e)
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            CHUCVU cv = new CHUCVU();
            if (txtChucVu.Text.Length > 0)
            {
                cv.MACHUCVU = b;
                cv.TENCV = txtChucVu.Text;


                int result = 0;
                result = service.themCV_dal(cv);
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
                MessageBox.Show("Vui lòng nhập tên chức vụ");

            showDataGridView();
        }

        private void btnSua_ChucVu_Click(object sender, EventArgs e)
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            CHUCVU cv = new CHUCVU();

            cv.MACHUCVU = txtMaChucVu.Text;
            cv.TENCV = txtChucVu.Text;

            int result = 0;

            result = service.SuaCV_dal(cv);

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

        private void btnXoa_ChucVu_Click(object sender, EventArgs e)
        {
            BLL_TTNhanVien service = new BLL_TTNhanVien();
            CHUCVU cv = new CHUCVU();

            cv.MACHUCVU = txtMaChucVu.Text;
            cv.TENCV = txtChucVu.Text;

            int result = -1;

            result = service.XoaCV_dal(cv);

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

        private void btn_LamMoiCV_Click(object sender, EventArgs e)
        {
            
            txtMaChucVu.Text = "CV" + bll_TTNhanVien.Sinh_Manv_dal();
            txtChucVu.Clear();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "NV" + bll_TTNhanVien.Sinh_Manv_dal();
            txtHoTenNV.Clear();
            txtGioiTinh.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtTinhTrang.Clear();
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtHoTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
