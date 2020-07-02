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
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;

namespace QuanLy_CH_VLXD
{
    public partial class frm_DanhMucSanPham : UserControl
    {
        BLL_DanhMucSanPham bll_DanhMucSanPham = new BLL_DanhMucSanPham();
        BLL_DonGia bLL_DonGia = new BLL_DonGia();
        int flag = 0;

        public frm_DanhMucSanPham()
        {
            InitializeComponent();
        }

        bool isLoadData = false;
        private List<Bangghep_DMMH> vl = null;
        private void frm_DanhMucSanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll_DanhMucSanPham.load_loaiMatHang();
            cbo_TenLoaiMH.DataSource = bll_DanhMucSanPham.load_loaiMatHang();
            cbo_TenLoaiMH.ValueMember = "MALOAIMATHANG";
            cbo_TenLoaiMH.DisplayMember = "TENLOAIMATHANG";

            //txt_MaMH.Text = "MH" + bll_DanhMucSanPham.Sinh_MaMatHang();

            cbo_DonViTinh.DataSource = bll_DanhMucSanPham.load_donViTinh();
            cbo_DonViTinh.ValueMember = "MADVT";
            cbo_DonViTinh.DisplayMember = "TENDVT";

            cbo_NhaSX.DataSource = bll_DanhMucSanPham.load_nhaSanXuat();
            cbo_NhaSX.ValueMember = "MANSX";
            cbo_NhaSX.DisplayMember = "TENNSX";
            //flag = 1;
            dateEdit1.Text = DateTime.Today.Day.ToString();
            vl = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();

            //List<test> tests = new List<test>();
            //foreach(Bangghep_DMMH d in vl)
            //{
            //    tests.Add(new test
            //    {
            //        GHICHU = d.GHICHU1,
            //        GIA = d.GIA1,
            //        HANMUCHETHANG = d.HANMUCHETHANG1,
            //        HINHMH = Base64ToImage(d.HINHMH1.ToArray()),
            //        MALOAIMATHANG = d.MALOAIMATHANG1,
            //        MAMATHANG = d.MAMATHANG1,
            //        NGAYAPDUNG = d.NGAYAPDUNG1,
            //        SOLUONG = d.SOLUONG1,
            //        TENDVT = d.TENDVT1,
            //        TENLOAIMATHANG = d.TENLOAIMATHANG1,
            //        TENMATHANG = d.TENMATHANG1,
            //        TENNSX = d.TENNSX1,
            //        TINHTRANG = d.TINHTRANG1,
            //        XUATXU = d.XUATXU1
            //    });
            //}
            dataGridView1.DataSource = vl;
            isLoadData = true;
            Console.WriteLine(vl.FirstOrDefault().HINHMH1.ToArray());
            pictureEdit1.Image = (Image)Base64ToImage(vl.FirstOrDefault().HINHMH1.ToArray());
        }





