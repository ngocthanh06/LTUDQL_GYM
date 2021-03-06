﻿using System;
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
       
        public DataTable select_InHoaDon(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return thaotac.SQL_Laydulieu_CoDK("select_InHoaDon", name, value, 1);
        }
        public DataTable select_HoaDonbyMonth(int thang, int nam)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@Thang"; value[0] = thang;
            name[1] = "@nam"; value[1] = nam;
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonbyMonth", name, value, 2);
        }
        public DataTable select_HoaDonMa(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMa", name, value, 1);
        }
        public DataTable select_HoaDontimkiem(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDontimkiem", name, value, 1);
        }

        //MaNV
        public DataTable select_HoaDonByMaNV(string MaNV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaNV"; value[0] = MaNV;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonByMaNV", name, value, 1);
        }

        public DataTable select_HoaDonNVvaKH(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonNVvaKH", name, value, 1);
        }
        //Mã NV và ngày
        public DataTable select_HoaDonMaNVbyday(string MaNV, string NgayBD, string NgayKT)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@NgayBD"; value[1] = NgayBD;
            name[2] = "@NgayKT"; value[2] = NgayKT;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMaNVbyday", name, value, 3);
        }
        //MaNV, MaHD, NgayHD
        public DataTable select_HoaDonMaHDvaMaNVbyday(string MaNV,string MaHD, string NgayHD)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaHD"; value[0] = MaNV;
            name[1] = "@MaHD"; value[1] = MaHD;
            name[2]= "@NgayHD"; value[2] = NgayHD;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMaHDvaMaNVbyday", name, value, 3);
        }
        //MaNV, Thang

        public DataTable select_HoaDonMaNVbyMonth(string MaNV, int Thang, int Nam)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@Thang"; value[1] = Thang;
            name[2] = "@nam"; value[2] = Nam;
            //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMaNVbyMonth", name, value, 3);
        }
        //MaNV MaHD
        public DataTable select_HoaDonMaHDvaMaNV(string MaNV, string MaHD)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@MaHD"; value[1] = MaHD;
             //thaotac.KetnoiCSDL();
            return thaotac.SQL_Laydulieu_CoDK("select_HoaDonMaHDvaMaNV", name, value, 2);
        }
        //phương thức này gọi phương thức SQL_Thuchien ở lớp ThaoTac_CoSoDuLieu để thực hiện insert
        public int insert_HoaDon(string MaHD,string NgayHD, string MaKH, string MaNV, int TongHoaDon)
        {
            //thaotac.KetnoiCSDL();
            name = new string[5];
            value = new object[5];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@NgayHD"; value[1] = NgayHD;//@HoTen,... là các tham số phải giống với tham số khai báo ở Stores Procedures trong CSDL
            name[2] = "@MaKH"; value[2] = MaKH;
            name[3] = "@MaNV"; value[3] = MaNV;
            name[4] = "@TongHoaDon"; value[4] = TongHoaDon;
            return thaotac.SQL_Thuchien("Insert_HoaDon", name, value, 5);
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
