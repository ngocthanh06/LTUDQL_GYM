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
    public partial class Form1 : Form
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

        string strfilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        void clearbutton()
        {
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            ricktbGhiChu.Clear();
            txtSoNgay.Clear();
            txtGia.Clear();
            dateNgayBD.ResetText();
            dateNgaySinh.ResetText();
        }

        //tạo mã hóa đơn tự tăng
        string createMaKH()
        {
            int MaKH = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow)
                {
                    string b = row.Cells[0].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaKH < c)
                        MaKH = c;
                }
            }
            MaKH++;

            return "KH" + MaKH;
        }
        //Tạo mã thẻ tự tăng
        string createMaThe()
        {
            int Mathe = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if(!row.IsNewRow)
                {
                    string b = row.Cells[8].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (Mathe < c)
                        Mathe = c;
                }
            }
            Mathe++;
            return "MT" + Mathe;
        }
        //Giới tính
        bool RadioBT()
        {
            if (nam.Checked == true)
                return true;
            else
                return false;
        }
        //loadcombobox Dịch vụ
        void LoadDichVu()
        {
            cbbDichvu.DataSource = DV.select_DichVu();
            cbbDichvu.DisplayMember = "TenDV";
            cbbDichvu.ValueMember = "MaDV";
        }
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = KH.select_KhachHang();
            MaKH.Visible = false;
            MaThe.Visible = false;
        }


        

        private void cbbDichvu_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dtSongay = DV.select_DichVuMa(cbbDichvu.SelectedValue.ToString());
            
            if(dtSongay.Rows.Count>0)
            {
                txtSoNgay.Text = dtSongay.Rows[0]["ThoiHan"].ToString();
                txtGia.Text = dtSongay.Rows[0]["Gia"].ToString();
            }
        }

        //load dịch vụ theo hướng xổ xuống
        private void cbbDichvu_DropDown(object sender, EventArgs e)
        {
            LoadDichVu();
        }

        //Thêm dữ liệu vào dataGr tạm thời
        private void button5_Click(object sender, EventArgs e)
        {

            //Add dl vào bảng
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRow drAdd = dataTable.NewRow();
            //Lưu hình ảnh vào dataGridview
            MemoryStream mmst = new MemoryStream();
            pictureBox1.Image.Save(mmst, pictureBox1.Image.RawFormat);
            byte[] img = mmst.ToArray();

            drAdd["MaKH"] = createMaKH();
            drAdd["TenKH"] = txtTenKH.Text;
            drAdd["DiaChi"] = txtDiaChi.Text;
            drAdd["SDT"] = txtSDT.Text;
            drAdd["NgaySinh"] = dateNgaySinh.Text;
            drAdd["GioiTinh"] = RadioBT(); 
            drAdd["GhiChu"] = ricktbGhiChu.Text;
            drAdd["Avatar"] = img;
            drAdd["MaThe"] = createMaThe();
            //Add dữ liệu vào bảng
            dataTable.Rows.Add(drAdd);
            //Chấp nhận thay đổi
            dataTable.AcceptChanges();
            clearbutton();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearbutton();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int MaKHCu = 1;
            //int MaKHMoi = 0;
            DataTable dtAdd = KH.select_KhachHang();
            //Xử lý lấy mã KH
            foreach (DataRow row in dtAdd.Rows)
            {
                MaKHCu++;
            }

            if (pictureBox1.Image != null && txtTenKH.Text != null && cbbDichvu.SelectedValue != null)
            {
                //Xử lý ảnh
                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                if (Th.insert_The("MT" + MaKHCu.ToString(), dateNgayBD.Value.ToString(), cbbDichvu.SelectedValue.ToString()) > 0)
                {
                    if (KH.insert_KhachHang("KH" + MaKHCu.ToString(), txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, dateNgaySinh.Value.ToString(), RadioBT(), ricktbGhiChu.Text, arr, "MT" + MaKHCu.ToString()) > 0)
                    {
                        MessageBox.Show("Thành công ");
                        clearbutton();
                        pictureBox1.Image = null;
                        dataGridView1.DataSource = KH.select_KhachHang();

                    }
                    else
                        MessageBox.Show("Thất bại");
                }
            }
            else if (txtTenKH.Text == "")
                MessageBox.Show("Chưa có tên khách hàng");
            else if (cbbDichvu.SelectedValue == null)
                MessageBox.Show("Chưa chọn dịch vụ");
            else
                MessageBox.Show("Chưa có ảnh");
        }

        //Đổ dữ liệu trong lưới của danh sách thành viên
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //Hiển thị ảnh
                //Kiểm tra tồn tại của ảnh
                if (!Convert.IsDBNull(row.Cells[7].Value))
                {
                    var data = (Byte[])(row.Cells[7].Value);
                    var stream = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                else
                    pictureBox1.Image = null;

                dataGridView1.CurrentRow.Selected = true;
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtDiaChi.Text = row.Cells[2].Value.ToString();
                txtSDT.Text = row.Cells[3].Value.ToString();
                MaKH.Text = row.Cells[0].Value.ToString();
                dateNgaySinh.Text = row.Cells[4].Value.ToString();
                //MaKH.Visible = true;
                MaThe.Text = row.Cells[8].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True")
                    nam.Checked = true;
                else
                    nu.Checked = true;

                ricktbGhiChu.Text = row.Cells[6].Value.ToString();

                //combb dịch vụ
                cbbDichvu.DataSource = DV.select_DichVu_TheByMa(row.Cells[8].Value.ToString());
                cbbDichvu.DisplayMember = "TenDV";
                cbbDichvu.ValueMember = "MaDV";
                
                //Dịch vụ thẻ
                DataTable dvthe = DV.select_DichVu_TheByMa(row.Cells[8].Value.ToString());
                if (dvthe.Rows.Count > 0)
                {
                    txtSoNgay.Text = dvthe.Rows[0]["ThoiHan"].ToString();
                    txtGia.Text = dvthe.Rows[0]["Gia"].ToString();
                    dateNgayBD.Text = dvthe.Rows[0]["NgayDK"].ToString();
                }
             }
        }

        //Thêm ảnh
        private void button6_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"﻿;
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Xử lý ảnh
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            if (KH.update_KhachHang(MaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, dateNgaySinh.Value.ToString(), RadioBT(), ricktbGhiChu.Text, arr) > 0)
            {
                MessageBox.Show("Thành công");
                clearbutton();
                dataGridView1.DataSource = KH.select_KhachHang();
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(KH.delete_KhachHang(MaKH.Text)>0)
            {
                if(Th.delete_The(MaThe.Text)>0)
                {
                    MessageBox.Show("Thành công");
                    clearbutton();
                    pictureBox1.Image = null;
                    dataGridView1.DataSource = KH.select_KhachHang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Thất bại");
        }

        

        

       
    }
}
