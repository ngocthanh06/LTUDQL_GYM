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
    public partial class Login : Form
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
        int error = 0;
        public Login()
        {
            InitializeComponent();
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        
     

        //xử lý nút đăng nhập
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //Xét điều kiện
            if (txtusername.Text != "" && txtpass.Text != "")
            {
                DataTable DT = TK.select_loginTK(txtusername.Text,txtpass.Text);
                if (DT.Rows.Count > 0 && error <= 5)
                {
                    if (DT.Rows[0]["Quyen"].ToString() == "1")
                    {
                        string a = "Admin";

                        Form1 Form = new Form1();
                        Form.Message = DT.Rows[0]["MaTK"].ToString();

                        Form.Quyen = a;
                        this.Hide();
                        Form.Show(); 
                    }
                    else
                    {
                        string a = "Nhân viên";

                        Form1 Form = new Form1();
                        Form.Message = DT.Rows[0]["MaTK"].ToString();
                        Form.Quyen = a;
                        this.Hide();
                        Form.Show();
                    }
                }
                else if (DT.Rows.Count == 0 && error <= 5)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    error++;
                }
                else
                {
                    MessageBox.Show("Phiên làm việc đã hết");
                    this.Close();
                }
            }
            else if (txtusername.Text == "")
                MessageBox.Show("Tên đăng nhập không được để trống");
            else
                MessageBox.Show("Mật khẩu không được để trống");
        }

        private void btnres_Click(object sender, EventArgs e)
        {


        }
        //Sự kiện Enter ở textbox
        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                 {
                     btnlogin.PerformClick();
                 }
        }
        
    }
}
