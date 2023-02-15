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
    public partial class frmMain : Form
    {
        public static List<DanhMuc> danhSachDM = new List<DanhMuc>();
        public static string DuongDan = Application.StartupPath + "\\data.txt";
        public frmMain()
        {
            InitializeComponent();
        }
        public void HienThiDMLenComboBox()
        {
            cboDanhMuc.Items.Clear();
            foreach(DanhMuc dm in danhSachDM)
            {
                cboDanhMuc.Items.Add(dm);
            }
        }
        public void HienThiLenListBox(DanhMuc dm)
        {
            lstSanPham.Items.Clear();
            foreach(KeyValuePair<string,SanPham> item in dm.SanPhams)
            {
                lstSanPham.Items.Add(item.Value);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            danhSachDM = FileFactory.DocDanhMuc(DuongDan);
            HienThiDMLenComboBox();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmDM = new frmDanhMuc();
            frmDanhMuc.CoThayDoi = false;
            if (frmDM.ShowDialog() == DialogResult.OK)
            {
                HienThiDMLenComboBox();
            }
        }

        private void btnLuuThongTin_Click(object sender, EventArgs e)
        {
            if (cboDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Ban chua chon danh muc");
            }
            else
            {
                if (txtMaSanPham.Text == "" || txtTenSanPham.Text == "" || txtXuatXu.Text == "" || txtDonGia.Text == "")
                {
                    MessageBox.Show("Thong tin san pham chua day du. Hay kiem tra lai.");
                }
                else
                {
                    SanPham sp = new SanPham();
                    sp.MaSP = txtMaSanPham.Text;
                    sp.TenSP = txtTenSanPham.Text;
                    sp.DonGia = double.Parse(txtDonGia.Text);
                    sp.XuatXu = txtXuatXu.Text;
                    sp.HanDung = dtpHanDung.Value;
                    bool SpDaTonTai = false;
                    DanhMuc dm = new DanhMuc();
                    dm = cboDanhMuc.SelectedItem as DanhMuc;
                    foreach(KeyValuePair<string,SanPham> item in dm.SanPhams)
                    {
                        if (item.Key == sp.MaSP)
                            SpDaTonTai = true;
                    }
                    if (SpDaTonTai == false)
                    {
                        dm.ThemSanPham(sp);
                        HienThiLenListBox(dm);
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtXuatXu.Text = "";
                        txtDonGia.Text = "";
                        txtMaSanPham.Focus();
                    }   
                    else
                        MessageBox.Show("Ma san pham da ton tai!");
                        
                }
            }
        }

        private void cboDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiLenListBox(cboDanhMuc.SelectedItem as DanhMuc);
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtDonGia.Text = "";
            txtXuatXu.Text = "";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileFactory.LuuDanhMuc(danhSachDM, DuongDan);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSanPham.SelectedIndex != -1)
            {
                SanPham sp = lstSanPham.SelectedItem as SanPham;
                txtMaSanPham.Text = sp.MaSP;
                txtTenSanPham.Text = sp.TenSP;
                txtDonGia.Text = sp.DonGia + "";
                txtXuatXu.Text = sp.XuatXu;
                dtpHanDung.Value = sp.HanDung;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoaThongTin_Click(object sender, EventArgs e)
        {
           if(lstSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Ban chua chon Sp de xoa.");
            }
            else
            {
                SanPham sp = lstSanPham.SelectedItem as SanPham;
                DanhMuc dm = cboDanhMuc.SelectedItem as DanhMuc;
                dm.XoaSanPham(sp);
                HienThiLenListBox(dm);
            }
        }
    }
}
