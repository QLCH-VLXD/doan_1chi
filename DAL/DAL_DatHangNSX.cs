using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DatHangNSX
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaDatHangNSX()
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
        public String Load_tinhtrangMH(string mamathang)
        {
            if (mamathang != null)
            {
                var dulieu = (from s in dal_data.MATHANGs
                              where s.MAMATHANG == mamathang
                              select s.TINHTRANG).FirstOrDefault();
                return dulieu.ToString();
            }
            else
                return null;
        }

        public List<BangGhep_DatHangNSX> LoadDL_DHNSX()
        {
            var dathangnsx = from s in dal_data.PHIEUDATHANGNSXes
                             join q in dal_data.NHASANXUATs on s.MANSX equals (q.MANSX)
                             where s.MANSX == q.MANSX
                            select new
                            {
                                s.MAPDHNSX,
                                s.MANV,
                                q.TENNSX,
                                s.NGAYLAP,
                                s.TONGTIENHANGDAT,
                                s.SOTIENTRATRUOC,
                            };
            var kq = dathangnsx.ToList().ConvertAll(t => new BangGhep_DatHangNSX()
            {
                MAPDHNSX1 = t.MAPDHNSX,
                MANV1 = t.MANV,
                TENNSX1 = t.TENNSX,
                NGAYLAP1 = Convert.ToString(t.NGAYLAP),
                TONGTIENHANGDAT1 = Convert.ToString(t.TONGTIENHANGDAT),
                SOTIENTRATRUOC1 = Convert.ToString(t.SOTIENTRATRUOC),
            });
            return kq.ToList<BangGhep_DatHangNSX>();
        }

        public List<CHITIET_DATHANGNSX> LoadDL_CTDatHangNSX(String j)
        {
            var CT_dathangnsx = from s in dal_data.CTPHIEUDATHANGNSXes
                               from q in dal_data.MATHANGs
                               from dg in dal_data.DONGIAs
                               where s.MAMATHANG == q.MAMATHANG && dg.MAMATHANG == q.MAMATHANG && s.MAPDHNSX == j

                               select new
                               {
                                   s.MACTPHIEUDATHANG,
                                   q.TENMATHANG,
                                   s.SOLUONG,
                                   dg.GIA,
                                   s.THANHTIEN

                               };
            var kq = CT_dathangnsx.ToList().ConvertAll(t => new CHITIET_DATHANGNSX()
            {
                MACTPHIEUDATHANG1 = t.MACTPHIEUDATHANG,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONG1 = Convert.ToString(t.SOLUONG),
                GIA1 = Convert.ToString(t.GIA),
                THANHTIEN1 = Convert.ToString(t.THANHTIEN)
            });


            return kq.ToList<CHITIET_DATHANGNSX>();
        }
        public List<CHITIET_DATHANGNSX> LoadDL_CTDatHangNSX1()
        {
            var CT_dathangnsx = from s in dal_data.CTPHIEUDATHANGNSXes
                                from q in dal_data.MATHANGs
                                from dg in dal_data.DONGIAs
                                where s.MAMATHANG == q.MAMATHANG && dg.MAMATHANG == q.MAMATHANG 

                                select new
                                {
                                    s.MACTPHIEUDATHANG,
                                    q.TENMATHANG,
                                    s.SOLUONG,
                                    dg.GIA,
                                    s.THANHTIEN

                                };
            var kq = CT_dathangnsx.ToList().ConvertAll(t => new CHITIET_DATHANGNSX()
            {
                MACTPHIEUDATHANG1 = t.MACTPHIEUDATHANG,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONG1 = Convert.ToString(t.SOLUONG),
                GIA1 = Convert.ToString(t.GIA),
                THANHTIEN1 = Convert.ToString(t.THANHTIEN)
            });


            return kq.ToList<CHITIET_DATHANGNSX>();
        }

        public bool them_DonDatHangNSX(PHIEUDATHANGNSX hdb)
        {
            try
            {
                dal_data.PHIEUDATHANGNSXes.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(PHIEUDATHANGNSX hdb)
        {
            int r = dal_data.PHIEUDATHANGNSXes.Count(t => t.MAPDHNSX == hdb.MAPDHNSX.ToString());
            try
            {
                if (r == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// CT hoa don ban
        public bool them_CTDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            try
            {
                dal_data.CTPHIEUDATHANGNSXes.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cthdb);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc_ctDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            int r = dal_data.CTPHIEUDATHANGNSXes.Count(t => t.MACTPHIEUDATHANG == cthdb.MACTPHIEUDATHANG.ToString());
            try
            {
                if (r == 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool sua_CTDHNSX(CTPHIEUDATHANGNSX mh)
        {
            try
            {
                var aa = dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mh.MACTPHIEUDATHANG.ToString()).FirstOrDefault();
                aa.MAMATHANG = mh.MAMATHANG;
                aa.SOLUONG = mh.SOLUONG;
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa_CTDHNSX(CTPHIEUDATHANGNSX pmh)
        {
            try
            {
                var mh = dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == pmh.MACTPHIEUDATHANG.ToString()).FirstOrDefault();
                var mh2 = (from s in dal_data.CTPHIEUDATHANGNSXes where s.MACTPHIEUDATHANG == pmh.MACTPHIEUDATHANG select s.MAMATHANG).FirstOrDefault();
                var mh3 = (from s in dal_data.CTPHIEUDATHANGNSXes where s.MACTPHIEUDATHANG == pmh.MACTPHIEUDATHANG select s.MAPDHNSX).FirstOrDefault();
                mh.MAPDHNSX = mh3.ToString();
                mh.MAMATHANG = mh2.ToString();
                mh.SOLUONG = pmh.SOLUONG;
                mh.THANHTIEN = pmh.THANHTIEN;
                dal_data.CTPHIEUDATHANGNSXes.DeleteOnSubmit(mh);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public String layma(String sdt)
        {
            var lm = (from k in dal_data.NHASANXUATs where k.TENNSX == sdt select k.MANSX).FirstOrDefault();
            String s = lm.ToString();
            return lm.ToString();
        }

        public bool sua_pdhnsx(PHIEUDATHANGNSX mh)
        {
            try
            {
                var aa = dal_data.PHIEUDATHANGNSXes.Where(t => t.MAPDHNSX == mh.MAPDHNSX.ToString()).FirstOrDefault();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, aa);
                String s = aa.ToString();
                aa.TONGTIENHANGDAT = mh.TONGTIENHANGDAT;
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
