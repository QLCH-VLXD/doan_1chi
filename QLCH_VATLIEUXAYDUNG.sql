﻿CREATE DATABASE QL_CH_VATLIEUXAYDUNG
GO
use QL_CH_VATLIEUXAYDUNG
GO

CREATE TABLE CHUCVU
(
	MACHUCVU NVARCHAR(50) NOT NULL,
	TENCV NVARCHAR(100),
	--LUONG FLOAT
	PRIMARY KEY(MACHUCVU)
)

CREATE TABLE NHANVIEN
(
	MANV  NVARCHAR(50) NOT NULL,
	HOTENNV NVARCHAR(100),
	MACHUCVU NVARCHAR(50),
	NGAYSINH DATE,
	GIOITINH NVARCHAR(10),
	SOCMND NVARCHAR(15),
	SDT NVARCHAR(11),
	EMAIL NVARCHAR(100),
	DIACHI NVARCHAR(100),
	TINHTRANG NVARCHAR(100),
	NGAYVAOLAM DATE,
	PRIMARY KEY (MANV)
);
ALTER TABLE NHANVIEN
 ADD HINH IMAGE;

CREATE TABLE TAIKHOAN
(
	MANV  NVARCHAR(50) NOT NULL,
	MATKHAU NVARCHAR(10),
	HOATDONG BIT,
	PRIMARY KEY (MANV)
);

CREATE TABLE NHOMNGUOIDUNG
(
	MANHOM  NVARCHAR(50) NOT NULL,
	TENNHOM NVARCHAR(100),
	GHICHU NVARCHAR(100) NOT NULL,
	PRIMARY KEY (MANHOM)
);

CREATE TABLE NGUOIDUNGNHOMNGUOIDUNG
(
	MANV  NVARCHAR(50) NOT NULL,
	MANHOM NVARCHAR(50) NOT NULL,
	GHICHU NVARCHAR(100) NOT NULL,
	PRIMARY KEY (MANV,MANHOM)
);

CREATE TABLE MANHINH
(
	MAMANHINH  NVARCHAR(50) NOT NULL,
	TENMANHINH NVARCHAR(100) NOT NULL,
	PRIMARY KEY (MAMANHINH)
);

CREATE TABLE PHANQUYEN
(
	MAMANHINH  NVARCHAR(50) NOT NULL,
	MANHOM NVARCHAR(50) NOT NULL,
	COQUYEN BIT,
	PRIMARY KEY (MAMANHINH,MANHOM)
);

CREATE TABLE LOAIKHACHHANG
(
	MALOAIKH  NVARCHAR(50) NOT NULL,
	TENLOAIKH NVARCHAR(100),		--(KH THÂN THIẾT, VIP, THƯỜNG)
	PRIMARY KEY (MALOAIKH)
);

CREATE TABLE KHACHHANG
(
	MAKH  NVARCHAR(50) NOT NULL,
	MALOAIKH NVARCHAR(50) ,
	HOTENKH NVARCHAR(100),
	SDT NVARCHAR(11),
	DIACHI NVARCHAR(100),
	PRIMARY KEY (MAKH)
);

CREATE TABLE NHASANXUAT
(
	MANSX NVARCHAR(50) NOT NULL,
	TENNSX NVARCHAR(100),
	SDT NVARCHAR(11),
	EMAIL NVARCHAR(100),
	DIACHI NVARCHAR(200),
	PRIMARY KEY (MANSX)
);


CREATE TABLE CHITIETNHASANXUAT
(
	MANSX NVARCHAR(50) NOT NULL,
	MAMATHANG NVARCHAR(50) ,
	PRIMARY KEY (MANSX,MAMATHANG)
);

CREATE TABLE LOAIMATHANG
(
	MALOAIMATHANG NVARCHAR(50) NOT NULL,
	TENLOAIMATHANG NVARCHAR(100),		--(GẠCH, CÁT, KÍNH, XI MĂNG, NGÓI, SƠN, KEO, TÔN,.....)
	PRIMARY KEY (MALOAIMATHANG)
);

