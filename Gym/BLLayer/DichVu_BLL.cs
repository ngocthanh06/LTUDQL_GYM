using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
namespace BLLayer
{
    public class DichVu_BLL
    {
        DichVu DV = new DichVu();
        public DataTable select_DichVu()
        {
            return DV.select_DichVu();
        }

        public DataTable select_DichVuMa(string MaDV)
        {
            return DV.select_DichVuMa(MaDV);
        }

        //Dịch vụ + thẻ by ma thẻ
        public DataTable select_DichVu_TheByMa(string Mathe)
        {
            return DV.select_DichVu_TheByMa(Mathe);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_DichVu(string TenDV, int Thoihan, float Gia)
        {
            return DV.insert_DichVu(TenDV, Thoihan, Gia);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_DichVu(string MaDV, string TenDV, int Thoihan, float Gia)
        {
            return DV.update_DichVu(MaDV, TenDV, Thoihan, Gia);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_DichVu(string MaDV)
        {
            return DV.delete_DichVu(MaDV);
        }
    }
}
