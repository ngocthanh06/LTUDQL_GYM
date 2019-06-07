using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class HoaDon_BLL
    {
        Hoadon HD = new Hoadon();
        public DataTable select_HoaDon()
        {
            return HD.select_HoaDon();
        }
        
        public DataTable select_InHoaDon(string MaHD)
        {
            return HD.select_InHoaDon( MaHD);
        }
        public DataTable select_HoaDonbyMonth(int thang, int nam)
        {
            return HD.select_HoaDonbyMonth(thang,nam);
        }
        public DataTable select_HoaDonMa(string MaHD)
        {
            return HD.select_HoaDonMa(MaHD);
        }
       
        public DataTable select_HoaDontimkiem(string MaHD)
        {
            return HD.select_HoaDontimkiem(MaHD);
        }
        //Mã NV
        public DataTable select_HoaDonByMaNV(string MaNV)
        {
            return HD.select_HoaDonByMaNV(MaNV);
        }
        public DataTable select_HoaDonNVvaKH(string MaHD)
        {
            return HD.select_HoaDonNVvaKH(MaHD);
        }
        //Mã NV, Ngày
        public DataTable select_HoaDonMaNVbyday(string MaNV, string NgayBD, string NgayKT)
        {
            return HD.select_HoaDonMaNVbyday(MaNV, NgayBD, NgayKT);
        }
        //MaNV Và MaHD
        public DataTable select_HoaDonMaHDvaMaNV(string MaNV, string MaHD)
        {
            return HD.select_HoaDonMaHDvaMaNV( MaNV,  MaHD);
        }
        //MaNV, MaHD, Ngay
        public DataTable select_HoaDonMaHDvaMaNVbyday(string MaNV, string MaHD, string NgayHD)
        {
            return HD.select_HoaDonMaHDvaMaNVbyday( MaNV, MaHD,  NgayHD);
        }
        //MaNV, Thang
        public DataTable select_HoaDonMaNVbyMonth(string MaNV, int Thang, int Nam)
        {
            return HD.select_HoaDonMaNVbyMonth(MaNV, Thang, Nam);
        }
        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_HoaDon(string MaHD,string NgayHD, string MaKH, string MaNV, int TongHoaDon)
        {
            return HD.insert_HoaDon( MaHD,NgayHD, MaKH, MaNV,TongHoaDon);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_HoaDon(string MaHD, string NgayHD, string MaKH, string MaNV)
        {
            return HD.update_HoaDon(MaHD, NgayHD, MaKH, MaNV);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_HoaDon(string MaHD)
        {
            return HD.delete_HoaDon(MaHD);
        }
    }
}