CREATE TABLE DONVITINH
(
	MADVT NVARCHAR(50) NOT NULL,
	TENDVT NVARCHAR(100),		--(KHỐI, MÉT, BAO, THÙNG, KG,.....)
	PRIMARY KEY (MADVT)
);

CREATE TABLE MATHANG
(
	MAMATHANG NVARCHAR(50) NOT NULL,
	TENMATHANG NVARCHAR(100),
	MALOAIMATHANG NVARCHAR(50),
	MANSX NVARCHAR(50),
	MADVT NVARCHAR(50),
	SOLUONG INT,
	TINHTRANG NVARCHAR(100),
	GHICHU NVARCHAR(100),
	PRIMARY KEY (MAMATHANG)	
);

 ALTER TABLE MATHANG
 ADD HANMUCHETHANG INT;
 ALTER TABLE MATHANG
 ADD XUATXU NVARCHAR(50);

CREATE TABLE CHITIETMATHANG
(
	MACHITIETMATHANG NVARCHAR(50) NOT NULL,
	MAMATHANG NVARCHAR(50),
	MAPN NVARCHAR(50),
	NGAYSANXUAT DATE,
	NGAYHETHAN DATE,
	PRIMARY KEY (MACHITIETMATHANG)	
);

CREATE TABLE DONGIA
(
	MADONGIA NVARCHAR(50) NOT NULL,
	MAMATHANG NVARCHAR(50),
	GIA MONEY,		--(ĐƠN GIÁ CẬP NHẬT LIỆN TỤC, THAY ĐỔI THEO GIỜ, NGÀY)
	NGAYAPDUNG DATE,
	NGAYKETTHUC DATE,
	PRIMARY KEY (MADONGIA)	
);

CREATE TABLE PHIEUDATHANGNSX
(
	MAPDHNSX NVARCHAR(50) NOT NULL,
	MANSX NVARCHAR(50),
	MANV NVARCHAR(50),
	NGAYLAP DATETIME,
	TONGTIENHANGDAT MONEY,
	TINHTRANGHANG NVARCHAR(100),
	SOTIENTRATRUOC MONEY,
	HOANTAT BIT,
	PRIMARY KEY(MAPDHNSX)

);




CREATE TABLE CTPHIEUDATHANGNSX
(
	MACTPHIEUDATHANG NVARCHAR(50) NOT NULL,
	MAPDHNSX NVARCHAR(50),
	MAMATHANG NVARCHAR(50),
	SOLUONG INT,
	GIA MONEY,
	THANHTIEN MONEY,
	PRIMARY KEY(MACTPHIEUDATHANG)
);

CREATE TABLE PHIEUNHAPHANG
(
	MAPN NVARCHAR(50) NOT NULL,
	MANV NVARCHAR(50),
	MANSX NVARCHAR(50),
	NGAYNHAP DATE,
	SOLUONGMATHANG INT,
	TONGTIENHANGNHAP MONEY,
	TINHTRANG NVARCHAR(100),
	PRIMARY KEY (MAPN)
);

CREATE TABLE CHITIETPHIEUNHAPHANG
(
	MACTPN NVARCHAR(50) NOT NULL,
	MAPN NVARCHAR(50),
	--(là khóa ngoại,có thể nhập hàng nhiều lần)
	MACTPHIEUDATHANG NVARCHAR(50),
	SOLUONGMH INT,
	THANHTIENCTPNH MONEY,
	PRIMARY KEY(MACTPN)
);
ALTER TABLE CHITIETPHIEUNHAPHANG
 ADD NGAYSX DATE;
 ALTER TABLE CHITIETPHIEUNHAPHANG
 ADD NGAYHH DATE;


