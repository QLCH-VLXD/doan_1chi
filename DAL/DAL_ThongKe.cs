using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThongKe
    {

        linQDataContext dal_data = new linQDataContext();

        public List<PHIEUNHAPHANG> Load_NhapHang()
        {
            return dal_data.PHIEUNHAPHANGs.Select(t => t).ToList<PHIEUNHAPHANG>();
        }

    }
}
