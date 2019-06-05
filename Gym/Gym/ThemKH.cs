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

namespace Gym
{
    public partial class ThemKH : Form
    {
        KhachHang_BLL KH = new KhachHang_BLL();
        The_BLL Th = new The_BLL();
        DichVu_BLL DV = new DichVu_BLL();
        public ThemKH()
        {
            InitializeComponent();
        }
        public string MaNVKH
        {
            get { return MaNV.Text; }
            set { MaNV.Text = value; }
        }

        //Thêm mã khách hàng
        string ThemMaKH()
        {
            int MaKHCu = 0;
            DataTable dtAdd = KH.select_KhachHang();
            //Xử lý lấy mã KH
            foreach (DataRow row in dtAdd.Rows)
            {
                string b = row["MaKH"].ToString();
                string c = b.Substring(2);
                int Ma = Convert.ToInt32(c);
                if (Ma > MaKHCu)
                    MaKHCu = Ma;
            }
            MaKHCu++;
            if (MaKHCu > 10)
                return "KH" + MaKHCu;
            else
                return "KH0" + MaKHCu;
        }
        //Thêm mã thẻ
        string Themmathe()
        {
            int MaThecu = 0;
            DataTable dtMathe = Th.select_The();
            foreach (DataRow row in dtMathe.Rows)
            {
                string b = row["MaThe"].ToString();
                string c = b.Substring(2);
                int Mathe = Convert.ToInt32(c);
                if (Mathe > MaThecu)
                    MaThecu = Mathe;
            }
            MaThecu++;
            if (MaThecu > 10)
                return "MT" + MaThecu;
            else
                return "MT0" + MaThecu;
        }
        
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
            pictureBox1.Image = null;
        }
        bool RadioBT()
        {
            if (nam.Checked == true)
                return true;
            else
                return false;
        }
        private void ThemKH_Load(object sender, EventArgs e)
        {
            LoadDichVu();
            MaKH.Visible = false;
            MaThe.Visible = false;
            MaNV.Visible = false;
        }
        
        void LoadDichVu()
        {
            cbbDichvu.DataSource = DV.select_DichVu();
            cbbDichvu.DisplayMember = "TenDV";
            cbbDichvu.ValueMember = "MaDV";
        }
        // click Load Cbb dịch vụ
        private void cbbDichvu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dtSongay = DV.select_DichVuMa(cbbDichvu.SelectedValue.ToString());

            if (dtSongay.Rows.Count > 0)
            {
                txtSoNgay.Text = dtSongay.Rows[0]["ThoiHan"].ToString();
                txtGia.Text = dtSongay.Rows[0]["Gia"].ToString();
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"﻿;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
        //Thêm
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Mã thẻ
            string a = ThemMaKH();

            if (pictureBox1.Image != null && txtTenKH.Text != null && cbbDichvu.SelectedValue != null)
            {
                //Xử lý ảnh
                Image img = pictureBox1.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                if (KH.insert_KhachHang(a, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, dateNgaySinh.Value.ToString(), RadioBT(), ricktbGhiChu.Text, arr) > 0)
                {
                    if (Th.insert_The(Themmathe(), dateNgayBD.Value.ToString(), cbbDichvu.SelectedValue.ToString(), a, MaNV.Text) > 0)
                    {
                        MessageBox.Show("Thành công ");
                        clearbutton();
                        pictureBox1.Image = null;
                      //  dataGridView1.DataSource = KH.select_KhachHang();

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
        //Làm Mới
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            clearbutton();
            
        }
    }
}