CREATE TABLE HOADONBAN
(
	MAHDB NVARCHAR(50) NOT NULL,
	MANV NVARCHAR(50),
	MAKH  NVARCHAR(50),
	NGAYLAP DATE,
	TONGSLSANPHAM INT,
	TONGTIEN MONEY,
	TINHTRANG NVARCHAR(50),
	PRIMARY KEY (MAHDB)	
);

CREATE TABLE CHITIETHOADONBAN
(
	MACTHDB NVARCHAR(50) NOT NULL,
	MAHDB NVARCHAR(50) ,
	MAMATHANG NVARCHAR(50) ,
	SOLUONGBAN INT,
	--MADGHANG NVARCHAR(10) NOT NULL,
	THANHTIEN MONEY,
	PRIMARY KEY (MACTHDB)	
);

CREATE TABLE GIAOHANG
(
	MAGIAOHANG NVARCHAR(50)  NOT NULL,

	MANVGIAOHANG NVARCHAR(50),
	NGAYGIOGIAOHANG DATETIME,
	SOLUONGGIAO INT,
	TONGTIENHANGGIAO MONEY,
	TINHTRANG NVARCHAR(100),
	PRIMARY KEY(MAGIAOHANG)
);

CREATE TABLE CHITIETGIAOHANG
(
	MACTGIAOHNAG NVARCHAR(50)  NOT NULL,
	MAGIAOHANG NVARCHAR(50),
	MACTHDB NVARCHAR(50),
	SOLUONGMH INT,
	THANHTIEN MONEY,
	PRIMARY KEY(MACTGIAOHNAG)

);


CREATE TABLE THONGKE
(
	MATK NVARCHAR(50)  NOT NULL,
	THANG DATE,
	PRIMARY KEY(MATK)
);

CREATE TABLE TKHANGSAPHET
(
	MATKHANGSAPHET NVARCHAR(50)  NOT NULL,
	MATK NVARCHAR(50) ,
	MAMATHANG NVARCHAR(50),
	SOLUONGSAPHET INT,
	GHICHU NVARCHAR(200),
	PRIMARY KEY(MATKHANGSAPHET)
);

CREATE TABLE TKHANGTONKHO
(
	MATKHANGTONKHO NVARCHAR(50)  NOT NULL,
	MATK NVARCHAR(50) ,
	MAMATHANG NVARCHAR(50),
	SOLUONGTONKHO INT,
	GHICHU NVARCHAR(200),
	PRIMARY KEY(MATKHANGTONKHO)
);


------------------------------------------------------------KHÓA NGOẠI----------------------------------------------------------
--ALTER TABLE NHANVIEN
--ADD FOREIGN KEY(MACHUCVU)REFERENCES CHUCVU(MACHUCVU)

--ALTER TABLE TAIKHOAN
--ADD FOREIGN KEY(MANV)REFERENCES NHANVIEN(MANV)

--ALTER TABLE NGUOIDUNGNHOMNGUOIDUNG
--ADD FOREIGN KEY(MANV)REFERENCES NHANVIEN(MANV),
--	FOREIGN KEY(MANHOM)REFERENCES NHOMNGUOIDUNG(MANHOM)

--ALTER TABLE PHANQUYEN
--ADD FOREIGN KEY(MAMANHINH)REFERENCES MANHINH(MAMANHINH),
--	FOREIGN KEY(MANHOM)REFERENCES NHOMNGUOIDUNG(MANHOM)

--ALTER TABLE KHACHHANG
--ADD FOREIGN KEY(MALOAIKH)REFERENCES LOAIKHACHHANG(MALOAIKH)

--ALTER TABLE CHITIETNHASANXUAT
--ADD FOREIGN KEY(MANSX)REFERENCES NHASANXUAT(MANSX),
--	FOREIGN KEY(MAMATHANG)REFERENCES MATHANG(MAMATHANG)

