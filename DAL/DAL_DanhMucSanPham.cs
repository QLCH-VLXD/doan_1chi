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

        //public List<MATHANG> Load_MatHang(string maloaimathang)
        //{
        //    return dal_data.MATHANGs.Where(t => t.MALOAIMATHANG == maloaimathang).ToList<MATHANG>();
        //}

        public String Load_tenloaiMH(string maloaimathang)
        {


            var dulieu = (from s in dal_data.LOAIMATHANGs
                          where s.MALOAIMATHANG == maloaimathang
                          select s.TENLOAIMATHANG).FirstOrDefault();
            return dulieu.ToString();


        }

        public bool themMH(MATHANG mhg)
        {
            try
            {
                dal_data.MATHANGs.InsertOnSubmit(mhg);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themLoaiMH(LOAIMATHANG lmh)
        {
            try
            {
                dal_data.LOAIMATHANGs.InsertOnSubmit(lmh);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool themDonGia(DONGIA dg)
        {
            try
            {
                dal_data.DONGIAs.InsertOnSubmit(dg);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themCTNSX(CHITIETNHASANXUAT ctnsx)
        {
            try
            {
                dal_data.CHITIETNHASANXUATs.InsertOnSubmit(ctnsx);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool themNSX(NHASANXUAT nsx)
        {
            try
            {
                dal_data.NHASANXUATs.InsertOnSubmit(nsx);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themDVT(DONVITINH dvt)
        {
            try
            {
                dal_data.DONVITINHs.InsertOnSubmit(dvt);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string SinhMaDonGia()
        {
            return dal_data.SINHMA_DG();

        }

        public bool SuaMH(MATHANG mh)
        {
            try
            {
                MATHANG k = dal_data.MATHANGs.FirstOrDefault(m => m.MAMATHANG == mh.MAMATHANG);
                k.GHICHU = mh.GHICHU;
                k.MADVT = mh.MADVT;
                k.MALOAIMATHANG = mh.MALOAIMATHANG;
                k.MAMATHANG = mh.MAMATHANG;
                k.MANSX = mh.MANSX;
                k.SOLUONG = mh.SOLUONG;
                k.TENMATHANG = mh.TENMATHANG;
                k.TINHTRANG = mh.TINHTRANG;

                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return !true;
            }
        }

        //public bool suaMH(MATHANG mh)
        //{
        //    try
        //    {
        //        MATHANG Mh = dal_data.MATHANGs.Where(t => t.MAMATHANG == mh.MAMATHANG.ToString()).FirstOrDefault();
        //        Mh.GHICHU = mh.GHICHU;
        //        Mh.MADVT = mh.MADVT;
        //        Mh.MALOAIMATHANG = mh.MALOAIMATHANG;
        //        Mh.MAMATHANG = mh.MAMATHANG;
        //        Mh.MANSX = mh.MANSX;
        //        Mh.SOLUONG = mh.SOLUONG;
        //        Mh.TENMATHANG = mh.TENMATHANG;
        //        Mh.TINHTRANG = mh.TINHTRANG;
        //        dal_data.SubmitChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public bool suaDG(DONGIA dg)
        {
            try
            {
                DONGIA Dg = dal_data.DONGIAs.Where(t => t.MADONGIA == dg.MADONGIA.ToString()).FirstOrDefault();
                Dg.MADONGIA = dg.MADONGIA;
                Dg.MAMATHANG = dg.MAMATHANG;
                Dg.NGAYAPDUNG = dg.NGAYAPDUNG;
                Dg.NGAYKETTHUC = dg.NGAYKETTHUC;
                Dg.GIA = dg.GIA;
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaMH(MATHANG mh)
        {
            //try
            //{
            MATHANG Mh = dal_data.MATHANGs.Where(t => t.MAMATHANG == mh.MAMATHANG.ToString()).FirstOrDefault();
            dal_data.MATHANGs.DeleteOnSubmit(Mh);
            dal_data.SubmitChanges(); ;
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public bool xoaDG(DONGIA dg)
        {
            try
            {
                DONGIA Dg = dal_data.DONGIAs.Where(t => t.MADONGIA == dg.MADONGIA.ToString()).FirstOrDefault();
                dal_data.DONGIAs.DeleteOnSubmit(Dg);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaCTNSX(CHITIETNHASANXUAT ctnsx)
        {
            //try
            //{
            CHITIETNHASANXUAT Ctnsx = dal_data.CHITIETNHASANXUATs.Where(t => t.MANSX == ctnsx.MANSX.ToString() && t.MAMATHANG == ctnsx.MAMATHANG.ToString()).FirstOrDefault();
            dal_data.CHITIETNHASANXUATs.DeleteOnSubmit(Ctnsx);
            dal_data.SubmitChanges();
            return true;

            //}
            //catch
            //{
            //    return false;
            //}
        }

        public string mahang(string mh)
        {
            try
            {
                DONGIA Dg = dal_data.DONGIAs.Where(t => t.MAMATHANG == mh.ToString()).FirstOrDefault();

                return Dg.MADONGIA.ToString();
            }
            catch
            {
                return null;
            }
        }

        //public int XoaMH(MATHANG mh)
        //{
        //    int result = 0;

        //    MATHANG k = dal_data.MATHANGs.FirstOrDefault(m => m.MAMATHANG.ToUpper() == mh.MAMATHANG.ToUpper());

        //    if (k == null)
        //    {
        //        result = 2;
        //    }
        //    else
        //    {

        //        dal_data.MATHANGs.DeleteOnSubmit(k);
        //        dal_data.SubmitChanges();
        //    }


        //    return result;
        //}

        //public int XoaDG(DONGIA dg)
        //{
        //    int result = 0;

        //    DONGIA d = dal_data.DONGIAs.FirstOrDefault(m => m.MADONGIA.ToUpper() == dg.MADONGIA.ToUpper());

        //    if (d == null)
        //    {
        //        result = 2;
        //    }
        //    else
        //    {

        //        dal_data.DONGIAs.DeleteOnSubmit(d);
        //        dal_data.SubmitChanges();
        //    }


        //    return result;
        // }



        public List<DONVITINH> LoadDT_DonViTinh()
        {
            return dal_data.DONVITINHs.Select(t => t).ToList<DONVITINH>();
        }

        public List<NHASANXUAT> LoadDT_NhaSX()
        {
            return dal_data.NHASANXUATs.Select(t => t).ToList<NHASANXUAT>();
        }

        //public List<MATHANG> LoadDT_TinhTrang()
        //{
        //    return dal_data.MATHANGs.Select(t => t).ToList<MATHANG>();
        //}

        public List<Bangghep_DMMH> LoadDL_DSMATHANG()
        {
            var DS_MatHang = from mh in dal_data.MATHANGs
                             from dg in dal_data.DONGIAs
                             from lmh in dal_data.LOAIMATHANGs
                             from nsx in dal_data.NHASANXUATs
                             from dvt in dal_data.DONVITINHs

                                 //  from nv in dal_data.NHANVIENs
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
                                 dg.NGAYKETTHUC,
                                 dvt.TENDVT,
                                 nsx.TENNSX,
                                 mh.GHICHU,
                                 mh.TINHTRANG

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
                NGAYKETTHUC1 = t.NGAYKETTHUC,
                TENDVT1 = t.TENDVT,
                TENNSX1 = t.TENNSX,
                GHICHU1 = t.GHICHU,
                TINHTRANG1 = t.TINHTRANG

            });


            return kq.ToList<Bangghep_DMMH>();
        }

        public bool ktkc(MATHANG mh)
        {
            int r = dal_data.MATHANGs.Count(t => t.MAMATHANG == mh.MAMATHANG.ToString());
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




    }
}
