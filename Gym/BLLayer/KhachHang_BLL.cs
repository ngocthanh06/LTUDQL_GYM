using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class KhachHang_BLL
    {
        Khachhang KH = new Khachhang();
        public DataTable select_KhachHang()
        {
            return KH.select_KhachHang();
        }

        public DataTable select_KhachHangMa(string MaKH)
        {
            return KH.select_KhachHangMa(MaKH);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_KhachHang(string MaKH,string TenKH, string DiaChi, string SDT, string NgaySinh, bool GioiTinh, string GhiChu, object avatar, string Mathe)
        {
            return KH.insert_KhachHang(  MaKH, TenKH,  DiaChi,  SDT,  NgaySinh,  GioiTinh,  GhiChu,  avatar,  Mathe);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_KhachHang(string MaKH, string TenKH, string DiaChi, string SDT, string NgaySinh, bool GioiTinh, string GhiChu, object avatar)
        {
            return KH.update_KhachHang( MaKH,  TenKH,  DiaChi,  SDT,  NgaySinh,  GioiTinh,  GhiChu,  avatar);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_KhachHang(string MaKH)
        {
            return KH.delete_KhachHang(MaKH);
        }
    }
}
