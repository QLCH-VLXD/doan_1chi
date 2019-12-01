using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public partial class HOADONBAN
    {
        public object bll_BanHang;
        private String tenkhachhang;
        private String sdt;
        // private String tennhanvien;
        public String TenKH
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
        }

        public String Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        //public String tenNV
        //{
        //    get { return tennhanvien; }
        //    set { tennhanvien = value; }
        //}
    }
}
