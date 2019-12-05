using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_TTKhachHang
    {
        DAL_TTKhachHang dal_TTKhachHang = new DAL_TTKhachHang();
        
        public List<LOAIKHACHHANG> load_LoaiKhachHang()
        {
            return dal_TTKhachHang.Loaddata_LoaiKhachHang();
        }

        public List<KHACHHANG> load_KhachHang()
        {
            return dal_TTKhachHang.Loaddata_KhachHang();
        }
        public List<BangGhep_KHACHHANG> LoadDL_khachhang()
        {
            return dal_TTKhachHang.Loaddl_khachhang();
        }

        public string Sinh_MaLoaiKH_dal()
        {
            return dal_TTKhachHang.SinhMaHoaDon();
        }
        public bool them_loaikh(LOAIKHACHHANG hdb)
        {
            return dal_TTKhachHang.them_LoaiKH(hdb);
        }
        public bool KTKC(LOAIKHACHHANG hdb)
        {
            return dal_TTKhachHang.ktkc(hdb);
        }
        public bool sua_loaikh(LOAIKHACHHANG hdb)
        {
            return dal_TTKhachHang.sua_LoaiKH(hdb);
        }
        public bool xoa_loaikh(LOAIKHACHHANG hdb)
        {
            return dal_TTKhachHang.xoa_LoaiKH(hdb);
        }

        //////////////////////////////////////////////////
        public bool them_kh(KHACHHANG hdb)
        {
            return dal_TTKhachHang.them_KH(hdb);
        }
        public bool KTKC_kh(KHACHHANG hdb)
        {
            return dal_TTKhachHang.ktkc_kh(hdb);
        }
        public bool sua_kh(KHACHHANG hdb)
        {
            return dal_TTKhachHang.sua_KH(hdb);
        }
        public bool xoa_kh(KHACHHANG hdb)
        {
            return dal_TTKhachHang.xoa_KH(hdb);
        }
    }
}
