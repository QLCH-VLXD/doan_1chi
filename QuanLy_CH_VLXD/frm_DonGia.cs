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
    public partial class frm_DonGia : UserControl
    {
        BLL_DonGia bll_DonGia = new BLL_DonGia();


        public frm_DonGia()
        {
            InitializeComponent();
        }

        private void loaddatagirdview()
        {
            bll_DonGia = new BLL_DonGia();
            dataGridView1.DataSource = bll_DonGia.LoadDL_DSDonGiadll();
        }

        int flag = 0;

        private void frm_DonGia_Load(object sender, EventArgs e)
        {
            cboMaLoaiMH.DataSource = bll_DonGia.load_loaiMatHang();
            cboMaLoaiMH.ValueMember = "MALOAIMATHANG";
            cboMaLoaiMH.DisplayMember = "MALOAIMATHANG";

            //cboMaMH.DataSource = bll_DonGia.load_MaMatHang();
            //cboMaMH.ValueMember = "MAMATHANG";
            //cboMaMH.DisplayMember = "MAMATHANG";

            loaddatagirdview();
            this.txtTenLoaiMH.Enabled = false;
            this.txtMaMH.Enabled = false;
            this.txtMaDonGia.Enabled = false;

            flag = 1;
        }
        int flag2 = 0;

        private void cboMaLoaiMH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (cboMaLoaiMH.SelectedValue.ToString() != String.Empty)
                {
                    //            cbo_MaMH.DataSource = bll_DanhMucSanPham.load_MatHang(cbo_MaLoaiMH.SelectedValue.ToString());
                    //            cbo_MaMH.ValueMember = "MAMATHANG";
                    //            cbo_MaMH.DisplayMember = "MAMATHANG";


                    txtTenLoaiMH.Text = bll_DonGia.Load_tenloaiMH(cboMaLoaiMH.SelectedValue.ToString());
                    //cboMaMH.Text = bll_DonGia.load_MaMatHang(cboMaLoaiMH.SelectedValue.ToString());

                    //            //txt_TenMH.Text = bll_DanhMucSanPham.Load_tenMH(cbo_MaLoaiMH.SelectedValue.ToString());

                    flag2 = 1;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //   binding du lieu
            if (flag == 1)
            {
                if (dataGridView1.SelectedRows != null)
                {

                    if (dataGridView1.CurrentRow.Cells[0].Value != null)
                    {
                        cboMaLoaiMH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txtTenLoaiMH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        txtMaMH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        txtTenMH.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        txtMaDonGia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        txtDonGia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        dateEdit_NgayBD.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        dateEdit_NgayKT.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                        this.txtTenLoaiMH.Enabled = false;
                        this.txtMaMH.Enabled = false;
                        this.txtMaDonGia.Enabled = false;


                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cboMaLoaiMH.Text.Length > 0 && /*txtMaMH.Text.Length > 0*/  txtDonGia.Text.Length > 0/* && txtMaDonGia.Text.Length > 0*/ && txtTenLoaiMH.Text.Length > 0 && txtTenMH.Text.Length > 0)
            {
                MATHANG mh = new MATHANG();
                mh.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                mh.TENMATHANG = txtTenMH.Text;
                mh.MALOAIMATHANG = cboMaLoaiMH.SelectedValue.ToString();
                bll_DonGia.Load_ThemMHdll(mh);

                // LOAIMATHANG lmh = new LOAIMATHANG();
                //lmh.MALOAIMATHANG = cboMaLoaiMH.SelectedValue.ToString();
                //lmh.TENLOAIMATHANG = txtTenLoaiMH.Text;
                //bll_DonGia.Load_ThemloaiMHdll(lmh);

                DONGIA dg = new DONGIA();
                dg.MADONGIA = "DG" + bll_DonGia.Sinh_MaDonGia_BLL();
                dg.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit_NgayBD.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit_NgayKT.Text);
                dg.GIA = decimal.Parse(txtDonGia.Text);
                bll_DonGia.Load_ThemDonGiadll(dg);


                loaddatagirdview();
                MessageBox.Show("thêm thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("vui lòng điền đầy đủ dữ liệu");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cboMaLoaiMH.Text.Length > 0 && /*txtMaMH.Text.Length > 0*/  txtDonGia.Text.Length > 0/* && txtMaDonGia.Text.Length > 0*/ && txtTenLoaiMH.Text.Length > 0 && txtTenMH.Text.Length > 0)
            {

                MATHANG mh = new MATHANG();
                mh.MAMATHANG = txtMaMH.Text;
                //mh.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                mh.TENMATHANG = txtTenMH.Text;
                mh.MALOAIMATHANG = cboMaLoaiMH.SelectedValue.ToString();

                if (!bll_DonGia.Load_SuaMHdll(mh))
                {
                    MessageBox.Show("ko thể sửa mặt hang");
                    return;
                }
                DONGIA dg = new DONGIA();
                dg.MADONGIA = bll_DonGia.mahangdll(mh.MAMATHANG);
                dg.MAMATHANG = txtMaMH.Text;
                //dg.MADONGIA = "DG" + bll_DonGia.Sinh_MaDonGia_BLL();
                //dg.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit_NgayBD.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit_NgayKT.Text);
                dg.GIA = decimal.Parse(txtDonGia.Text);


                if (!bll_DonGia.Load_SuaDonGiadll(dg))
                {
                    MessageBox.Show("ko thê sửa don gia");
                    return;

                }


                loaddatagirdview();
                MessageBox.Show("Đã cập nhật thành công");

            }
            else
            {
                MessageBox.Show("vui lòng điền đầy đủ dữ liệu");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (cboMaLoaiMH.Text.Length > 0 && /*txtMaMH.Text.Length > 0*/  txtDonGia.Text.Length > 0/* && txtMaDonGia.Text.Length > 0*/ && txtTenLoaiMH.Text.Length > 0 && txtTenMH.Text.Length > 0)
            {

                MATHANG mh = new MATHANG();
                mh.MAMATHANG = txtMaMH.Text;
                //mh.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                mh.TENMATHANG = txtTenMH.Text;
                mh.MALOAIMATHANG = cboMaLoaiMH.SelectedValue.ToString();

                LOAIMATHANG lmh = new LOAIMATHANG();
                //lmh.MALOAIMATHANG = cboMaLoaiMH.SelectedValue.ToString();
                lmh.TENLOAIMATHANG = txtTenLoaiMH.Text;


                DONGIA dg = new DONGIA();
                dg.MADONGIA = bll_DonGia.mahangdll(mh.MAMATHANG);
                dg.MAMATHANG = txtMaMH.Text;
                //dg.MADONGIA = "DG" + bll_DonGia.Sinh_MaDonGia_BLL();
                //dg.MAMATHANG = "MH" + bll_DonGia.Sinh_MaMatHang_BLL();
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit_NgayBD.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit_NgayKT.Text);
                dg.GIA = decimal.Parse(txtDonGia.Text);

                if (!bll_DonGia.Load_XoaDGdll(dg))
                {
                    MessageBox.Show("ko thê xoa don gia");
                    return;

                }

                bll_DonGia.Load_XoaMHdll(mh);
                //if (!)
                //{
                //    MessageBox.Show("ko thể xoa mathang");
                //    return;
                //}
                bll_DonGia.Load_XoaLMHdll(lmh);
                // if (!)
                //{
                //    MessageBox.Show("ko thể xoa loai mặt hàng");
                //    return;
                //}






                loaddatagirdview();
                MessageBox.Show("Thanh cong xoa");
            }
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txtDonGia.Text);
            }
            catch
            {
                MessageBox.Show("Đơn giá phải là số!");
            }
        }
    }
}