--ALTER TABLE MATHANG
--ADD FOREIGN KEY(MALOAIMATHANG)REFERENCES LOAIMATHANG(MALOAIMATHANG),
--	FOREIGN KEY(MANSX)REFERENCES NHASANXUAT(MANSX),
--	FOREIGN KEY(MADVT)REFERENCES DONVITINH(MADVT)

--ALTER TABLE CHITIETMATHANG
--ADD FOREIGN KEY(MAMATHANG)REFERENCES MATHANG(MAMATHANG),
--	FOREIGN KEY(MAPN)REFERENCES PHIEUNHAPHANG(MAPN)

--ALTER TABLE DONGIA
--ADD FOREIGN KEY(MAMATHANG)REFERENCES MATHANG(MAMATHANG)

--ALTER TABLE PHIEUDATHANGNSX
--ADD FOREIGN KEY(MANV)REFERENCES NHANVIEN(MANV),
--	FOREIGN KEY(MANSX)REFERENCES NHASANXUAT(MANSX)

--ALTER TABLE CTPHIEUDATHANGNSX
--ADD FOREIGN KEY(MAPDHNSX)REFERENCES PHIEUDATHANGNSX(MAPDHNSX),
--	FOREIGN KEY(MAMATHANG)REFERENCES MATHANG(MAMATHANG)

--ALTER TABLE PHIEUNHAPHANG
--ADD FOREIGN KEY(MANV)REFERENCES NHANVIEN(MANV),
--	FOREIGN KEY(MANSX)REFERENCES NHASANXUAT(MANSX)

--ALTER TABLE CHITIETPHIEUNHAPHANG
--ADD FOREIGN KEY(MAPN)REFERENCES PHIEUNHAPHANG(MAPN),
--	FOREIGN KEY(MACTPHIEUDATHANG)REFERENCES CTPHIEUDATHANGNSX(MACTPHIEUDATHANG)

--ALTER TABLE HOADONBAN
--ADD FOREIGN KEY(MANV)REFERENCES NHANVIEN(MANV),
--	FOREIGN KEY(MAKH)REFERENCES KHACHHANG(MAKH)

--ALTER TABLE CHITIETHOADONBAN
--ADD FOREIGN KEY(MAHDB)REFERENCES HOADONBAN(MAHDB),
--	FOREIGN KEY(MAMATHANG)REFERENCES MATHANG(MAMATHANG)

--ALTER TABLE GIAOHANG
--ADD 
--	FOREIGN KEY(MANVGIAOHANG)REFERENCES NHANVIEN(MANV)

--ALTER TABLE CHITIETGIAOHANG
--ADD FOREIGN KEY(MAGIAOHANG)REFERENCES GIAOHANG(MAGIAOHANG),
--	FOREIGN KEY(MACTHDB)REFERENCES CHITIETHOADONBAN(MACTHDB)

----------------------------------DEFAULT--------------------------
--ALTER TABLE DONGIA
--ADD CONSTRAINT NGAY_AD DEFAULT (CONVERT (DATE,GETDATE(),120) ) FOR NGAYAPDUNG

--ALTER TABLE PHIEUDATHANGNSX
--ADD CONSTRAINT NGAY_LAP DEFAULT (CONVERT (DATE,GETDATE(),120) ) FOR NGAYLAP

--ALTER TABLE PHIEUNHAPHANG
--ADD CONSTRAINT NGAY_NHAP DEFAULT (CONVERT (DATE,GETDATE(),120) ) FOR NGAYNHAP

--ALTER TABLE HOADONBAN
--ADD CONSTRAINT NGAY_LAPHD DEFAULT (CONVERT (DATE,GETDATE(),120) ) FOR NGAYLAP
--------------------------------------------------TRIGEER----------------------------------------------------------

