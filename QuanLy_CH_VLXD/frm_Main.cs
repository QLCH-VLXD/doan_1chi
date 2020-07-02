using DevExpress.XtraBars.Ribbon;
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
            // TODO: This line of code loads data into the 'dataSet1.MANHINH' table. You can move, or remove it, as needed.
            this.mANHINHTableAdapter.Fill(this.dataSet1.MANHINH);
            // TODO: This line of code loads data into the 'dataSet1.NGUOIDUNGNHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Fill(this.dataSet1.NGUOIDUNGNHOMNGUOIDUNG);
            // TODO: This line of code loads data into the 'dataSet1.TAIKHOAN' table. You can move, or remove it, as needed.
            this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);
            // TODO: This line of code loads data into the 'dataSet1.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet1.NHOMNGUOIDUNG);
            // TODO: This line of code loads data into the 'dataSet1.PHANQUYEN' table. You can move, or remove it, as needed.
            this.pHANQUYENTableAdapter.Fill(this.dataSet1.PHANQUYEN);
            s = Lay_DL;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //load screen 
            DataTable dt = GetNhomNguoiDung(Properties.Settings.Default.user.ToUpper());

            foreach (DataRow item in dt.Rows)
            {
                DataTable dsQuyen = GetMaManHinh(item[1].ToString());
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbonPage_TacVu.Groups, mh[0].ToString(), Convert.ToBoolean(mh[2].ToString()));
                }
            }
            foreach (DataRow item in dt.Rows)
            {
                DataTable dsQuyen = GetMaManHinh(item[1].ToString());
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbonPage_DanhMuc.Groups, mh[0].ToString(), Convert.ToBoolean(mh[2].ToString()));
                }
            }
            foreach (DataRow item in dt.Rows)
            {
                DataTable dsQuyen = GetMaManHinh(item[1].ToString());
                foreach (DataRow mh in dsQuyen.Rows)
                {
                    FindMenuPhanQuyen(this.ribbonPage_HeThong.Groups, mh[0].ToString(), Convert.ToBoolean(mh[2].ToString()));
                }
            }
        }
        public DataTable GetMaManHinh(string str)
        {
            DataTable dt = dataSet1.PHANQUYEN;
            DataTable dtR = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString() == str)
                {
                    dtR.ImportRow(dr);
                }
            }
            return dtR;
         
        }
        public DataTable GetNhomNguoiDung(string str)
        {
            DataTable dt = dataSet1.NGUOIDUNGNHOMNGUOIDUNG;
            DataTable dtR = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString().ToUpper() == str.ToUpper())
                {
                    dtR.ImportRow(dr);
                }
            }
            return dtR;

        }
        private void FindMenuPhanQuyen(RibbonPageGroupCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (RibbonPageGroup menu in mnuItems)
            {
                if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pHANQUYENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pHANQUYENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                     
            //this.Hide();
            this.Close();
            Program.Frm_DangNhap.Show(); 
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_NhapLieu_PhanQuyen frm_NhapLieu_PhanQuyen = new frm_NhapLieu_PhanQuyen();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_NhapLieu_PhanQuyen);
        }

        private void DanhMucPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DanhMucPhanQuyen frm_DanhMucPhanQuyen = new frm_DanhMucPhanQuyen();
            panel1.Controls.Clear();
            panel1.Controls.Add(frm_DanhMucPhanQuyen);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Frm_DangNhap.Show();

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Đăng xuất", "Exit!!!!!!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // lấy dữ liệu 
        public string Lay_DL
        {
            get { return lay_dl; }
            set { lay_dl = value; }
        }
    }
}
