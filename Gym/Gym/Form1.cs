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

        
        //contructor

        public string Message
        {
            get { return tennguoidung.Text; }
            set { tennguoidung.Text = value; }
        }

        public string Quyen
        {
            get { return quyen.Text; }
            set { quyen.Text = value; }
        }

        

        //string strfilePath = "";
        //Image DefaultImage;
        //Byte[] ImageByteArray;
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
            if (MaKH < 10)
                return "KH0" + MaKH;
            else
            return "KH" + MaKH;
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
        void loadcbbLoaihang()
        {
            cbbloaihang.DataSource = LH.select_LoaiHang();
            cbbloaihang.DisplayMember = "TenLH";
            cbbloaihang.ValueMember = "MaLH";
        }
        public Form1()
        {
            InitializeComponent();

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //Khách hàng
            dataGridView1.DataSource = KH.select_KhachHang();
            MaKH.Visible = false;
            MaThe.Visible = false;
            MaNV.Visible = false;
            matk.Visible = false;
            labelMaNV.Visible = false;
            //mahh.Visible = false;
            DataTable DT = NV.select_NhanVienMaTK(tennguoidung.Text);
            tennguoidung.Text = "Xin chào, "+DT.Rows[0]["TenNV"].ToString();
            labelMaNV.Text = DT.Rows[0]["MaNV"].ToString();
            if (!Convert.IsDBNull(DT.Rows[0]["hinhanh"]))
            {
                var data = (Byte[])(DT.Rows[0]["hinhanh"]);
                var stream = new MemoryStream(data);
                pictureuser.Image = Image.FromStream(stream);
            }
            else
                pictureuser.Image = null;
            closeTabcontrol();

            textMaNV.Text = DT.Rows[0]["MaNV"].ToString();
            //nhân viên
            dtgnhanvien.DataSource = NV.select_NhanVien();
            //hanghoa
            dtgLoaiHang.DataSource = HH.select_HangHoa();
            //loaihang
            dtgdsloaihang.DataSource = LH.select_LoaiHang(); 
            //Dịch vụ
            dtgkhachhang.DataSource = KH.select_KhachHang();
            dtgsanpham.DataSource = HH.select_HangHoa();

            texttongtien.Enabled = false;
            textMaKH.Enabled = false;
            textMaLH.Enabled = false;
            textMaNV.Enabled = false;
            textSlcon.Enabled = false;
            numericUpDown2.Increment = 1;
            numericUpDown2.DecimalPlaces = 0;
            numericUpDown2.Minimum = -9999;
            numericUpDown2.Maximum = 9999;
            //Danh sách hóa đơn
            if (radioNV.Checked == true)
                textmahd.Enabled = false;
            ngaybatdau.Enabled = false;
            ngayketthuc.Enabled = false;
            datengayhd.Enabled = false;
            tongtienhd.Enabled = false;
            //Danh sách thẻ
            cbbNvthe.Enabled = false;
            datenvthe.Enabled = false;
            checkBox1.Enabled = false;
           
        }
        
        void closeTabcontrol()
        {
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
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
                return "KH0"+MaKHCu;
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
                return "MT0"+MaThecu;
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

        //Làm mới 
        private void button1_Click(object sender, EventArgs e)
        {
            clearbutton();
        }
        //Thêm KH
        private void button2_Click(object sender, EventArgs e)
        {
            //int MaKHMoi = 0;
            
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
                    if (Th.insert_The(Themmathe(), dateNgayBD.Value.ToString(), cbbDichvu.SelectedValue.ToString(),a,labelMaNV.Text) > 0)
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
                //chọn dòng dtgrid
                dataGridView1.CurrentRow.Selected = true;
                txtTenKH.Text = row.Cells[1].Value.ToString().Trim();
                txtDiaChi.Text = row.Cells[2].Value.ToString().Trim();
                txtSDT.Text = row.Cells[3].Value.ToString().Trim();
                MaKH.Text = row.Cells[0].Value.ToString().Trim();
                dateNgaySinh.Text = row.Cells[4].Value.ToString().Trim();
                //MaKH.Visible = true;
                //MaThe.Text = row.Cells[8].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True")
                    nam.Checked = true;
                else
                    nu.Checked = true;

                ricktbGhiChu.Text = row.Cells[6].Value.ToString();

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

       //Sửa KH

        private void button3_Click(object sender, EventArgs e)
        {
            //Xử lý ảnh
            Image img = pictureBox1.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (pictureBox1.Image != null && txtTenKH.Text != null)
            {
                if (KH.update_KhachHang(MaKH.Text, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text, dateNgaySinh.Value.ToString(), RadioBT(), ricktbGhiChu.Text, arr) > 0)
                {
                    MessageBox.Show("Thành công");
                    clearbutton();
                    dataGridView1.DataSource = KH.select_KhachHang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else if (txtTenKH.Text == "")
                MessageBox.Show("Chưa có tên khách hàng");
            else
                MessageBox.Show("Chưa có ảnh");
        }

        
        //Xóa KH
        private void button4_Click(object sender, EventArgs e)
        {
            
            DataTable DT = Th.select_TheMa(MaKH.Text);
            //Xóa thẻ trong csdl
            foreach (DataRow row in DT.Rows)
            {
                Th.delete_The(row["Mathe"].ToString());
            }
            //Xóa khách hàng
            if (KH.delete_KhachHang(MaKH.Text) > 0)
            {
                MessageBox.Show("Thành công");
                clearbutton();
                pictureBox1.Image = null;
                dataGridView1.DataSource = KH.select_KhachHang();
            }
            else
                MessageBox.Show("Thất bại");
        }

        

        private void txtgiahan_Click(object sender, EventArgs e)
        {
            GiaHanThe GHThe = new GiaHanThe();
            DataTable DT = Th.select_TheMa(MaKH.Text);
            if(DT.Rows.Count>0)
            {
                //Gọi properties để gọi chuyển dữ liệu sang fomr 2 
                GHThe.Message = MaKH.Text;
                GHThe.MaNV = labelMaNV.Text;
                GHThe.ShowDialog();
                
            }
            else
                MessageBox.Show("Khách hàng chưa có thẻ");               
           
        }

        /* NHÂN VIÊN
         * Nhân viên 
         * Nhân viên
         */
        //clear button nhân viên
        //Nhân viên
        //Xử lý lỗi của dtgnhanvien load ảnh
        private void dtgnhanvien_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
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
        bool RadioBTNV()
        {
            if (nvnam.Checked == true)
                return true;
            else
                return false;
        }
        bool RadioBTTrangThai()
        {
            if (lamviec.Checked == true)
                return true;
            else
                return false;
        }
        private void btlammoiNV_Click(object sender, EventArgs e)
        {
            clearbuttonNV();
        }

        string createMaNV()
        {
            int MaNV = 0;
            foreach (DataGridViewRow row in dtgnhanvien.Rows)
            {
                if (!row.IsNewRow)
                {
                    string b = row.Cells[0].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaNV < c)
                        MaNV = c;
                }
            }
            MaNV++;
            if (MaNV < 10)
                return "NV0" + MaNV;
            else
                return "NV" + MaNV;
        }

        string createMaTKNV()
        {
            int MaTK = 0;
            foreach (DataGridViewRow row in dtgnhanvien.Rows)
            {
                if (!row.IsNewRow)
                {
                    string b = row.Cells[6].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaTK < c)
                        MaTK = c;
                }
            }
            MaTK++;
            if (MaTK < 10)
                return "TK0" + MaTK;
            else
                return "TK" + MaTK;
        }

        private void dtgnhanvien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //chọn dòng dtgrid
                dtgnhanvien.CurrentRow.Selected = true;
                DataGridViewRow row = this.dtgnhanvien.Rows[e.RowIndex];

                //Hiển thị ảnh
                //Kiểm tra tồn tại của ảnh
                if (!Convert.IsDBNull(row.Cells[7].Value))
                {
                    var data = (Byte[])(row.Cells[7].Value);
                    var stream = new MemoryStream(data);
                    pictureNV.Image = Image.FromStream(stream);
                }
                else
                    pictureNV.Image = null;
                txtTenNV.Text = row.Cells[1].Value.ToString().Trim();
                dtpickngaysinhNV.Text = row.Cells[2].Value.ToString().Trim();
                txtDiachiNV.Text = row.Cells[4].Value.ToString().Trim();
                txtSDTNV.Text = row.Cells[5].Value.ToString().Trim();
                matk.Text = row.Cells[6].Value.ToString().Trim();
                MaNV.Text = row.Cells[0].Value.ToString().Trim();
                if (dtgnhanvien.CurrentRow.Cells[9].Value.ToString() == "True")
                    lamviec.Checked = true;
                else
                    nghilam.Checked = true;
                if (dtgnhanvien.CurrentRow.Cells[3].Value.ToString() == "True")
                    nvnam.Checked = true;
                else
                    nvnu.Checked = true;

                richghichuNV.Text = row.Cells[8].Value.ToString().Trim();

            }
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text != "" && pictureNV.Image != null)
            {
                //Xử lý ảnh
                Image imgNV = pictureNV.Image;
                byte[] arrNV;
                ImageConverter converter = new ImageConverter();
                arrNV = (byte[])converter.ConvertTo(imgNV, typeof(byte[]));
                //Thêm nhân viên không cần user, pass
                if (TK.insert_TaiKhoan(createMaTKNV(), "", "", 0) > 0)
                {
                    if (NV.insert_NhanVien(createMaNV(), txtTenNV.Text, dtpickngaysinhNV.Value.ToString(), RadioBTNV(), txtDiachiNV.Text, txtSDTNV.Text, createMaTKNV(), arrNV, richghichuNV.Text, RadioBTTrangThai()) > 0)
                    {
                        MessageBox.Show("Thành công");
                        clearbuttonNV();
                        dtgnhanvien.DataSource = NV.select_NhanVien();
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
        private void button5_Click_1(object sender, EventArgs e)
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

        private void btsuaNV_Click(object sender, EventArgs e)
        {
            //Xử lý ảnh
            Image imgNV = pictureNV.Image;
            byte[] arrNV;
            ImageConverter converter = new ImageConverter();
            arrNV = (byte[])converter.ConvertTo(imgNV, typeof(byte[]));
            if (txtTenNV.Text != "" && pictureNV.Image != null)
            {
                if (NV.update_NhanVien(MaNV.Text, txtTenNV.Text, dtpickngaysinhNV.Value.ToString(), RadioBTNV(), txtDiachiNV.Text, txtSDT.Text, arrNV, richghichuNV.Text, RadioBTTrangThai()) > 0)
                {
                    MessageBox.Show("Thành công");
                    clearbuttonNV();
                    dtgnhanvien.DataSource = NV.select_NhanVien();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            //Bắt lỗi thêm số ký tự
            else if (txtTenNV.Text == "")
                MessageBox.Show("Bạn chưa nhập tên nhân viên");
            else
                MessageBox.Show("Bạn chưa có ảnh");
        }

        private void btxoaNV_Click(object sender, EventArgs e)
        {
            if (NV.delete_NhanVien(MaNV.Text) > 0)
            {
                if (TK.delete_TaiKhoan(matk.Text) > 0)
                {
                    MessageBox.Show("Thành công");
                    clearbuttonNV();
                    dtgnhanvien.DataSource = NV.select_NhanVien();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Thất bại");
        }

        private void bthienthiNV_Click(object sender, EventArgs e)
        {
            TaikhoanNV TKNV = new TaikhoanNV();
            DataTable DT = NV.select_NhanVienMa(MaNV.Text);
            if (DT.Rows.Count > 0)
            {
                //Gọi properties để gọi chuyển dữ liệu sang fomr 2 
                TKNV.Message = matk.Text;
                TKNV.ShowDialog();

            }
            else
                MessageBox.Show("Chưa chọn nhân viên");  
        }

        /* Hàng Hóa
         * Hàng Hóa 
         * Hàng Hóa
         */
        //Loadcbb loại hàng
        //Kiểm tra sản phẩm còn hàng
        void checksplh()
        {

            foreach (DataGridViewRow row in dtgLoaiHang.Rows)
            {
                int so = Convert.ToInt32(row.Cells[3].Value.ToString());
                if (so <= 10)
                    row.DefaultCellStyle.BackColor = Color.Red;

            }
        }
        void loadloaihang()
        {
                txtTenLH.Clear();
                txtDongia.Clear();
                datehansudung.ResetText();
                richghichuLH.Clear();
                numericUpDown1.Value = 0;
                pictureLoaiHang.Image = null;
        }
        private void cbbloaihang_DropDown(object sender, EventArgs e)
        {
            loadcbbLoaihang();
        }
        //Tạo mã hàng hóa
        string createMahh()
        {
            int MaLH = 0;
            foreach (DataGridViewRow row in dtgLoaiHang.Rows)
            {
                if (!row.IsNewRow)
                {
                    string b = row.Cells[0].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaLH < c)
                        MaLH = c;
                }
            }
            MaLH++;
            if(MaLH<10)
                return "LH0" + MaLH;
            else
                 return "LH" + MaLH;
        }
        //load cbb
        private void dtgLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //chọn dòng dtgrid

                dtgLoaiHang.CurrentRow.Selected = true;
                DataGridViewRow row = this.dtgLoaiHang.Rows[e.RowIndex];
                //Hiển thị ảnh
                //Kiểm tra tồn tại của ảnh
                if (!Convert.IsDBNull(row.Cells[5].Value))
                {
                    var data = (Byte[])(row.Cells[5].Value);
                    var stream = new MemoryStream(data);
                    pictureLoaiHang.Image = Image.FromStream(stream);
                }
                else
                    pictureLoaiHang.Image = null;

                txtTenLH.Text = row.Cells[1].Value.ToString().Trim();
                txtDongia.Text = row.Cells[2].Value.ToString().Trim();
                datehansudung.Text = row.Cells[6].Value.ToString().Trim();
                richghichuLH.Text = row.Cells[7].Value.ToString().Trim();
                numericUpDown1.Value = Convert.ToInt32(row.Cells[3].Value.ToString());
                cbbloaihang.DataSource = LH.select_LoaiHangMa(row.Cells[4].Value.ToString());
                cbbloaihang.DisplayMember = "TenLH";
                cbbloaihang.ValueMember = "MaLH";
                mahh.Text = row.Cells[0].Value.ToString().Trim();
                
                
            }
        }
        //load ảnh
        private void btnUpload_Click(object sender, EventArgs e)
        {
            String imageLocationNV = "";
            try
            {              
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*"﻿;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocationNV = dialog.FileName;
                    pictureLoaiHang.ImageLocation = imageLocationNV;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Định dạng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlammoi_Click(object sender, EventArgs e)
        {
            loadloaihang();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //Xử lý ảnh
            Image imgNV = pictureLoaiHang.Image;
            byte[] arrLH;
            ImageConverter converter = new ImageConverter();
            arrLH = (byte[])converter.ConvertTo(imgNV, typeof(byte[]));
            //Kiểm tra điều kiện
            if (cbbloaihang.SelectedValue != null && txtTenLH.Text != "" && pictureLoaiHang.Image != null)
            {
                //Chuyển đơn giá
                string a = txtDongia.Text;
                float dongia = Convert.ToInt32(a);
                //Chuyển số lượng
                string b = numericUpDown1.Value.ToString();
                int soluong = Convert.ToInt32(b);
                if (HH.insert_HangHoa(createMahh(), txtTenLH.Text, dongia, soluong, cbbloaihang.SelectedValue.ToString(), arrLH, datehansudung.Value.ToString(), richghichuLH.Text) > 0)
                {
                    MessageBox.Show("Thành công");
                    //Loại hàng
                    dtgLoaiHang.DataSource = HH.select_HangHoa();
                    loadloaihang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else if (cbbloaihang.SelectedValue == null)
                MessageBox.Show("Bạn chưa chọn loại hàng");
            else if (pictureLoaiHang.Image == null)
                MessageBox.Show("Bạn chưa chọn ảnh");
            else
                MessageBox.Show("Tên sản phẩm không được để trống");
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            //Xử lý ảnh
            Image imgNV = pictureLoaiHang.Image;
            byte[] arrLH;
            ImageConverter converter = new ImageConverter();
            arrLH = (byte[])converter.ConvertTo(imgNV, typeof(byte[]));
            //Kiểm tra điều kiện
            if (cbbloaihang.SelectedValue != null && txtTenLH.Text != "" && pictureLoaiHang.Image != null)
            {
                //Chuyển đơn giá
                string a = txtDongia.Text;
                float dongia = Convert.ToInt32(a);
                //Chuyển số lượng
                string b = numericUpDown1.Value.ToString();
                int soluong = Convert.ToInt32(b);
                if (HH.update_HangHoa(mahh.Text, txtTenLH.Text, dongia, soluong, cbbloaihang.SelectedValue.ToString(), arrLH, datehansudung.Value.ToString(), richghichuLH.Text) > 0)
                {
                    MessageBox.Show("Thành công");
                    //Loại hàng
                    dtgLoaiHang.DataSource = HH.select_HangHoa();
                    loadloaihang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else if (cbbloaihang.SelectedValue == null)
                MessageBox.Show("Bạn chưa chọn loại hàng");
            else if (pictureLoaiHang.Image == null)
                MessageBox.Show("Bạn chưa chọn ảnh");
            else
                MessageBox.Show("Tên sản phẩm không được để trống");
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(HH.delete_HangHoa(mahh.Text)>0)
            {
                MessageBox.Show("Thành công");
                //Loại hàng
                dtgLoaiHang.DataSource = HH.select_HangHoa();
                loadloaihang();
            }
            else
                MessageBox.Show("Thất bại");
        }
        /*Loại hàng
         * Loại hàng
         * 
         * */
        void loadlhang()
        {
            txtmalh.Clear();
            TenLHtxt.Clear();
            richghichuLoaiH.Clear();
        }
        //Tạo mã loại hàng
        string createMaLH()
        {
            int MaLH = 0;
            foreach (DataGridViewRow row in dtgdsloaihang.Rows)
            {
                if (!row.IsNewRow)
                {
                    string b = row.Cells[0].Value.ToString().Substring(2);
                    int c = Convert.ToInt32(b);
                    if (MaLH < c)
                        MaLH = c;
                }
            }
            MaLH++;
            if(MaLH<10)
                return "LH0" + MaLH;
            else
                return "LH" + MaLH;
        }

        private void dtgdsloaihang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //chọn dòng dtgrid

                dtgdsloaihang.CurrentRow.Selected = true;
                DataGridViewRow row = this.dtgdsloaihang.Rows[e.RowIndex];
                txtmalh.Enabled = false;
                txtmalh.Text = row.Cells[0].Value.ToString();
                TenLHtxt.Text = row.Cells[1].Value.ToString();
                richghichuLoaiH.Text = row.Cells[2].Value.ToString();

            }
           
        }

        private void bthlammoilh_Click(object sender, EventArgs e)
        {
            loadlhang();
            txtmalh.Enabled = true;  
        }

        private void btnthemlh_Click(object sender, EventArgs e)
        {
            if (TenLHtxt.Text != "")
            {
                if (LH.insert_LoaiHang(createMaLH(), TenLHtxt.Text,richghichuLoaiH.Text) > 0)
                {
                    MessageBox.Show("Thành công");
                    dtgdsloaihang.DataSource = LH.select_LoaiHang();
                    loadlhang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Chưa nhập tên loại hàng");
        }

        private void btnsualh_Click(object sender, EventArgs e)
        {
            if (TenLHtxt.Text != "")
            {
                if(LH.update_LoaiHang(txtmalh.Text,TenLHtxt.Text,richghichuLoaiH.Text)>0)
                {
                    MessageBox.Show("Thành công");
                    dtgdsloaihang.DataSource = LH.select_LoaiHang();
                    loadlhang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Chưa nhập tên loại hàng");
        }

        private void btnxoalh_Click(object sender, EventArgs e)
        {
            DataTable DT = HH.select_HangHoaMaLH(txtmalh.Text);
            if (DT.Rows.Count > 0)
            {
                MessageBox.Show("Loại hàng đã chứa trong sản phẩm. Bạn không thể xóa.!");
            }
            else
            {
                if (LH.delete_LoaiHang(txtmalh.Text) > 0)
                {
                    MessageBox.Show("Thành công");
                    dtgdsloaihang.DataSource = LH.select_LoaiHang();
                    loadlhang();
                }
                else
                    MessageBox.Show("Thất bại");
            }
        }

        /*Dịch vụ
         * Dịch vụ
         * Dịch vụ
         * 
         * */
        //Kiểm tra sản phẩm còn hàng
        void checksp()
        {

            foreach (DataGridViewRow row in dtgsanpham.Rows)
            {
                int a = Convert.ToInt32(row.Cells[3].Value.ToString());
                if (a <= 10)
                    row.DefaultCellStyle.BackColor = Color.Red;

            }
        }
        //Tạo mã hóa đơn
        string createMaHD()
        {
            int MaHD = 0;
            DataTable DT = HD.select_HoaDon();
            foreach (DataRow row in DT.Rows)
            {
                string a = row["MaHD"].ToString().Substring(2);
                int b = Convert.ToInt32(a);
                if (MaHD < b)
                    MaHD = b; 
            }
            MaHD++;
            if (MaHD < 10)
                return "HD0" + MaHD;
            else
                return "HD" + MaHD;
        }
        void clearHD()
        {
            texttongtien.Clear();
            textMaKH.Clear();
            textMaLH.Clear();
            textTenKH.Clear();
            texttensp.Clear();
            textgia.Clear();
            textSlcon.Clear();
            numericUpDown2.Value = 0;
            pictureSanP.Image = null;
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
        }
        private void dtgkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //chọn dòng dtgrid
                checksp();
                dtgkhachhang.CurrentRow.Selected = true;
                DataGridViewRow row = this.dtgkhachhang.Rows[e.RowIndex];
                textTenKH.Text = row.Cells[1].Value.ToString().Trim();
                textMaKH.Text = row.Cells[0].Value.ToString().Trim();       
            }

        }

        private void dtgsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                checksp();
                //chọn dòng dtgrid
                dtgsanpham.CurrentRow.Selected = true;
                DataGridViewRow row = this.dtgsanpham.Rows[e.RowIndex];
                //Hiển thị ảnh
                //Kiểm tra tồn tại của ảnh
                if (!Convert.IsDBNull(row.Cells[5].Value))
                {
                    var data = (Byte[])(row.Cells[5].Value);
                    var stream = new MemoryStream(data);
                    pictureSanP.Image = Image.FromStream(stream);
                }
                else
                    pictureSanP.Image = null;

                
                texttensp.Text = row.Cells[1].Value.ToString().Trim();
                textMaLH.Text = row.Cells[0].Value.ToString().Trim();
                textgia.Text = row.Cells[2].Value.ToString().Trim();
                textSlcon.Text = row.Cells[3].Value.ToString().Trim();
            }
        }
        private static int sum = 0;
        private void button11_Click_1(object sender, EventArgs e)
        {
            checksp();
            textMaKH.Clear();
            textMaLH.Clear();

            textTenKH.Text = "Khách vãn lai";
            textMaKH.Text = ThemMaKH();
        }
        //Add vào bảng phụ
      
        private void button9_Click_1(object sender, EventArgs e)
        {

            checksp();
            
            
            //Nếu thông tin trống sẽ không được thực hiện           
            if (textMaLH.Text != "" && textMaKH.Text != "" && numericUpDown2.Value != 0)
            {
                string malh="";
                int b = Convert.ToInt32(numericUpDown2.Value.ToString());
                int gia = Convert.ToInt32(textgia.Text);
               
                
                //Tạo tiêu đề cột
                dataGridView4.ColumnCount = 8;
                dataGridView4.Columns[0].Name = "Mã Hóa đơn";
                dataGridView4.Columns[1].Name = "Mã Hàng";
                dataGridView4.Columns[2].Name = "Tên Hàng";
                dataGridView4.Columns[3].Name = "Số Lượng";
                dataGridView4.Columns[4].Name = "Đơn giá";
                dataGridView4.Columns[5].Name = "Ngày Hóa Đơn";
                dataGridView4.Columns[6].Name = "Mã Khách Hàng";
                dataGridView4.Columns[7].Name = "Mã Nhân Viên";
                    
                //Kiểm tra khi dữ liệu đã có trong bảng
                string makh = textMaKH.Text;
             
                foreach (DataGridViewRow ro in dataGridView4.Rows)
                {
                    int soluong = Convert.ToInt32(ro.Cells[3].Value.ToString());
                    malh = ro.Cells[1].Value.ToString();
                    makh = ro.Cells[6].Value.ToString();
                    if (textMaLH.Text == malh && textMaKH.Text == ro.Cells[6].Value.ToString())
                    {
                        makh = ro.Cells[6].Value.ToString();
                        int c = soluong + b;
                        int dongia = gia * c;
                        //Xóa dòng khi số lượng bằng 0
                        if (c <= 0)
                        {
                            dataGridView4.Rows.RemoveAt(ro.Index);
                        }
                        //Thực hiện thêm dòng sản phẩm trong hóa đơn
                        else
                        {
                            ro.Cells[3].Value = c.ToString();
                            ro.Cells[4].Value = dongia.ToString();
                            sum = sum + (gia * b);
                            texttongtien.Text = sum.ToString();
                        }
                        numericUpDown2.Value = 0;
                        break;
                    }
                    else if (textMaKH.Text != makh)
                    {
                        MessageBox.Show("Việc thay đổi khách hàng là không được phép");
                        break;
                    }
                    
                    
                }
                //Nếu khách hàng không đúng sẽ không được thêm vào hóa đơn
                if (textMaKH.Text == makh)
                {
                    //Tạo dữ liệu đầu tiên
                    if (textMaLH.Text != malh && numericUpDown2.Value > 0)
                    {
                        
                        int dongia = b * gia;
                        //Thêm dòng sản phẩm trong hóa đơn
                        string[] row = new string[] { createMaHD(), textMaLH.Text, texttensp.Text, b.ToString(), dongia.ToString(), DateTime.Now.ToString(), textMaKH.Text, textMaNV.Text };
                        dataGridView4.Rows.Add(row);
                        numericUpDown2.Value = 0;
                        sum = sum + dongia;
                        texttongtien.Text = sum.ToString();
                        
                    }

                    else if (numericUpDown2.Value < 0) MessageBox.Show("Số lượng không được nhỏ hơn 0");
                }
                
            }
            else if (numericUpDown2.Value == 0)
                        MessageBox.Show("Bạn chưa nhập số lượng");
            else if (textMaKH.Text == "")
                MessageBox.Show("Bạn chưa chọn khách hàng");
            else
                MessageBox.Show("Bạn chưa nhập sản phẩm");

            
        }
        //Làm mới
        private void button16_Click(object sender, EventArgs e)
        {
            clearHD();
            checksp();
        }
        //Thực thi vào csdl
        private void button12_Click_1(object sender, EventArgs e)
        {
            
            int a = 0;
            if (dataGridView4.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    DataTable DT = HH.select_HangHoaMa(row.Cells[1].Value.ToString());
                    int slcon = Convert.ToInt32(DT.Rows[0]["SLCon"].ToString()) - Convert.ToInt32(row.Cells[3].Value.ToString()); 
                    if (HD.insert_HoaDon(row.Cells[0].Value.ToString(),row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString())>0)
                    {

                        if (CTHD.insert_CTHD(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), Convert.ToInt32(row.Cells[3].Value.ToString())) > 0)
                        {
                            if (HH.update_SLConHangHoa(row.Cells[1].Value.ToString(), slcon) > 0)
                            {
                                a++;
                                clearHD();
                                dtgsanpham.DataSource = HH.select_HangHoa();
                                checksp();
                            }
                        }
                    }
                    if (a > 0) MessageBox.Show("Thành công");
                    else MessageBox.Show("Thất bại");
                   

                }
            }
            else
                MessageBox.Show("Chưa có dữ liệu hóa đơn");
            
        }

        /*
         * 
         * 
         * 
         * */
        private void button7_Click(object sender, EventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage1);
            tabControl1.SelectTab(tabPage1);
            khachhang.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage2);
            tabControl1.SelectTab(tabPage2);
            nhanvien.Enabled = true;
        }
        //click sản phẩm
        private void button11_Click(object sender, EventArgs e)
        {
            
            closeTabcontrol();
            
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage3);
            tabControl1.SelectTab(tabPage3);
            sanpham.Enabled = true;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage4);
            tabControl1.SelectTab(tabPage4);
            loaihang.Enabled = true;
            
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectTab(tabPage6);
            hoadon.Enabled = true;
        }
        //Dịch vụ
        /*Dịch vụ
         * Dịch vụ
         * Dịch vụ
         * Dịch vụ
         * */
        //Kiểm tra theo ngày
        bool Radiongay()
        {
            if (theongay.Checked == true)
                return true;
            else if (thang.Checked == true)
                return true;
            else
                return false;           
        }
        private void button14_Click(object sender, EventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.SelectTab(tabPage5);
            loaihang.Enabled = true;
        }
        //hiển thị theo ngày
        void showday()
        {
            ngaybatdau.Enabled = true;
            textngaybd.Enabled = true;
            ngayketthuc.Enabled = true;
            textngaykt.Enabled = true;
        }
        //Hiển thị theo tháng
        void showmonth()
        {
            textthang.Enabled = true;
            datengayhd.Enabled = true;
        }
        //ân theo ngày
        void hideday()
        {
            ngaybatdau.Enabled = false;
            textngaybd.Enabled = false;
            ngayketthuc.Enabled = false;
            textngaykt.Enabled = false;
        }
        //Ẩn theo tháng
        void hideMonth()
        {
            textthang.Enabled = false;
            datengayhd.Enabled = false;
        }
        //Tìm kiếm
        private void button17_Click(object sender, EventArgs e)
        {
            
            //Hóa đơn theo mã nvien
            if (cbbTennv.SelectedValue != null && textmahd.Text ==""&&toanthoigian.Checked == true)
            {  
                cbbdshoadon.DataSource = HD.select_HoaDonByMaNV(cbbTennv.SelectedValue.ToString().Trim());
                cbbdshoadon.DisplayMember = "TenHD";
                cbbdshoadon.ValueMember = "MaHD";
                if (cbbdshoadon.SelectedItem == null)
                {
                    cbbdshoadon.SelectedIndex = -1;
                    cbbdshoadon.ResetText();
                    MessageBox.Show("Không có dữ liệu hóa đơn");
                }
            }
            //Hóa đơn theo mã nv +  ngày bắt đầ kết thúc
            if (cbbTennv.SelectedValue != null && theongay.Checked == true && textmahd.Text == "")
            {
                cbbdshoadon.DataSource = HD.select_HoaDonMaNVbyday(cbbTennv.SelectedValue.ToString().Trim(), ngaybatdau.Value.ToString().Trim(), ngayketthuc.Value.ToString().Trim());
                cbbdshoadon.DisplayMember = "TenHD";
                cbbdshoadon.ValueMember = "MaHD";
                if (cbbdshoadon.SelectedItem == null)
                {
                    cbbdshoadon.SelectedIndex = -1;
                    cbbdshoadon.ResetText();
                    MessageBox.Show("Không có dữ liệu hóa đơn");
                }
            }
            //Hóa đơn theo mã nv + tháng
            if (cbbTennv.SelectedValue != null && thang.Checked == true && textmahd.Text == "")
            {
                int Month = datengayhd.Value.Month;
                int Year = datengayhd.Value.Year;
                cbbdshoadon.DataSource = HD.select_HoaDonMaNVbyMonth(cbbTennv.SelectedValue.ToString(), Month, Year);
                cbbdshoadon.DisplayMember = "TenHD";
                cbbdshoadon.ValueMember = "MaHD";
                if (cbbdshoadon.SelectedItem == null)
                {
                    cbbdshoadon.SelectedIndex = -1;
                    cbbdshoadon.ResetText();
                    MessageBox.Show("Không có dữ liệu hóa đơn");
                }
            }
            
            //Mã hóa đơn
            if (textmahd.Text != "")
            {
                dtgdshoadon.DataSource = HD.select_HoaDontimkiem(textmahd.Text);
                int a = 0;
                int tong = 0;
                //ĐỔi mã thành tên
                dtgdshoadon.Columns[5].HeaderText = "Tên Khách Hàng";
                dtgdshoadon.Columns[6].HeaderText = "Tên Nhân Viên";
                foreach (DataGridViewRow row in dtgdshoadon.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataTable DT = HD.select_HoaDonNVvaKH(textmahd.Text);
                        foreach (DataRow ro in DT.Rows)
                        {
                            row.Cells[5].Value = ro[1].ToString();
                            row.Cells[6].Value = ro[0].ToString();
                        }
                        a = Convert.ToInt32(row.Cells[2].Value.ToString()) * Convert.ToInt32(row.Cells[3].Value.ToString());
                        tong = tong + a;
                    }
                }
                if (dtgdshoadon.Rows.Count <= 1)
                {
                    MessageBox.Show("Không có dữ liệu về hóa đơn");
                }
                tongtienhd.Text = tong.ToString();
            }
            //Bắt lỗi
            if (cbbTennv.SelectedValue == null && textmahd.Text == "")
                MessageBox.Show("Bạn chưa chọn tên mục tìm kiếm");

        }

        private void cbbTennv_DropDown(object sender, EventArgs e)
        {
            cbbTennv.DataSource = NV.select_NhanVien();
            cbbTennv.DisplayMember = "TenNV".Trim();
            cbbTennv.ValueMember = "MaNV";
        }

        private void theongay_CheckedChanged(object sender, EventArgs e)
        {
            hideMonth();
            showday();
        }

        private void thang_CheckedChanged(object sender, EventArgs e)
        {
            hideday();
            showmonth();
        }

        private void toanthoigian_CheckedChanged(object sender, EventArgs e)
        {
            hideday();
            hideMonth();
        }

        private void radioNV_CheckedChanged(object sender, EventArgs e)
        {
            
            cbbTennv.Enabled = true;
            textmahd.Enabled = false;
            textmahd.Clear();
        }

        private void radioHD_CheckedChanged(object sender, EventArgs e)
        {
            textmahd.Enabled = true;
            cbbTennv.Enabled = false;
            cbbdshoadon.Enabled = false;
        }

        private void cbbdshoadon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbdshoadon.SelectedValue != null)
            {
                dtgdshoadon.DataSource = HD.select_HoaDontimkiem(cbbdshoadon.SelectedValue.ToString());
                int tong = 0;
                int a = 0;
                //ĐỔi mã thành tên
                foreach (DataGridViewRow row in dtgdshoadon.Rows)
                {
                    
                    
                    if (!row.IsNewRow)
                    {
                        a = Convert.ToInt32(row.Cells[2].Value.ToString()) * Convert.ToInt32(row.Cells[3].Value.ToString());
                        tong = tong + a;
                    }
                    if (row.Cells.Count<=1)
                        MessageBox.Show("Không có dữ liệu về hóa đơn");
                }
                tongtienhd.Text = tong.ToString();
            }
        }
        /*
         * Danh sách thẻ
         * Danh sách thẻ
         * Danh sách thẻ
         * */
        private void button17_Click_2(object sender, EventArgs e)
        {
            
            if(allradio.Checked == true)
            {
                dsthe.DataSource = Th.select_ThebyDichvuAll();
                foreach (DataGridViewRow row in dsthe.Rows)
                {
                    if(!row.IsNewRow)
                    {
                        DateTime ngaydk = Convert.ToDateTime(row.Cells[3].Value.ToString());
                        DateTime today = DateTime.Now;
                        TimeSpan time = today - ngaydk;
                        int Songaydk = time.Days;

                        int thoihan = Convert.ToInt32(row.Cells[4].Value.ToString());

                        if (Songaydk - thoihan >=0)
                            row.DefaultCellStyle.BackColor = Color.Red;
                        else if (Songaydk < thoihan && Songaydk - thoihan >= -3)
                            row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            else if(danghoatdongradio.Checked == true)
            {
                dsthe.DataSource = Th.select_ThebyDichvuAll();
                for (int i = 0; i < dsthe.Rows.Count; i++)
                {
                    if (dsthe.Rows[i].Cells[0].Value != null)
                    {
                        DateTime ngaydk = Convert.ToDateTime(dsthe.Rows[i].Cells[3].Value.ToString());
                        DateTime today = DateTime.Now;
                        TimeSpan time = today - ngaydk;
                        int Songaydk = time.Days;

                        int thoihan = Convert.ToInt32(dsthe.Rows[i].Cells[4].Value.ToString());

                        
                        if (Songaydk > thoihan)
                        {
                            dsthe.Rows.Remove(dsthe.Rows[i]);
                            if (i != 0)
                                i--;
                        }      
                        if (Songaydk < thoihan && Songaydk - thoihan  >= -3)
                        {
                            dsthe.Rows.Remove(dsthe.Rows[i]);
                            if (i != 0)
                                i--;
                        }
                    }
                }     
            }
            else if (hethanradio.Checked == true)
            {
                dsthe.DataSource = Th.select_ThebyDichvuAll();
                for (int i = 0; i < dsthe.Rows.Count; i++)
                {
                    if (dsthe.Rows[i].Cells[0].Value != null)
                    {
                        DateTime ngaydk = Convert.ToDateTime(dsthe.Rows[i].Cells[3].Value.ToString());
                        DateTime today = DateTime.Now;
                        TimeSpan time = today - ngaydk;
                        int Songaydk = time.Days;

                        int thoihan = Convert.ToInt32(dsthe.Rows[i].Cells[4].Value.ToString());


                        if (Songaydk > thoihan )
                            dsthe.DefaultCellStyle.BackColor = Color.White;
                        else if (Songaydk < thoihan && Songaydk - thoihan >= -3)
                        {
                            dsthe.Rows.Remove(dsthe.Rows[i]);
                            if (i != 0)
                                i--;
                        }
                        else if (Songaydk < thoihan && Songaydk - thoihan < -3)
                        {
                            dsthe.Rows.Remove(dsthe.Rows[i]);
                            if (i != 0)
                                i--;
                        }
                    }
                }     
            }
            else if(NVradio.Checked == true)
            {
               int day = Convert.ToInt32(datenvthe.Value.Day.ToString());
               int Month = Convert.ToInt32(datenvthe.Value.Month.ToString());
               int Year = Convert.ToInt32(datenvthe.Value.Year.ToString());
               DateTime now = DateTime.Now;
               if (checkBox1.Checked == true)
                   dsthe.DataSource = Th.select_ThebyDichvuMaNV(cbbNvthe.SelectedValue.ToString());
               else
                 dsthe.DataSource = Th.select_ThebyDichvuMaNVandMonthYear(cbbNvthe.SelectedValue.ToString(), Month, Year);
                  

            }
        }

        private void NVradio_CheckedChanged(object sender, EventArgs e)
        {
            cbbNvthe.Enabled = true;
            datenvthe.Enabled = true;
            checkBox1.Enabled = true;
            cbbNvthe.DataSource = NV.select_NhanVien();
            cbbNvthe.DisplayMember = "TenNV";
            cbbNvthe.ValueMember = "MaNV";
        }

        private void dsthe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //chọn dòng dtgrid
                dsthe.CurrentRow.Selected = true;
                DataGridViewRow row = this.dsthe.Rows[e.RowIndex];
                
                GiaHanThe GHThe = new GiaHanThe();
                DataTable DT = Th.select_TheMa(row.Cells[6].Value.ToString().Trim());
                if (DT.Rows.Count > 0)
                {
                    //Gọi properties để gọi chuyển dữ liệu sang fomr 2 
                    GHThe.Message = row.Cells[6].Value.ToString().Trim(); ;
                    GHThe.MaNV = labelMaNV.Text;
                    GHThe.ShowDialog();

                }
                else
                    MessageBox.Show("Khách hàng chưa có thẻ");
            }

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            cbbtheKH.DataSource = KH.select_KhachHang();
            cbbtheKH.DisplayMember = "TenKH";
            cbbtheKH.ValueMember = "MaKH";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            dsthe.DataSource = Th.select_TheMa(cbbtheKH.SelectedValue.ToString());
            foreach (DataGridViewRow row in dsthe.Rows)
            {
                if (!row.IsNewRow)
                {
                    DateTime ngaydk = Convert.ToDateTime(row.Cells[3].Value.ToString());
                    DateTime today = DateTime.Now;
                    TimeSpan time = today - ngaydk;
                    int Songaydk = time.Days;

                    int thoihan = Convert.ToInt32(row.Cells[4].Value.ToString());

                    if (Songaydk - thoihan >= 0)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    else if (Songaydk < thoihan && Songaydk - thoihan >= -3)
                        row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            GiaHanThe GHThe = new GiaHanThe();
            DataTable DT = Th.select_TheMa(cbbtheKH.SelectedValue.ToString());
            if (DT.Rows.Count > 0)
            {
                //Gọi properties để gọi chuyển dữ liệu sang fomr 2 
                GHThe.Message = cbbtheKH.SelectedValue.ToString();
                GHThe.MaNV = labelMaNV.Text;
                GHThe.ShowDialog();

            }
            else
                MessageBox.Show("Khách hàng chưa có thẻ");
        }

        
        

        

       

        

        

       

        

        

       



        

      


       
    }
}
