using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiMatHang
    {
        linQDataContext DAl_data = new linQDataContext();
        public List<LOAIMATHANG> Loaddata_LoaiMatHang()
        {
            return DAl_data.LOAIMATHANGs.Select(t => t).ToList<LOAIMATHANG>();

        }

        public bool IsExit(string malmh)
        {
            linQDataContext DAl_data = new linQDataContext();
            return DAl_data.LOAIMATHANGs.Any(t => t.MALOAIMATHANG.ToUpper() == malmh.ToUpper());

        }

        public int themloaiMH(LOAIMATHANG lmh)
        {
            int result = 0;
            if (IsExit(lmh.MALOAIMATHANG))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.LOAIMATHANGs.InsertOnSubmit(lmh);
                context.SubmitChanges();

            }

            return result;
        }

        public int SualoaiMH(LOAIMATHANG lmh)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            LOAIMATHANG k = context.LOAIMATHANGs.FirstOrDefault(m => m.MALOAIMATHANG.ToUpper() == lmh.MALOAIMATHANG.ToUpper());

            if (k != null)
            {
                k.MALOAIMATHANG = lmh.MALOAIMATHANG;
                k.TENLOAIMATHANG = lmh.TENLOAIMATHANG;


                result = 1;

            }
            context.SubmitChanges();


            return result;
        }

        public int XoaloaiMH(LOAIMATHANG lmh)
        {
            int result = 0;

            LOAIMATHANG k = DAl_data.LOAIMATHANGs.FirstOrDefault(m => m.MALOAIMATHANG.ToUpper() == lmh.MALOAIMATHANG.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                DAl_data.LOAIMATHANGs.DeleteOnSubmit(k);
                DAl_data.SubmitChanges();
            }


            return result;
        }
    
}
}
