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


    }
}
