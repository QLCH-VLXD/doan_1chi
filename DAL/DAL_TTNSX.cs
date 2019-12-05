using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TTNSX
    {
        linQDataContext DAL_Data = new linQDataContext();

        public List<NHASANXUAT> Loaddata_TTNSX()
        {
            return DAL_Data.NHASANXUATs.Select(t => t).ToList<NHASANXUAT>();

        }
    }
}
