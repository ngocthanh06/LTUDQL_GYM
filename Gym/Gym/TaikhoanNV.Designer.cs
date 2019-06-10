namespace Gym
{
    partial class TaikhoanNV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaikhoanNV));
            this.txtmatk = new System.Windows.Forms.TextBox();
            this.matk = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.quyen = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.admin = new System.Windows.Forms.RadioButton();
            this.nhanvien = new System.Windows.Forms.RadioButton();
            this.btcapnhat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtmatk
            // 
            this.txtmatk.Location = new System.Drawing.Point(106, 16);
            this.txtmatk.Name = "txtmatk";
            this.txtmatk.Size = new System.Drawing.Size(151, 20);
            this.txtmatk.TabIndex = 0;
            // 
            // matk
            // 
            this.matk.AutoSize = true;
            this.matk.Location = new System.Drawing.Point(12, 19);
            this.matk.Name = "matk";
            this.matk.Size = new System.Drawing.Size(73, 13);
            this.matk.TabIndex = 1;
            this.matk.Text = "Mã Tài khoản";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(12, 75);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(81, 13);
            this.username.TabIndex = 2;
            this.username.Text = "Tên đăng nhập";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(12, 130);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(52, 13);
            this.password.TabIndex = 3;
            this.password.Text = "Mật khẩu";
            // 
            // quyen
            // 
            this.quyen.AutoSize = true;
            this.quyen.Location = new System.Drawing.Point(12, 186);
            this.quyen.Name = "quyen";
            this.quyen.Size = new System.Drawing.Size(38, 13);
            this.quyen.TabIndex = 4;
            this.quyen.Text = "Quyền";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(106, 72);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(151, 20);
            this.txtusername.TabIndex = 5;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(106, 127);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(151, 20);
            this.txtpassword.TabIndex = 6;
            // 
            // admin
            // 
            this.admin.AutoSize = true;
            this.admin.Location = new System.Drawing.Point(106, 186);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(54, 17);
            this.admin.TabIndex = 7;
            this.admin.TabStop = true;
            this.admin.Text = "Admin";
            this.admin.UseVisualStyleBackColor = true;
            // 
            // nhanvien
            // 
            this.nhanvien.AutoSize = true;
            this.nhanvien.Location = new System.Drawing.Point(206, 186);
            this.nhanvien.Name = "nhanvien";
            this.nhanvien.Size = new System.Drawing.Size(74, 17);
            this.nhanvien.TabIndex = 8;
            this.nhanvien.TabStop = true;
            this.nhanvien.Text = "Nhân viên";
            this.nhanvien.UseVisualStyleBackColor = true;
            // 
            // btcapnhat
            // 
            this.btcapnhat.Location = new System.Drawing.Point(158, 226);
            this.btcapnhat.Name = "btcapnhat";
            this.btcapnhat.Size = new System.Drawing.Size(99, 31);
            this.btcapnhat.TabIndex = 10;
            this.btcapnhat.Text = "Cập nhật";
            this.btcapnhat.UseVisualStyleBackColor = true;
            this.btcapnhat.Click += new System.EventHandler(this.button2_Click);
            // 
            // TaikhoanNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(288, 277);
            this.Controls.Add(this.btcapnhat);
            this.Controls.Add(this.nhanvien);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.quyen);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.matk);
            this.Controls.Add(this.txtmatk);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TaikhoanNV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaikhoanNV";
            this.Load += new System.EventHandler(this.TaikhoanNV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmatk;
        private System.Windows.Forms.Label matk;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label quyen;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.RadioButton admin;
        private System.Windows.Forms.RadioButton nhanvien;
        private System.Windows.Forms.Button btcapnhat;
    }
}