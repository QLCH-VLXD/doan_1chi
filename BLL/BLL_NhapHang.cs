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

        public List<LOAIMATHANG> load_loaiMatHang()
        {
            return dAL_NhapHang.Loaddata_LoaiMatHang();
        }

        public List<MATHANG> load_MatHang(String maLoaimathang)
        {
            return dAL_NhapHang.Load_MatHang(maLoaimathang);
        }

        public String Load_dongia(string mamathang)
        {

            return dAL_NhapHang.Load_DonGia(mamathang);
        }

        public String Load_donvitinh(string mamathang)
        {

            return dAL_NhapHang.Load_DonViTinh(mamathang);
        }

        public List<NHASANXUAT> load_NSX(String maLoaimathang)
        {
            return dAL_NhapHang.Load_NSX(maLoaimathang);
        }

        public List<PHIEUDATHANGNSX> load_maPNHNSX()
        {
            return dAL_NhapHang.Load_MaPDHNSX();
        }
    }
}
