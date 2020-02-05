using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_GiaoHang
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaHoaDon()
        {
            return dal_data.SINHMA_HDN();

        }
        public string XemTenKhachHang(String makh)
        {
            return dal_data.XEM_TENKH(makh);
        }
        public List<NHANVIEN> Load_MaMV()
        {
            return dal_data.NHANVIENs.Select(t => t).ToList<NHANVIEN>();
        }

        public List<HOADONBAN> Load_HDB()
        {
            return dal_data.HOADONBANs.Select(t => t).ToList<HOADONBAN>();
        }
        public List<CHITIETHOADONBAN> Load_CTHDB()
        {
            return dal_data.CHITIETHOADONBANs.Select(t => t).ToList<CHITIETHOADONBAN>();
        }
        public List<CHITIETHOADONBAN> Load_CTHDB1(string mact)
        {
            return dal_data.CHITIETHOADONBANs.Where(t => t.MAHDB == mact).ToList<CHITIETHOADONBAN>();
        }
        public String Load_MatHang(string mamathang)
        {


            var dulieu = (from s in dal_data.CHITIETHOADONBANs
                          from ss in dal_data.MATHANGs
                          where s.MAMATHANG == ss.MAMATHANG
                          select ss.TENMATHANG).FirstOrDefault();
            return dulieu.ToString();
        }
        public string Loaddata_LoaiMatHang(string mactmathang)
        {
            if (dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mactmathang).FirstOrDefault() != null)
            {
                string maphieu = dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mactmathang).FirstOrDefault().MAMATHANG.ToString();
                if (dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault() != null)
                {
                    return dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault().MALOAIMATHANG.ToString();
                }
            }
            return null;
        }
        public string Load_SoLuong(string mact)
        {
            if (dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mact).FirstOrDefault() != null)
                return dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mact).FirstOrDefault().SOLUONGBAN.ToString();
            return null;
        }
        public string Load_SoLuong2(string mact)
        {
            //----------
            //if (dal_data.CHITIETGIAOHANGs.Where(t => t.MACTHDB == mact).FirstOrDefault() != null)
            //    return dal_data.CHITIETGIAOHANGs.Where(t => t.MACTHDB == mact).FirstOrDefault().SOLUONGMH.ToString();
            //return null;
            var dulieu = (from f in dal_data.CHITIETGIAOHANGs
                          where f.MACTHDB == mact.ToString()
                          select f.SOLUONGMH);
            dulieu.ToList<int?>();
            int? sum = dulieu.Sum();
            if (sum >= 0)
            {
                return sum.ToString();
            }
            return null;
        }
        public string Load_DonGia(string mamathang)
        {
            if (dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mamathang).FirstOrDefault() != null)
            {
                string maphieu = dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == mamathang).FirstOrDefault().MAMATHANG.ToString();
                if (dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault() != null)
                {
                    var dulieu = (from s in dal_data.DONGIAs
                                  where s.MAMATHANG == maphieu
                                  select s.GIA).FirstOrDefault();
                    return dulieu.ToString();
                }
            }

            return null;
        }


        public List<BangGhep_GiaoHang> LoadDL_giaohang()
        {
            var nhaphang = from s in dal_data.GIAOHANGs
                           join q in dal_data.NHANVIENs on s.MANVGIAOHANG equals (q.MANV)

                           select new
                           {
                               s.MAGIAOHANG,
                               s.MANVGIAOHANG,
                               s.NGAYGIOGIAOHANG,
                               s.SOLUONGGIAO,
                               s.TONGTIENHANGGIAO
                           };
            var kq = nhaphang.ToList().ConvertAll(t => new BangGhep_GiaoHang()
            {
                MAGIAOHANG1 = t.MAGIAOHANG,
                MANVGIAOHANG1 = t.MANVGIAOHANG,
                NGAYGIOGIAOHANG1 =Convert.ToString( t.NGAYGIOGIAOHANG),
                SOLUONGGIAO1 = Convert.ToString(t.SOLUONGGIAO),
                TONGTIENHANGGIAO1 = Convert.ToString(t.TONGTIENHANGGIAO),
            });
            return kq.ToList<BangGhep_GiaoHang>();
        }

        public List<CT_GiaoHang> LoadDL_CTgiaohang()
        {

            var CTgiaohang = from s in dal_data.CHITIETGIAOHANGs
                             join q in dal_data.CHITIETHOADONBANs on s.MACTHDB equals (q.MACTHDB)
                             join Qq in dal_data.MATHANGs on q.MAMATHANG equals (Qq.MAMATHANG)
                             select new
                                {
                                    s.MACTGIAOHNAG,
                                    s.MAGIAOHANG,
                                    s.MACTHDB,
                                    s.SOLUONGMH,
                                    s.THANHTIEN
                                };
            var kq = CTgiaohang.ToList().ConvertAll(t => new CT_GiaoHang()
            {
                MACTGIAOHNAG1 = t.MACTGIAOHNAG,
                MAGIAOHANG1 = t.MAGIAOHANG,
                MACTHDB1 = t.MACTHDB,
                SOLUONGMH1 = Convert.ToString(t.SOLUONGMH),
                THANHTIEN1 = Convert.ToString(t.THANHTIEN)
            });
            return kq.ToList<CT_GiaoHang>();
        }

        public List<CT_GiaoHang> LoadDL_CTgiaohang1(string a)
        {
            var CTnhaphang = from s in dal_data.CHITIETGIAOHANGs
                             where s.MAGIAOHANG == a
                             join q in dal_data.CHITIETHOADONBANs on s.MACTHDB equals (q.MACTHDB)
                             join Qq in dal_data.MATHANGs on q.MAMATHANG equals (Qq.MAMATHANG)
                             select new
                             {
                                 s.MACTGIAOHNAG,
                                 s.MAGIAOHANG,
                                 s.MACTHDB,
                                 s.SOLUONGMH,
                                 s.THANHTIEN
                             };
            var kq = CTnhaphang.ToList().ConvertAll(t => new CT_GiaoHang()
            {
                MACTGIAOHNAG1 = t.MACTGIAOHNAG,
                MAGIAOHANG1 = t.MAGIAOHANG,
                MACTHDB1 = t.MACTHDB,
                SOLUONGMH1 = Convert.ToString(t.SOLUONGMH),
                THANHTIEN1 = Convert.ToString(t.THANHTIEN)
            });
            return kq.ToList<CT_GiaoHang>();
        }

        public bool them_GiaoHang(GIAOHANG hdb)
        {
            try
            {
                dal_data.GIAOHANGs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(GIAOHANG hdb)
        {
            int r = dal_data.GIAOHANGs.Count(t => t.MAGIAOHANG == hdb.MAGIAOHANG.ToString());
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
        public bool them_CTGiaoHang(CHITIETGIAOHANG cthdb)
        {
            try
            {

                dal_data.CHITIETGIAOHANGs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cthdb);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc_ctpnh(CHITIETGIAOHANG cthdb)
        {
            int r = dal_data.CHITIETGIAOHANGs.Count(t => t.MACTGIAOHNAG == cthdb.MACTGIAOHNAG.ToString());
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

        public int laysomathangGIAO(String s)
        {
            var dulieu = (from f in dal_data.CHITIETHOADONBANs
                          from d in dal_data.CHITIETGIAOHANGs
                          where d.MACTGIAOHNAG == s.ToString() && f.MACTHDB == d.MACTHDB
                          select f.SOLUONGBAN).FirstOrDefault();
            return Convert.ToInt32(dulieu.ToString());
        }

        public bool sua_GH(GIAOHANG mh)
        {
            try
            {
                var aa = dal_data.GIAOHANGs.Where(t => t.MAGIAOHANG == mh.MAGIAOHANG.ToString()).FirstOrDefault();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, aa);
                String s = aa.ToString();
                aa.SOLUONGGIAO = mh.SOLUONGGIAO;
                aa.TONGTIENHANGGIAO = mh.TONGTIENHANGGIAO;
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // //////////////////////////////
        public int laysoluong_ctdathang(String s)
        {
            var dulieu = (from f in dal_data.CHITIETHOADONBANs
                          where f.MAHDB == s.ToString()
                          select f.SOLUONGBAN);
            dulieu.ToList<int?>();
            int? sum = dulieu.Sum();
            if (sum >= 0)
            {
                return Convert.ToInt32(sum.ToString());
            }

            return 0;
        }

        public int laysoluong_ctdathang1(String s)
        {
            var dulieu = (from f in dal_data.CHITIETHOADONBANs
                          where f.MACTHDB == s.ToString()
                          select f.SOLUONGBAN);
            dulieu.ToList<int?>();
            int? sum = dulieu.Sum();
            if (sum >= 0)
            {
                return Convert.ToInt32(sum.ToString());
            }

            return 0;
        }

        public int laysoluong_ctdathang2(String s)
        {
            var dulieu = (from f in dal_data.CHITIETHOADONBANs
                          where f.MACTHDB == s.ToString()
                          select f.SOLUONGBAN);
            dulieu.ToList<int?>();
            int? sum = dulieu.Sum();
            if (sum >= 0)
            {
                return Convert.ToInt32(sum.ToString());
            }

            return 0;
        }
    }
}
