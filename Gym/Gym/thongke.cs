using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLayer;
using System.Data.SqlClient;

namespace Gym
{
    public partial class thongke : Form
    {
        CTHD_BLL CTHD = new CTHD_BLL();
        DichVu_BLL DV = new DichVu_BLL();
        HangHoa_BLL HH = new HangHoa_BLL();
        HoaDon_BLL HD = new HoaDon_BLL();
        KhachHang_BLL KH = new KhachHang_BLL();
        LoaiHang_BLL LH = new LoaiHang_BLL();
        NhanVien_BLL NV = new NhanVien_BLL();
        TaiKhoan_BLL TK = new TaiKhoan_BLL();
        The_BLL Th = new The_BLL();
        public thongke()
        {
            InitializeComponent();
        }
        public void soluongnhanvien()
        {
            int dilam = 0;
            int nghilam = 0;
            DataTable DSNV = NV.select_NhanVien();
            labelControl1.Text = DSNV.Rows.Count.ToString() + " Nhân viên";
            foreach (DataRow row in DSNV.Rows)
            {
                if (row["TrangThai"].ToString() == "True")
                {
                    dilam++;
                }
                else nghilam++;
            }
            labelControl5.Text = dilam.ToString() + " Nhân viên";
            labelControl6.Text = nghilam.ToString() + " Nhân viên";
            //Hủy đối tượng
            DSNV.Dispose();

        }
        //Đếm số lượng dskhang
        public void dskhachhang()
        {
            int KHcon = 0;
            int KHhet = 0;
            DataTable DSKH = KH.select_KhachHang();
            labelControl2.Text = DSKH.Rows.Count.ToString() + " Khách";
            foreach (DataRow row in DSKH.Rows)
            {
                DataTable DT = Th.select_TheMa(row["MaKH"].ToString());
                if (DT.Rows.Count > 0)
                    KHcon++;
                else
                    KHhet++;
            }
            labelControl7.Text = KHcon.ToString() + " Khách";
            labelControl8.Text = KHhet.ToString() + " Khách";
            //Hủy đối tượng
            DSKH.Dispose();
        }
        //đếm số lượng dssp
        public void dssanpham()
        {
            int saphet = 0;
            int hethang = 0;
            DataTable DSSP = HH.select_HangHoa();
            labelControl3.Text = DSSP.Rows.Count.ToString() + " Sản phẩm";
            foreach (DataRow row in DSSP.Rows)
            {
                int slcon = Convert.ToInt32(row["SLCon"].ToString());
                if (slcon > 10)
                {
                    saphet++;
                }
                else
                    hethang++;
            }
            labelControl9.Text = saphet.ToString() + " Sản phẩm";
            labelControl10.Text = hethang.ToString() + " Sản phẩm";
            //Hủy đối tượng
            DSSP.Dispose();
        }
        public void dshoadon()
        {
            int tonghoadon = 0;
            int tongthe = 0;
            DataTable DSHD = HD.select_HoaDon();
            labelControl4.Text = DSHD.Rows.Count.ToString() + " Hóa đơn";
            foreach (DataRow row in DSHD.Rows)
            {
                tonghoadon += Convert.ToInt32(row["TongHoaDon"].ToString());

            }
            //Hủy đối tượng 
            DSHD.Dispose();
            labelControl11.Text = String.Format("{0:0,0}", tonghoadon) + "VND";

            
            //Thẻ
            DataTable DSThe = Th.select_The();
            foreach (DataRow row in DSThe.Rows)
            {

                DataTable DSDV = DV.select_DichVu_TheByMa(row["Mathe"].ToString());
                int gia = 0;
                foreach (DataRow ro in DSDV.Rows)
                {
                    gia = Convert.ToInt32(ro["Gia"].ToString());
                    tongthe += gia;
                }
                //Hủy đối tượng
                DSDV.Dispose();
            }
            labelControl12.Text = String.Format("{0:0,0}", tongthe) + "VND";
            //Thêm dữ liệu vào chart
            chartControl1.Series["Chi Phí Hóa Đơn"].Points.AddPoint("Hóa Đơn", tonghoadon);
            chartControl1.Series["Chi Phí Hóa Đơn"].Points.AddPoint("Thẻ", tongthe);
            chartControl1.Series["Chi Phí Hóa Đơn"].Points.AddPoint("Tổng doanh thu", tonghoadon+tongthe);
            //Hủy đối tượng
            DSThe.Dispose();
        }
        private void thongke_Load(object sender, EventArgs e)
        {
            soluongnhanvien();
            dskhachhang();
            dssanpham();
            dshoadon();

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int tong = 0;
            DateTime now = DateTime.Now;
            int thang = Convert.ToInt32(dateTimePicker1.Value.Month.ToString());
            int nam = Convert.ToInt32(dateTimePicker1.Value.Year.ToString());
            DataTable DT = HD.select_HoaDonbyMonth(thang, nam);
            foreach (DataRow row in DT.Rows)
            {
                //Thêm dl vào chart
                chartControl2.Series["Sản Phẩm"].Points.AddPoint(row["NgayHD"].ToString(), Convert.ToInt32(row["TongHoaDon"].ToString()));
                tong += Convert.ToInt32(row["TongHoaDon"].ToString());
            }
            //Hủy đối tượng
            DT.Clone();
            DataTable DT1 = Th.select_TheDichVubyMonth(thang, nam);
            foreach (DataRow row in DT1.Rows)
            {
                //Thêm dl vào chart
                chartControl2.Series["Thẻ hội viên"].Points.AddPoint(row["NgayDK"].ToString(), Convert.ToInt32(row["Gia"].ToString()));
                tong += Convert.ToInt32(row["Gia"].ToString());
            }
            //Hủy đối tượng
            DT1.Clone();
            //Thêm dl vào chart
            chartControl2.Series["Tổng Thu nhập"].Points.AddPoint(now.ToString(), tong);
        }
    }
}
