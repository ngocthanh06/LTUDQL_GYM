USE [master]
GO
/****** Object:  Database [GYM]    Script Date: 6/8/2019 8:41:00 PM ******/
CREATE DATABASE [GYM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GYM', FILENAME = N'D:\SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GYM.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GYM_log', FILENAME = N'D:\SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\GYM_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [GYM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GYM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GYM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GYM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GYM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GYM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GYM] SET ARITHABORT OFF 
GO
ALTER DATABASE [GYM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GYM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GYM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GYM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GYM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GYM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GYM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GYM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GYM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GYM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GYM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GYM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GYM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GYM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GYM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GYM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GYM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GYM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GYM] SET  MULTI_USER 
GO
ALTER DATABASE [GYM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GYM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GYM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GYM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [GYM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GYM] SET QUERY_STORE = OFF
GO
USE [GYM]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [GYM]
GO
/****** Object:  Table [dbo].[CTHD]    Script Date: 6/8/2019 8:41:00 PM ******/
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
/****** Object:  Table [dbo].[DichVu]    Script Date: 6/8/2019 8:41:02 PM ******/
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
/****** Object:  Table [dbo].[HangHoa]    Script Date: 6/8/2019 8:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHang] [nchar](10) NOT NULL,
	[TenHang] [nvarchar](255) NULL,
	[DonGia] [float] NULL,
	[SLCon] [int] NULL,
	[MaLH] [nchar](10) NULL,
	[hinhanh] [image] NULL,
	[hansudung] [date] NULL,
	[ghichu] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 6/8/2019 8:41:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nchar](10) NOT NULL,
	[NgayHD] [date] NULL,
	[MaKH] [nchar](10) NULL,
	[MaNV] [nchar](10) NULL,
	[TongHoaDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/8/2019 8:41:02 PM ******/
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
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/8/2019 8:41:03 PM ******/
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
	[hinhanh] [image] NULL,
	[ghichu] [nvarchar](255) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Taikhoan]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Taikhoan](
	[MaTK] [nchar](10) NOT NULL,
	[TenDN] [nchar](50) NULL,
	[Matkhau] [nchar](50) NULL,
	[Quyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[The]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[The](
	[Mathe] [nchar](10) NOT NULL,
	[NgayDK] [date] NULL,
	[MaDV] [nchar](10) NULL,
	[MaKH] [nchar](10) NULL,
	[MaNV] [nchar](10) NULL,
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
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[Taikhoan] ([MaTK])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[The]  WITH CHECK ADD FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[The]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
/****** Object:  StoredProcedure [dbo].[delete_CTHD]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_DichVu]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_HangHoa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_HoaDon]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_KhachHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_LoaiHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_NhanVien]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_Taikhoan]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_The]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_CTHD]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_DichVu]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_HangHoa]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_HangHoa] @MaHang nchar(10), @TenHang nvarchar(255), @DonGia float, @SLCon int, @MaLH nchar(10), @hinhanh image, @hansudung date,@ghichu text  
as 
Begin 
	insert into HangHoa values( @MaHang, @TenHang, @DonGia, @SLCon, @MaLH, @hinhanh, @hansudung,@ghichu )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_HoaDon]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_HoaDon] @MaHD nchar(10), @NgayHD date, @MaKH nchar(20), @MaNV nchar(10), @TongHoaDon int 
as 
Begin 
	insert into HoaDon values( @MaHD, @NgayHD,@MaKH, @MaNV,@TongHoaDon )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_KhachHang]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_KhachHang] @MaKH nchar(10), @TenKH nvarchar(255), @DiaChi nvarchar(255), @SDT nchar(20), @NgaySinh datetime, @GioiTinh bit, @GhiChu nvarchar(255), @avatar image 
as 
Begin 
	insert into KhachHang values( @MaKH, @TenKH,@DiaChi, @SDT,@NgaySinh,@GioiTinh,@GhiChu,@avatar )
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_LoaiHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_NhanVien]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_NhanVien] @MaNV nchar(10), @TenNV nchar(10), @NgaySinh date, @GioiTinh bit, @DiaChi nvarchar(255), @SDT nchar(10) , @MaTK nchar(10), @hinhanh image, @ghichu nvarchar(255), @TrangThai bit
as 
Begin 
	insert into NhanVien values( @MaNV, @TenNV,@NgaySinh,@GioiTinh,@DiaChi,@SDT, @MaTK, @hinhanh,@ghichu,@TrangThai)
end 
GO
/****** Object:  StoredProcedure [dbo].[Insert_Taikhoan]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_The]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Insert_The] @Mathe nchar(10), @NgayDK date, @MaDV nchar(10), @MaKH nchar(10),@MaNV nchar(10) 
as 
Begin 
	insert into The values( @Mathe, @NgayDK,@MaDV,@MaKH,@MaNV)
end 
GO
/****** Object:  StoredProcedure [dbo].[select_CTHD]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_CTHDMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_DichVu]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_DichVu_TheByMa]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_DichVu_TheByMa] @Mathe nchar(10)
as 
Begin 
	select Mathe,DV.MaDV,TenDV,NgayDK,ThoiHan,Gia,MaKH,MaNV from The as TH inner join DichVu as DV on DV.MaDV = TH.MaDV where TH.Mathe = @Mathe
end 
GO
/****** Object:  StoredProcedure [dbo].[select_DichVuMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_HangHoa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_HangHoaMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_HangHoaMaLH]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[select_HangHoaMaLH] @MaLH nchar(10)
as 
Begin 
	select * from HangHoa where MaLH = @MaLH
end 
GO
/****** Object:  StoredProcedure [dbo].[select_Hoadon]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_HoaDonByMaNV]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonByMaNV] @MaNV nchar(10)
as 
Begin 
	select DISTINCT Hoadon.MaHD from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonByMaNVCBB]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[select_HoaDonByMaNVCBB] @MaNV nchar(10)
as 
Begin 
	select Hoadon.MaHD,MaHang,SL,NgayHD,MaKH,MaNV from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV
end
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonbyMonth]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonbyMonth] @Thang int, @nam int
as 
Begin 
	select * from HoaDon where Month(NgayHD) = @Thang and YEAR(NgayHD) = @nam
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_HoaDonMaHDvaMaNV]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonMaHDvaMaNV] @MaNV nchar(10),@MaHD nchar(10)
as 
Begin 
	select Hoadon.MaHD,MaHang,SL,NgayHD,MaKH,MaNV from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV and Hoadon.MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonMaHDvaMaNVbyday]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonMaHDvaMaNVbyday] @MaNV nchar(10),@MaHD nchar(10),@NgayHD date
as 
Begin 
	select DISTINCT Hoadon.MaHD from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV and Hoadon.MaHD = @MaHD and NgayHD = @NgayHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonMaNVbyday]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonMaNVbyday] @MaNV nchar(10), @NgayBD date, @NgayKT date
as 
Begin 
	select DISTINCT Hoadon.MaHD from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV and NgayHD between @NgayBD and @NgayKT
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonMaNVbyMonth]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDonMaNVbyMonth] @MaNV nchar(10), @Thang int, @nam int
as 
Begin 
	select DISTINCT Hoadon.MaHD from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD where MaNV = @MaNV and Month(NgayHD) = @Thang and YEAR(NgayHD) = @nam
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDonNVvaKH]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[select_HoaDonNVvaKH] @MaHD nchar(10)
as 
Begin 
	select TenNV, TenKH from NhanVien inner join HoaDon on NhanVien.MaNV = HoaDon.MaNV inner join KhachHang on KhachHang.MaKH = HoaDon.MaKH where MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_HoaDontimkiem]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_HoaDontimkiem] @MaHD nchar(10)
as 
Begin 
	select Hoadon.MaHD,TenHang,DonGia,SL,NgayHD,MaKH,MaNV,TongHoaDon from HoaDon inner join CTHD on HoaDon.MaHD = CTHD.MaHD inner join HangHoa on CTHD.MaHang = HangHoa.MaHang where Hoadon.MaHD = @MaHD
end 
GO
/****** Object:  StoredProcedure [dbo].[select_InHoaDon]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_InHoaDon] @MaHD nchar(10)
as 
Begin 
	select CTHD.MaHD,TenKH,TenNV, NgayHD, HH.MaHang,HH.MaLH,TenLH, SL, KH.MaKH,NV.MaNV, KH.DiaChi,KH.SDT,KH.NgaySinh,KH.GioiTinh,TenHang,DonGia
	from KhachHang as KH inner join HoaDon as HD on HD.MaKH = KH.MaKH
	inner join NhanVien as NV on HD.MaNV = NV.MaNV
	inner join CTHD on CTHD.MaHD = HD.MaHD 
	inner join HangHoa as HH on CTHD.MaHang = HH.MaHang
	inner join LoaiHang as LH on LH.MaLH = HH.MaLH
	where HD.MaHD = @MaHD 
	
	
end 
GO
/****** Object:  StoredProcedure [dbo].[select_KhachHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_KhachHangMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_LoaiHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_LoaiHangMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_LoginTK]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[select_LoginTK] @TenDN nchar(50),@MatKhau nchar(50)  
as 
Begin 
	select * from Taikhoan where TenDN = @TenDN and Matkhau = @MatKhau
end 
GO
/****** Object:  StoredProcedure [dbo].[select_NhanVien]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_NhanVienMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_NhanVienMaTK]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[select_NhanVienMaTK] @MaTK nchar(10)
as 
Begin 
	select * from NhanVien where MaTK = @MaTK
end 
GO
/****** Object:  StoredProcedure [dbo].[select_Taikhoan]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_TaikhoanMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_The]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[select_ThebyDichvuAll]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[select_ThebyDichvuAll]
as 
Begin 
	select Mathe, TenKH, TenDV, NgayDK, ThoiHan, Gia, TenNV from DichVu inner join The on The.MaDV = DichVu.MaDV inner join KhachHang on KhachHang.MaKH = The.MaKH inner join NhanVien on The.MaNV = NhanVien.MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[select_ThebyDichvuMaNV]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_ThebyDichvuMaNV] @MaNV nchar(10)
as 
Begin 
	select Mathe, TenKH, TenDV, NgayDK, ThoiHan, Gia, TenNV from DichVu inner join The on The.MaDV = DichVu.MaDV inner join KhachHang on KhachHang.MaKH = The.MaKH inner join NhanVien on The.MaNV = NhanVien.MaNV where The.MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[select_ThebyDichvuMaNVandMonthYear]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[select_ThebyDichvuMaNVandMonthYear] @MaNV nchar(10), @Thang int, @Nam int 
as 
Begin 
	select Mathe, TenKH, TenDV, NgayDK, ThoiHan, Gia, TenNV from DichVu inner join The on The.MaDV = DichVu.MaDV inner join KhachHang on KhachHang.MaKH = The.MaKH inner join NhanVien on The.MaNV = NhanVien.MaNV where The.MaNV = @MaNV and MONTH(NgayDK) = @Thang and YEAR(NgayDK) = @Nam
end 
GO
/****** Object:  StoredProcedure [dbo].[select_ThebyMaKH]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[select_ThebyMaKH] @MaKH nchar(10)
as 
Begin 
	select Mathe, TenKH,The.MaKH, TenDV, The.MaDV, NgayDK, ThoiHan, Gia, TenNV from DichVu inner join The on The.MaDV = DichVu.MaDV inner join KhachHang on KhachHang.MaKH = The.MaKH inner join NhanVien on The.MaNV = NhanVien.MaNV where The.MaKH = @MaKH
end 
GO
/****** Object:  StoredProcedure [dbo].[select_TheDichVubyMonth]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[select_TheDichVubyMonth] @Thang int, @nam int
as 
Begin 
	select * from The inner join Dichvu on The.MaDV = DichVu.MaDV where Month(NgayDK) = @Thang and YEAR(NgayDK) = @nam
end 
GO
/****** Object:  StoredProcedure [dbo].[select_TheMa]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_CTHD]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_DichVu]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_HangHoa]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[update_HangHoa] @MaHang nchar(10), @TenHang nvarchar(255), @DonGia float, @SLCon int, @MaLH nchar(10), @hinhanh image, @hansudung date,@ghichu text
as 
Begin 
	update HangHoa set  TenHang = @TenHang, DonGia = @DonGia, SLCon = @SLCon, MaLH = @MaLH,hinhanh = @hinhanh,hansudung = @hansudung, ghichu = @ghichu where MaHang = @MaHang
end 
GO
/****** Object:  StoredProcedure [dbo].[update_HoaDon]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_KhachHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_LoaiHang]    Script Date: 6/8/2019 8:41:03 PM ******/
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
/****** Object:  StoredProcedure [dbo].[update_NhanVien]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[update_NhanVien] @MaNV nchar(10), @TenNV nchar(10), @NgaySinh date, @GioiTinh bit, @DiaChi nvarchar(255), @SDT nchar(10), @hinhanh image,@ghichu nvarchar(255),@TrangThai bit
as 
Begin 
	update NhanVien set  TenNV = @TenNV, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SDT = @SDT, hinhanh = @hinhanh,ghichu = @ghichu,TrangThai = @TrangThai where MaNV = @MaNV
end 
GO
/****** Object:  StoredProcedure [dbo].[update_SLConHangHoa]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[update_SLConHangHoa] @MaHang nchar(10), @SLCon int
as 
Begin 
	update HangHoa set  SLCon = @SLCon where MaHang = @MaHang
end 
GO
/****** Object:  StoredProcedure [dbo].[update_Taikhoan]    Script Date: 6/8/2019 8:41:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[update_Taikhoan] @MaTK nchar(10), @TenDN nchar(100), @Matkhau nchar(100),@Quyen int 
as 
Begin 
	update Taikhoan set TenDN = @TenDN , Matkhau = @Matkhau, Quyen = @Quyen where MaTK = @MaTK
end 
GO
/****** Object:  StoredProcedure [dbo].[update_The]    Script Date: 6/8/2019 8:41:03 PM ******/
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
USE [master]
GO
ALTER DATABASE [GYM] SET  READ_WRITE 
GO
