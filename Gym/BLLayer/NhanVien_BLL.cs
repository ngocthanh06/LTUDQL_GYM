using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class NhanVien_BLL
    {
        NhanVien NV = new NhanVien();
        public DataTable select_NhanVien()
        {
            return NV.select_NhanVien();
        }

        public DataTable select_NhanVienMa(string MaNV)
        {
            return NV.select_NhanVienMa(MaNV);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_NhanVien(string TenNV, string NgaySinh, bool GioiTinh, string DiaChi, string SDT, string MaTK)
        {
            return NV.insert_NhanVien(TenNV, NgaySinh, GioiTinh, DiaChi, SDT, MaTK);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_NhanVien(string MaNV, string TenNV, string NgaySinh, bool GioiTinh, string DiaChi, string SDT, string MaTK)
        {
            return NV.update_NhanVien(MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SDT, MaTK);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_NhanVien(string MaNV)
        {
            return NV.delete_NhanVien(MaNV);
        }
    }
}
