using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAL;

namespace BLLayer
{
    public class CTHD_BLL
    {
        CTHD_DAL CTHD = new CTHD_DAL();
        //phương thức này gọi phương thức sv_select() ở lớp SinhVien_DAL (tầng DAL)
        public DataTable select_CTHD()
        {
            return CTHD.select_CTHD();
        }

        public DataTable select_CTHDMa(string MaHD)
        {
            return CTHD.select_CTHDMa(MaHD);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_CTHD(string MaHD,string MaHang, int SL)
        {
            return CTHD.insert_CTHD(MaHD,MaHang, SL);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_CTHD(string MaHD, string MaHang, int SL)
        {
            return CTHD.update_CTHD(MaHD, MaHang, SL);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_CTHD(string MaHD)
        {
            return CTHD.delete_CTHD(MaHD);
        }

    }
}
