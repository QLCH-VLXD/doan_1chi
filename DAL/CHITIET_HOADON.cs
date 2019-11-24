using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class CHITIETHOADONBAN
    {
        private String tenmathang;
        private Decimal gia;

        public String Tenmathang
        {
            get { return tenmathang; }
            set { tenmathang = value; }
        }

        public Decimal Gia
        {
            get { return gia; }
            set { gia = value; }
        }

    }
}
