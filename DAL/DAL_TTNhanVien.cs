using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_TTNhanVien
    {
        linQDataContext Dal_data = new linQDataContext();
        public string XemTenNhanVien(String manv)
        {
            return Dal_data.XEM_TENNV(manv);

        }

        public string SinhMaNV()
        {
            return Dal_data.SINHMA_HDN();

        }

        public List<NHANVIEN> Loaddata_NhanVien()
        {
            return Dal_data.NHANVIENs.Select(t => t).ToList<NHANVIEN>();

        }

        public List<CHUCVU> Loaddata_ChucVu()
        {
            return Dal_data.CHUCVUs.Select(t => t).ToList<CHUCVU>();

        }

        public int them(NHANVIEN nv)
        {
            int result = 0;
            if (IsExit(nv.MANV))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.NHANVIENs.InsertOnSubmit(nv);
                context.SubmitChanges();

            }

            return result;

        }

        public bool IsExit(string manv)
        {
            linQDataContext Dal_data = new linQDataContext();
            return Dal_data.NHANVIENs.Any(t => t.MANV.ToUpper() == manv.ToUpper());

        }

        public int Sua(NHANVIEN nv)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            NHANVIEN k = context.NHANVIENs.FirstOrDefault(m => m.MANV.ToUpper() == nv.MANV.ToUpper());

            if (k != null)
            {
                k.HOTENNV = nv.HOTENNV;
                k.MACHUCVU = nv.MACHUCVU;
                k.NGAYSINH = nv.NGAYSINH;
                k.GIOITINH = nv.GIOITINH;
                k.SOCMND = nv.SOCMND;
                k.SDT = nv.SDT;
                k.DIACHI = nv.DIACHI;
                k.EMAIL = nv.EMAIL;
                k.NGAYVAOLAM = nv.NGAYVAOLAM;
                k.TINHTRANG = nv.TINHTRANG;
                result = 1;

            }
            context.SubmitChanges();


            return result;
        }

        public int Xoa(NHANVIEN nv)
        {
            int result = 0;

            NHANVIEN k = Dal_data.NHANVIENs.FirstOrDefault(m => m.MANV.ToUpper() == nv.MANV.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                Dal_data.NHANVIENs.DeleteOnSubmit(k);
                Dal_data.SubmitChanges();
            }


            return result;
        }

        public int themCV(CHUCVU cv)
        {
            int result = 0;
            if (IsExit(cv.MACHUCVU))
            {
                result = 2;
            }
            else
            {
                linQDataContext context = new linQDataContext();
                context.CHUCVUs.InsertOnSubmit(cv);
                context.SubmitChanges();

            }

            return result;

        }

        public int SuaCV(CHUCVU cv)
        {
            int result = 0;
            linQDataContext context = new linQDataContext();
            CHUCVU k = context.CHUCVUs.FirstOrDefault(m => m.MACHUCVU.ToUpper() == cv.MACHUCVU.ToUpper());

            if (k != null)
            {
                k.MACHUCVU = cv.MACHUCVU;
                k.TENCV = cv.TENCV;
                result = 1;

            }
            context.SubmitChanges();


            return result;
        }

        public int XoaCV(CHUCVU cv)
        {
            int result = 0;

            CHUCVU k = Dal_data.CHUCVUs.FirstOrDefault(m => m.MACHUCVU.ToUpper() == cv.MACHUCVU.ToUpper());

            if (k == null)
            {
                result = 2;
            }
            else
            {

                Dal_data.CHUCVUs.DeleteOnSubmit(k);
                Dal_data.SubmitChanges();
            }


            return result;
        }





    }
}

