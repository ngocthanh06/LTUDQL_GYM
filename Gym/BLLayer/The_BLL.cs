using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLLayer
{
    public class The_BLL
    {
        The Th = new The();
        public DataTable select_The()
        {
            return Th.select_The();
        }

        public DataTable select_TheMa(string MaKH)
        {
            return Th.select_TheMa(MaKH);
        }

        //phương thức này gọi phương thức sv_insert() ở lớp SinhVien_DAL (tầng DAL)
        public int insert_The(string Mathe,string NgayDK, string MaDV)
        {
            return Th.insert_The( Mathe,NgayDK, MaDV);
        }

        //phương thức này gọi phương thức sv_update() ở lớp SinhVien_DAL (tầng DAL)
        public int update_The(string Mathe, string NgayDK, string MaDV, string GhiChu)
        {
            return Th.update_The(Mathe, NgayDK, MaDV, GhiChu);
        }

        //phương thức này gọi phương thức sv_delete() ở lớp SinhVien_DAL (tầng DAL)
        public int delete_The(string Mathe)
        {
            return Th.delete_The(Mathe);
        }
    }
}
