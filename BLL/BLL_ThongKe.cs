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
        DAL_ThongKe dal_ThongKe = new DAL_ThongKe();
        //public List<BangGhep_ThongKe_TonKho> load_TKTonKho()
        //{
        //    return dal_ThongKe.load_TK_TonKho();
        //}


        public List<TKHANGSAPHET> load_TKsaphet()
        {
            return dal_ThongKe.Loaddata_tksaphet();
        }
        public List<TKHANGTONKHO> load_TKtonkho()
        {
            return dal_ThongKe.Loaddata_tktonkho();
        }
        public List<BangGhep_ThongKe_SapHet> load_TKSapHet()
        {
            return dal_ThongKe.load_TK_SapHet();
        }
        public List<BangGhep_ThongKe_TonKho> load_TKTonKho()
        {
            return dal_ThongKe.load_TK_TonKho();
        }
        public bool Luu_TK_saphet_tk(THONGKE c)
        {
            return dal_ThongKe.luu_tk_saphet_tk(c);
        }

        public bool Luu_TK_saphet_tksh(TKHANGSAPHET cthdb)
        {
            return dal_ThongKe.luu_tk_saphet_tksh(cthdb);
        }
        public bool Luu_TK_tonkho_tktk(TKHANGTONKHO cthdb)
        {
            return dal_ThongKe.luu_tk_tonkho_tktk(cthdb);
        }

        public string Test(DateTime a)
        {
            return dal_ThongKe.test(a);
        }

        public bool Them_tk()
        {
            return dal_ThongKe.Them_TK();
        }

        public List<TKHANGSAPHET> tk()
        {
            return dal_ThongKe.tk();
        }

        public List<TKHANGSAPHET> search_TKSH(DateTime a)
        {
            return dal_ThongKe.Search_TKSH(a);
        }

        public List<TKHANGTONKHO> search_TKTK(DateTime a)
        {
            return dal_ThongKe.Search_TKTK(a);
        }


    }
}
