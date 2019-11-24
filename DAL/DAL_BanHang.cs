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

        public List<HOADONBAN1> LoadDL()
        {
            var hoadonban = from s in dal_data.HOADONBANs
                            from q in dal_data.KHACHHANGs
                          //  from nv in dal_data.NHANVIENs
                            where s.MAKH == q.MAKH 
                            //&& s.MANV==nv.MANV
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
            var kq = hoadonban.ToList().ConvertAll(t => new HOADONBAN1()
            {
                MAHDB = t.MAHDB,
                MANV = t.MANV,
                Sdt = t.SDT,
                TenKH = t.HOTENKH,
                NGAYLAP = t.NGAYLAP,
                TONGSLSANPHAM = t.TONGSLSANPHAM,
                TONGTIEN = t.TONGTIEN
            });


            kq.ToList<HOADONBAN1>();

            return kq;

        }

        public List<CHITIETHOADONBAN> LoadDL_CTHoaDonBan()
        {
            var CT_hoadonban = from s in dal_data.CHITIETHOADONBANs
                                from q in dal_data.MATHANGs
                                from dg in dal_data.DONGIAs
                                //  from nv in dal_data.NHANVIENs
                            where s.MAMATHANG == q.MAMATHANG && dg.MAMATHANG==q.MAMATHANG
                            //&& s.MANV==nv.MANV
                            select new
                            {
                                s.MACTHDB,
                                q.TENMATHANG,
                                s.SOLUONGBAN,
                                dg.GIA,
                                s.THANHTIEN
                                
                            };
            var kq = CT_hoadonban.ToList().ConvertAll(t => new CHITIETHOADONBAN()
            {
                MACTHDB = t.MACTHDB,
                Tenmathang = t.TENMATHANG,
                SOLUONGBAN = t.SOLUONGBAN,
                Gia =Convert.ToDecimal( t.GIA),
                THANHTIEN = t.THANHTIEN
                
            });


            return kq.ToList<CHITIETHOADONBAN>();
        }

        public bool them(HOADONBAN1 hdb)
        {
            try
            {
                dal_data.HOADONBANs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ktkc(HOADONBAN1 hdb)
        {
            int r =dal_data.HOADONBANs.Count(t => t.MAHDB == hdb.MAHDB.ToString());
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

        public bool sua(CHITIETHOADONBAN hdb)
        {
            try
            {
                CHITIETHOADONBAN mh = dal_data.CHITIETHOADONBANs.Where(t => t.MACTHDB == hdb.MACTHDB.ToString()).FirstOrDefault();
                mh.Tenmathang = hdb.Tenmathang;
                mh.SOLUONGBAN = hdb.SOLUONGBAN;
                mh.Gia = hdb.Gia;
                mh.THANHTIEN = hdb.THANHTIEN;
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public bool xoa(MonHoc pmh)
        //{
        //    try
        //    {
        //        MonHoc mh = DL.MonHocs.Where(t => t.MaMonHoc == pmh.MaMonHoc.ToString()).FirstOrDefault();
        //        DL.MonHocs.DeleteOnSubmit(mh);
        //        DL.SubmitChanges(); ;
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
