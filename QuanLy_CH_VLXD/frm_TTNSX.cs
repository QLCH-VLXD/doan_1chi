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
    public partial class frm_TTNSX : UserControl
    {
        BLL_TTNSX bll_TTNSX = new BLL_TTNSX();
        public frm_TTNSX()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frm_TTNSX_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bll_TTNSX.load_TTNSX();
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                //MessageBox.Show("sdsd");
                txtMaNSX.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenNSX.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtSDT.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
        }
    }
}
