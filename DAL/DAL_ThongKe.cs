using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ThongKe
    {

        linQDataContext dal_data = new linQDataContext();

        
        public List<TKHANGSAPHET> Loaddata_tksaphet()
        {
            return dal_data.TKHANGSAPHETs.Select(t => t).ToList<TKHANGSAPHET>();

        }
        public List<BangGhep_ThongKe_SapHet> load_TK_SapHet()
        {
            var dulieu = from s in dal_data.MATHANGs
                         join q in dal_data.LOAIMATHANGs on s.MALOAIMATHANG equals (q.MALOAIMATHANG)
                         join qq in dal_data.NHASANXUATs on s.MANSX equals (qq.MANSX)
                         where s.SOLUONG==s.HANMUCHETHANG || s.SOLUONG < s.HANMUCHETHANG
                         select new
                         {
                             q.MALOAIMATHANG,
                             q.TENLOAIMATHANG,
                             s.MAMATHANG,
                             s.TENMATHANG,
                             qq.TENNSX,
                             s.SOLUONG
                         };
            var kq = dulieu.ToList().ConvertAll(t => new BangGhep_ThongKe_SapHet()
            {
                MALOAIMATHANG1 = t.MALOAIMATHANG,
                TENLOAIMATHANG1 = t.TENLOAIMATHANG,
                MAMATHANG1 = t.MAMATHANG,
                TENMATHANG1 = t.TENMATHANG,
                TENNSX1 = t.TENNSX,
                SOLUONG1 = Convert.ToInt32(t.SOLUONG)
            });
            return kq.ToList<BangGhep_ThongKe_SapHet>();

        }

        public bool luu_tk_saphet_tk(THONGKE cthdb)
        {
            try
            {

                dal_data.THONGKEs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                dal_data.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, cthdb);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool luu_tk_saphet_tksh(TKHANGSAPHET cthdb)
        {
            try
            {
               
                cthdb.MATKHANGSAPHET = "TKSH" + DateTime.Now.Millisecond.ToString() + tk().Count().ToString();
                dal_data.TKHANGSAPHETs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                cthdb = new TKHANGSAPHET();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string test (DateTime a)
        {
            try
            {
                var dl = (from s in dal_data.THONGKEs
                          where s.THANG.Value.Month == a.Month && s.THANG.Value.Year == a.Year
                          select s.MATK).FirstOrDefault();
                if (dl == null)
                {
                    return "0";
                }
                else
                {
                    return dl;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Them_TK()
        {
            try
            {
                THONGKE v = new THONGKE();
                v.MATK = "TK" + test(DateTime.Today);
                v.THANG = DateTime.Today;
                dal_data.THONGKEs.InsertOnSubmit(v);
                dal_data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TKHANGSAPHET> tk()
        {
            try
            {
                var dl = (from s in dal_data.TKHANGSAPHETs
                         
                          select s).ToList();
                return dl;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TKHANGSAPHET> Search_TKSH(DateTime a)
        {

            var search = (from s in dal_data.TKHANGSAPHETs
                          join qq in dal_data.THONGKEs on s.MATK equals (qq.MATK)
                          where qq.THANG.Value.Month == a.Month && qq.THANG.Value.Year == a.Year
                          select s).ToList<TKHANGSAPHET>();
            return search;
        }

        public List<BangGhep_ThongKe_TonKho> load_TK_TonKho()
        {
            var dulieu = from s in dal_data.MATHANGs
                         join qq in dal_data.NHASANXUATs on s.MANSX equals (qq.MANSX)
                         select new
                         {
                             s.MAMATHANG,
                             s.TENMATHANG,
                             qq.TENNSX,
                             s.SOLUONG
                         };
            var kq = dulieu.ToList().ConvertAll(t => new BangGhep_ThongKe_TonKho()
            {
                MAMATHANG1 = t.MAMATHANG,
                TENMATHANG1 = t.TENMATHANG,
                TENNSX1 = t.TENNSX,
                SOLUONG1 = Convert.ToInt32(t.SOLUONG)
            });
            return kq.ToList<BangGhep_ThongKe_TonKho>();

        }
        public List<TKHANGTONKHO> Loaddata_tktonkho()
        {
            return dal_data.TKHANGTONKHOs.Select(t => t).ToList<TKHANGTONKHO>();

        }

        public bool luu_tk_tonkho_tktk(TKHANGTONKHO cthdb)
        {
            try
            {
                cthdb.MATKHANGTONKHO = "TKTK" + DateTime.Now.Millisecond.ToString() + tk().Count().ToString();
                dal_data.TKHANGTONKHOs.InsertOnSubmit(cthdb);
                dal_data.SubmitChanges();
                cthdb = new TKHANGTONKHO();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TKHANGTONKHO> Search_TKTK(DateTime a)
        {

            var search = (from s in dal_data.TKHANGTONKHOs
                          join qq in dal_data.THONGKEs on s.MATK equals (qq.MATK)
                          where qq.THANG.Value.Month == a.Month && qq.THANG.Value.Year == a.Year
                          select s).ToList<TKHANGTONKHO>();
            return search;
        }


    }
}
