using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GiaoHang
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaHoaDon()
        {
            return dal_data.SINHMA_HDN();

        }
        public string XemTenKhachHang(String makh)
        {
            return dal_data.XEM_TENKH(makh);

        }




    }
}
