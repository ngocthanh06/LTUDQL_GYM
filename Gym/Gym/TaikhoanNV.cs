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
using System.Drawing.Imaging;
using System.IO;
using Microsoft.VisualBasic;

namespace Gym
{
    public partial class TaikhoanNV : Form
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
        public TaikhoanNV()
        {
            InitializeComponent();
        }
        //quyền
        bool RadioBT()
        {
            if (admin.Checked == true)
                return true;
            else
                return false;
        }
        //Chuyển dữ liệu từ form 1 sang
        public string Message
        {
            get { return txtmatk.Text; }
            set { txtmatk.Text = value; }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void TaikhoanNV_Load(object sender, EventArgs e)
        {
            txtmatk.Enabled = false;
            DataTable DT = TK.select_TaiKhoanMa(txtmatk.Text);
            if (DT.Rows.Count > 0)
            {
                string a = DT.Rows[0]["TenDN"].ToString();
                //xóa khoảng trắng trim
                txtusername.Text =a.Trim();

                txtpassword.Text = DT.Rows[0]["MatKhau"].ToString();
                if (DT.Rows[0]["Quyen"].ToString() == "1")
                    admin.Checked = true;
                else
                    nhanvien.Checked = true;
            }
        }

        

        
    }
}
