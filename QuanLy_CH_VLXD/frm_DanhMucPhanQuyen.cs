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
    public partial class frm_DanhMucPhanQuyen : UserControl
    {
        public frm_DanhMucPhanQuyen()
        {
            InitializeComponent();
        }

        private void nHOMNGUOIDUNGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nHOMNGUOIDUNGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }

        private void frm_DanhMucPhanQuyen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.NGUOIDUNGNHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Fill(this.dataSet1.NGUOIDUNGNHOMNGUOIDUNG);
            // TODO: This line of code loads data into the 'dataSet1.PHANQUYEN' table. You can move, or remove it, as needed.
            this.pHANQUYENTableAdapter.Fill(this.dataSet1.PHANQUYEN);
            // TODO: This line of code loads data into the 'dataSet1.PHANQUYEN' table. You can move, or remove it, as needed.
            this.pHANQUYENTableAdapter.Fill(this.dataSet1.PHANQUYEN);
            // TODO: This line of code loads data into the 'dataSet1.TAIKHOAN' table. You can move, or remove it, as needed.
            this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);
            // TODO: This line of code loads data into the 'dataSet1.MANHINH' table. You can move, or remove it, as needed.
            this.mANHINHTableAdapter.Fill(this.dataSet1.MANHINH);
            // TODO: This line of code loads data into the 'dataSet1.NHOMNGUOIDUNG' table. You can move, or remove it, as needed.
            this.nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet1.NHOMNGUOIDUNG);

        }

        ///kiểm tra khóa chính
        public bool KTKC_New(string pKhoaChinh, DataTable pdt)
        {
            DataRow dtKiemTra = pdt.Rows.Find(pKhoaChinh);
            if (dtKiemTra != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void load_dataNhomNguoiDung()
        {
            gridControl_NhomNguoiDung.DataSource = nHOMNGUOIDUNGTableAdapter.Fill(this.dataSet1.NHOMNGUOIDUNG);
        }
        private void btn_Them_NhomNguoiDung_Click(object sender, EventArgs e)
        {
            if (mANHOMComboBox.Text.Length > 0 && tENNHOMTextEdit.Text.Length > 0)
            {
                if (KTKC_New(mANHOMComboBox.Text.ToString(), dataSet1.NHOMNGUOIDUNG) == false)
                {
                    nHOMNGUOIDUNGTableAdapter.Insert(mANHOMComboBox.Text, tENNHOMTextEdit.Text, gHICHUTextEdit.Text);
                    load_dataNhomNguoiDung();
                    MessageBox.Show("Thêm thành công !!!");
                }
                else
                {
                    MessageBox.Show("Trùng khoá chính !!!");
                }
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu !!!");
            }
        }

        private void btn_Xoa_NhomNguoiDung_Click(object sender, EventArgs e)
        {
            if (gridView_NhomNguoiDung.GetFocusedDataRow() != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                int cathu = gridView_NhomNguoiDung.FocusedRowHandle;
                string sql_manhom = gridView_NhomNguoiDung.GetRowCellValue(cathu, "MANHOM").ToString();
                string sql_tennhom = gridView_NhomNguoiDung.GetRowCellValue(cathu, "TENNHOM").ToString();
                string sql_ghichu = gridView_NhomNguoiDung.GetRowCellValue(cathu, "GHICHU").ToString();
                MessageBox.Show(sql_manhom);
                nHOMNGUOIDUNGTableAdapter.Delete(sql_manhom, sql_tennhom, sql_ghichu);
                load_dataNhomNguoiDung();
            }
            else
            {
                MessageBox.Show("chọn dòng muốn xóa !!!");
            }
        }

        private void btn_Sua_NhomNguoiDung_Click(object sender, EventArgs e)
        {
            if (mANHOMComboBox.Text.Length > 0 && tENNHOMTextEdit.Text.Length > 0)
            {
                int cathu = gridView_NhomNguoiDung.FocusedRowHandle;
                string sql_manhom = gridView_NhomNguoiDung.GetRowCellValue(cathu, "MANHOM").ToString();
                string sql_tennhom = gridView_NhomNguoiDung.GetRowCellValue(cathu, "TENNHOM").ToString();
                string sql_ghichu = gridView_NhomNguoiDung.GetRowCellValue(cathu, "GHICHU").ToString();

                DataSet1.NHOMNGUOIDUNGRow data = dataSet1.NHOMNGUOIDUNG.FindByMANHOM(sql_manhom);
                data.TENNHOM = sql_tennhom;
                nHOMNGUOIDUNGTableAdapter.Update(this.dataSet1.NHOMNGUOIDUNG);

                load_dataNhomNguoiDung();
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu !!!");
            }
        }

        public void load_dataManHinh()
        {
            gridControl_ManHinh.DataSource = mANHINHTableAdapter.Fill(this.dataSet1.MANHINH);
        }

        private void btn_Them_ManHinh_Click(object sender, EventArgs e)
        {
            if (tENMANHINHTextEdit.Text.Length > 0 && mAMANHINHTextEdit.Text.Length > 0)
            {
                if (KTKC_New(mAMANHINHTextEdit.Text.ToString(), dataSet1.MANHINH) == false)
                {
                    mANHINHTableAdapter.Insert(mAMANHINHTextEdit.Text, tENMANHINHTextEdit.Text);
                    load_dataManHinh();
                    MessageBox.Show("Thêm thành công !!!");
                }
                else
                {
                    MessageBox.Show("Trùng khoá chính !!!");
                }
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu !!!");
            }
        }

        private void btn_Xoa_ManHinh_Click(object sender, EventArgs e)
        {
            if (gridView_ManHinh.GetFocusedDataRow() != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                int cathu = gridView_ManHinh.FocusedRowHandle;
                string sql_mamanhinh = gridView_ManHinh.GetRowCellValue(cathu, "MAMANHINH").ToString();
                string sql_tenmanhinh = gridView_ManHinh.GetRowCellValue(cathu, "TENMANHINH").ToString();

                MessageBox.Show(sql_mamanhinh);
                mANHINHTableAdapter.Delete(sql_mamanhinh, sql_tenmanhinh);
                load_dataManHinh();
            }
            else
            {
                MessageBox.Show("chọn dòng muốn xóa !!!");
            }
        }

        private void btn_Sua_ManHinh_Click(object sender, EventArgs e)
        {
            if (gridView_ManHinh.GetFocusedDataRow() != null)
            {
                int cathu = gridView_ManHinh.FocusedRowHandle;
                string sql_mamanhinh = gridView_ManHinh.GetRowCellValue(cathu, "MAMANHINH").ToString();
                string sql_tenmanhinh = gridView_ManHinh.GetRowCellValue(cathu, "TENMANHINH").ToString();

                DataSet1.MANHINHRow data = dataSet1.MANHINH.FindByMAMANHINH(sql_mamanhinh);
                data.TENMANHINH = sql_tenmanhinh;
                mANHINHTableAdapter.Update(this.dataSet1.MANHINH);

                load_dataManHinh();
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu !!!");
            }
        }

        private void loadgrid()
        {
            if (gridViewNhomNguoiDung.GetFocusedDataRow() != null)
            {
                gridView_TaiKhoan.ClearSelection();
                gridViewManHinh.ClearSelection();
                //load các giá trị tài khoản
                for (int i = 0; i < gridView_TaiKhoan.DataRowCount; i++)
                {
                    nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Fill(dataSet1.NGUOIDUNGNHOMNGUOIDUNG);
                    DataSet1.NGUOIDUNGNHOMNGUOIDUNGRow data = dataSet1.NGUOIDUNGNHOMNGUOIDUNG.FindByMANVMANHOM(gridView_TaiKhoan.GetDataRow(i)["MANV"].ToString().Trim(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString());
                    if (data != null)
                    {
                        gridView_TaiKhoan.SelectRow(i);
                    }

                }

                //load các giá trị màn hình
                for (int i = 0; i < gridViewManHinh.DataRowCount; i++)
                {
                    pHANQUYENTableAdapter.Fill(dataSet1.PHANQUYEN);
                    DataSet1.PHANQUYENRow data = dataSet1.PHANQUYEN.FindByMAMANHINHMANHOM(gridViewManHinh.GetDataRow(i)["MAMANHINH"].ToString().Trim(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString());
                    if (data != null)
                    {
                        gridViewManHinh.SelectRow(i);
                    }
                }
            }
        }

        private void gridViewManHinh_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int i = gridViewManHinh.GetFocusedDataSourceRowIndex();
            //update ManHinh
            if (gridViewManHinh.IsRowSelected(i))//dang duoc click
            {
                try
                {
                    pHANQUYENTableAdapter.Delete(gridViewManHinh.GetRowCellValue(i, "MAMANHINH").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), true);
                    //gridViewManHinh.CancelSelection();

                }
                catch
                {

                }
            }
            else //dang khong duoc click
            {
                try
                {
                    pHANQUYENTableAdapter.Insert(gridViewManHinh.GetRowCellValue(i, "MAMANHINH").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), true);
                    //gridViewManHinh.SelectRow(i);
                    //gridControlManHinh.Refresh();
                }
                catch
                {
                    pHANQUYENTableAdapter.Update(true, gridViewManHinh.GetRowCellValue(i, "MAMANHINH").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), true);
                    //gridViewManHinh.SelectRow(i);
                    // gridControlManHinh.Refresh();
                }
            }
            loadgrid();
        }

        private void gridView_TaiKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            int i = gridView_TaiKhoan.GetFocusedDataSourceRowIndex();
            //update ManHinh
            if (gridView_TaiKhoan.IsRowSelected(i))
            {
                try
                {
                    nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Delete(gridView_TaiKhoan.GetRowCellValue(i, "MANV").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), "");
                    //gridView_TaiKhoan.CancelSelection();
                    //gridControl_TaiKhoan.Refresh();
                }
                catch
                {

                }
            }
            else
            {

                try
                {
                    nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Insert(gridView_TaiKhoan.GetRowCellValue(i, "MANV").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), "");
                    //gridView_TaiKhoan.SelectRow(i);
                    //gridControl_TaiKhoan.Refresh();
                }
                catch
                {
                    nGUOIDUNGNHOMNGUOIDUNGTableAdapter.Update("", gridView_TaiKhoan.GetRowCellValue(i, "MANV").ToString(), gridViewNhomNguoiDung.GetFocusedRowCellValue("MANHOM").ToString(), "");
                    //gridView_TaiKhoan.SelectRow(i);
                    //gridControl_TaiKhoan.Refresh();
                }
            }
            loadgrid();
        }

        private void gridViewNhomNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadgrid();
        }
    }
}
