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

        public DataTable select_TheMa(string Mathe)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Mathe"; value[0] = Mathe;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_The", name, value, 1);
        }
       
        

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_The(string Mathe,string NgayDK, string MaDV)
        {
            //thaotac.KetnoiCSDL();
            name = new string[3];
            value = new object[3];
            name[0] = "@Mathe"; value[0] = Mathe;
            name[1] = "@NgayDK"; value[1] = NgayDK;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaDV"; value[2] = MaDV;
           

            return thaotac.SQL_Thuchien("Insert_The", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_The(string Mathe, string NgayDK, string MaDV, string GhiChu)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@Mathe"; value[0] = Mathe;
            name[1] = "@NgayDK"; value[1] = NgayDK;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaDV"; value[2] = MaDV;
            name[3] = "@GhiChu"; value[3] = GhiChu;
            return thaotac.SQL_Thuchien("Update_The", name, value, 4);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_The(string Mathe)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Mathe"; value[0] = Mathe;
            return thaotac.SQL_Thuchien("Delete_The", name, value, 1);
        }
    }
}
