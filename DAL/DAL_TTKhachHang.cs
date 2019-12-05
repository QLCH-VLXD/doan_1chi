using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TTKhachHang
    {
        linQDataContext dal_data = new linQDataContext();

        public string SinhMaHoaDon()
        {
            return dal_data.SINHMA_HDN();

        }
        public List<LOAIKHACHHANG> Loaddata_LoaiKhachHang()
        {
            return dal_data.LOAIKHACHHANGs.Select(t => t).ToList<LOAIKHACHHANG>();
        }
        public List<KHACHHANG> Loaddata_KhachHang()
        {
            return dal_data.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();
        }
        public bool them_LoaiKH(LOAIKHACHHANG hdb)
        {
            try
            {
                dal_data.LOAIKHACHHANGs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc(LOAIKHACHHANG hdb)
        {
            int r = dal_data.LOAIKHACHHANGs.Count(t => t.MALOAIKH == hdb.MALOAIKH.ToString());
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
        public bool sua_LoaiKH(LOAIKHACHHANG mh)
        {
            try
            {
                LOAIKHACHHANG aa = dal_data.LOAIKHACHHANGs.Where(t => t.MALOAIKH == mh.MALOAIKH.ToString()).FirstOrDefault();
                aa.TENLOAIKH = mh.TENLOAIKH;
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool xoa_LoaiKH(LOAIKHACHHANG pmh)
        {
            try
            {
                LOAIKHACHHANG mh = dal_data.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pmh.MALOAIKH.ToString()).FirstOrDefault();
                dal_data.LOAIKHACHHANGs.DeleteOnSubmit(mh);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<BangGhep_KHACHHANG> Loaddl_khachhang()
        {
            var khachhang = from s in dal_data.KHACHHANGs
                            join q in dal_data.LOAIKHACHHANGs on s.MALOAIKH equals (q.MALOAIKH)

                            select new
                            {
                                s.MAKH,
                                q.TENLOAIKH,
                                s.HOTENKH,
                                s.SDT,
                                s.DIACHI
                            };
            var kq = khachhang.ToList().ConvertAll(t => new BangGhep_KHACHHANG()
            {
                MAKH1 = t.MAKH,
                TENLOAIKH1 = t.TENLOAIKH,
                HOTENKH1 = t.HOTENKH,
                SDT1 = t.SDT,
                DIACHI1 = t.DIACHI
            });
            return kq.ToList<BangGhep_KHACHHANG>();
        }

        public bool them_KH(KHACHHANG hdb)
        {
            try
            {
                dal_data.KHACHHANGs.InsertOnSubmit(hdb);
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ktkc_kh(KHACHHANG hdb)
        {
            int r = dal_data.KHACHHANGs.Count(t => t.MAKH == hdb.MAKH.ToString());
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
        public bool sua_KH(KHACHHANG mh)
        {
            try
            {
                KHACHHANG aa = dal_data.KHACHHANGs.Where(t => t.MAKH == mh.MAKH.ToString()).FirstOrDefault();
                aa.HOTENKH= mh.HOTENKH;
                aa.LOAIKHACHHANG = mh.LOAIKHACHHANG;
                aa.SDT = mh.SDT;
                aa.DIACHI = mh.DIACHI;
                dal_data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool xoa_KH(KHACHHANG pmh)
        {
            try
            {
                KHACHHANG mh = dal_data.KHACHHANGs.Where(t => t.MAKH == pmh.MAKH.ToString()).FirstOrDefault();
                dal_data.KHACHHANGs.DeleteOnSubmit(mh);
                dal_data.SubmitChanges(); ;
                return true;
            }
            catch
            {
                return false;
            }
        }




    }
}