        public static Bitmap Base64ToImage(byte[] byteArray)
        {
            ImageConverter imagec = new ImageConverter();
            Bitmap bm = (Bitmap)imagec.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        //public Image Base64ToImage(byte[] base64String)
        //{
        //    try {
        //        MemoryStream ms = new MemoryStream(base64String);
        //        System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //        return returnImage;
        //    }
        //    catch
        //    {
        //        return null;
        //    }

   


        public byte[] ImageToBase64(Image image)
        {
            // CONVERT JPG TO A BYTE ARRAY

            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();


        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            MATHANG mh = new MATHANG();
            DONGIA dg = new DONGIA();
            //kt
            if (txt_MaMH.Text.Length > 0 && txt_TenMH.Text.Length > 0 && txt_SoLuong.Text.Length > 0 && txt_DonGia.Text.Length > 0 && txt_hanMucHetHang.Text.Length > 0 && txt_XuatXu.Text.Length > 0)
            {
                mh.MAMATHANG = txt_MaMH.Text;
                mh.MALOAIMATHANG = cbo_TenLoaiMH.SelectedValue.ToString();
                mh.TENMATHANG = txt_TenMH.Text;
                mh.SOLUONG = Convert.ToInt32(txt_SoLuong.Text);
                mh.MADVT = cbo_DonViTinh.SelectedValue.ToString();
                mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
                mh.HANMUCHETHANG = Convert.ToInt32(txt_hanMucHetHang.Text);
                if (radioButton_Con.Checked == true)
                {
                    mh.TINHTRANG = "còn hàng";
                }
                else
                {
                    mh.TINHTRANG = "hết hàng";
                }
                mh.XUATXU = txt_XuatXu.Text;
                mh.GHICHU = txt_GhiChu.Text;

                mh.HINHMH = ImageToBase64(pictureEdit1.Image);

                if (bll_DanhMucSanPham.KTKC(mh) == true)
                {
                    if (bll_DanhMucSanPham.them_DMMH(mh) == true)
                    {
                        MessageBox.Show("Thành công");
                        dg.MADONGIA = "DG" + (bll_DanhMucSanPham.load_dongia().Count + 1).ToString();
                        dg.GIA = Convert.ToDecimal(txt_DonGia.Text);
                        dg.NGAYAPDUNG = Convert.ToDateTime(dateEdit1.Text);
                        dg.MAMATHANG = txt_MaMH.Text;
                        if (bLL_DonGia.Load_ThemDonGiadll(dg) == true)
                        {
                            dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();

                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thất bại");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mặt hàng đã tồn tại");
                }


            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin");
            loaddatagirdview();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void loaddatagirdview()
        {
            bll_DanhMucSanPham = new BLL_DanhMucSanPham();
            vl = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
            dataGridView1.DataSource = vl;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            MATHANG mh = new MATHANG();
            DONGIA dg = new DONGIA();
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            mh.MAMATHANG = dataGridView1.CurrentRow.Cells[2].Value.ToString();


            if (bll_DanhMucSanPham.Xoa_DMMH(mh) == true)
            {
                MessageBox.Show("Thành công");
                dg.MAMATHANG = txt_MaMH.Text;
                if (bLL_DonGia.Load_XoaDG_dmmh(dg) == true)
                {
                    dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();

                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Thất bại");
                // return;
            }
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

            if (dataGridView1.CurrentRow.Index>=0 && isLoadData == true)//SelectedRows!= null
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
                    //dateEdit_ngaySanXuat.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    // dateEdit_ngayHetHan.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    txt_XuatXu.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[12].Value.ToString() == "còn hàng")
                    {
                        radioButton_Con.Checked = true;
                        radioButton_Het.Checked = false;
                    }
                    else
                    {
                        radioButton_Het.Checked = false;
                        radioButton_Het.Checked = true;
                    }
                    txt_GhiChu.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    //byte[] a = ObjectToByteArray(vl[dataGridView1.CurrentRow.Index].HINHMH1.ToArray());
                    pictureEdit1.Image = Base64ToImage(vl[dataGridView1.CurrentRow.Index].HINHMH1.ToArray());

                }
            }

        }

        //byte[] ObjectToByteArray(object obj)
        //{
        //    if (obj == null)
        //        return null;
        //    BinaryFormatter bf = new BinaryFormatter();
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bf.Serialize(ms, obj);
        //        return ms.ToArray();
        //    }
        //}


        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cbo_TenLoaiMH.Text = "";
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
            //pictureEdit1.Clear();

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

        List<Bangghep_DMMH> mh_bangghep = new List<Bangghep_DMMH>();
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
            //catch (Exception)
            //{

            //}
        }

        public static byte[] CopyImageToByteArray(Image theImage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                theImage.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }

        private void btn_Sửa_Click(object sender, EventArgs e)
        {
            MATHANG mh = new MATHANG();
            DONGIA dg = new DONGIA();

            mh.MAMATHANG = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mh.MALOAIMATHANG = cbo_TenLoaiMH.SelectedValue.ToString();
            mh.MADVT = cbo_DonViTinh.SelectedValue.ToString();
            mh.MANSX = cbo_NhaSX.SelectedValue.ToString();
            mh.TENMATHANG = txt_TenMH.Text;
            mh.SOLUONG = Convert.ToInt32(txt_SoLuong.Text);
            mh.HANMUCHETHANG = Convert.ToInt32(txt_hanMucHetHang.Text);
            if (radioButton_Con.Checked == true)
            {
                mh.TINHTRANG = "còn hàng";
            }
            else
            {
                mh.TINHTRANG = "hết hàng";
            }

            mh.XUATXU = txt_XuatXu.Text;
            mh.GHICHU = txt_GhiChu.Text;

            mh.HINHMH = CopyImageToByteArray(pictureEdit1.Image);


            if (bll_DanhMucSanPham.Sua_DMMH(mh) == true)
            {
                MessageBox.Show("Thành công");
                dg.GIA = Convert.ToDecimal(txt_DonGia.Text);
                dg.NGAYAPDUNG = Convert.ToDateTime(dateEdit1.Text);
                dg.MAMATHANG = txt_MaMH.Text;
                if (!bLL_DonGia.Load_SuaDG_DMMH(dg))
                    return;

            }
            else
            {
                MessageBox.Show("Thất bại");
                // return;
            }
            loaddatagirdview();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                xtraOpenFileDialog1.ShowDialog();
                xtraOpenFileDialog1.Filter = "JPG FILE (*.jpg)|*.jpg|All files (*.*)|*.*";
                string file = xtraOpenFileDialog1.FileName;
                if (string.IsNullOrEmpty(file))
                {
                    return;
                }
                System.Drawing.Image image = System.Drawing.Image.FromFile(file);
                pictureEdit1.Image = image;

            }
            catch
            { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureEdit1.Image != null && pictureEdit1 != null)
            {
                pictureEdit1.Image.Dispose();
                pictureEdit1.Image = null;
            }
        }




        private void btn_Sửa_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridView1.DataSource = bll_DanhMucSanPham.LoadDL_DSMATHANGdll();
        }
    }
}
