using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TTKhachHang
    {
        linQDataContext DAL_data = new linQDataContext();

        public string SinhMaHoaDon()
        {
            return DAL_data.SINHMA_HDN();

        }

        public List<KHACHHANG> Loaddata_TTKhachHang()
        {
            return DAL_data.KHACHHANGs.Select(t => t).ToList<KHACHHANG>();

        }

        public List<LOAIKHACHHANG> Loaddata_LoaiKhachHang()
        {
            return DAL_data.LOAIKHACHHANGs.Select(t => t).ToList<LOAIKHACHHANG>();

        }

        public int them(KHACHHANG kh)
        {
            int result = 0;
            if (IsExit(kh.MAKH))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.KHACHHANGs.InsertOnSubmit(kh);
                context.SubmitChanges();

            }

            return result;

        }

        public bool IsExit(string makh)
        {
            linQDataContext DAl_data = new linQDataContext();
            return DAl_data.KHACHHANGs.Any(t => t.MAKH.ToUpper() == makh.ToUpper());

        }

        public int Sua(KHACHHANG kh)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            KHACHHANG k = context.KHACHHANGs.FirstOrDefault(m => m.MAKH == kh.MAKH);

            k.MAKH = kh.MAKH;
            k.HOTENKH = kh.HOTENKH;
            k.MALOAIKH = kh.MALOAIKH;
            k.SDT = kh.SDT;
            k.DIACHI = kh.DIACHI;
            context.SubmitChanges();

            result = 1;


            return result;
        }

        public int Xoa(KHACHHANG kh)
        {
            int result = 0;

            KHACHHANG k = DAL_data.KHACHHANGs.FirstOrDefault(m => m.MAKH.ToUpper() == kh.MAKH.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                DAL_data.KHACHHANGs.DeleteOnSubmit(k);
                DAL_data.SubmitChanges();
            }


            return result;
        }

        public int themloaiKH(LOAIKHACHHANG lkh)
        {
            int result = 0;
            if (IsExit(lkh.MALOAIKH))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.LOAIKHACHHANGs.InsertOnSubmit(lkh);
                context.SubmitChanges();

            }

            return result;

        }

        public int SualoaiKH(LOAIKHACHHANG lkh)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            LOAIKHACHHANG k = context.LOAIKHACHHANGs.FirstOrDefault(m => m.MALOAIKH.ToUpper() == lkh.MALOAIKH.ToUpper());

            if (k != null)
            {
                k.MALOAIKH = lkh.MALOAIKH;
                k.TENLOAIKH = lkh.TENLOAIKH;


                result = 1;

            }
            context.SubmitChanges();


            return result;
        }

        public int XoaloaiKH(LOAIKHACHHANG lkh)
        {
            int result = 0;

            LOAIKHACHHANG k = DAL_data.LOAIKHACHHANGs.FirstOrDefault(m => m.MALOAIKH.ToUpper() == lkh.MALOAIKH.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                DAL_data.LOAIKHACHHANGs.DeleteOnSubmit(k);
                DAL_data.SubmitChanges();
            }


            return result;
        }




    }
}
