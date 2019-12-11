using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_TTNhanVien
    {
        DAL_TTNhanVien dal_TTNhanVien = new DAL_TTNhanVien();


        public string Sinh_Manv_dal()
        {
            return dal_TTNhanVien.SinhMaNV();

        }

        public string XemTenNhanVien_dal(String manv)
        {
            return dal_TTNhanVien.XemTenNhanVien(manv);

        }
        public List<NHANVIEN> load_NhanVien()
        {
            return dal_TTNhanVien.Loaddata_NhanVien();

        }

        public List<CHUCVU> load_ChucVu()
        {
            return dal_TTNhanVien.Loaddata_ChucVu();

        }

        public int them_dal(NHANVIEN nv)
        {
            return dal_TTNhanVien.them(nv);
        }

        public int Sua_dal(NHANVIEN nv)
        {
            return dal_TTNhanVien.Sua(nv);
        }

        public int Xoa_dal(NHANVIEN nv)
        {
            return dal_TTNhanVien.Xoa(nv);
        }

        public int themCV_dal(CHUCVU cv)
        {
            return dal_TTNhanVien.themCV(cv);
        }

        public int SuaCV_dal(CHUCVU cv)
        {
            return dal_TTNhanVien.SuaCV(cv);
        }

        public int XoaCV_dal(CHUCVU cv)
        {
            return dal_TTNhanVien.XoaCV(cv);
        }

    }
}
