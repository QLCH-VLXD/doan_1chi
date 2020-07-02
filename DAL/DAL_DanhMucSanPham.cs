using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DanhMucSanPham
    {
        linQDataContext dal_data = new linQDataContext();

        public List<LOAIMATHANG> Loaddata_LoaiMatHang()
        {
            return dal_data.LOAIMATHANGs.Select(t => t).ToList<LOAIMATHANG>();
        }

        public string SinhMaMatHang_dal()
        {
            return dal_data.SINHMA_HDN();

        }
        public List<DONVITINH> Loaddata_DonViTinh()
        {
            return dal_data.DONVITINHs.Select(t => t).ToList<DONVITINH>();
        }

        public List<NHASANXUAT> Loaddata_NhaSanXuat()
        {
            return dal_data.NHASANXUATs.Select(t => t).ToList<NHASANXUAT>();
        }
        public List<Bangghep_DMMH> LoadDL_DSMATHANG()
        {
            var DS_MatHang = from mh in dal_data.MATHANGs
                             from dg in dal_data.DONGIAs
                             from lmh in dal_data.LOAIMATHANGs
                             from nsx in dal_data.NHASANXUATs
                             from dvt in dal_data.DONVITINHs
                             where mh.MALOAIMATHANG == lmh.MALOAIMATHANG && dg.MAMATHANG == mh.MAMATHANG
                                  && mh.MAMATHANG == dg.MAMATHANG && mh.MADVT == dvt.MADVT && mh.MANSX == nsx.MANSX
                             select new
                             {
                                 mh.MALOAIMATHANG,
                                 lmh.TENLOAIMATHANG,
                                 mh.MAMATHANG,
                                 mh.TENMATHANG,
                                 mh.SOLUONG,
                                 dg.GIA,
                                 dg.NGAYAPDUNG,
                                 dvt.TENDVT,
                                 nsx.TENNSX,
                                 mh.HANMUCHETHANG,
                                 mh.XUATXU,
                                 mh.GHICHU,
                                 mh.TINHTRANG,
                                 mh.HINHMH,
                             };
            var kq = DS_MatHang.ToList().ConvertAll(t => new Bangghep_DMMH()
            {
                MALOAIMATHANG1 = t.MALOAIMATHANG,
                TENLOAIMATHANG1 = t.TENLOAIMATHANG,
                MAMATHANG1 = t.MAMATHANG,
                TENMATHANG1 = t.TENMATHANG,
                SOLUONG1 = t.SOLUONG,
                GIA1 = t.GIA,
                NGAYAPDUNG1 = t.NGAYAPDUNG,
                TENDVT1 = t.TENDVT,
                TENNSX1 = t.TENNSX,
                HANMUCHETHANG1 = t.HANMUCHETHANG,
                XUATXU1 = t.XUATXU,
                GHICHU1 = t.GHICHU,
                TINHTRANG1 = t.TINHTRANG,
                HINHMH1=t.HINHMH,
            });
            return kq.ToList<Bangghep_DMMH>();
        }

        public bool them_DanhMucMH(MATHANG hdb)
        {
            try
            {
                dal_data.MATHANGs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(MATHANG hdb)
        {
            int r = dal_data.MATHANGs.Count(t => t.MAMATHANG == hdb.MAMATHANG.ToString());
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

        public String layma(int gia)
        {
            var lm = (from k in dal_data.DONGIAs where k.GIA == gia select k.MADONGIA).FirstOrDefault();
            String s = lm.ToString();
            return lm.ToString();
        }

        public List<DONGIA> dongia ()
        {
            return dal_data.DONGIAs.Select(t => t).ToList<DONGIA>();
        }

        public bool sua_DMMH(MATHANG mh)
        {
            try
            {
                var aa = dal_data.MATHANGs.Where(t => t.MAMATHANG == mh.MAMATHANG.ToString()).FirstOrDefault();
                aa.MAMATHANG = mh.MAMATHANG;
                aa.MALOAIMATHANG = mh.MALOAIMATHANG;
                aa.TENMATHANG = mh.TENMATHANG;
                aa.SOLUONG = mh.SOLUONG;
                aa.MADVT = mh.MADVT;
                aa.MANSX = mh.MANSX;
                aa.HANMUCHETHANG = mh.HANMUCHETHANG;
                aa.TINHTRANG = mh.TINHTRANG;
                aa.XUATXU = mh.XUATXU;
                aa.GHICHU = mh.GHICHU;
                aa.HINHMH = mh.HINHMH;
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoa_DMMH(MATHANG mh)
        {
            try
            {
                MATHANG k = dal_data.MATHANGs.FirstOrDefault(m => m.MAMATHANG == mh.MAMATHANG); 
                dal_data.MATHANGs.DeleteOnSubmit(k);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }





        //public List<Bangghep_DMMH> Search_TT()
        //{

        //    var search =( from c in .Bangghep_DMMH
        //    where c.Like(c.te, "%/12/%")
        //    select *);

        //}

        //        public bool SuaMH(MATHANG mh)
        //        {
        //            try
        //            {
        //                MATHANG k = dal_data.MATHANGs.FirstOrDefault(m => m.MAMATHANG == mh.MAMATHANG);
        //                k.GHICHU = mh.GHICHU;
        //                k.MADVT = mh.MADVT;
        //                k.MALOAIMATHANG = mh.MALOAIMATHANG;
        //                k.MAMATHANG = mh.MAMATHANG;
        //                k.MANSX = mh.MANSX;
        //                k.SOLUONG = mh.SOLUONG;
        //                k.TENMATHANG = mh.TENMATHANG;
        //                k.TINHTRANG = mh.TINHTRANG;

        //                dal_data.SubmitChanges();
        //                return true;
        //            }
        //            catch
        //            {
        //                return !true;
        //            }
        //        }

    }
}
