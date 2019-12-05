using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_CH_VLXD
{
    public partial class frmDangNhap : Form
    {
        CauHinh cauhinh = new CauHinh();
      
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            {
                if (txtnameDN.Text.Length == 0 && txtMatKhau.Text.Length == 0)
                {
                    MessageBox.Show("Chưa nhập tài khoản và mật khẩu vui lòng nhập!");
                }
                else
                {
                    if (txtnameDN.Text.Length == 0)
                    {
                        MessageBox.Show("Chưa nhập tài khoản, vui lòng nhập!");
                    }
                    else
                    {
                        if (txtMatKhau.Text.Length == 0)
                        {
                            MessageBox.Show("Chưa nhập mật khẩu, vui lòng nhập!");
                        }
                        else
                        {
                            if (cauhinh.Check_Config() == 0)
                            {
                                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập

                               


                            }
                            if (cauhinh.Check_Config() == 1)
                            {
                                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                                ProcessConfig();
                            }
                            if (cauhinh.Check_Config() == 2)
                            {
                                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                                ProcessConfig();
                            }


                            Properties.Settings.Default.user = txtnameDN.Text;
                            Properties.Settings.Default.pass = txtMatKhau.Text;

                        }

                    }
                }
            }
        }

        public void ProcessLogin()
        {
            int result;
            result = cauhinh.Check_User(txtnameDN.Text, txtMatKhau.Text);
            // Wrong username or pass
            if (result == 0)
            {
                MessageBox.Show("Sai " + txtnameDN.Text + " Hoặc " + txtMatKhau.Text);
                return;
            }
            // Account had been disabled
            else if (result == -1)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.Frm_Main == null || Program.Frm_Main.IsDisposed)
            {
                Program.Frm_Main = new FrmMain();
            }
            
            Program.Frm_Main.Lay_DL = txtnameDN.Text;
            Program.Frm_Main.Show();

            this.Visible = false;
        }

        public void ProcessConfig()
        {
            this.Hide();
            this.Show();
            FrmKetNoiCSDL frm = new FrmKetNoiCSDL();
            frm.ShowDialog();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        
       



    }
}
            
        


