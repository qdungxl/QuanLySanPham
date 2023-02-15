using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChuongTrinhQuanLySanPham
{
    public class FileFactory
    {
        public static bool LuuDanhMuc(List<DanhMuc> dsDM, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dsDM);
                fs.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<DanhMuc> DocDanhMuc(string path)
        {
            List<DanhMuc> dsDM = new List<DanhMuc>();
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                object data = bf.Deserialize(fs);
                dsDM = data as List<DanhMuc>;
                fs.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return dsDM;
        }
    }
}
