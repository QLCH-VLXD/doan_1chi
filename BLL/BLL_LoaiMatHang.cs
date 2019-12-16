using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_LoaiMatHang
    {
        DAL_LoaiMatHang dal_LoaiMatHang = new DAL_LoaiMatHang();

        public List<LOAIMATHANG> load_LoaiMatHang()
        {
            return dal_LoaiMatHang.Loaddata_LoaiMatHang();

        }

        public int themloaiMH_dal(LOAIMATHANG lmh)
        {
            return dal_LoaiMatHang.themloaiMH(lmh);
        }

        public int SualoaiMH_dal(LOAIMATHANG lmh)
        {
            return dal_LoaiMatHang.SualoaiMH(lmh);
        }

        public int XoaloaiKMH_dal(LOAIMATHANG lmh)
        {
            return dal_LoaiMatHang.XoaloaiMH(lmh);
        }
    }
}
