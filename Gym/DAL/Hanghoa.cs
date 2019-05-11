using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Hanghoa
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_HangHoa()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_HangHoa");
        }
        public DataTable select_HangHoaMa(string MaHang)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHang"; value[0] = MaHang;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HangHoaMa", name, value, 1);
        }
        

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_HangHoa(string MaHang, string TenHang, float DonGia, int SLCon, string MaLH, object hinhanh, string hansudung, string ghichu)
        {
            //thaotac.KetnoiCSDL();
            name = new string[8];
            value = new object[8];
            name[0] = "@MaHang"; value[0] = MaHang;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@TenHang"; value[1] = TenHang;
            name[2] = "@DonGia"; value[2] = DonGia;
            name[3] = "@SLCon"; value[3] = SLCon;
            name[4] = "@MaLH"; value[4] = MaLH;
            name[5] = "@hinhanh"; value[5] = hinhanh;
            name[6] = "@hansudung"; value[6] = hansudung;
            name[7] = "@ghichu"; value[7] = ghichu;
            return thaotac.SQL_Thuchien("Insert_HangHoa", name, value, 8);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_HangHoa(string TenHang, string DVT, float DonGia, int SLCon, string MaLH, object hinhanh, string hansudung, string ghichu)
        {
            name = new string[8];
            value = new object[8];
            name[0] = "@MaHang"; value[0] = TenHang;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[1] = "@TenHang"; value[1] = DVT;
            name[2] = "@DonGia"; value[2] = DonGia;
            name[3] = "@SLCon"; value[3] = SLCon;
            name[4] = "@MaLH"; value[4] = MaLH;
            name[5] = "@hinhanh"; value[5] = hinhanh;
            name[6] = "@hansudung"; value[6] = hansudung;
            name[7] = "@ghichu"; value[7] = ghichu;
            return thaotac.SQL_Thuchien("Update_HangHoa", name, value, 8);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_HangHoa(string MaHang)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHang"; value[0] = MaHang;
            return thaotac.SQL_Thuchien("Delete_HangHoa", name, value, 1);
        }
    }
}
