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

        public string Loaddata_LoaiMatHang(string mactmathang)
        {
            if (dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault() != null)
            {
                string maphieu = dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault().MAMATHANG.ToString();
                if (dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault() != null)
                {
                    return dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault().MALOAIMATHANG.ToString();
                }
            }
            return null;
        }
        public string Loaddata_TenLoaiMatHang(string mact)
        {
            if(dal_data.LOAIMATHANGs.Where(t => t.MALOAIMATHANG == mact).FirstOrDefault()!=null)
            return dal_data.LOAIMATHANGs.Where(t => t.MALOAIMATHANG == mact).FirstOrDefault().TENLOAIMATHANG.ToString();


            return null;
        }

        public String Load_MatHang(string mamathang)
        {


            var dulieu = (from s in dal_data.CTPHIEUDATHANGNSXes
                          from ss in dal_data.MATHANGs
                          where s.MAMATHANG == ss.MAMATHANG 
                          select ss.TENMATHANG).FirstOrDefault();
            return dulieu.ToString();
        }
        public String Load_DonGia(string mamathang)
        {
            if (dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mamathang).FirstOrDefault() != null)
                return dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mamathang).FirstOrDefault().GIA.ToString();


            return null;
        }

        public String Load_DonViTinh(string mactmathang)
        {
            if (dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault() != null)
            {
                string maphieu = dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault().MAMATHANG.ToString();
                if (dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault() != null)
                {
                    return dal_data.MATHANGs.Where(t => t.MAMATHANG == maphieu).FirstOrDefault().MADVT.ToString();
                }
            }
            return null;
        }

        public String Load_NSX(string mactmathang)
        {
            if (dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault() != null)
            {
                string maphieu = dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mactmathang).FirstOrDefault().MAPDHNSX.ToString();
                if (dal_data.PHIEUDATHANGNSXes.Where(t => t.MAPDHNSX == maphieu).FirstOrDefault() != null)
                {
                    return dal_data.PHIEUDATHANGNSXes.Where(t => t.MAPDHNSX == maphieu).FirstOrDefault().MANSX.ToString();
                }
            }
            return null;
        }
        public string Load_SoLuong(string mact)
        {
            if(dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mact).FirstOrDefault()!=null)
            return dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MACTPHIEUDATHANG == mact).FirstOrDefault().SOLUONG.ToString();
            return null;
        }

        public List<PHIEUDATHANGNSX> Load_MaPDHNSX()
        {
            return dal_data.PHIEUDATHANGNSXes.Select(t =>t).ToList<PHIEUDATHANGNSX>();
        }
        public List<CTPHIEUDATHANGNSX> Load_ChiTietPDNSX(string mact)
        {
            return dal_data.CTPHIEUDATHANGNSXes.Where(t => t.MAPDHNSX == mact).ToList<CTPHIEUDATHANGNSX>();
        }

        public List<Bangghep_NhapHang> LoadDL_nhaphang()
        {
            var nhaphang = from s in dal_data.PHIEUNHAPHANGs
                            join q in dal_data.NHASANXUATs on s.MANSX equals (q.MANSX)

                            select new
                            {
                                s.MAPN,
                                s.MANV,
                                q.TENNSX,
                                s.NGAYNHAP,
                                s.SOLUONGMATHANG,
                                s.TONGTIENHANGNHAP,
                            };
            var kq = nhaphang.ToList().ConvertAll(t => new Bangghep_NhapHang()
            {
                MAPN1 = t.MAPN,
                MANV1 = t.MANV,
                TENNSX1 = t.TENNSX,
                NGAYNHAP1 =Convert.ToString( t.NGAYNHAP),
                SOLUONGMATHANG1 = Convert.ToString(t.SOLUONGMATHANG),
                TONGTIENHANGNHAP1 = Convert.ToString(t.TONGTIENHANGNHAP)
            });
            return kq.ToList<Bangghep_NhapHang>();
        }

        public List<CT_NhapHang> LoadDL_CTnhaphang()
        {
            var CTnhaphang = from s in dal_data.CHITIETPHIEUNHAPHANGs
                           join q in dal_data.CTPHIEUDATHANGNSXes on s.MACTPHIEUDATHANG equals (q.MACTPHIEUDATHANG)
                            join Qq in dal_data.MATHANGs on q.MAMATHANG equals (Qq.MAMATHANG)
                           select new
                           {
                               s.MACTPN,
                               s.MACTPHIEUDATHANG,
                               Qq.TENMATHANG,
                               s.SOLUONGMH,
                               s.THANHTIENCTPNH
                           };
            var kq = CTnhaphang.ToList().ConvertAll(t => new CT_NhapHang()
            {
                MACTPN1 = t.MACTPN,
                MACTPHIEUDATHANG1 = t.MACTPHIEUDATHANG,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONGMH1 = Convert.ToString(t.SOLUONGMH),
                THANHTIENCTPNH1 = Convert.ToString(t.THANHTIENCTPNH)
            });
            return kq.ToList<CT_NhapHang>();
        }

        public List<CT_NhapHang> LoadDL_CTnhaphang1(string a)
        {
            var CTnhaphang = from s in dal_data.CHITIETPHIEUNHAPHANGs where s.MAPN==a
                             join q in dal_data.CTPHIEUDATHANGNSXes on s.MACTPHIEUDATHANG equals (q.MACTPHIEUDATHANG)
                             join Qq in dal_data.MATHANGs on q.MAMATHANG equals (Qq.MAMATHANG)
                             
                             select new
                             {
                                 s.MACTPN,
                                 s.MACTPHIEUDATHANG,
                                 Qq.TENMATHANG,
                                 s.SOLUONGMH,
                                 s.THANHTIENCTPNH
                             };
            var kq = CTnhaphang.ToList().ConvertAll(t => new CT_NhapHang()
            {
                MACTPN1 = t.MACTPN,
                MACTPHIEUDATHANG1 = t.MACTPHIEUDATHANG,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONGMH1 = Convert.ToString(t.SOLUONGMH),
                THANHTIENCTPNH1 = Convert.ToString(t.THANHTIENCTPNH)
            });
            return kq.ToList<CT_NhapHang>();
        }

        public bool them_PhieuNhapHang(PHIEUNHAPHANG hdb)
        {
            try
            {
                dal_data.PHIEUNHAPHANGs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(PHIEUNHAPHANG hdb)
        {
            int r = dal_data.PHIEUNHAPHANGs.Count(t => t.MAPN == hdb.MAPN.ToString());
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
        public bool them_CTPNhapHang(CHITIETPHIEUNHAPHANG cthdb)
        {
            try
            {

                dal_data.CHITIETPHIEUNHAPHANGs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cthdb);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc_ctpnh(CHITIETPHIEUNHAPHANG cthdb)
        {
            int r = dal_data.CHITIETPHIEUNHAPHANGs.Count(t => t.MACTPN == cthdb.MACTPN.ToString());
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

        public String layten(String sdt)
        {
            var lm = (from k in dal_data.NHASANXUATs where k.MANSX == sdt select k.TENNSX).FirstOrDefault();
            String s = lm.ToString();
            return lm.ToString();
        }

    }
}
