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


        public string Sinh_Makh_dal()
        {
            return dal_TTKhachHang.SinhMaHoaDon();

        }

        public List<KHACHHANG> load_TTKhachHang()
        {
            return dal_TTKhachHang.Loaddata_TTKhachHang();

        }

        public List<LOAIKHACHHANG> load_LoaiKhachHang()
        {
            return dal_TTKhachHang.Loaddata_LoaiKhachHang();

        }

        public int them_dal(KHACHHANG kh)
        {
            return dal_TTKhachHang.them(kh);
        }

        public int Sua_dal(KHACHHANG kh)
        {
            return dal_TTKhachHang.Sua(kh);
        }

        public int Xoa_dal(KHACHHANG kh)
        {
            return dal_TTKhachHang.Xoa(kh);
        }

        public int themloaiKH_dal(LOAIKHACHHANG lkh)
        {
            return dal_TTKhachHang.themloaiKH(lkh);
        }

        public int SualoaiKH_dal(LOAIKHACHHANG lkh)
        {
            return dal_TTKhachHang.SualoaiKH(lkh);
        }

        public int XoaloaiKH_dal(LOAIKHACHHANG lkh)
        {
            return dal_TTKhachHang.XoaloaiKH(lkh);
        }


    }
}
