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
    public partial class frm_LoaiMatHang : UserControl
    {
        BLL_LoaiMatHang bll_loaiMH = new BLL_LoaiMatHang();

        public frm_LoaiMatHang()
        {
            InitializeComponent();
        }

        private void frm_LoaiMatHang_Load(object sender, EventArgs e)
        {
            showDataGridView();
        }

        public void showDataGridView()
        {
            bll_loaiMH = new BLL_LoaiMatHang();
            dataGridView1.DataSource = bll_loaiMH.load_LoaiMatHang();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //MessageBox.Show("sdsd");
                txtMaLoaiMH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenLoaiMH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();


            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemLoaiMH();
        }
        public void ThemLoaiMH()
        {
            BLL_LoaiMatHang service = new BLL_LoaiMatHang();
            LOAIMATHANG lmh = new LOAIMATHANG();

            lmh.MALOAIMATHANG = txtMaLoaiMH.Text;
            lmh.TENLOAIMATHANG = txtTenLoaiMH.Text;


            int result = 0;
            result = service.themloaiMH_dal(lmh);
            if (result == 2)
            {
                MessageBox.Show("đã tồn tại", "Thông báo");
            }
            else
            {
                MessageBox.Show("thêm thành công", "Thông báo");
            }

            showDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BLL_LoaiMatHang service = new BLL_LoaiMatHang();
            LOAIMATHANG lmh = new LOAIMATHANG();


            lmh.MALOAIMATHANG = txtMaLoaiMH.Text;
            lmh.TENLOAIMATHANG = txtTenLoaiMH.Text;

            int result = 0;

            result = service.SualoaiMH_dal(lmh);

            if (result == 1)
            {
                MessageBox.Show("Thành Công", "Thông báo");
            }
            else
            {
                MessageBox.Show("sửa thất bại", "Inofity");
            }



            showDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaloaiMH();
        }
        public void XoaloaiMH()
        {
            BLL_LoaiMatHang service = new BLL_LoaiMatHang();
            LOAIMATHANG lmh = new LOAIMATHANG();


            lmh.MALOAIMATHANG = txtMaLoaiMH.Text;
            lmh.TENLOAIMATHANG = txtTenLoaiMH.Text;


            int result = -1;

            result = service.XoaloaiKMH_dal(lmh);

            if (result == 0)
            {
                MessageBox.Show("Thành Công", "Thông báo");
            }
            else if (result == 2)
            {
                MessageBox.Show("Không tìm thấy khoa", "Thông báo");
            }


            showDataGridView();

        }

    }
}
