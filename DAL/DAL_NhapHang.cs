using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhapHang
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaNhapHang()
        {
            return dal_data.SINHMA_HDN();

        }

        public List<LOAIMATHANG> Loaddata_LoaiMatHang()
        {
            return dal_data.LOAIMATHANGs.Select(t => t).ToList<LOAIMATHANG>();

        }

        public List<MATHANG> Load_MatHang(string maloaimathang)
        {
            return dal_data.MATHANGs.Where(t => t.MALOAIMATHANG == maloaimathang).ToList<MATHANG>();
        }
        public String Load_DonGia(string mamathang)
        {
            var dulieu = (from s in dal_data.DONGIAs
                          where s.MAMATHANG == mamathang
                          select s.GIA).FirstOrDefault();
            return dulieu.ToString();
        }

        public String Load_DonViTinh(string mamathang)
        {
            var dulieu = (from s in dal_data.MATHANGs
                          from ss in dal_data.DONVITINHs
                          where s.MADVT == ss.MADVT && s.MAMATHANG == mamathang
                          select ss.TENDVT).FirstOrDefault();
            return dulieu.ToString();
        }

        public List<NHASANXUAT> Load_NSX(string mamathang)
        {
            var dulieu = (from s in dal_data.MATHANGs
                          from ss in dal_data.NHASANXUATs
                          where s.MANSX == ss.MANSX && s.MAMATHANG == mamathang
                          select ss);
            return dulieu.ToList<NHASANXUAT>();
        }

        public List<PHIEUDATHANGNSX> Load_MaPDHNSX()
        {
            return dal_data.PHIEUDATHANGNSXes.Select(t =>t).ToList<PHIEUDATHANGNSX>();
        }

       

        



    }
}
