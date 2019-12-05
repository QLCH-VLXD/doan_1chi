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


        public List<NHASANXUAT> load_TTNSX()
        {
            return dal_TTNSX.Loaddata_TTNSX();

        }
    }
}
