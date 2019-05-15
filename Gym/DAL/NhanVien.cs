using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class NhanVien
    {
        ThaotacCSDL thaotac = new ThaotacCSDL();
        //khai báo 2 mảng để truyền tên tham số và giá trị tham số vào Stored Procedures
        string[] name = { };
        object[] value = { };
        //phương thức này gọi phương thức SQL_Laydulieu ở lớp ThaoTac_CoSoDuLieu để thực hiện lấy dữ liệu
        public DataTable select_NhanVien()
        {
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu("select_NhanVien");
        }
        public DataTable select_NhanVienMa(string MaNV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaNV"; value[0] = MaNV;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_NhanVienMa", name, value, 1);
        }
        public DataTable select_NhanVienMaTK(string MaTK)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaTK"; value[0] = MaTK;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_NhanVienMaTK", name, value, 1);
        }
        

        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_NhanVien(string MaNV,string TenNV, string NgaySinh, bool GioiTinh, string DiaChi, string SDT, string MaTK,object hinhanh,string ghichu ,bool trangthai)
        {
            //thaotac.KetnoiCSDL();
            name = new string[10];
            value = new object[10];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@TenNV"; value[1] = TenNV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@NgaySinh"; value[2] = NgaySinh;
            name[3] = "@GioiTinh"; value[3] = GioiTinh;
            name[4] = "@DiaChi"; value[4] = DiaChi;
            name[5] = "@SDT"; value[5] = SDT;
            name[6] = "@MaTK"; value[6] = MaTK;
            name[7] = "@hinhanh"; value[7] = hinhanh;
            name[8] = "@ghichu"; value[8] = ghichu;
            name[9] = "@TrangThai"; value[9] = trangthai;
           
            return thaotac.SQL_Thuchien("Insert_NhanVien", name, value, 10);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện update
        public int update_NhanVien(string MaNV, string TenNV, string NgaySinh, bool GioiTinh, string DiaChi, string SDT, object hinhanh, string ghichu, bool trangthai)
        {
            name = new string[9];
            value = new object[9];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@TenNV"; value[1] = TenNV;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@NgaySinh"; value[2] = NgaySinh;
            name[3] = "@GioiTinh"; value[3] = GioiTinh;
            name[4] = "@DiaChi"; value[4] = DiaChi;
            name[5] = "@SDT"; value[5] = SDT;      
            name[6] = "@hinhanh"; value[6] = hinhanh;
            name[7] = "@ghichu"; value[7] = ghichu;
            name[8] = "@TrangThai"; value[8] = trangthai;
            return thaotac.SQL_Thuchien("Update_NhanVien", name, value, 9);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện delete
        public int delete_NhanVien(string MaNV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaNV"; value[0] = MaNV;
            return thaotac.SQL_Thuchien("Delete_NhanVien", name, value, 1);
        }
    }
}
