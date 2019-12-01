using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DatHangNSX
    {
        DAL_DatHangNSX dll_DatHangNSX = new DAL_DatHangNSX();
        public string Sinh_MaCTDHNSX_dal()
        {
           
            return dll_DatHangNSX.SinhMaDatHangNSX();
        }

        public List<LOAIMATHANG> load_loaiMatHang()
        {
            return dll_DatHangNSX.Loaddata_LoaiMatHang();
        }

        public List<MATHANG> load_MatHang(String maLoaimathang)
        {
            return dll_DatHangNSX.Load_MatHang(maLoaimathang);
        }

        
        public String Load_donGia(string mamathang)
        {

            return dll_DatHangNSX.Load_DonGia(mamathang);
        }

        public String Load_tinhtrang(string mamathang)
        {

            return dll_DatHangNSX.Load_tinhtrangMH(mamathang);
        }

        public String Load_donvitinh(string mamathang)
        {

            return dll_DatHangNSX.Load_DonViTinh(mamathang);
        }

        public List<NHASANXUAT> load_NSX(String maLoaimathang)
        {
            return dll_DatHangNSX.Load_NSX(maLoaimathang);
        }

        public List<BangGhep_DatHangNSX> load_dathangnsx()
        {
            return dll_DatHangNSX.LoadDL_DHNSX();
        }

        public List<CHITIET_DATHANGNSX> load_CTDHNSX(String f)
        {
            return dll_DatHangNSX.LoadDL_CTDatHangNSX(f);
        }
        public List<CHITIET_DATHANGNSX> load_CTDHNSX1()
        {
            return dll_DatHangNSX.LoadDL_CTDatHangNSX1();
        }
        public bool them_PDHNSX(PHIEUDATHANGNSX hdb)
        {
            return dll_DatHangNSX.them_DonDatHangNSX(hdb);
        }

        public bool KTKC(PHIEUDATHANGNSX hdb)
        {
            return dll_DatHangNSX.ktkc(hdb);
        }
        public string LAYMA(string sdt)
        {
            return dll_DatHangNSX.layma(sdt);
        }
        public bool them_CTDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            return dll_DatHangNSX.them_CTDHNSX(cthdb);
        }
        public bool KTKC_ctCTPDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            return dll_DatHangNSX.ktkc_ctDHNSX(cthdb);
        }
        public bool Sua_CTDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            return dll_DatHangNSX.sua_CTDHNSX(cthdb);
        }
        public bool Xoa_CTDHNSX(CTPHIEUDATHANGNSX cthdb)
        {
            return dll_DatHangNSX.xoa_CTDHNSX(cthdb);
        }

        public string Sinh_MaHoaDon_dal()
        {
            return dll_DatHangNSX.SinhMaDatHangNSX();
        }
        public bool Sua_PDHNSX(PHIEUDATHANGNSX hdb)
        {
            return dll_DatHangNSX.sua_pdhnsx(hdb);
        }
    }
}
