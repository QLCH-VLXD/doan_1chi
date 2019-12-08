using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_GiaoHang
    {
        DAL_GiaoHang dal_GiaoHang = new DAL_GiaoHang();

        public string Sinh_MaHoaDon_dal()
        {
            return dal_GiaoHang.SinhMaHoaDon();

        }

        public string XemTenKhachHang_dal(String makh)
        {
            return dal_GiaoHang.XemTenKhachHang(makh);

        }
        public List<NHANVIEN> load_MaMV()
        {
            return dal_GiaoHang.Load_MaMV();
        }
        public List<HOADONBAN> load_HDB()
        {
            return dal_GiaoHang.Load_HDB();
        }

        public List<CHITIETHOADONBAN> load_CTHDB()
        {
            return dal_GiaoHang.Load_CTHDB();
        }
        public List<CHITIETHOADONBAN> load_CTHDB1(string mact)
        {
            return dal_GiaoHang.Load_CTHDB1(mact);
        }
        public String load_MatHang(string mact)
        {
            return dal_GiaoHang.Load_MatHang(mact);
        }
        public string load_loaiMatHang(String mact)
        {
            return dal_GiaoHang.Loaddata_LoaiMatHang(mact);
        }
        public string load_SoLuong(string mact)
        {
            return dal_GiaoHang.Load_SoLuong(mact);
        }

        public String Load_dongia(string mamathang)
        {

            return dal_GiaoHang.Load_DonGia(mamathang);
        }
        public List<BangGhep_GiaoHang> load_giaophang()
        {
            return dal_GiaoHang.LoadDL_giaohang();
        }

        public List<CT_GiaoHang> load_CTgiaohang()
        {
            return dal_GiaoHang.LoadDL_CTgiaohang();
        }

        public List<CT_GiaoHang> load_CTgiaohang1(string a)
        {
            return dal_GiaoHang.LoadDL_CTgiaohang1(a);
        }
        public bool Them_GiaoHang(GIAOHANG hdb)
        {
            return dal_GiaoHang.them_GiaoHang(hdb);
        }
        public bool Ktkc(GIAOHANG hdb)
        {
            return dal_GiaoHang.ktkc(hdb);
        }
        public bool Them_CTGiaoHang(CHITIETGIAOHANG cthdb)
        {
            return dal_GiaoHang.them_CTGiaoHang(cthdb);
        }
        public bool Ktkc_ctpnh(CHITIETGIAOHANG cthdb)
        {
            return dal_GiaoHang.ktkc_ctpnh(cthdb);
        }

        public int laysoluong(string maphieudat)
        {
            return dal_GiaoHang.laysomathangGIAO(maphieudat);
        }

        public bool Sua_GH(GIAOHANG mh)
        {
            return dal_GiaoHang.sua_GH(mh);
        }
    }
}
