using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class HoaDon_BLL
    {
        Hoadon HD = new Hoadon();
        public DataTable select_HoaDon()
        {
            return HD.select_HoaDon();
        }

        public DataTable select_HoaDonMa(string MaHD)
        {
            return HD.select_HoaDonMa(MaHD);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_HoaDon(string NgayHD, string MaKH, string MaNV)
        {
            return HD.insert_HoaDon(NgayHD, MaKH, MaNV);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_HoaDon(string MaHD, string NgayHD, string MaKH, string MaNV)
        {
            return HD.update_HoaDon(MaHD, NgayHD, MaKH, MaNV);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_HoaDon(string MaHD)
        {
            return HD.delete_HoaDon(MaHD);
        }
    }
}
