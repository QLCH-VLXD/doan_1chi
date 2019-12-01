using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DAL_BanHang
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaHoaDon()
        {
          return  dal_data.SINHMA_HDN();
            
        }

        public string XemTenKhachHang(String makh)
        {
            return dal_data.XEM_TENKH(makh);

        }

        public List<LOAIMATHANG> Loaddata_LoaiMatHang()
        {
            return dal_data.LOAIMATHANGs.Select(t => t).ToList<LOAIMATHANG>();

        }

        public List<MATHANG> Load_MatHang(string maloaimathang)
        {
            return dal_data.MATHANGs.Where(t => t.MALOAIMATHANG == maloaimathang ).ToList<MATHANG>();
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
        public String Load_DonGia(string mamathang)
        {
            var dulieu = (from s in dal_data.DONGIAs
                          where s.MAMATHANG==mamathang
                          select s.GIA).FirstOrDefault();
            return dulieu.ToString();
        }

        public String Load_DonViTinh(string mamathang)
        {
            var dulieu = (from s in dal_data.MATHANGs
                          from ss in dal_data.DONVITINHs
                          where s.MADVT == ss.MADVT && s.MAMATHANG==mamathang
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

        public List<BangGhep_HoaDonBan> LoadDL()
        {
            var hoadonban = from s in dal_data.HOADONBANs
                            join q in dal_data.KHACHHANGs on s.MAKH equals( q.MAKH)

                            select new
                            {
                                s.MAHDB,
                                s.MANV,
                                q.SDT,
                                q.HOTENKH,
                                s.NGAYLAP,
                                s.TONGSLSANPHAM,
                                s.TONGTIEN
                            };
            var kq = hoadonban.ToList().ConvertAll(t => new BangGhep_HoaDonBan()
            {
                MAHDB1 = t.MAHDB,
                MANV1 = t.MANV,
                SDT1 = t.SDT,
                HOTENKH1 = t.HOTENKH,
                NGAYLAP1 =Convert.ToString( t.NGAYLAP),
                TONGSLSANPHAM1 =Convert.ToString (t.TONGSLSANPHAM),
                TONGTIEN1 =Convert.ToString( t.TONGTIEN)
            });
           return kq.ToList<BangGhep_HoaDonBan>();
        }

        public List<CHITIET_HOADON> LoadDL_CTHoaDonBan()
        {
            var CT_hoadonban = from s in dal_data.CHITIETHOADONBANs
                                from q in dal_data.MATHANGs
                                from dg in dal_data.DONGIAs
                            where s.MAMATHANG == q.MAMATHANG && dg.MAMATHANG==q.MAMATHANG
                            select new
                            {
                                s.MACTHDB,
                                q.TENMATHANG,
                                s.SOLUONGBAN,
                                dg.GIA,
                                s.THANHTIEN
                                
                            };
            var kq = CT_hoadonban.ToList().ConvertAll(t => new CHITIET_HOADON()
            {
                MACTHDB1 = t.MACTHDB,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONGBAN1 =  Convert.ToString(t.SOLUONGBAN),
                GIA1 =Convert.ToString( t.GIA),
                THANHTIEN1 =Convert.ToString( t.THANHTIEN)
                
            });


            return kq.ToList<CHITIET_HOADON>();
        }

        public List<CHITIET_HOADON> LoadDL_CTHoaDonBan1(String j)
        {
            var CT_hoadonban = from s in dal_data.CHITIETHOADONBANs
                               from q in dal_data.MATHANGs
                               from dg in dal_data.DONGIAs
                               where s.MAMATHANG == q.MAMATHANG && dg.MAMATHANG == q.MAMATHANG && s.MAHDB==j
                              
                               select new
                               {
                                   s.MACTHDB,
                                   q.TENMATHANG,
                                   s.SOLUONGBAN,
                                   dg.GIA,
                                   s.THANHTIEN

                               };
            var kq = CT_hoadonban.ToList().ConvertAll(t => new CHITIET_HOADON()
            {
                MACTHDB1 = t.MACTHDB,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONGBAN1 = Convert.ToString(t.SOLUONGBAN),
                GIA1 = Convert.ToString(t.GIA),
                THANHTIEN1 = Convert.ToString(t.THANHTIEN)
            });


            return kq.ToList<CHITIET_HOADON>();
        }

        public bool them_HoaDonBan(HOADONBAN hdb)
        {
            try
            {
                dal_data.HOADONBANs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(HOADONBAN hdb)
        {
            int r = dal_data.HOADONBANs.Count(t => t.MAHDB == hdb.MAHDB.ToString());
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
        public bool them_CTHoaDonBan(CHITIETHOADONBAN cthdb)
        {
            try
            {
                
                dal_data.CHITIETHOADONBANs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cthdb);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc_cthdb(CHITIETHOADONBAN cthdb)
        {
            int r = dal_data.CHITIETHOADONBANs.Count(t => t.MACTHDB == cthdb.MACTHDB.ToString());
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
        public bool sua_CTHDB(CHITIETHOADONBAN mh)
        {
            try
            {
               var aa = dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mh.MACTHDB.ToString()).FirstOrDefault();
                aa.MAMATHANG = mh.MAMATHANG;
                aa.SOLUONGBAN = mh.SOLUONGBAN;
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool sua_HDB(HOADONBAN mh)
        {
            try
            {
                var aa = dal_data.HOADONBANs.Where(t => t.MAHDB == mh.MAHDB.ToString()).FirstOrDefault();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, aa);
                String s = aa.ToString();
                aa.TONGSLSANPHAM = mh.TONGSLSANPHAM;
                aa.TONGTIEN = mh.TONGTIEN;
                dal_data.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool xoa_CTHDB(CHITIETHOADONBAN pmh)
        {
            try
            {
                var mh = dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == pmh.MACTHDB.ToString()).FirstOrDefault();
                var mh2=( from s in dal_data.CHITIETHOADONBANs where s.MACTHDB==pmh.MACTHDB select s.MAMATHANG).FirstOrDefault();
                var mh3 = (from s in dal_data.CHITIETHOADONBANs where s.MACTHDB == pmh.MACTHDB select s.MAHDB).FirstOrDefault();
                mh.MAHDB = mh3.ToString();
                mh.MAMATHANG = mh2.ToString();
                mh.SOLUONGBAN = pmh.SOLUONGBAN;
                mh.THANHTIEN = pmh.THANHTIEN;
                dal_data.CHITIETHOADONBANs.DeleteOnSubmit(mh);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public String layma(String sdt)
        {
            var lm =( from k in dal_data.KHACHHANGs where k.SDT == sdt select k.MAKH).FirstOrDefault();
            String s = lm.ToString();
            return lm.ToString();
        }
    }
}
