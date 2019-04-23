using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Hoadon
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_HoaDon()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_HoaDon");
        }
        public DataTable select_HoaDonMa(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMa", name, value, 1);
        }
        

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_HoaDon(string NgayHD, string MaKH, string MaNV)
        {
            //thaotac.KetnoiCSDL();
            name = new string[3];
            value = new object[3];
            name[0] = "@NgayHD"; value[0] = NgayHD;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@MaKH"; value[1] = MaKH;
            name[2] = "@MaNV"; value[2] = MaNV;
            return thaotac.SQL_Thuchien("Insert_HoaDon", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_HoaDon(string MaHD, string NgayHD, string MaKH, string MaNV)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@NgayHD"; value[1] = NgayHD;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaKH"; value[2] = MaKH;
            name[3] = "@MaNV"; value[3] = MaNV;
            return thaotac.SQL_Thuchien("Update_HoaDon", name, value, 4);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_HoaDon(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return thaotac.SQL_Thuchien("Delete_HoaDon", name, value, 1);
        }
    }
}
