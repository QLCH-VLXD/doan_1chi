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
        
        public frm_ThongKe()
        {
            InitializeComponent();
        }
        int i = 0;
        private void frm_ThongKe_Load(object sender, EventArgs e)
        {
            pHIEUNHAPHANGTableAdapter.Fill(dataSet1.PHIEUNHAPHANG);
            cHITIETPHIEUNHAPHANGTableAdapter.Fill(dataSet1.CHITIETPHIEUNHAPHANG);
            hOADONBANTableAdapter.Fill(dataSet1.HOADONBAN);
            cHITIETHOADONBANTableAdapter.Fill(dataSet1.CHITIETHOADONBAN);
            mATHANGTableAdapter.FillBy(dataSet1.MATHANG);
            mATHANGTableAdapter.Fill(dataSet1.MATHANG);
            i = 1;
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pHIEUNHAPHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
            //this.pHIEUNHAPHANGBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

 

        private void pHIEUNHAPHANGDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void hOADONBANDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
