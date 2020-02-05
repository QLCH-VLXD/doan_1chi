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
    public partial class frm_TTNSX : UserControl
    {
        BLL_TTNSX bll_TTNSX = new BLL_TTNSX();
        string a;
        public frm_TTNSX()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frm_TTNSX_Load(object sender, EventArgs e)
        {
            txtMaNSX.Text = "NSX" + bll_TTNSX.Sinh_Mansx_dal();
            a = txtMaNSX.Text;
            dataGridView1.DataSource = bll_TTNSX.load_TTNSX();
            showDataGridView();
            
        }
        public void showDataGridView()
        {
            bll_TTNSX = new BLL_TTNSX();
            dataGridView1.DataSource = bll_TTNSX.load_TTNSX();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            txtMaNSX.Text = "NSX" + bll_TTNSX.Sinh_Mansx_dal();
            txtTenNSX.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                //MessageBox.Show("sdsd");
                txtMaNSX.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenNSX.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BLL_TTNSX service = new BLL_TTNSX();
            NHASANXUAT cv = new NHASANXUAT();
            if (txtTenNSX.Text.Length > 0 && txtSDT.Text.Length > 0 && txtEmail.Text.Length > 0 && txtDiaChi.Text.Length > 0)
            {
                cv.MANSX = a;
                cv.TENNSX = txtTenNSX.Text;
                cv.SDT = txtSDT.Text;
                cv.EMAIL = txtEmail.Text;
                cv.DIACHI = txtDiaChi.Text;
                int result = 0;
                result = service.themnsx(cv);
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
            BLL_TTNSX service = new BLL_TTNSX();
            NHASANXUAT cv = new NHASANXUAT();

            cv.MANSX = a;
            cv.TENNSX = txtTenNSX.Text;
            cv.SDT = txtSDT.Text;
            cv.EMAIL = txtEmail.Text;
            cv.DIACHI = txtDiaChi.Text;

            int result = 0;

            result = service.suansx(cv);

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
            BLL_TTNSX service = new BLL_TTNSX();
            NHASANXUAT cv = new NHASANXUAT();

            cv.MANSX = a;
            cv.TENNSX = txtTenNSX.Text;
            cv.SDT = txtSDT.Text;
            cv.EMAIL = txtEmail.Text;
            cv.DIACHI = txtDiaChi.Text;

            int result = -1;

            result = service.xoansx(cv);

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

        private void txtTenNSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
