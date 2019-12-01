using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_BanHang
    {
        DAL_BanHang dal_BanHang = new DAL_BanHang();
        public string Sinh_MaHoaDon_dal()
        {
            return dal_BanHang.SinhMaHoaDon();

        }

        public String XemTenKhachHang_dal(String makh)
        {
            return dal_BanHang.XemTenKhachHang(makh);

        }

        public List<LOAIMATHANG> load_loaiMatHang()
        {
            return dal_BanHang.Loaddata_LoaiMatHang();
        }

        public List<MATHANG> load_MatHang(String maLoaimathang)
        {
            return dal_BanHang.Load_MatHang(maLoaimathang);
        }

        public String Load_dongia(string mamathang)
        {
            
            return dal_BanHang.Load_DonGia(mamathang);
        }

        public String Load_donvitinh(string mamathang)
        {

            return dal_BanHang.Load_DonViTinh(mamathang);
        }

        public List<NHASANXUAT> load_NSX(String maLoaimathang)
        {
            return dal_BanHang.Load_NSX(maLoaimathang);
        }

        public List<BangGhep_HoaDonBan> load_HDB()
        {
            return dal_BanHang.LoadDL();
        }

        public List<CHITIET_HOADON> load_CTHDB()
        {
            return dal_BanHang.LoadDL_CTHoaDonBan();
        }

        public List<CHITIET_HOADON> load_CTHDB1(String f)
        {
            return dal_BanHang.LoadDL_CTHoaDonBan1(f);
        }

        public String Load_TinhtrangMH(string mamathang)
        {

            return dal_BanHang.Load_tinhtrangMH(mamathang);
        }
        public bool them_HDB(HOADONBAN hdb)
        {
            return dal_BanHang.them_HoaDonBan(hdb);
        }

        public bool KTKC (HOADONBAN hdb)
        {
            return dal_BanHang.ktkc(hdb);
        }
        public string LAYMA(string sdt)
        {
            return dal_BanHang.layma(sdt);
        }

        public bool them_CTHDB(CHITIETHOADONBAN cthdb)
        {
            return dal_BanHang.them_CTHoaDonBan(cthdb);
        }
        public bool KTKC_cthdb(CHITIETHOADONBAN cthdb)
        {
            return dal_BanHang.ktkc_cthdb(cthdb);
        }
        public bool Sua_CTHDB(CHITIETHOADONBAN cthdb)
        {
            return dal_BanHang.sua_CTHDB(cthdb);
        }
        public bool Xoa_CTHDB(CHITIETHOADONBAN cthdb)
        {
            return dal_BanHang.xoa_CTHDB(cthdb);
        }

        public bool Sua_HDB(HOADONBAN hdb)
        {
            return dal_BanHang.sua_HDB(hdb);
        }
    }
}
