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

        public string XemTenKhachHang_dal(String makh)
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

        public List<HOADONBAN1> load_HDB()
        {
            return dal_BanHang.LoadDL();
        }

        public List<CHITIETHOADONBAN> load_CTHDB()
        {
            return dal_BanHang.LoadDL_CTHoaDonBan();
        }

        public String Load_TinhtrangMH(string mamathang)
        {

            return dal_BanHang.Load_tinhtrangMH(mamathang);
        }

    }
}
