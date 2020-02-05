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
            //dataGridView1.DataSource = bll_DanhMucSanPham.load_MATHANG();
            cbo_MaLoaiMH.DataSource = bll_DanhMucSanPham.load_loaiMatHang();
            cbo_MaLoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_MaLoaiMH.DisplayMember = "MALOAIMATHANG";
            cbo_DonViTinh.DataSource = bll_DanhMucSanPham.Load_DonViTinhdll();
            cbo_DonViTinh.ValueMember = "MADVT";
            cbo_DonViTinh.DisplayMember = "TENDVT";
            cbo_NhaSX.DataSource = bll_DanhMucSanPham.Load_NhaSXdll();
            cbo_NhaSX.ValueMember = "MANSX";
            cbo_NhaSX.DisplayMember = "TENNSX";

            cbo_mathang.DataSource = bll_DanhMucSanPham.load_MatHang();
            cbo_mathang.ValueMember = "MAMATHANG";
            cbo_mathang.DisplayMember = "TENMATHANG";

            Load_CboGT();
            lbl_Manv.Text = Properties.Settings.Default.user;
            //cbo_TinhTrang.DataSource = bll_DanhMucSanPham.Load_TinhTrangdll();
            //cbo_TinhTrang.ValueMember = "MAMATHANG";
            //cbo_TinhTrang.DisplayMember = "TINHTRANG";

            loaddatagirdview();
            this.txt_TenloaiMH.Enabled = false;
            //this.cbo_mathang.Enabled = false;

            flag = 1;
            //dataGridView_HoaDonBan.DataSource = bll_BanHang.load_HDB();
            //dataGridView_CTHoaDonBan.DataSource = bll_BanHang.load_CTHDB();
            //dataGridView1.DataSource = bll_BanHang.load_HDB();
            //lbl_Manv.Text = Lay_DL;
        }

        int flag2 = 0;

        private void cbo_MaLoaiMH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                if (cbo_MaLoaiMH.SelectedValue.ToString() != String.Empty)
                {
                    //            cbo_MaMH.DataSource = bll_DanhMucSanPham.load_MatHang(cbo_MaLoaiMH.SelectedValue.ToString());
                    //            cbo_MaMH.ValueMember = "MAMATHANG";
                    //            cbo_MaMH.DisplayMember = "MAMATHANG";


                    txt_TenloaiMH.Text = bll_DanhMucSanPham.Load_tenloaiMH(cbo_MaLoaiMH.SelectedValue.ToString());

                    //            //txt_TenMH.Text = bll_DanhMucSanPham.Load_tenMH(cbo_MaLoaiMH.SelectedValue.ToString());

                    flag2 = 1;
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txt_DonGia.Text.Length > 0 && txt_GhiChu.Text.Length > 0 && txt_SoLuong.Text.Length > 0 && txt_TenloaiMH.Text.Length > 0 && cbo_DonViTinh.Text.Length > 0 && cbo_MaLoaiMH.Text.Length > 0 && cbo_NhaSX.Text.Length > 0 && cbo_TinhTrang.Text.Length > 0)
            {



                MATHANG mh = new MATHANG();
                mh.GHICHU = txt_GhiChu.Text;
                mh.MADVT = cbo_DonViTinh.SelectedValue.ToString();
                mh.MALOAIMATHANG = cbo_MaLoaiMH.Text;
                mh.MAMATHANG = "MH" + bll_DanhMucSanPham.Sinh_MaMatHang_BLL();
                mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
                mh.SOLUONG = int.Parse(txt_SoLuong.Text);
                mh.TENMATHANG = cbo_mathang.Text;
                mh.TINHTRANG = cbo_TinhTrang.Text;
                bll_DanhMucSanPham.Load_ThemMHdll(mh);


                DONGIA dg = new DONGIA();
                dg.MADONGIA = "DG" + bll_DanhMucSanPham.Sinh_MaDonGia_BLL();
                dg.MAMATHANG = "MH" + bll_DanhMucSanPham.Sinh_MaMatHang_BLL();
                mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit1.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit2.Text);
                dg.GIA = decimal.Parse(txt_DonGia.Text);
                bll_DanhMucSanPham.Load_ThemDonGiadll(dg);

                //CHITIETNHASANXUAT ctnsx = new CHITIETNHASANXUAT();
                //ctnsx.MANSX = cbo_NhaSX.SelectedValue.ToString();
                //ctnsx.MAMATHANG = txt_MaMH.Text;
                //bll_DanhMucSanPham.Load_ThemCTNSXdll(ctnsx);

                loaddatagirdview();
                MessageBox.Show("Thêm thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ dữ liệu");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //sửa
            if (txt_DonGia.Text.Length > 0 && txt_GhiChu.Text.Length > 0 && txt_SoLuong.Text.Length > 0 && txt_TenloaiMH.Text.Length > 0 && cbo_mathang.Text.Length > 0 && cbo_DonViTinh.Text.Length > 0  && cbo_MaLoaiMH.Text.Length > 0 && cbo_NhaSX.Text.Length > 0 && cbo_TinhTrang.Text.Length > 0)
            {
                MATHANG mh = new MATHANG();
                mh.GHICHU = txt_GhiChu.Text;
                mh.MADVT = cbo_DonViTinh.SelectedValue.ToString();
                mh.MALOAIMATHANG = cbo_MaLoaiMH.Text;
                mh.MAMATHANG = cbo_mathang.Text;
                mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
                mh.SOLUONG = int.Parse(txt_SoLuong.Text);
                mh.TENMATHANG = cbo_mathang.Text;
                mh.TINHTRANG = cbo_TinhTrang.Text;
                if (!bll_DanhMucSanPham.Load_SuaMHdll(mh))
                {
                    MessageBox.Show("Không thể sửa mặt hàng");
                    return;
                }

                //if (bll_DanhMucSanPham.KTKC(mh) == true)
                //{

                //    if (bll_DanhMucSanPham.Load_SuaMHdll(mh) == true)
                //    {
                //        MessageBox.Show("thanh cong");
                //        //dataGridView1.DataSource = bll_DanhMucSanPham.loaddatagirdview();
                //        bll_DanhMucSanPham = new BLL_DanhMucSanPham();
                //        dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
                //    }
                //    else
                //    {
                //        MessageBox.Show("that bai");
                //        return;
                //    }
                //}

                DONGIA dg = new DONGIA();
                dg.MADONGIA = bll_DanhMucSanPham.mahangdll(mh.MAMATHANG);
                dg.MAMATHANG = cbo_mathang.Text;
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit1.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit2.Text);
                dg.GIA = decimal.Parse(txt_DonGia.Text);
                if (!bll_DanhMucSanPham.Load_SuaDonGiadll(dg))
                {
                    MessageBox.Show("Không thể sửa đơn giá");
                    return;

                }




                loaddatagirdview();
                MessageBox.Show("Đã cập nhật thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ dữ liệu");
            }
        }
        private void loaddatagirdview()
        {
            bll_DanhMucSanPham = new BLL_DanhMucSanPham();
            dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (txt_DonGia.Text.Length > 0 && txt_GhiChu.Text.Length > 0 && txt_SoLuong.Text.Length > 0 && txt_TenloaiMH.Text.Length > 0 && cbo_mathang.Text.Length > 0 && cbo_DonViTinh.Text.Length > 0  && cbo_MaLoaiMH.Text.Length > 0 && cbo_NhaSX.Text.Length > 0 && cbo_TinhTrang.Text.Length > 0 && cbo_mathang.SelectedValue!=null)
            {

                MATHANG mh = new MATHANG();
                mh.GHICHU = txt_GhiChu.Text;
                mh.MADVT = cbo_DonViTinh.SelectedValue.ToString();
                mh.MALOAIMATHANG = cbo_MaLoaiMH.Text;
                mh.MAMATHANG = cbo_mathang.SelectedValue.ToString();//
                mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
                mh.SOLUONG = int.Parse(txt_SoLuong.Text);
                mh.TENMATHANG = cbo_mathang.Text;
                mh.TINHTRANG = cbo_TinhTrang.Text;

                CHITIETNHASANXUAT ctnsx = new CHITIETNHASANXUAT();
                ctnsx.MANSX = cbo_NhaSX.SelectedValue.ToString();
                ctnsx.MAMATHANG = cbo_mathang.Text;

                DONGIA dg = new DONGIA();
                dg.MADONGIA = bll_DanhMucSanPham.mahangdll(mh.MAMATHANG);
                dg.MAMATHANG = cbo_mathang.Text;
                dg.NGAYAPDUNG = DateTime.Parse(dateEdit1.Text);
                dg.NGAYKETTHUC = DateTime.Parse(dateEdit2.Text);
                dg.GIA = decimal.Parse(txt_DonGia.Text);
                if (!bll_DanhMucSanPham.Load_XoaDGdll(dg))
                {
                    MessageBox.Show("Không thể sửa đơn giá");
                    return;

                }

                bll_DanhMucSanPham.Load_XoaMHdll(mh);


                bll_DanhMucSanPham.Load_Xoactnsxdll(ctnsx);




                loaddatagirdview();
                MessageBox.Show("Thành công", "Thông báo");
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
                        cbo_MaLoaiMH.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txt_TenloaiMH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        //cbo_mathang.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        cbo_mathang.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                        txt_SoLuong.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        txt_DonGia.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        dateEdit1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                        dateEdit2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                        cbo_DonViTinh.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        cbo_NhaSX.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                        txt_GhiChu.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                        cbo_TinhTrang.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                        this.txt_TenloaiMH.Enabled = false;
                       // this.cbo_mathang.Enabled = false;

                    }
                }
            }
        }

        private void txt_SoLuong_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    int a = int.Parse(txt_SoLuong.Text);
            //}
            //catch
            //{
            //    MessageBox.Show("Số lượng phải là số!");
            //}
        }

        private void txt_DonGia_Leave(object sender, EventArgs e)
        {
        //    try
        //    {
        //        int a = int.Parse(txt_DonGia.Text);
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Đơn giá phải là số!");
        //    }
        }

        List<Bangghep_DMMH> mh_bangghep = new List<Bangghep_DMMH>();

        private void txt_TimKiemTenMH_TextChanged(object sender, EventArgs e)
        {
            if (txt_TimKiemTenMH.Text.Length > 0)
            {
                mh_bangghep.Clear();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value != null)
                        if (dataGridView1.Rows[i].Cells[3].Value.ToString().Contains(txt_TimKiemTenMH.Text) == true)
                        {
                            Bangghep_DMMH mH_BangGhep = new Bangghep_DMMH();
                            mH_BangGhep.GHICHU1 = dataGridView1.Rows[i].Cells[10].Value.ToString();
                            mH_BangGhep.GIA1 = decimal.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            mH_BangGhep.MALOAIMATHANG1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            mH_BangGhep.MAMATHANG1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            mH_BangGhep.NGAYAPDUNG1 = DateTime.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            mH_BangGhep.NGAYKETTHUC1 = DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                            mH_BangGhep.SOLUONG1 = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                            mH_BangGhep.TENDVT1 = dataGridView1.Rows[i].Cells[8].Value.ToString();
                            mH_BangGhep.TENLOAIMATHANG1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            mH_BangGhep.TENMATHANG1 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            mH_BangGhep.TENNSX1 = dataGridView1.Rows[i].Cells[9].Value.ToString();
                            mH_BangGhep.TINHTRANG1 = dataGridView1.Rows[i].Cells[11].Value.ToString();
                            mh_bangghep.Add(mH_BangGhep);
                        }
                }
                dataGridView1.DataSource = mh_bangghep;
            }
            else { dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll(); }
        }

        void Load_CboGT()
        {
            cbo_TinhTrang.Items.Add("Còn hàng");
            cbo_TinhTrang.Items.Add("Hết hàng");
        }

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
    }
}
