﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLL_DanhMucSanPham
    {
        DAL_DanhMucSanPham dal_DanhMucSanPham = new DAL_DanhMucSanPham();

        public List<LOAIMATHANG> load_loaiMatHang()
        {
            return dal_DanhMucSanPham.Loaddata_LoaiMatHang();
        }
        public string Sinh_MaMatHang()
        {
            return dal_DanhMucSanPham.SinhMaMatHang_dal();
        }
        public List<DONVITINH> load_donViTinh()
        {
            return dal_DanhMucSanPham.Loaddata_DonViTinh();
        }
        public List<NHASANXUAT> load_nhaSanXuat()
        {
            return dal_DanhMucSanPham.Loaddata_NhaSanXuat();
        }
        public List<DONGIA> load_dongia()
        {
            return dal_DanhMucSanPham.dongia();
        }
        public List<Bangghep_DMMH> LoadDL_DSMATHANGdll()
        {
            return dal_DanhMucSanPham.LoadDL_DSMATHANG();
        }

        public bool them_DMMH(MATHANG hdb)
        {
            return dal_DanhMucSanPham.them_DanhMucMH(hdb);
        }

        public bool Sua_DMMH(MATHANG hdb)
        {
            return dal_DanhMucSanPham.sua_DMMH(hdb);
        }
        public bool Xoa_DMMH(MATHANG hdb)
        {
            return dal_DanhMucSanPham.xoa_DMMH(hdb);
        }
        public bool KTKC(MATHANG hdb)
        {
            return dal_DanhMucSanPham.ktkc(hdb);
        }

        public string LAYMA(int gia)
        {
            return dal_DanhMucSanPham.layma(gia);
        }

        //public List<MATHANG> load_MatHang()
        //{
        //    return dal_DanhMucSanPham.Loaddata_MatHang();
        //}

        //public String Load_tenloaiMH(string maloaimathang)
        //{

        //    return dal_DanhMucSanPham.Load_tenloaiMH(maloaimathang);
        //}

        //public List<DONVITINH> Load_DonViTinhdll()
        //{

        //    return dal_DanhMucSanPham.LoadDT_DonViTinh();
        //}

        //public List<NHASANXUAT> Load_NhaSXdll()
        //{

        //    return dal_DanhMucSanPham.LoadDT_NhaSX();
        //}

        ////public List<MATHANG> Load_TinhTrangdll()
        ////{

        ////    return dal_DanhMucSanPham.LoadDT_TinhTrang();
        ////}



        //public bool Load_ThemMHdll(MATHANG mhg)
        //{

        //    return dal_DanhMucSanPham.themMH(mhg);
        //}

        //public bool Load_ThemloaiMHdll(LOAIMATHANG lmh)
        //{

        //    return dal_DanhMucSanPham.themLoaiMH(lmh);
        //}

        //public bool Load_ThemDonGiadll(DONGIA dg)
        //{

        //    return dal_DanhMucSanPham.themDonGia(dg);
        //}

        //public bool Load_ThemNSXdll(NHASANXUAT nsx)
        //{

        //    return dal_DanhMucSanPham.themNSX(nsx);
        //}

        //public bool Load_ThemCTNSXdll(CHITIETNHASANXUAT ctnsx)
        //{

        //    return dal_DanhMucSanPham.themCTNSX(ctnsx);
        //}

        //public bool Load_ThemDVTdll(DONVITINH dvt)
        //{

        //    return dal_DanhMucSanPham.themDVT(dvt);
        //}

        //public string Sinh_MaDonGia_BLL()
        //{
        //    return dal_DanhMucSanPham.SinhMaDonGia();

        //}
        //public string Sinh_MaMatHang_BLL()
        //{
        //    return dal_DanhMucSanPham.SinhMaMatHang();

        //}




        //public bool Load_SuaMHdll(MATHANG mh)
        //{

        //    return dal_DanhMucSanPham.SuaMH(mh);
        //}

        //public bool Load_SuaDonGiadll(DONGIA dg)
        //{

        //    return dal_DanhMucSanPham.suaDG(dg);
        //}

        //public bool Load_XoaMHdll(MATHANG mh)
        //{

        //    return dal_DanhMucSanPham.xoaMH(mh);
        //}

        //public bool Load_XoaDGdll(DONGIA dg)
        //{

        //    return dal_DanhMucSanPham.xoaDG(dg);
        //}

        //public bool Load_Xoactnsxdll(CHITIETNHASANXUAT ctnsx)
        //{

        //    return dal_DanhMucSanPham.XoaCTNSX(ctnsx);
        //}

        //public string mahangdll(string mh)
        //{

        //    return dal_DanhMucSanPham.mahang(mh);
        //}

        //public bool KTKC(MATHANG mh)
        //{
        //    return dal_DanhMucSanPham.ktkc(mh);

        //}

    }


}

