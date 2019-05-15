using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class TaiKhoan_BLL
    {
        TaiKhoan TK = new TaiKhoan();
        public DataTable select_TaiKhoan()
        {
            return TK.select_TaiKhoan();
        }

        public DataTable select_TaiKhoanMa(string MaKH)
        {
            return TK.select_TaiKhoanMa(MaKH);
        }

        public DataTable select_loginTK(string TenDN, string Matkhau)
        {
            return TK.select_loginTK( TenDN, Matkhau);
        }
        
        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_TaiKhoan(string MaTK,string TenDN, string MatKhau, int quyen)
        {
            return TK.insert_TaiKhoan( MaTK,TenDN,  MatKhau, quyen);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_TaiKhoan(string MaTK, string TenDN, string MatKhau, int quyen)
        {
            return TK.update_TaiKhoan(MaTK, TenDN, MatKhau, quyen);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_TaiKhoan(string MaTK)
        {
            return TK.delete_TaiKhoan(MaTK);
        }
    }
}
