using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLySanPham
{
    public partial class frmDanhMuc : Form
    {
        public static bool CoThayDoi = false;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void btnLuuDM_Click(object sender, EventArgs e)
        {
            DanhMuc dm = new DanhMuc();
            dm.TenDM = txtTenDanhMuc.Text;
            dm.MaDM = txtMaDanhMuc.Text;
            bool DmDaLuuHayChua = false;
            foreach(DanhMuc item in frmMain.danhSachDM)
            {
                if (item.MaDM == dm.MaDM)
                    DmDaLuuHayChua = true;
            }
            if (DmDaLuuHayChua == false)
            {
                frmMain.danhSachDM.Add(dm);
                HienThiDanhMucLenListBox();
                txtMaDanhMuc.Text = "";
                txtTenDanhMuc.Text = "";
                txtMaDanhMuc.Focus();
                CoThayDoi = true;
                //FileFactory.LuuDanhMuc(frmMain.danhSachDM, frmMain.DuongDan);
            }
            else
            {
                MessageBox.Show("Ma danh muc da ton tai!", "Thong bao");
            }   
        }
        void HienThiDanhMucLenListBox()
        {
            lstDanhMuc.Items.Clear();
            foreach(DanhMuc dm in frmMain.danhSachDM)
            {
                lstDanhMuc.Items.Add(dm);
            }
        }

        private void lvDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMucLenListBox();
        }

        private void btnXoaDM_Click(object sender, EventArgs e)
        {
            if (lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                DialogResult ret = MessageBox.Show("Ban co chac muon xoa?", "Xac nhan xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    frmMain.danhSachDM.Remove(dm);
                    CoThayDoi = true;
                    //MessageBox.Show("Da xoa!");
                    HienThiDanhMucLenListBox();

                }               
            }
        }

        private void lstDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDanhMuc.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMuc.SelectedItem as DanhMuc;
                txtMaDanhMuc.Text = dm.MaDM;
                txtTenDanhMuc.Text = dm.TenDM;
            }
        }

        private void frmDanhMuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileFactory.LuuDanhMuc(frmMain.danhSachDM, frmMain.DuongDan);
        }

        private void btnDongDM_Click(object sender, EventArgs e)
        {
            if (CoThayDoi == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
