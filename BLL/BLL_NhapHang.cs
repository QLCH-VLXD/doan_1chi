using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_NhapHang
    {
        DAL_NhapHang dAL_NhapHang = new DAL_NhapHang();

        public string Sinh_MaNhapHang_dal()
        {
            return dAL_NhapHang.SinhMaNhapHang();
        }

        public string load_loaiMatHang(String mact)
        {
            return dAL_NhapHang.Loaddata_LoaiMatHang(mact);
        }
      public string load_tenloaiMatHang(String mact)
        {
            return dAL_NhapHang.Loaddata_TenLoaiMatHang(mact);
        }
        public string load_SoLuong (string mact)
        {
            return dAL_NhapHang.Load_SoLuong(mact);
        }
        public String load_MatHang(string mact)
        {
            return dAL_NhapHang.Load_MatHang(mact);
        }

        public String Load_dongia(string mamathang)
        {

            return dAL_NhapHang.Load_DonGia(mamathang);
        }

        public String Load_donvitinh(string mamathang)
        {

            return dAL_NhapHang.Load_DonViTinh(mamathang);
        }

        public string load_NSX(String maLoaimathang)
        {
            return dAL_NhapHang.Load_NSX(maLoaimathang);
        }

        public List<PHIEUDATHANGNSX> load_maPNHNSX()
        {
            return dAL_NhapHang.Load_MaPDHNSX();
        }
        public List<CTPHIEUDATHANGNSX>load_ChiTietPDNSX(string mact)
        {
            return dAL_NhapHang.Load_ChiTietPDNSX(mact);
        }
        public List<Bangghep_NhapHang> load_nhaphang()
        {
            return dAL_NhapHang.LoadDL_nhaphang();
        }
        public List<CT_NhapHang> load_CTnhaphang()
        {
            return dAL_NhapHang.LoadDL_CTnhaphang();
        }

        public List<CT_NhapHang> load_CTnhaphang1(string a)
        {
            return dAL_NhapHang.LoadDL_CTnhaphang1(a);
        }

        public bool them_PNH(PHIEUNHAPHANG hdb)
        {
            return dAL_NhapHang.them_PhieuNhapHang(hdb);
        }

        public bool KTKC(PHIEUNHAPHANG hdb)
        {
            return dAL_NhapHang.ktkc(hdb);
        }
       

        public bool them_CTPNH(CHITIETPHIEUNHAPHANG cthdb)
        {
            return dAL_NhapHang.them_CTPNhapHang(cthdb);
        }
        public bool KTKC_CTPNH(CHITIETPHIEUNHAPHANG cthdb)
        {
            return dAL_NhapHang.ktkc_ctpnh(cthdb);
        }
        public string LAYten(string sdt)
        {
            return dAL_NhapHang.layten(sdt);
        }
    }
}
