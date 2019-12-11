using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_TTNSX
    {
        DAL_TTNSX dal_TTNSX = new DAL_TTNSX();

        public string Sinh_Mansx_dal()
        {
            return dal_TTNSX.SinhMaNSX();

        }
        public List<NHASANXUAT> load_TTNSX()
        {
            return dal_TTNSX.Loaddata_TTNSX();

        }

        public int themnsx(NHASANXUAT nv)
        {
           
            return dal_TTNSX.them(nv);

        }
        public int suansx(NHASANXUAT nv)
        {

            return dal_TTNSX.Sua(nv);

        }
        public int xoansx(NHASANXUAT nv)
        {

            return dal_TTNSX.Xoa(nv);

        }









    }
}
