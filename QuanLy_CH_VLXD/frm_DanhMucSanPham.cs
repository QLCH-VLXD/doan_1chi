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
    public partial class frm_DanhMucSanPham : UserControl
    {
        BLL_DanhMucSanPham bll_DanhMucSanPham = new BLL_DanhMucSanPham();
        int flag = 0;

        public frm_DanhMucSanPham()
        {
            InitializeComponent();
        }

       

        private void frm_DanhMucSanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll_DanhMucSanPham.load_loaiMatHang();
            cbo_TenLoaiMH.DataSource = bll_DanhMucSanPham.load_loaiMatHang();
            cbo_TenLoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_TenLoaiMH.DisplayMember = "TENLOAIMATHANG";

            txt_MaMH.Text = "MH" + bll_DanhMucSanPham.Sinh_MaMatHang();

            cbo_DonViTinh.DataSource = bll_DanhMucSanPham.load_donViTinh();
            cbo_DonViTinh.ValueMember = "MADVT";
            cbo_DonViTinh.DisplayMember = "TENDVT";

            cbo_NhaSX.DataSource = bll_DanhMucSanPham.load_nhaSanXuat();
            cbo_NhaSX.ValueMember = "MANSX";
            cbo_NhaSX.DisplayMember = "TENNSX";
            //flag = 1;
            dateEdit1.Text = DateTime.Today.Day.ToString();

            dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
        }

        private void loaddatagirdview()
        {
            bll_DanhMucSanPham = new BLL_DanhMucSanPham();
            //dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
        }

      

        private void txt_SoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txt_SoLuong.Text);
            }
            catch
            {
                MessageBox.Show("Số lượng phải là số!");
            }
        }

        private void txt_DonGia_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txt_DonGia.Text);
            }
            catch
            {
                MessageBox.Show("Đơn giá phải là số!");
            }
        }

        List<Bangghep_DMMH> mh_bangghep = new List<Bangghep_DMMH>();

       
        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            
                if (dataGridView1.SelectedRows != null)
                {
                    if (dataGridView1.CurrentRow.Cells[0].Value != null)
                    {
                        cbo_TenLoaiMH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        txt_MaMH.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        txt_TenMH.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        txt_SoLuong.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        txt_DonGia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        dateEdit1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        cbo_DonViTinh.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                        cbo_NhaSX.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        txt_hanMucHetHang.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                        dateEdit_ngaySanXuat.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                        dateEdit_ngayHetHan.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                        txt_XuatXu.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                        if (dataGridView1.CurrentRow.Cells[14].Value.ToString() == "còn hàng")
                        {
                            radioButton_Con.Checked = true;
                            radioButton_Het.Checked = false;
                        }
                        else
                        {
                            radioButton_Het.Checked = false;
                            radioButton_Het.Checked = true;
                        }
                        txt_GhiChu.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    }
                }
           
        }

       
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cbo_TenLoaiMH.Text="";
            txt_MaMH.Text = "MH" + bll_DanhMucSanPham.Sinh_MaMatHang();
            txt_TenMH.Clear();
            txt_SoLuong.Clear();
            txt_DonGia.Clear();
            dateEdit1.Text = DateTime.Today.ToString();
            cbo_DonViTinh.Text = "";
            cbo_NhaSX.Text = "";
            txt_hanMucHetHang.Clear();
            radioButton_Con.Checked = false;
            radioButton_Het.Checked = false;
            txt_XuatXu.Clear();
            txt_GhiChu.Clear();
        }

        private void txt_hanMucHetHang_Leave(object sender, EventArgs e)
        {
            try
            {
                int a = int.Parse(txt_hanMucHetHang.Text);
            }
            catch
            {
                MessageBox.Show("Hạn mức phải là số!");
            }
        }

        private void txt_hanMucHetHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txt_TimKiemTenMH_Click(object sender, EventArgs e)
        {

        }

        private void txt_TimKiemTenMH_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_TimKiemTenMH.Text.Length > 0)
            //    {
            //        mh_bangghep.Clear();
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (dataGridView1.Rows[i].Cells[3].Value != null)
            //                if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(txt_TimKiemTenMH.Text) == true)
            //                {
            //                    Bangghep_DMMH mH_BangGhep = new Bangghep_DMMH();
            //                    mH_BangGhep.GHICHU1 = dataGridView1.Rows[i].Cells[13].Value.ToString();
            //                    mH_BangGhep.GIA1 = decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            //                    mH_BangGhep.MALOAIMATHANG1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //                    mH_BangGhep.MAMATHANG1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //                    mH_BangGhep.NGAYAPDUNG1 = DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
            //                    //mH_BangGhep.NGAYKETTHUC1 = DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
            //                    mH_BangGhep.SOLUONG1 = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
            //                    mH_BangGhep.TENDVT1 = dataGridView1.Rows[i].Cells[7].Value.ToString();
            //                    mH_BangGhep.TENLOAIMATHANG1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //                    mH_BangGhep.TENMATHANG1 = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //                    mH_BangGhep.TENNSX1 = dataGridView1.Rows[i].Cells[8].Value.ToString();
            //                    mH_BangGhep.TINHTRANG1 = dataGridView1.Rows[i].Cells[14].Value.ToString();
            //                    mH_BangGhep.HANMUCHETHANG1 = int.Parse(dataGridView1.Rows[i].Cells[9].Value.ToString());
            //                    mH_BangGhep.NGAYSX1 = DateTime.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString());
            //                    mH_BangGhep.NGAYHH1 = DateTime.Parse(dataGridView1.Rows[i].Cells[11].Value.ToString());
            //                    mH_BangGhep.XUATXU1 = dataGridView1.Rows[i].Cells[12].Value.ToString();
            //                    mh_bangghep.Add(mH_BangGhep);
            //                }
            //        }
            //        dataGridView1.DataSource = mh_bangghep;
            //    }
            //    else
            //    {
            //        dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
            //    }
            //}
            //catch(Exception )
            //{

            //}
    }

    }
}