--- TỰ SINH MÃ 
create FUNCTION SINHMA_HDN()
RETURNS NVARCHAR(30)
AS
	BEGIN
	DECLARE @MHD NVARCHAR(100)
	SET @MHD=CONVERT(NVARCHAR(10),MONTH(GETDATE()))+CONVERT(NVARCHAR(10),DAY(GETDATE()))+REPLACE(((CONVERT(NVARCHAR(10),(GETDATE()),108))),':','')
	RETURN @MHD
END

--- nhap sdt ra tên khách hàng
create FUNCTION XEM_TENKH(@MKH NVARCHAR(10))
RETURNS NVARCHAR(50)
AS
	BEGIN
		DECLARE @HT NVARCHAR(50)
		SET @HT=(SELECT HOTENKH FROM KHACHHANG WHERE SDT LIKE '%'+@MKH+'%')
		RETURN @HT
END

--XEM TEN MAT HANG CÓ GỢI Ý 
CREATE FUNCTION XEMTEN_MH(@MMH NVARCHAR(10))
RETURNS TABLE
AS
	RETURN (SELECT * FROM MATHANG WHERE MATHANG.TENMATHANG LIKE '%'+@MMH+'%')
GO

--- cộng dồn tong so luong san pham
CREATE TRIGGER TONG_SLSP
ON CHITIETHOADONBAN
FOR INSERT, UPDATE, DELETE
AS
	BEGIN
		UPDATE HOADONBAN 
		SET TONGSLSANPHAM = TONGSLSANPHAM +1
		WHERE HOADONBAN.MAHDB = (SELECT MAHDB FROM inserted)
	END

--tu sinh ma don gia
CREATE FUNCTION SINHMA_DG()
RETURNS NVARCHAR(30)
AS
	BEGIN
	DECLARE @DG NVARCHAR(100)
	SET @DG=CONVERT(NVARCHAR(10),DAY(GETDATE()))+REPLACE(((CONVERT(NVARCHAR(10),(GETDATE()),108))),':','')
	RETURN @DG
END

--- nhap maNV ra tên nhân viên
CREATE FUNCTION XEM_TENNV(@MNV NVARCHAR(10))
RETURNS NVARCHAR(50)
AS
	BEGIN
		DECLARE @MN NVARCHAR(50)
		SET @MN=(SELECT HOTENNV FROM NHANVIEN WHERE MANV LIKE '%'+@MNV+'%')
		RETURN @MN
END

--


--- mat hang
---- so luong  >= 0
--CREATE TRIGGER SOLUONG_LON_BANG_0
--ON MATHANG
--FOR INSERT, UPDATE
--AS
--	BEGIN
--		IF(SELECT SOLUONG FROM inserted) < 0
--			ROLLBACK TRAN
--	END

---- CHI TIET MAT HANG
----NGAYSX SAU NGAYHETHAN
--CREATE TRIGGER NGAY_SX_HH
--ON CHITIETMATHANG
--FOR INSERT, UPDATE
--AS
--	BEGIN
--			IF(SELECT NGAYSANXUAT FROM inserted) > (SELECT NGAYHETHAN FROM inserted)
--			ROLLBACK TRAN
--	END

------DONGIA
-----NGAYAPDUNG SAU NGAYKETTHUC
--CREATE TRIGGER NGAY_AP_KT
--ON DONGIA
--FOR INSERT, UPDATE
--AS
--	BEGIN
--			IF(SELECT NGAYAPDUNG FROM inserted) > (SELECT NGAYKETTHUC FROM inserted)
--			ROLLBACK TRAN
--	END
--- GIA LỚN HƠN 0
--CREATE TRIGGER GIA_LON_0
--ON DONGIA
--FOR INSERT, UPDATE
--AS
--	BEGIN
--		IF(SELECT GIA FROM inserted) < 0
--			ROLLBACK TRAN
--	END

