 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CT_NhapHang
    {
        String MACTPN;
        String MAPN;
        String MACTPHIEUDATHANG;
        String SOLUONGMH;
        String THANHTIENCTPNH;
        DateTime NGAYSX;
        DateTime NGAYHH;

        public string MACTPN1 { get => MACTPN; set => MACTPN = value; }
        public string MAPN1 { get => MAPN; set => MAPN = value; }
        public string MACTPHIEUDATHANG1 { get => MACTPHIEUDATHANG; set => MACTPHIEUDATHANG = value; }
        
        public string SOLUONGMH1 { get => SOLUONGMH; set => SOLUONGMH = value; }
        public string THANHTIENCTPNH1 { get => THANHTIENCTPNH; set => THANHTIENCTPNH = value; }
        public DateTime NGAYSX1 { get => NGAYSX; set => NGAYSX = value; }
        public DateTime NGAYHH1 { get => NGAYHH; set => NGAYHH = value; }
    }
}
