using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DichVu
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_DichVu()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_DichVu");
        }

        public DataTable select_DichVuMa(string MaDV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaDV"; value[0] = MaDV;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_DichVuMa", name, value, 1);
        }

        //Dịch vụ + THẻ by mã thẻ
        public DataTable select_DichVu_TheByMa(string MaDV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@Mathe"; value[0] = MaDV;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_DichVu_TheByMa", name, value, 1);
        }

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_DichVu(string TenDV, int Thoihan, float Gia)
        {
            //thaotac.KetnoiCSDL();
            name = new string[3];
            value = new object[3];
            name[0] = "@TenDV"; value[0] = TenDV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@Thoihan"; value[1] = Thoihan;
            name[2] = "@Gia"; value[2] = Gia;
            return thaotac.SQL_Thuchien("Insert_DichVu", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_DichVu(string MaDV, string TenDV, int Thoihan, float Gia)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaDV"; value[0] = MaDV;
            name[1] = "@TenDV"; value[1] = TenDV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@Thoihan"; value[2] = Thoihan;
            name[3] = "@Gia"; value[3] = Gia;
            return thaotac.SQL_Thuchien("Update_DichVu", name, value, 4);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_DichVu(string MaDV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaDV"; value[0] = MaDV;
            return thaotac.SQL_Thuchien("Delete_DichVu", name, value, 1);
        }
    }
}
