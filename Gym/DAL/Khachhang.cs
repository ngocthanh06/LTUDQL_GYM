using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class Khachhang
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_KhachHang()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_KhachHang");
        }
        public DataTable select_KhachHangMa(string MaKH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaKH"; value[0] = MaKH;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_KhachHangMa", name, value, 1);
        }
       

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_KhachHang(string MaKH, string TenKH, string DiaChi, string SDT, string NgaySinh, bool GioiTinh, string GhiChu, object avatar, string Mathe)
        {
            //thaotac.KetnoiCSDL();
            name = new string[9];
            value = new object[9];
            name[0] = "@MaKH"; value[0] = MaKH;
            name[1] = "@TenKH"; value[1] = TenKH;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@DiaChi"; value[2] = DiaChi;
            name[3] = "@SDT"; value[3] = SDT;
            name[4] = "@NgaySinh"; value[4] = NgaySinh;
            name[5] = "@GioiTinh"; value[5] = GioiTinh;
            name[6] = "@GhiChu"; value[6] = GhiChu;
            name[7] = "@avatar"; value[7] = avatar;
            name[8] = "@Mathe"; value[8] = Mathe;
            return thaotac.SQL_Thuchien("Insert_KhachHang", name, value, 9);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_KhachHang(string MaKH, string TenKH, string DiaChi, string SDT, string NgaySinh, bool GioiTinh, string GhiChu, object avatar)
        {
            name = new string[8];
            value = new object[8];
            name[0] = "@MaKH"; value[0] = MaKH;
            name[1] = "@TenKH"; value[1] = TenKH;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@DiaChi"; value[2] = DiaChi;
            name[3] = "@SDT"; value[3] = SDT;
            name[4] = "@NgaySinh"; value[4] = NgaySinh;
            name[5] = "@GioiTinh"; value[5] = GioiTinh;
            name[6] = "@GhiChu"; value[6] = GhiChu;
            name[7] = "@avatar"; value[7] = avatar;
            
            return thaotac.SQL_Thuchien("Update_KhachHang", name, value, 8);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_KhachHang(string MaKH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaKH"; value[0] = MaKH;
            return thaotac.SQL_Thuchien("Delete_KhachHang", name, value, 1);
        }
    }
}
