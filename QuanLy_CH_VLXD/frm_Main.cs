using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_CH_VLXD
{
    public partial class FrmMain : Form
    {
        private String lay_dl, s;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            s = Lay_DL;

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DonGia frm_DonGia = new frm_DonGia();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_DonGia);
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DatHangNSX frm_DatHangNSX = new frm_DatHangNSX();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_DatHangNSX);
        }

        private void barButtonItem_NhapHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NhapHang frm_NhapHang = new frm_NhapHang();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_NhapHang);
        }

        private void barButtonItem_BanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panel1.Controls.Clear();
            frm_BanHang Frm_BanHang = new frm_BanHang();
            Frm_BanHang.Lay_DL = s;
            panel1.Controls.Add(Frm_BanHang);



        }

        private void barButtonItem_GiaoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_GiaoHang frm_GiaoHang = new frm_GiaoHang();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_GiaoHang);
        }

        private void barButtonItem_DMHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DanhMucSanPham frm_DanhMucSanPham = new frm_DanhMucSanPham();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_DanhMucSanPham);
        }

        private void barButtonItem_LoaiMatHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_LoaiMatHang frm_LoaiMatHang = new frm_LoaiMatHang();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_LoaiMatHang);
        }

        private void barButtonItem_ThongKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_ThongKe frm_ThongKe = new frm_ThongKe();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_ThongKe);
        }

        private void barButtonItem_DoMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDoiMatKhau frmDMK = new FrmDoiMatKhau();

            frmDMK.ShowDialog();
        }

        private void barButtonItem_NhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_TTNhanVien frm_TTNhanVien = new frm_TTNhanVien();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_TTNhanVien);
        }

        private void barButtonItem_KhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_TTKhachHang frm_TTKhachHang = new frm_TTKhachHang();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_TTKhachHang);
        }

        private void barButtonItem_NSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_TTNSX frm_TTNSX = new frm_TTNSX();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_TTNSX);
        }

        private void barButtonItem_DangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap frmDN = new frmDangNhap();
            frmDN.Show();
            this.Hide();
        }

        // lấy dữ liệu 
        public string Lay_DL
        {
            get { return lay_dl; }
            set { lay_dl = value; }
        }
    }
}
