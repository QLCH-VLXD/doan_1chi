using DevExpress.Skins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_CH_VLXD
{
   public static class Program
    {
        public static FrmMain Frm_Main;
        public static frmDangNhap Frm_DangNhap;
        public static frm_NhapLieu_PhanQuyen Frm_NhapLieu_PhanQuyen;
        public static frm_DonGia Frm_DonGia;



        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //BonusSkins.Register();
            //SkinManager.EnableFormSkins();
            Application.Run(Frm_DangNhap = new frmDangNhap());
            //Application.Run(new Form1());
        }
    }
}
