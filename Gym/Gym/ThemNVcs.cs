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
    public partial class ThemNVcs : Form
    {
        NhanVien_BLL NV = new NhanVien_BLL();
        TaiKhoan_BLL TK = new TaiKhoan_BLL();
        The_BLL Th = new The_BLL();
        //Load form dtg từ form 1
        DataGridView data;
        public ThemNVcs(DataGridView dt)
        {
            InitializeComponent();
            data = dt;
        }
        public ThemNVcs()
        {
            InitializeComponent();
        }
        //Check radiobutton
        bool RadioBTNV()
        {
            if (nvnam.Checked == true)
                return true;
            else
                return false;
        }
        //Check radiobutton
        bool RadioBTTrangThai()
        {
            if (lamviec.Checked == true)
                return true;
            else
                return false;
        }
        //Tạo Mã TK
        string createMaTKNV()
        {
            int MaTK = 0;
            DataTable dstaikhoan = TK.select_TaiKhoan();
            foreach (DataRow row in dstaikhoan.Rows)
            {
                    string b = row["MaTK"].ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaTK < c)
                        MaTK = c;    
            }
            MaTK++;
            if (MaTK < 10)
                return "TK0" + MaTK;
            else
                return "TK" + MaTK;
        }
        //Tạo mã NV
        string createMaNV()
        {
            DataTable dsnhanvien = NV.select_NhanVien();
            int MaNV = 0;
            foreach (DataRow row in dsnhanvien.Rows)
            {        
                    string b = row["MaNV"].ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaNV < c)
                        MaNV = c;
            }
            MaNV++;
            if (MaNV < 10)
                return "NV0" + MaNV;
            else
                return "NV" + MaNV;
        }
        //Làm mới
        void clearbuttonNV()
        {
            txtTenNV.Clear();
            txtSDTNV.Clear();
            txtDiachiNV.Clear();
            dtpickngaysinhNV.ResetText();
            richghichuNV.Clear();
            pictureNV.Image = null;
        }
        //Thêm NV
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            string MaNV = createMaNV();
            string MaTKNV = createMaTKNV();
            if (txtTenNV.Text != "" && pictureNV.Image != null)
            {
                //Xử lý ảnh
                Image imgNV = pictureNV.Image;
                byte[] arrNV;
                ImageConverter converter = new ImageConverter();
                arrNV = (byte[])converter.ConvertTo(imgNV, typeof(byte[]));
                //Thêm nhân viên không cần user, pass
                if (TK.insert_TaiKhoan(MaTKNV, "", "", 0) > 0)
                {
                    if (NV.insert_NhanVien(MaNV, txtTenNV.Text, dtpickngaysinhNV.Value.ToString(), RadioBTNV(), txtDiachiNV.Text, txtSDTNV.Text, MaTKNV, arrNV, richghichuNV.Text, RadioBTTrangThai()) > 0)
                    {
                        MessageBox.Show("Thành công");
                        clearbuttonNV();
                        data.DataSource = NV.select_NhanVien();
                    }
                    else
                        MessageBox.Show("Thất bại");
                }
            }
            //Bắt lỗi thêm số ký tự
            else if (txtTenNV.Text == "")
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
            else
                MessageBox.Show("Bạn chưa có ảnh");
        }
        //làm mới
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            clearbuttonNV();
        }
        //Load Ảnh
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            String imageLocationNV = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"﻿;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocationNV = dialog.FileName;
                    pictureNV.ImageLocation = imageLocationNV;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Load form
        private void ThemNVcs_Load(object sender, EventArgs e)
        {
            MaNV.Visible = false;
            nghilam.Visible = false;
            matk.Visible = false;
        }

       
    }
}
