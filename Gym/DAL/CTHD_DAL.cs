using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class CTHD_DAL
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_CTHD()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_CTHD");
        }

        public DataTable select_CTHDMa(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_CTHDMa", name, value, 1);
        }

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_CTHD( string MaHang, int SL)
        {
            //thaotac.KetnoiCSDL();
            name = new string[2];
            value = new object[2];
            name[0] = "@MaHang"; value[0] = MaHang;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@SL"; value[1] = SL;
            return thaotac.SQL_Thuchien("Insert_CTHD", name, value, 2);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_CTHD(string MaHD, string MaHang, int SL)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@MaHang"; value[1] = MaHang;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@SL"; value[2] = SL;
            return thaotac.SQL_Thuchien("Update_CTHD", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_CTHD(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return thaotac.SQL_Thuchien("Delete_CTHD", name, value, 1);
        }

    }
}