------PHIEUDATHANGNSX
-----TONGTIENHANGDAT ,SOTIENTRATRUOC LỚN HƠN 0
--CREATE TRIGGER LON_0
--ON PHIEUDATHANGNSX
--FOR INSERT, UPDATE
--AS
--	BEGIN
--		IF(SELECT TONGTIENHANGDAT FROM inserted) > 0
--			BEGIN
--				IF(SELECT SOTIENTRATRUOC FROM inserted) < 0
--				ROLLBACK TRAN
--			END
--		ELSE
--			BEGIN
--				ROLLBACK TRAN
--			END
--	END

--XEM TEN MAT HANG CÓ GỢI Ý 
CREATE FUNCTION gomnhom()
RETURNS TABLE
AS
	RETURN (SELECT MACTPHIEUDATHANG, SUM(SOLUONGMH) as"tongsl" FROM CHITIETPHIEUNHAPHANG GROUP BY MACTPHIEUDATHANG)
GO

-------------------------------------------------------------NHẬP LIỆU------------------------------------------------------------
INSERT INTO  CHUCVU
VALUES	('CV01',N'Quản lý'),
		('CV02',N'Nhân viên')


SET DATEFORMAT DMY
INSERT INTO  NHANVIEN
VALUES	('NV01',N'Trần Văn Minh','CV01','12/06/1976',N'Nam','123456789','0976123456','vanminh123@gmail.com',N'140 Lê Trọng Tấn','Đang làm','20/11/2010',''),
		('NV02',N'Vũ Hương Giang','CV02','01/01/1988',N'Nữ','987654321','0123456789','huonggiang@gmail.com',N'12 Lê Văn Sĩ','Đang làm','13/08/2013',''),
		('NV03',N'Đỗ Hoàng Mỹ','CV02','29/03/1996',N'Nữ','567843219','0324567912','hoangmy996@gmail.com',N'85 Cộng Hòa','Đang làm','17/04/2018',''),
		('NV04',N'Nguyễn Công Thành','CV02','06/06/1993',N'Nam','897364521','0745344922','abc123@gmail.com',N'347 Hoàng Văn Thụ','Đang làm','04/04/2019',''),
		('NV05',N'Đào Ánh Mai','CV02','06/01/1997',N'Nữ','567843319','0324567212','anhmai994@gmail.com',N'85 Lê Trọng Tấn','Đang làm','17/01/2017',''),
		('NV06',N'Nguyễn Ánh Nguyệt','CV02','23/05/1994',N'Nam','899364521','0745544922','xyz123@gmail.com',N'347 Hoàng Văn Thụ','Đang làm','23/08/2018','')

INSERT INTO  TAIKHOAN
VALUES	('NV01','123','True'),
		('NV02','123','True'),
		('NV03','123','True'),
		('NV04','123','false')

INSERT INTO  NGUOIDUNGNHOMNGUOIDUNG
VALUES	('NV01','NND01',' ')

INSERT INTO  NHOMNGUOIDUNG
VALUES	('NND01','ADMIN',' '),
		('NND02','USER',' ')


INSERT INTO  MANHINH
VALUES	('MH01',N'nhap hang'),
		('MH02',N'ban hang'),
		('MH03',N'danh muc hang hoa'),
		('MH04',N'don gia'),
		('MH05',N'thong ke'),
		('MH06',N'khach hang'),
		('MH07',N'nhan vien'),
		('MH08',N'nha san xuat'),
		('MH09',N'doi mat khau'),
		('MH10',N'dang xuat'),
		('MH11',N'phan quyen')
INSERT INTO  PHANQUYEN
VALUES	('MH01','NND01',1),
		('MH02','NND01',1),
		('MH03','NND01',1),
		('MH04','NND01',1),
		('MH05','NND01',1),
		('MH06','NND01',1),
		('MH07','NND01',1),
		('MH08','NND01',1),
		('MH09','NND01',1),
		('MH10','NND01',1),
		('MH11','NND01',1)

INSERT INTO  LOAIKHACHHANG
VALUES	('LKH001', N'Khách hàng thân thiết'),
		('LKH002', N'Khách hàng Vip'),
		('LKH003', N'Khách hàng thường')


