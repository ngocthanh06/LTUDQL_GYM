using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class LoaiHang
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_LoaiHang()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_LoaiHang");
        }
        public DataTable select_LoaiHangMa(string MaLH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaLH"; value[0] = MaLH;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_LoaiHangMa", name, value, 1);
        }
        

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_LoaiHang(string MaLH,string TenLH, string GhiChu)
        {
            //thaotac.KetnoiCSDL();
            name = new string[3];
            value = new object[3];
            name[0] = "@MaLH"; value[0] = MaLH;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@TenLH"; value[1] = TenLH;
            name[2] = "@GhiChu"; value[2] = GhiChu;
            
            return thaotac.SQL_Thuchien("Insert_LoaiHang", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_LoaiHang(string MaLH, string TenLH, string GhiChu)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaLH"; value[0] = MaLH;
            name[1] = "@TenLH"; value[1] = TenLH;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@GhiChu"; value[2] = GhiChu;
            return thaotac.SQL_Thuchien("Update_LoaiHang", name, value, 3);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_LoaiHang(string MaLH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaLH"; value[0] = MaLH;
            return thaotac.SQL_Thuchien("Delete_LoaiHang", name, value, 1);
        }
    }
}
