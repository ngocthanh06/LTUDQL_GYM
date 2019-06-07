using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class The
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_The()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_The");
        }
        public DataTable select_ThebyDichvuAll()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_ThebyDichvuAll");
        }
        public DataTable select_ThebyDichvuMaNV(string MaNV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaNV"; value[0] = MaNV;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_ThebyDichvuMaNV", name, value, 1);
        }
        public DataTable select_TheDichVubyMonth(int thang, int nam)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@Thang"; value[0] = thang;
            name[1] = "@nam";value[1]= nam;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_TheDichVubyMonth", name, value, 2);
        }
        public DataTable select_ThebyDichvuMaNVandMonthYear(string MaNV, int Month, int Year)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@Thang"; value[1] = Month;
            name[2] = "@Nam"; value[2] = Year;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_ThebyDichvuMaNVandMonthYear", name, value, 3);
        }
        public DataTable select_TheMa(string MaKH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaKH"; value[0] = MaKH;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_ThebyMaKH", name, value, 1);
        }

        public DataTable select_MaThe(string Mathe)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaThe"; value[0] = Mathe;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_TheMa", name, value, 1);
        }


        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_The(string Mathe, string NgayDK, string MaDV, string MaKH, string MaNV)
        {
            //thaotac.KetnoiCSDL();
            name = new string[5];
            value = new object[5];
            name[0] = "@Mathe"; value[0] = Mathe;
            name[1] = "@NgayDK"; value[1] = NgayDK;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaDV"; value[2] = MaDV;
            name[3] = "@MaKH"; value[3] = MaKH;
            name[4] = "@MaNV"; value[4] = MaNV;


            return thaotac.SQL_Thuchien("insert_The", name, value, 5);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_The(string Mathe, string NgayDK, string MaDV)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@Mathe"; value[0] = Mathe;
            name[1] = "@NgayDK"; value[1] = NgayDK;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaDV"; value[2] = MaDV;

            return thaotac.SQL_Thuchien("update_The", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_The(string Mathe)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Mathe"; value[0] = Mathe;
            return thaotac.SQL_Thuchien("delete_The", name, value, 1);
        }
    }
}
