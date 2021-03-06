USE [GYM]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 4/23/2019 2:32:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTHD](
	[MaHD] [nchar](10) NULL,
	[MaHang] [nchar](10) NULL,
	[SL] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDV] [nchar](10) NOT NULL,
	[TenDV] [nvarchar](255) NULL,
	[ThoiHan] [int] NULL,
	[Gia] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHang] [nchar](10) NOT NULL,
	[TenHang] [nvarchar](255) NULL,
	[DVT] [nchar](20) NULL,
	[DonGia] [float] NULL,
	[SLCon] [int] NULL,
	[MaLH] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nchar](10) NOT NULL,
	[NgayHD] [date] NULL,
	[MaKH] [nchar](10) NULL,
	[MaNV] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nchar](10) NOT NULL,
	[TenKH] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SDT] [nchar](20) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[GhiChu] [nvarchar](255) NULL,
	[Avatar] [image] NULL,
	[MaThe] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHang](
	[MaLH] [nchar](10) NOT NULL,
	[TenLH] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nchar](10) NOT NULL,
	[TenNV] [nvarchar](255) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SDT] [nchar](20) NULL,
	[MaTK] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taikhoan](
	[MaTK] [nchar](10) NOT NULL,
	[TenDN] [nchar](100) NULL,
	[Matkhau] [nchar](100) NULL,
	[Quyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[The]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[The](
	[Mathe] [nchar](10) NOT NULL,
	[NgayDK] [date] NULL,
	[MaDV] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Mathe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MaHang])
REFERENCES [dbo].[HangHoa] ([MaHang])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CTHD]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD FOREIGN KEY([MaLH])
REFERENCES [dbo].[LoaiHang] ([MaLH])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD FOREIGN KEY([MaThe])
REFERENCES [dbo].[The] ([Mathe])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[Taikhoan] ([MaTK])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[The]  WITH CHECK ADD FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
ON DELETE SET NULL
GO
/****** Object:  StoredProcedure [dbo].[delete_CTHD]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_CTHD] @MaHD nchar(10)
as
begin 
	delete from CTHD where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_DichVu]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_DichVu] @MaDV nchar(10)
as
begin 
	delete from DichVu where MaDV = @MaDV
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_HangHoa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_HangHoa] @MaHang nchar(10)
as
begin 
	delete from HangHoa where MaHang = @MaHang
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_HoaDon]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_HoaDon] @MaHD nchar(10)
as
begin 
	delete from HoaDon where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_KhachHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_KhachHang] @MaKH nchar(10)
as
begin 
	delete from KhachHang where MaKH = @MaKH
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_LoaiHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_LoaiHang] @MaLH nchar(10)
as
begin 
	delete from LoaiHang where MaLH = @MaLH
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_NhanVien]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_NhanVien] @MaNV nchar(10)
as
begin 
	delete from NhanVien where MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_Taikhoan]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_Taikhoan] @MaTK nchar(10)
as
begin 
	delete from Taikhoan where MaTK = @MaTK
end 
GO
/****** Object:  StoredProcedure [dbo].[delete_The]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[delete_The] @Mathe nchar(10)
as
begin 
	delete from The where Mathe = @Mathe
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_CTHD]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_CTHD] @MaHD nchar(10), @MaHang nchar(10), @SL int 
as 
Begin 
	insert into CTHD values( @MaHD,@MaHang, @SL)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_DichVu]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_DichVu] @MaDV nchar(10), @TenDV nvarchar(255), @Ngay int, @Gia float 
as 
Begin 
	insert into DichVu values( @MaDV,@TenDV, @Ngay,@Gia)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_HangHoa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_HangHoa] @MaHang nchar(10), @TenHang nvarchar(255), @DVT nchar(20), @DonGia float, @SLCon int, @MaLH nchar(10) 
as 
Begin 
	insert into HangHoa values( @MaHang, @TenHang,@DVT, @DonGia,@SLCon, @MaLH )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_HoaDon]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_HoaDon] @MaHD nchar(10), @NgayHD date, @MaKH nchar(20), @MaNV nchar(10) 
as 
Begin 
	insert into HoaDon values( @MaHD, @NgayHD,@MaKH, @MaNV )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_KhachHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_KhachHang] @MaKH nchar(10), @TenKH nvarchar(255), @DiaChi nvarchar(255), @SDT nchar(20), @NgaySinh datetime, @GioiTinh bit, @GhiChu nvarchar(255), @avatar image, @Mathe nchar(10) 
as 
Begin 
	insert into KhachHang values( @MaKH, @TenKH,@DiaChi, @SDT,@NgaySinh,@GioiTinh,@GhiChu,@avatar,@Mathe )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_LoaiHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_LoaiHang] @MaLH nchar(10), @TenLH nvarchar(255), @GhiChu nvarchar(255) 
as 
Begin 
	insert into LoaiHang values( @MaLH, @TenLH,@GhiChu)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_NhanVien]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_NhanVien] @MaNV nchar(10), @TenNV nchar(10), @NgaySinh date, @GioiTinh bit, @DiaChi nvarchar(255), @SDT nchar(10) , @MaTK nchar(10)
as 
Begin 
	insert into NhanVien values( @MaNV, @TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SDT, @MaTK)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_Taikhoan]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Insert_Taikhoan] @MaTK nchar(10), @TenDN nchar(100), @Matkhau nchar(100), @Quyen int 
as 
Begin 
	insert into Taikhoan values( @MaTK, @TenDN,@Matkhau,@Quyen)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_The]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_The] @Mathe nchar(10), @NgayDK date, @MaDV nchar(10) 
as 
Begin 
	insert into The values( @Mathe, @NgayDK,@MaDV)
end 
GO
/****** Object:  StoredProcedure [dbo].[select_CTHD]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START CTHD --
create PROC [dbo].[select_CTHD]
as 
Begin 
	select * from CTHD 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_CTHDMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_CTHDMa] @MaHD nchar(10)
as 
Begin 
	select * from CTHD where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_DichVu]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START DICHVU --
create PROC [dbo].[select_DichVu]
as 
Begin 
	select * from DichVu 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_DichVu_TheByMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_DichVu_TheByMa] @Mathe nchar(10)
as 
Begin 
	select * from The as TH inner join DichVu as DV on DV.MaDV = TH.MaDV where TH.Mathe = @Mathe
end 
GO
/****** Object:  StoredProcedure [dbo].[select_DichVuMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_DichVuMa] @MaDV nchar(10)
as 
Begin 
	select * from DichVu where MaDV = @MaDV
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HangHoa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START Hanghoa --
create PROC [dbo].[select_HangHoa]
as 
Begin 
	select * from HangHoa 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HangHoaMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_HangHoaMa] @MaHang nchar(10)
as 
Begin 
	select * from HangHoa where MaHang = @MaHang
end 
GO
/****** Object:  StoredProcedure [dbo].[select_Hoadon]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START Hoadon --
create PROC [dbo].[select_Hoadon]
as 
Begin 
	select * from HoaDon 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_HoaDonMa] @MaHD nchar(10)
as 
Begin 
	select * from HoaDon where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_KhachHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START KhachHang --
create PROC [dbo].[select_KhachHang]
as 
Begin 
	select * from KhachHang 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_KhachHangMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_KhachHangMa] @MaKH nchar(10)
as 
Begin 
	select * from KhachHang where MaKH = @MaKH
end 
GO
/****** Object:  StoredProcedure [dbo].[select_LoaiHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START LoaiHang --
create PROC [dbo].[select_LoaiHang]
as 
Begin 
	select * from LoaiHang 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_LoaiHangMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_LoaiHangMa] @MaLH nchar(10)
as 
Begin 
	select * from LoaiHang where MaLH = @MaLH
end 
GO
/****** Object:  StoredProcedure [dbo].[select_NhanVien]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START LoaiHang --
create PROC [dbo].[select_NhanVien]
as 
Begin 
	select * from NhanVien 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_NhanVienMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_NhanVienMa] @MaNV nchar(10)
as 
Begin 
	select * from NhanVien where MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[select_Taikhoan]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START Taikhoan --
create PROC [dbo].[select_Taikhoan]
as 
Begin 
	select * from Taikhoan 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_TaikhoanMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_TaikhoanMa] @MaTK nchar(10)
as 
Begin 
	select * from Taikhoan where MaTK = @MaTK
end 
GO
/****** Object:  StoredProcedure [dbo].[select_The]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--START The --
create PROC [dbo].[select_The]
as 
Begin 
	select * from The 
end 
GO
/****** Object:  StoredProcedure [dbo].[select_TheMa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_TheMa] @Mathe nchar(10)
as 
Begin 
	select * from The where Mathe = @Mathe
end 
GO
/****** Object:  StoredProcedure [dbo].[update_CTHD]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[update_CTHD] @MaHD nchar(10), @MaHang nchar(10), @SL int
as 
Begin 
	update CTHD set  MaHang = @MaHang , SL = @SL where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[update_DichVu]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[update_DichVu] @MaDV nchar(10), @TenDV nvarchar(255), @Ngay int, @Gia float
as 
Begin 
	update DichVu set  TenDV = @TenDV , ThoiHan = @Ngay, Gia = @Gia where MaDV = @MaDV
end 
GO
/****** Object:  StoredProcedure [dbo].[update_HangHoa]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[update_HangHoa] @MaHang nchar(10), @TenHang nvarchar(255), @DVT nchar(20), @DonGia float, @SLCon int, @MaLH nchar(10)
as 
Begin 
	update HangHoa set  TenHang = @TenHang, DVT = @DVT, DonGia = @DonGia, SLCon = @SLCon, MaLH = @MaLH where MaHang = @MaHang
end 
GO
/****** Object:  StoredProcedure [dbo].[update_HoaDon]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[update_HoaDon] @MaHD nchar(10), @NgayHD date, @MaKH nchar(20), @MaNV nchar(10)
as 
Begin 
	update HoaDon set  NgayHD = @NgayHD, MaKH = @MaKH, MaNV = @MaNV where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[update_KhachHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[update_KhachHang] @MaKH nchar(10), @TenKH nvarchar(255), @DiaChi nvarchar(255), @SDT nchar(20), @NgaySinh date, @GioiTinh bit, @GhiChu nvarchar(255), @Avatar image
as 
Begin 
	update KhachHang set  TenKH = @TenKH, DiaChi = @DiaChi, SDT = @SDT, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, GhiChu = @GhiChu, Avatar = @Avatar where MaKH = @MaKH
end 
GO
/****** Object:  StoredProcedure [dbo].[update_LoaiHang]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[update_LoaiHang] @MaLH nchar(10), @TenLH nvarchar(255), @GhiChu nvarchar(255)
as 
Begin 
	update LoaiHang set  TenLH = @TenLH, GhiChu = @GhiChu where MaLH = @MaLH
end 
GO
/****** Object:  StoredProcedure [dbo].[update_NhanVien]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[update_NhanVien] @MaNV nchar(10), @TenNV nchar(10), @NgaySinh date, @GioiTinh bit, @DiaChi nvarchar(255), @SDT nchar(10),@MaTK nchar(10)
as 
Begin 
	update NhanVien set  TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT, MaTK = @MaTK where MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[update_Taikhoan]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[update_Taikhoan] @MaTK nchar(10), @TenDN nchar(100), @Matkhau nchar(100),@Quyen int 
as 
Begin 
	update Taikhoan set TenDN = @TenDN , Matkhau = @Matkhau where MaTK = @MaTK
end 
GO
/****** Object:  StoredProcedure [dbo].[update_The]    Script Date: 4/23/2019 2:32:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[update_The] @Mathe nchar(10), @NgayDK date, @MaDV nchar(10)  
as 
Begin 
	update The set   NgayDK = @NgayDK , MaDV = @MaDV where Mathe = @Mathe
end 
GO
