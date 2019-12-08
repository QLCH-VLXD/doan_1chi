using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_ThongKe
    {
        DAL_ThongKe dAL_ThongKe = new DAL_ThongKe();

        public List<PHIEUNHAPHANG> Load_nhapHang()
        {
            return dAL_ThongKe.Load_NhapHang();
        }
    }
}
