using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class LoaiHang_BLL
    {
        LoaiHang LH = new LoaiHang();
        public DataTable select_LoaiHang()
        {
            return LH.select_LoaiHang();
        }

        public DataTable select_LoaiHangMa(string MaLH)
        {
            return LH.select_LoaiHangMa( MaLH);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_LoaiHang(string MaLH, string TenLH, string GhiChu)
        {
            return LH.insert_LoaiHang(MaLH,TenLH, GhiChu);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_LoaiHang(string MaLH, string TenLH, string GhiChu)
        {
            return LH.update_LoaiHang( MaLH, TenLH, GhiChu);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_LoaiHang(string MaLH)
        {
            return LH.delete_LoaiHang(MaLH);
        }
    }
}