INSERT INTO  KHACHHANG
VALUES	(N'KH01', N'LKH001', N'Nguyễn Kim Chi', N'0923456765', N'123,Tân Kì Tân Quý, Quận Tân Phú,Hồ Chí Minh'),
		(N'KH02', N'LKH001', N'Nguyễn Hoài Phương', N'09234344765', N'123,Bình Long, Quận Tân Phú,Hồ Chí Minh'),
		(N'KH03', N'LKH002', N'Nguyễn Minh Phát', N'0921236765', N'123,abc, Quận Đống Đa,Hà Nội'),
		(N'KH04', N'LKH003', N'Nguyễn Nhật Ân', N'0363456765', N'112,Lê Trọng Tấn, Quận 12,Hồ Chí Minh')


INSERT INTO  NHASANXUAT
VALUES	('NSX01',N'Công ty TNHH Sản xuất thương mại và dịch vụ thép Quốc Việt','090763267',N'ctythepquocviet@gmail.com',N'52 Tây Thạnh, Phường 15, Tân Phú, Hồ Chí Minh'),
		('NSX02',N'Công Ty TNHH Thương Mại Sản Xuất Tân Hoàng Thiên Bảo','080543267',N'ctyhtb@gmail.com',N'12 Bình Giã, Phường 13, Tân Bình, Hồ Chí Minh'),
		('NSX03',N'Tổng Công Ty Vật Liệu Xây Dựng Số 1 - FiCO','080547267',N'ctyFico@gmail.com',N'Sailing Tower, 111 A Pasteur, Bến Nghé, Quận 1, Bến Nghé Quận 1 Thành phố Hồ Chí Minh'),
		('NSX04',N'Công Ty TNHH Sản Xuất Thương Mại Dịch Vụ Xây Dựng Trung Thành Lợi','036832267',N'ctytrungthanhloi@gmail.com',N'309, Tân Kỳ Tân Quý, Phường Tân Sơn Nhì, Quận Tân Phú, Thành Phố Hồ Chí Minh')


INSERT INTO  CHITIETNHASANXUAT
VALUES	('NSX01','MH01'),
		('NSX02','MH02'),
		('NSX03','MH03'),
		('NSX04','MH04')

INSERT INTO  LOAIMATHANG
VALUES	('LMH01',N'Gạch'),
		('LMH02',N'Xi Măng'),
		('LMH03',N'Tôn'),
		('LMH04',N'Ngói')

INSERT INTO  DONVITINH
VALUES	('DVT01',N'Mét'),
		('DVT02',N'Bao'),
		('DVT03',N'kg'),
		('DVT04',N'Khối')

SET DATEFORMAT DMY
INSERT INTO  MATHANG
VALUES	('MH01',N'Gạch Men','LMH01','NSX01',N'DVT01','200',N'còn hàng','null',5, N'Việt Nam')
--		('MH02',N'Xi Măng LT','LMH02','NSX02',N'DVT01','300',N'còn hàng','null'),
--		('MH03',N'Tôn Fico','LMH03','NSX03',N'DVT01','450',N'còn hàng','null'),
--		('MH04',N'Ngói xanh','LMH04','NSX04',N'DVT01','0',N'hết hàng','null')


SET DATEFORMAT DMY
INSERT INTO  CHITIETMATHANG
VALUES	('CTMH01','MH01','PN01','22/03/2011','22/03/2020')
		--('CTMH02','MH02','PN02','14/12/2011','12/06/2020'),
		--('CTMH03','MH03','PN03','05/03/2011','17/09/2020'),
		--('CTMH04','MH04','PN04','09/01/2011','27/04/2020')


SET DATEFORMAT DMY
INSERT INTO  DONGIA
VALUES	('DG01','MH01','200000','22/03/2011','22/03/2020')
		--('DG02','MH02','500000','14/12/2011','12/06/2020'),
		--('DG03','MH03','350000','05/03/2011','17/09/2020'),
		--('DG04','MH04','100000','09/01/2011','27/04/2020')


