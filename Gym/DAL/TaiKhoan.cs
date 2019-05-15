using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class TaiKhoan
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_TaiKhoan()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_Taikhoan");
        }
        public DataTable select_TaiKhoanMa(string MaTK)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaTK"; value[0] = MaTK;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_TaikhoanMa", name, value, 1);
        }
        //login
        public DataTable select_loginTK(string TenDN, string Matkhau)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@TenDN"; value[0] = TenDN;
            name[1] = "@MatKhau"; value[1] = Matkhau;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_LoginTK", name, value, 2);
        }

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_TaiKhoan(string MaTK,string TenDN, string MatKhau, int quyen)
        {
            //thaotac.KetnoiCSDL();
            name = new string[4];
            value = new object[4];
            name[0] = "@MaTK"; value[0] = MaTK;
            name[1] = "@TenDN"; value[1] = TenDN;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MatKhau"; value[2] = MatKhau;
            name[3] = "@quyen"; value[3] = quyen;

            return thaotac.SQL_Thuchien("Insert_Taikhoan", name, value, 4);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_TaiKhoan(string MaTK, string TenDN, string MatKhau, int quyen)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@MaTK"; value[0] = MaTK;
            name[1] = "@TenDN"; value[1] = TenDN;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MatKhau"; value[2] = MatKhau;
            name[3] = "@quyen"; value[3] = quyen;
            return thaotac.SQL_Thuchien("Update_Taikhoan", name, value, 4);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_TaiKhoan(string MaTK)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaTK"; value[0] = MaTK;
            return thaotac.SQL_Thuchien("Delete_Taikhoan", name, value, 1);
        }
    }
}
