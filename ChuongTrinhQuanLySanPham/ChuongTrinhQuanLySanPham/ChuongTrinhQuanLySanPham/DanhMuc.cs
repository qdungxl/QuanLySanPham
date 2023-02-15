using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuongTrinhQuanLySanPham
{
    [Serializable]
    public class DanhMuc
    {
        Dictionary<string, SanPham> dsSP = new Dictionary<string, SanPham>();
        public string MaDM { get; set; }
        public string TenDM { get; set; }
        public void  ThemSanPham(SanPham sp)
        {
            if (this.dsSP.ContainsKey(sp.MaSP) == false)
            {
                
                this.dsSP.Add(sp.MaSP, sp);
            }
        }
        public Dictionary<string,SanPham> SanPhams
        {
            get { return this.dsSP; }
            set { this.dsSP = value; }
        }
        public void XoaSanPham(SanPham sp)
        {
            this.dsSP.Remove(sp.MaSP);
        }
        public override string ToString()
        {
            return this.TenDM;
        }
    }
}