SET DATEFORMAT DMY
INSERT INTO  PHIEUDATHANGNSX
VALUES	('PDHNSX01','NSX01','NV06','22/07/2019','40000000',N'còn hàng','20000000','')
		--('PDHNSX02','NSX02','NV06','23/05/2019','15000000',N'còn hàng','5000000'),
		--('PDHNSX03','NSX03','NV06','09/09/2019','20000000',N'còn hàng','15000000'),
		--('PDHNSX04','NSX04','NV06','25/08/2019','5000000',N'còn hàng','2500000')

INSERT INTO  CTPHIEUDATHANGNSX
VALUES	('CTPDHNSX01','PDHNSX01','MH01','100','40000000','4000000000')
		--('CTPDHNSX02','PDHNSX02','MH02','200','15000000','3000000000'),
		--('CTPDHNSX03','PDHNSX03','MH03','150','20000000','300000000'),
		--('CTPDHNSX04','PDHNSX04','MH04','300','5000000','1500000000')

SET DATEFORMAT DMY
INSERT INTO  PHIEUNHAPHANG
VALUES	('PN01','NV05','NSX01','21/01/2020','200','3000000',N'Còn hàng')
		--('PN02','NV05','NSX02','12/09/2020','300','45000000',N'Còn hàng'),
		--('PN03','NV05','NSX03','27/08/2020','150','2000000',N'Còn hàng'),
		--('PN04','NV05','NSX04','19/02/2020','450','10000000',N'Hết hàng')

SET DATEFORMAT DMY
INSERT INTO  CHITIETPHIEUNHAPHANG
VALUES	('CTPN01','PN01','CTPDHNSX01','200','3000000','22/03/2011','22/03/2019')
		--('CTPN02','PN02','CTPDHNSX02','300','45000000'),
		--('CTPN03','PN03','CTPDHNSX03','150','2000000'),
		--('CTPN04','PN04','CTPDHNSX04','450','10000000')

SET DATEFORMAT DMY
INSERT INTO  HOADONBAN
VALUES	('HD01','NV05','KH01','12/04/2019','300','3200000','null')
		--('HD02','NV05','KH02','17/02/2019','400','57000000','null'),
		--('HD03','NV05','KH03','23/09/2019','130','22400000','null'),
		--('HD04','NV05','KH04','19/02/2019','170','1300000','null')

INSERT INTO  CHITIETHOADONBAN
VALUES	('CTHDB01','HD01','MH01','2','3200000')
		--('CTHDB02','HD02','MH02','3','57000000'),
		--('CTHDB03','HD03','MH03','1','22400000'),
		--('CTHDB04','HD04','MH04','5','1300000')


SET DATEFORMAT DMY
INSERT INTO  GIAOHANG
VALUES	('GH01','NV04','12/04/2019','300','3200000','đang giao')
		--('GH02','NV04','17/02/2019','400','57000000','đang giao'),
		--('GH03','NV04','23/09/2019','130','22400000','đã giao'),
		--('GH04','NV04','19/02/2019','170','1300000','đang giao')

INSERT INTO  CHITIETGIAOHANG
VALUES	('CTGH01','GH01','CTHDB01','300','3200000')
		--('CTGH02','GH02','CTHDB02','400','57000000'),
		--('CTGH03','GH03','CTHDB03','130','22400000'),
		--('CTGH04','GH04','CTHDB04','170','1300000')

INSERT INTO  THONGKE
VALUES ('TK1','01/01/2020'),
		('TK2','01/02/2020')


INSERT INTO  TKHANGSAPHET
VALUES ('TKSH1','TK1','MH01','10','')
		


INSERT INTO  TKHANGTONKHO
VALUES ('TKTK','TK2','MH01','10','')