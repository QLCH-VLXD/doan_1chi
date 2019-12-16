using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DonGia
    {
        DAL_DonGia dal_DonGia = new DAL_DonGia();

        public List<LOAIMATHANG> load_loaiMatHang()
        {
            return dal_DonGia.Loaddata_LoaiMatHang();
        }

        public String Load_tenloaiMH(string maloaimathang)
        {

            return dal_DonGia.Load_tenloaiMH(maloaimathang);
        }


        //public List<MATHANG> load_MaMatHang()
        //{
        //    return dal_DonGia.Loaddata_MaMatHang();
        //}

        public string mahangdll(string mh)
        {

            return dal_DonGia.mahang(mh);
        }



        public List<DG_BangGhep> LoadDL_DSDonGiadll()
        {
            return dal_DonGia.LoadDL_DSDONGIA();
        }

        public bool Load_ThemMHdll(MATHANG mhg)
        {

            return dal_DonGia.themMH(mhg);
        }

        public bool Load_ThemloaiMHdll(LOAIMATHANG lmh)
        {

            return dal_DonGia.themLoaiMH(lmh);
        }

        public bool Load_ThemDonGiadll(DONGIA dg)
        {

            return dal_DonGia.themDonGia(dg);
        }

        public string Sinh_MaDonGia_BLL()
        {
            return dal_DonGia.SinhMaDonGia();

        }

        public string Sinh_MaMatHang_BLL()
        {
            return dal_DonGia.SinhMaMatHang();

        }

        public bool KTKC(MATHANG mh)
        {
            return dal_DonGia.ktkc(mh);

        }

        public bool Load_SuaMHdll(MATHANG mh)
        {

            return dal_DonGia.SuaMH(mh);
        }

        public bool Load_SuaDonGiadll(DONGIA dg)
        {

            return dal_DonGia.suaDG(dg);
        }

        public bool Load_XoaMHdll(MATHANG mh)
        {

            return dal_DonGia.xoaMH(mh);
        }

        public bool Load_XoaDGdll(DONGIA dg)
        {

            return dal_DonGia.xoaDG(dg);
        }

        public bool Load_XoaLMHdll(LOAIMATHANG lmh)
        {

            return dal_DonGia.XoaLMH(lmh);
        }
    }
}
