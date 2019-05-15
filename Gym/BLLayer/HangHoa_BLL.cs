using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLLayer
{
    public class HangHoa_BLL
    {
        Hanghoa HH = new Hanghoa();
        public DataTable select_HangHoa()
        {
            return HH.select_HangHoa();
        }

        public DataTable select_HangHoaMa(string MaHang)
        {
            return HH.select_HangHoaMa(MaHang);
        }

        public DataTable select_HangHoaMaLH(string MaLH)
        {
            return HH.select_HangHoaMaLH(MaLH);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_HangHoa(string MaHang, string TenHang, float DonGia, int SLCon, string MaLH, object hinhanh, string hansudung, string ghichu)
        {
            return HH.insert_HangHoa(MaHang, TenHang, DonGia, SLCon, MaLH, hinhanh, hansudung, ghichu);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_HangHoa(string MaHang, string TenHang, float DonGia, int SLCon, string MaLH, object hinhanh, string hansudung, string ghichu)
        {
            return HH.update_HangHoa(MaHang, TenHang, DonGia, SLCon, MaLH, hinhanh, hansudung, ghichu);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_HangHoa(string MaHang)
        {
            return HH.delete_HangHoa(MaHang);
        }

        
    }
}
