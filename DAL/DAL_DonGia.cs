using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DonGia
    {
        linQDataContext dal_data = new linQDataContext();

        public List<LOAIMATHANG> Loaddata_LoaiMatHang()
        {
            return dal_data.LOAIMATHANGs.Select(t => t).ToList<LOAIMATHANG>();

        }

        public String Load_tenloaiMH(string maloaimathang)
        {


            var dulieu = (from s in dal_data.LOAIMATHANGs
                          where s.MALOAIMATHANG == maloaimathang
                          select s.TENLOAIMATHANG).FirstOrDefault();
            return dulieu.ToString();


        }

        //public List<MATHANG> Loaddata_MaMatHang()
        //{
        //    return dal_data.MATHANGs.Select(t => t).ToList<MATHANG>();

        //}

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

        public List<DG_BangGhep> LoadDL_DSDONGIA()
        {
            var DS_DonGia = from mh in dal_data.MATHANGs
                            from dg in dal_data.DONGIAs
                            from lmh in dal_data.LOAIMATHANGs


                                //  from nv in dal_data.NHANVIENs
                            where mh.MALOAIMATHANG == lmh.MALOAIMATHANG && dg.MAMATHANG == mh.MAMATHANG

                            select new
                            {
                                mh.MALOAIMATHANG,
                                lmh.TENLOAIMATHANG,
                                mh.MAMATHANG,
                                mh.TENMATHANG,
                                dg.MADONGIA,
                                dg.GIA,
                                dg.NGAYAPDUNG,
                                dg.NGAYKETTHUC

                            };
            var kq = DS_DonGia.ToList().ConvertAll(t => new DG_BangGhep()
            {
                MALOAIMATHANG1 = t.MALOAIMATHANG,
                TENLOAIMATHANG1 = t.TENLOAIMATHANG,
                MAMATHANG1 = t.MAMATHANG,
                TENMATHANG1 = t.TENMATHANG,
                MADONGIA1 = t.MADONGIA,
                GIA1 = t.GIA,
                NGAYAPDUNG1 = t.NGAYAPDUNG,
                NGAYKETTHUC1 = t.NGAYKETTHUC
            });


            return kq.ToList<DG_BangGhep>();
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

        public string SinhMaDonGia()
        {
            return dal_data.SINHMA_DG();

        }

        public string SinhMaMatHang()
        {
            return dal_data.SINHMA_HDN();

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
            catch(Exception e)
            {
                return false;
            }
        }

        public bool SuaMH(MATHANG mh)
        {
            try
            {
                MATHANG k = dal_data.MATHANGs.FirstOrDefault(m => m.MAMATHANG == mh.MAMATHANG);
                //k.GHICHU = mh.GHICHU;
                //k.MADVT = mh.MADVT;
                k.MALOAIMATHANG = mh.MALOAIMATHANG;
                k.MAMATHANG = mh.MAMATHANG;
                //k.MANSX = mh.MANSX;
                //k.SOLUONG = mh.SOLUONG;
                k.TENMATHANG = mh.TENMATHANG;
                //k.TINHTRANG = mh.TINHTRANG;

                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return !true;
            }
        }

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

        public bool suaDG_DMMH(DONGIA dg)
        {
            try
            {
                DONGIA Dg = (from s in dal_data.DONGIAs
                             join q in dal_data.MATHANGs on s.MAMATHANG equals (q.MAMATHANG)
                             where s.MAMATHANG == dg.MAMATHANG 
                             select s).FirstOrDefault();
               
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
            try
            {
                MATHANG Mh = dal_data.MATHANGs.Where(t => t.MAMATHANG == mh.MAMATHANG.ToString()).FirstOrDefault();
                dal_data.MATHANGs.DeleteOnSubmit(Mh);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool xoaDG_dmmh(DONGIA dg)
        {
            try
            {
                DONGIA Dg = (from s in dal_data.DONGIAs
                          where s.MAMATHANG == dg.MAMATHANG
                          select s).FirstOrDefault();
                dal_data.DONGIAs.DeleteOnSubmit(Dg);
                dal_data.SubmitChanges(); 
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaLMH(LOAIMATHANG lmh)
        {
            try
            {
                LOAIMATHANG LMH = dal_data.LOAIMATHANGs.Where(t => t.MALOAIMATHANG == lmh.MALOAIMATHANG.ToString()).FirstOrDefault();
                dal_data.LOAIMATHANGs.DeleteOnSubmit(LMH);
                dal_data.SubmitChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
