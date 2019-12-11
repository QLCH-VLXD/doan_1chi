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

        public string SinhMaNSX()
        {
            return DAL_Data.SINHMA_HDN();

        }

        public List<NHASANXUAT> Loaddata_TTNSX()
        {
            return DAL_Data.NHASANXUATs.Select(t => t).ToList<NHASANXUAT>();

        }

        public int them(NHASANXUAT nv)
        {
            int result = 0;
            if (IsExit(nv.MANSX))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.NHASANXUATs.InsertOnSubmit(nv);
                context.SubmitChanges();

            }

            return result;

        }
        public bool IsExit(string manv)
        {
            linQDataContext Dal_data = new linQDataContext();
            return Dal_data.NHASANXUATs.Any(t => t.MANSX.ToUpper() == manv.ToUpper());

        }

        public int Sua(NHASANXUAT nv)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            NHASANXUAT k = context.NHASANXUATs.FirstOrDefault(m => m.MANSX.ToUpper() == nv.MANSX.ToUpper());

            if (k != null)
            {
                k.MANSX = nv.MANSX;
                k.TENNSX = nv.TENNSX;
                k.SDT = nv.SDT;
                k.EMAIL = nv.EMAIL;
                k.DIACHI = nv.DIACHI;
                result = 1;

            }
            context.SubmitChanges();


            return result;
            
        }

        public int Xoa(NHASANXUAT nv)
        {
            int result = 0;

            NHASANXUAT k = DAL_Data.NHASANXUATs.FirstOrDefault(m => m.MANSX.ToUpper() == nv.MANSX.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                DAL_Data.NHASANXUATs.DeleteOnSubmit(k);
                DAL_Data.SubmitChanges();
            }


            return result;
        }
    }
}
