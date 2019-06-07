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
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;


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
            get { return labeltennguoidung.Text; }
            set { labeltennguoidung.Text = value; }
        }

        public string Quyen
        {
            get { return labelChucvu.Text; }
            set { labelChucvu.Text = value; }
        }

        void clearbutton()
        {
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            ricktbGhiChu.Clear();
            
            dateNgaySinh.ResetText();
            pictureBox1.Image = null;
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
        //Load danh sách nhân viên trong datagridview
        public void loaddsnhanvien()
        {
            dtgnhanvien.DataSource = NV.select_NhanVien();
            foreach (DataGridViewRow row in dtgnhanvien.Rows)
            {
                if (row.Cells[9].Value.ToString() == "True")
                row.DefaultCellStyle.BackColor = Color.Red;
            }
            
        }
        //Thay đổi giao diện
        public void thaydoigiaodien()
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //THay đổi giao diện
            thaydoigiaodien();
            //Khách hàng
            dataGridView1.DataSource = KH.select_KhachHang();
            labelChucvu.Visible = false;
            labeltennguoidung.Visible = false;
            MaKH.Visible = false;
            MaThe.Visible = false;
            MaNV.Visible = false;
            matk.Visible = false;
            labelMaNV.Visible = false;
            //mahh.Visible = false;
            DataTable DT = NV.select_NhanVienMaTK(labeltennguoidung.Text);
            //Phân quyền
            if (labelChucvu.Text != "Admin")
            {
                nhanvien.Visible = false;
                sanpham.Visible = false;
                loaihang.Visible = false;
            }
            //Label tên người dùng
            barHeaderItem1.Caption = "Xin chào, " + DT.Rows[0]["TenNV"].ToString();
            //Label quyền
            barStaticItem2.Caption = labelChucvu.Text;
            labelMaNV.Text = DT.Rows[0]["MaNV"].ToString();
            closeTabcontrol();
            textMaNV.Text = DT.Rows[0]["MaNV"].ToString();
            //nhân viên
            loaddsnhanvien();
            //hanghoa
            dtgLoaiHang.DataSource = HH.select_HangHoa();
            //loaihang
            mahh.Visible = false;
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
            //Danh sách thẻ
            cbbNvthe.Enabled = false;
            datenvthe.Enabled = false;
            checkBox1.Enabled = false;
            //CryptalReport
           
           
        }
        
        void closeTabcontrol()
        {

            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);
           
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
       


        //Làm mới khách hàng
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clearbutton();
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
        //THêm ảnh
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
      

       //Sửa KH
        //Sửa Khách Hàng
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Xóa Khách hàng
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
      
        //Gia hạn thẻ
        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GiaHanThe GHThe = new GiaHanThe();
            DataTable DT = Th.select_TheMa(MaKH.Text);
            
            if (DT.Rows.Count > 0)
            {
                //Gọi properties để gọi chuyển dữ liệu sang fomr 2 
                GHThe.Message = MaKH.Text;
                GHThe.MaNV = labelMaNV.Text;
                GHThe.ShowDialog();

            }
            else
            {
                DialogResult Mes = MessageBox.Show("Khách hàng không có thẻ. Bạn muốn thêm thẻ không?", "Thông báo.!!", MessageBoxButtons.YesNo);
                if (Mes == DialogResult.Yes)
                {
                    GHThe.Message = MaKH.Text;
                    GHThe.MaNV = labelMaNV.Text;
                    GHThe.ShowDialog();
                }
            }
                
        }
        //THêm Khách Hàng
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemKH ThemKH = new ThemKH();

            ThemKH.MaNVKH = labelMaNV.Text;
            ThemKH.ShowDialog();
        }
      
        //load cbb view form child
        
       

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

        //Làm Mới 
        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clearbuttonNV();
        }
        //Sửa
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                MessageBox.Show("Bạn chưa chọn nhân viên");
            else
                MessageBox.Show("Bạn chưa có ảnh");
        }
        //Xóa
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Upload
        private void simpleButton2_Click(object sender, EventArgs e)
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
       
        //Hiển thị tài khoản
        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Load ảnh
        private void simpleButton3_Click(object sender, EventArgs e)
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
       
        //Thêm sản phẩm
        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Làm mới
        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadloaihang();
        }
        //Sửa
        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Xóa
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HH.delete_HangHoa(mahh.Text) > 0)
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
        //Xóa
        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
        //Sửa
        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TenLHtxt.Text != "")
            {
                if (LH.update_LoaiHang(txtmalh.Text, TenLHtxt.Text, richghichuLoaiH.Text) > 0)
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
        //Thêm
        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TenLHtxt.Text != "")
            {
                if (LH.insert_LoaiHang(createMaLH(), TenLHtxt.Text, richghichuLoaiH.Text) > 0)
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
        //Làm mới
        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadlhang();
            txtmalh.Enabled = true;
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
        //Khách vãn lai
        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            checksp();
            textMaKH.Clear();
            textMaLH.Clear();

            textTenKH.Text = "Khách vãn lai";
            textMaKH.Text = ThemMaKH();
        }
       
        //Add vào bảng phụ
        //THêm dịch vụ vào lưới
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            checksp();


            //Nếu thông tin trống sẽ không được thực hiện           
            if (textMaLH.Text != "" && textMaKH.Text != "" && numericUpDown2.Value != 0)
            {
                string malh = "";
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
                        int SumTien = 0;
                        int thue = 0;
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
                            if (sum > 1500000)
                                thue = sum * 10 / 100;
                            else
                                thue = 0;
                            SumTien = sum + thue;
                            GTGT.Text = String.Format("{0:0,0}", thue) + " VND";

                            tongsotien.Text = String.Format("{0:0,0}", SumTien) + " VND";
                            tongtien.Text = String.Format("{0:0,0}", sum) + " VND";

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
                        int thue = 0;
                        int SumTien = 0;
                        int dongia = b * gia;
                        //Thêm dòng sản phẩm trong hóa đơn
                        string[] row = new string[] { createMaHD(), textMaLH.Text, texttensp.Text, b.ToString(), dongia.ToString(), DateTime.Now.ToString(), textMaKH.Text, textMaNV.Text };
                        dataGridView4.Rows.Add(row);
                        numericUpDown2.Value = 0;
                        sum = sum + dongia;
                        if (sum > 1500000)
                            thue = sum * 10 / 100;
                        else
                            thue = 0;
                        SumTien = sum + thue;
                        GTGT.Text = String.Format("{0:0,0}",thue)+" VND";

                        tongsotien.Text = String.Format("{0:0,0}",SumTien)+" VND";
                        tongtien.Text = String.Format("{0:0,0}",sum)+" VND";

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

      
      
      
        //Hiển thị hóa đơn trong mục dshd
        private void btn_Inhd_Click(object sender, EventArgs e)
        {
            XtraReport1 report = new XtraReport1();
            report.DataSource = HD.select_InHoaDon(cbbdshoadon.SelectedValue.ToString());
            report.ShowPreview();
        }


        /*
         * 
         * 
         * 
         * */
        //Click page menu ribboncontrol
        
        private void ribbonControl1_MouseClick(object sender, MouseEventArgs e)
        {
            RibbonControl ribon = sender as RibbonControl;
            RibbonHitInfo hitInfo = ribon.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == RibbonHitTest.PageHeader)
            {

                    //Khách hàng
                    if (ribbonControl1.SelectedPage == khachhang)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage1);
                        tabControl1.SelectTab(tabPage1);
                    }
                    //Nhân viên
                    else if (ribbonControl1.SelectedPage == nhanvien)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage2);
                        tabControl1.SelectTab(tabPage2);
                    }
                    //Dịch vụ
                    else if (ribbonControl1.SelectedPage == dichvu)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage5);
                        tabControl1.SelectTab(tabPage5);
                    }
                    //Sản phẩm
                    else if (ribbonControl1.SelectedPage == sanpham)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage3);
                        tabControl1.SelectTab(tabPage3);
                    }
                    //Loại Hàng
                    else if (ribbonControl1.SelectedPage == loaihang)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage4);
                        tabControl1.SelectTab(tabPage4);
                    }
                    //Hóa đơn
                    else if (ribbonControl1.SelectedPage == hoadon)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage6);
                        tabControl1.SelectTab(tabPage6);
                    }
                    //Thẻ hội viên
                    else if (ribbonControl1.SelectedPage == thehoivien)
                    {
                        closeTabcontrol();
                        tabControl1.TabPages.Remove(tabPage1);
                        tabControl1.TabPages.Add(tabPage7);
                        tabControl1.SelectTab(tabPage7);
                    }
              
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dataGridView1.DataSource = KH.select_KhachHang();
        }
        //Nhân viên
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgnhanvien.DataSource = NV.select_NhanVien();
        }
        
        //click sản phẩm
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgLoaiHang.DataSource = HH.select_HangHoa();
        }
       
        //Loại hàng
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtgdsloaihang.DataSource = LH.select_LoaiHang();
        }
       
       
       
        //Dịch vụ
        /*Dịch vụ
         * Dịch vụ
         * Dịch vụ
         * Dịch vụ
         * */
        //Kiểm tra theo ngày
       
        //DỊch vụ
        //Làm mới
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clearHD();
            dataGridView4.Rows.Clear();
            dataGridView4.Refresh();
            checksp();
            GTGT.Text = "";
            tongsotien.Text = "";
            sum = 0;
            tongtien.Text = "";
        }
        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage5);
            tabControl1.SelectTab(tabPage5);
            //loaihang.Enabled = true;
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
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //Tất cả hóa đơn
            if (radioAllHD.Checked == true)
            {
                cbbdshoadon.DataSource = HD.select_HoaDon();
                cbbdshoadon.DisplayMember = "TenHD";
                cbbdshoadon.ValueMember = "MaHD";
            }
            //Hóa đơn theo mã nvien
            if (cbbTennv.SelectedValue != null && textmahd.Text == "" && toanthoigian.Checked == true)
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
                Tongtienhd.Text = String.Format("{0:0,0}",tong)+" VN";
            }
            //Bắt lỗi
            if (cbbTennv.SelectedValue == null && textmahd.Text == "" && radioAllHD.Checked != true)
                MessageBox.Show("Bạn chưa chọn tên mục tìm kiếm");
        }
       
        //Lưu hóa đơn
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int a = 0;
            string MaHD = createMaHD();
            string tien = Convert.ToDecimal(tongsotien.Text.Remove(tongtien.Text.Length - 4, 4)).ToString("#");
            int tongMoney = Convert.ToInt32(tien);
            if (dataGridView4.Rows.Count > 0)
            {
                //MessageBox.Show(dataGridView4.Rows.Count.ToString());
                if (HD.insert_HoaDon(createMaHD(), DateTime.Now.Date.ToString(), textMaKH.Text, textMaNV.Text,tongMoney) > 0)
                {


                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        DataTable DT = HH.select_HangHoaMa(dataGridView4.Rows[i].Cells[1].Value.ToString());
                        int slcon = Convert.ToInt32(DT.Rows[0]["SLCon"].ToString()) - Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value.ToString());
                        if (CTHD.insert_CTHD(dataGridView4.Rows[i].Cells[0].Value.ToString(), dataGridView4.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView4.Rows[i].Cells[3].Value.ToString())) > 0)
                        {
                            if (HH.update_SLConHangHoa(dataGridView4.Rows[i].Cells[1].Value.ToString(), slcon) > 0)
                            {
                                a++;
                                clearHD();
                                dtgsanpham.DataSource = HH.select_HangHoa();
                                checksp();
                            }
                        }
                    }
                }
                //Hiển thị thông báo thành công và in hóa đơn
                if (a > 0)
                {
                    DialogResult hoadon = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Lưu thành công.!!", MessageBoxButtons.OKCancel);
                    if (hoadon == DialogResult.OK)
                    {
                        XtraReport1 report = new XtraReport1();
                        report.DataSource = HD.select_InHoaDon(MaHD);
                        report.ShowPreview();
                    }
                    dataGridView4.Rows.Clear();
                    dataGridView4.Refresh();
                }
                else MessageBox.Show("Thất bại");
            }
            else
                MessageBox.Show("Chưa có dữ liệu hóa đơn");
        }
        //In hóa đơn
        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string MaHD = "";

            //In hóa đơn vừa mới tạo
            DataTable DT = HD.select_HoaDon();
            foreach (DataRow row in DT.Rows)
            {
                MaHD = row[0].ToString();
            }

            XtraReport1 report = new XtraReport1();
            report.DataSource = HD.select_InHoaDon(MaHD);
            report.ShowPreview();
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
            cbbdshoadon.Enabled = true;
            cbbTennv.Enabled = true;
            textmahd.Enabled = false;
            textmahd.Clear();
        }

        private void radioHD_CheckedChanged(object sender, EventArgs e)
        {
            textmahd.Enabled = true;
            cbbTennv.Enabled = false;
            cbbdshoadon.Enabled = false;
            cbbTennv.DataSource = null;

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
                    if (row.Cells.Count <= 1)
                        MessageBox.Show("Không có dữ liệu về hóa đơn");
                }
                if (tong > 1500000)
                    tong = tong + tong * 10 / 100;

                Tongtienhd.Text = String.Format("{0:0,0}", tong) + " VND";
            }
        }
        /*
         * Danh sách thẻ
         * Danh sách thẻ
         * Danh sách thẻ
         * */
        //TÌm kiếm 
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (allradio.Checked == true)
            {
                dsthe.DataSource = Th.select_ThebyDichvuAll();
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
            else if (danghoatdongradio.Checked == true)
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
                        if (Songaydk < thoihan && Songaydk - thoihan >= -3)
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


                        if (Songaydk > thoihan)
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
            else if (NVradio.Checked == true)
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

       

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            cbbtheKH.DataSource = KH.select_KhachHang();
            cbbtheKH.DisplayMember = "TenKH";
            cbbtheKH.ValueMember = "MaKH";
        }

      
        //TÌm kiếm
        private void simpleButton8_Click(object sender, EventArgs e)
        {
            dsthe.DataSource = Th.select_TheMa(cbbtheKH.SelectedValue.ToString());
            foreach (DataGridViewRow row in dsthe.Rows)
            {
                if (!row.IsNewRow)
                {
                    //Ngày đăng ký
                    DateTime ngaydk = Convert.ToDateTime(row.Cells[5].Value.ToString());
                    //Ngày hiện tại
                    DateTime today = DateTime.Now;
                    //hiệu thời gian
                    TimeSpan time = today - ngaydk;
                    int Songaydk = time.Days;

                    int thoihan = Convert.ToInt32(row.Cells[6].Value.ToString());

                    if (Songaydk - thoihan >= 0)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    else if (Songaydk < thoihan && Songaydk - thoihan >= -3)
                        row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

       

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            GiaHanThe GHThe = new GiaHanThe();
            if (cbbtheKH.SelectedValue != null)
            {
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
            else MessageBox.Show("Bạn chưa chọn khách hàng");
        }
        

        private void datenvthe_ValueChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void dsthe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dsthe.CurrentRow.Selected = true;
            DataGridViewRow row = this.dsthe.Rows[e.RowIndex];
        }

        private void radioAllHD_CheckedChanged(object sender, EventArgs e)
        {
            cbbTennv.DataSource = null;
            cbbdshoadon.Enabled = true;
            cbbTennv.Enabled = false;
            textmahd.Enabled = false;
            textmahd.Clear();
            
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThemNVcs NV = new ThemNVcs();
            NV.ShowDialog();
        }
        
        private void barButtonItem40_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            closeTabcontrol();
            tabControl1.TabPages.Remove(tabPage1);
            tabControl1.TabPages.Add(tabPage6);
            tabControl1.SelectTab(tabPage6);
        }

        

        private void barButtonItem51_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            thongke form = new thongke();
            form.ShowDialog();
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Mes = MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Thông báo.!!", MessageBoxButtons.YesNo);
            if (Mes == DialogResult.Yes)
            {
                
                Login lg = new Login();
                lg.Show();
                
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
             DialogResult Mes = MessageBox.Show("Bạn có muốn đóng chương trình không?", "Thông báo.!!", MessageBoxButtons.YesNo);
                if (Mes == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

      
       
    }
}
