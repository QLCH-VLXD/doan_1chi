using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;

namespace QuanLy_CH_VLXD
{
    public partial class frm_ThongKe : UserControl
    {
        BLL_ThongKe bLL_ThongKe = new BLL_ThongKe();
        public frm_ThongKe()
        {
            InitializeComponent();
        }

        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            dataGrid_TKNhaphang.DataSource = bLL_ThongKe.Load_nhapHang();
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
