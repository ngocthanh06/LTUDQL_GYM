﻿using System;
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
    //Khởi tạo delegate
    
    public partial class GiaHanThe : Form
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
        string MaNV1;
        public GiaHanThe()
        {
            InitializeComponent();
        }

        //Properties để nhận thông tin của form 1
        public string Message
        {
            get { return txtMaKh.Text; }
            set { txtMaKh.Text = value; }
        }
        //Mã nhân viên
        public string MaNV
        {
            get { return MaNV1 ; }
            set {MaNV1 = value ;}
        }
        //private void SetValue(String value)
        //{
        //    this.txtMaKh.Text = value;
        //}
        void loadngay()
        {
            //Tính số ngày còn lại
            //Ngày hiện tại
            DateTime now = DateTime.Now;
            //Ngày trong cbbdichvu
            int ngay = Convert.ToInt32(txtthoihan.Text);
            //Ngày đăng ký
            DateTime songaydk = dateTimePicker1.Value;
            //Ngày dự đoán hết hạn
            DateTime songaytt = songaydk.AddDays(ngay);

            if (DateTime.Compare(songaytt, now) < 0)
                txtSongaycon.Text = "Hết hạn";

            else
            {
                TimeSpan Time = songaytt - now;
                int songay = Time.Days;
                txtSongaycon.Text = "Còn lại: " + songay + " ngày";

            }
        }
        void load()
        {
            txtthoihan.Clear();
            txtGia.Clear();
            cbbDichVu.DataSource = DV.select_DichVu();
            dateTimePicker1.ResetText();
            txtSongaycon.Clear();
        }
        void loaddtgdanhsachthe()
        {
            foreach (DataGridViewRow row in dtgdanhsachthe.Rows)
            {
                DateTime now = DateTime.Now;
               // int ngay = Convert.ToInt32(row.Cells[1]);
                DataTable DTB = DV.select_DichVuMa(row.Cells[4].Value.ToString());

                int ngay = Convert.ToInt32(DTB.Rows[0]["ThoiHan"]);
                //Ngày đăng ký
                DateTime songaydky = Convert.ToDateTime(row.Cells[5].Value.ToString());
                //Ngày dự đoán hết hạn
                DateTime songayttp = songaydky.AddDays(ngay);
                //hiệu 2 ngày
                TimeSpan time = now - songaydky ;
                int hieu = time.Days;
                if (DateTime.Compare(songayttp, now) < 0)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else if (hieu - ngay>=-3 && hieu <ngay)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
        private void GiaHanThe_Load(object sender, EventArgs e)
        {
            //Tính số ngày còn lại
            //    //Ngày hiện tại
            
            dtgdanhsachthe.DataSource = Th.select_TheMa(txtMaKh.Text);
            loaddtgdanhsachthe();

            txtMaThe.Enabled = false;
            cbbDichVu.DataSource = DV.select_DichVu();
            cbbDichVu.DisplayMember = "TenDV";
            cbbDichVu.ValueMember = "MaDV";

            DataTable DT = KH.select_KhachHangMa(txtMaKh.Text);
            
            //Load thông tin khách hàng
            foreach(DataRow row in DT.Rows)
            {
                label10.Text = row["TenKH"].ToString();
                //Hiển thị hình ảnh
                if (!Convert.IsDBNull(row["Avatar"]))
                {
                    var data = (Byte[])(row["Avatar"]);
                    var stream = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                else
                    pictureBox1.Image = null;
            }    
        }

        private void cbbDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable Dichvu = DV.select_DichVuMa(cbbDichVu.SelectedValue.ToString());
            if (Dichvu.Rows.Count > 0)
            {
                txtthoihan.Text = Dichvu.Rows[0]["Thoihan"].ToString();
                txtGia.Text = Dichvu.Rows[0]["Gia"].ToString();
                loadngay();
            }

        }

        private void cbbdanhsachthe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgdanhsachthe.Rows[e.RowIndex];
                //chọn dòng dtgrid
                dtgdanhsachthe.CurrentRow.Selected = true;

                DataTable DT = Th.select_MaThe(row.Cells[0].Value.ToString());
                txtMaThe.Text = row.Cells[0].Value.ToString();
                if (DT.Rows.Count > 0)
                {
                    dateTimePicker1.Text = DT.Rows[0]["NgayDK"].ToString();

                }
                cbbDichVu.DataSource = DV.select_DichVu();
                cbbDichVu.DisplayMember = "TenDV";
                cbbDichVu.ValueMember = "MaDV";

                DataTable Dichvu = DV.select_DichVuMa(DT.Rows[0]["MaDV"].ToString());
                cbbDichVu.Text = Dichvu.Rows[0]["TenDV"].ToString();
                txtthoihan.Text = Dichvu.Rows[0]["Thoihan"].ToString();
                txtGia.Text = Dichvu.Rows[0]["Gia"].ToString();

                loadngay();
                    
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            load();
            loaddtgdanhsachthe();
        }
        bool check ()
        {
            return true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int checka = 0;
            int checkb = 0;
            DateTime songayttp= new DateTime();
            foreach (DataGridViewRow row in dtgdanhsachthe.Rows)
            {
                DateTime now = DateTime.Now;
                // int ngay = Convert.ToInt32(row.Cells[1]);
                DataTable DTB = DV.select_DichVuMa(row.Cells[4].Value.ToString());

                int ngay = Convert.ToInt32(DTB.Rows[0]["ThoiHan"]);
                //Ngày đăng ký
                DateTime songaydky = Convert.ToDateTime(row.Cells[5].Value.ToString());
                //Ngày dự đoán hết hạn
                songayttp = songaydky.AddDays(ngay);
                //thẻ hết hạn
                if (DateTime.Compare(songayttp, now) < 0)
                {
                    checka++;
                    checkb = 0;
                    songayttp = DateTime.Now;
                }
                else
                {
                    //còn hạn
                    DialogResult ThongBao = MessageBox.Show("Thẻ còn trong thời gian sử dụng, bạn có muốn thêm thẻ không?", "Yêu cầu thêm thẻ mới", MessageBoxButtons.YesNo);
                    if (ThongBao == DialogResult.Yes)
                    {
                        checka++;
                        checkb = 0;
                    }
                    else if (ThongBao == DialogResult.No)
                    {
                        checkb++;
                    }
                    break;
                }
            }

            if (checka > 0 && checkb == 0)
            {
                DataTable DT = Th.select_The();

                int a = 1;
                foreach (DataRow ro in DT.Rows)
                {
                    string b = ro["Mathe"].ToString();
                    string c = b.Substring(2);
                    int Ma = Convert.ToInt32(c);
                    if (Ma > a)
                        a = Ma;
                }
                a++;

                if (Th.insert_The("MT" + a, songayttp.ToString(), cbbDichVu.SelectedValue.ToString(), txtMaKh.Text, MaNV1) > 0)
                {
                    MessageBox.Show("Thành công");
                    load();
                    dtgdanhsachthe.DataSource = Th.select_TheMa(txtMaKh.Text);
                    loaddtgdanhsachthe();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            if (Th.update_The(txtMaThe.Text, dateTimePicker1.Value.ToString(), cbbDichVu.SelectedValue.ToString()) > 0)
            {
                MessageBox.Show("Thành công");
                load();
                dtgdanhsachthe.DataSource = Th.select_TheMa(txtMaKh.Text);
                loaddtgdanhsachthe();
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Th.delete_The(txtMaThe.Text) > 0)
            {
                MessageBox.Show("Thành Công");
                load();
                dtgdanhsachthe.DataSource = Th.select_TheMa(txtMaKh.Text);
                loaddtgdanhsachthe();
            }
            else
                MessageBox.Show("Thất bại");
        }

        
        
    }
}
