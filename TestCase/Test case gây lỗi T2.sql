﻿USE HuongViet
GO

/*Người thực hiện: Nguyễn Thị Ngọc Hân, MSSV: 1712415, Mã nhóm: 8*/

--LỖI DIRTY READ
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ COMMITTED
SELECT SL_CONLAI FROM THUCDON WHERE MACN = 1 AND MAMON=1 AND NGAY='2019-30-11'
COMMIT

---LỖI UNREPEATABLE READ
BEGIN TRAN
UPDATE THUCDON SET SL_CONLAI= 150
WHERE MAMON = 1 AND MACN = 1 AND NGAY='2019-11-30'
COMMIT

--LỖI PHANTOM
BEGIN TRAN
INSERT INTO THANHVIEN
VALUES (1000, N'Thành Viên 1000', N'123456', N'321907808', CAST(N'1970-11-09' AS Date), N'Phường 10, Quận 4 TP.HCM', 1, N'thanhvien999@gmail.com', 13000000, N'Gold')
COMMIT

--LỖI LOST UPDATE
BEGIN TRAN
SELECT Sl FROM CHITIETDONHANG
WHERE MADH=1 AND MAMON=1

UPDATE CHITIETDONHANG
SET SL=( SELECT SL FROM CHITIETDONHANG WHERE MADH=1 AND MAMON=1)+1
WHERE MADH=1 AND MAMON=1
COMMIT

--LỖI DEADLOCK
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT Sl FROM CHITIETDONHANG
WHERE MADH=1 AND MAMON=1

UPDATE CHITIETDONHANG
SET SL=( SELECT SL FROM CHITIETDONHANG WHERE MADH=1 AND MAMON=1)+1
WHERE MADH=1 AND MAMON=1
COMMIT

/*Người thực hiện: Lai Gia Phú, MSSV: 1712662, Mã nhóm: 8*/

--Dirty Read
BEGIN TRAN
set tran isolation level READ UNCOMMITTED
EXEC sp_XemThucDon 1,'2019-01-01'
COMMIT TRAN

--Unrepeatable Read
BEGIN TRAN
EXEC sp_InDH null,null,1,N'Trực tiếp',N'Qua thẻ'
EXEC sp_InCTDH 1,1,5
COMMIT TRAN

--Phantom
BEGIN TRAN
EXEC sp_ThemMonThucDon 1,2,'2020-01-01',50,50
COMMIT TRAN

--Lost Update
BEGIN TRAN
EXEC sp_XemThucDon 1,'2020-01-01'
EXEC sp_CapNhatSoPhanAn 1,1,'2020-01-01',50,40
COMMIT TRAN

--Deadlock
BEGIN TRAN
EXEC sp_CapNhatSoPhanAn 2,1,'2019-01-01',50,30
Waitfor delay '00:00:10'
EXEC sp_XemThucDon 1,'2019-01-01'
COMMIT TRAN

/*Người thực hiện: Nguyễn Đoàn Tấn Phúc, MSSV: 1712671, Mã nhóm: 8*/

--Dirty Read
BEGIN TRAN
set tran isolation level READ UNCOMMITTED
EXEC sp_XemThucDon 1,'2020-01-01'
COMMIT TRAN

-- Unrepeatable Read
BEGIN TRAN
EXEC sp_XoaMonThucDon 1,2,'2020-01-01'
COMMIT TRAN

--Phantom
BEGIN TRAN
EXEC sp_InDH null,null,1,N'Trực tiếp',N'Qua thẻ'
EXEC sp_InCTDH 1,1,5
COMMIT TRAN

--Lost update
BEGIN TRAN
select * from THANHVIEN where MATV = 1
EXEC sp_UPTHETV3 1,1,3
COMMIT TRAN

--Deadlock
BEGIN TRAN
EXEC sp_ThemMonThucDon 2,1,'2019-01-02',50,50
Waitfor delay '00:00:10'
EXEC sp_XemThucDon 1,'2019-01-02'
COMMIT TRAN

/*Người thực hiện: Trịnh Đức Thanh, MSSV: 1712769, Mã nhóm: 8*/

--Lỗi 1: Dirty Read
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ UNCOMMITTED
SELECT * FROM MONAN
COMMIT

SELECT*FROM MONAN

--Lỗi 2: Unrepeatable
BEGIN TRAN
UPDATE THUCDON 
SET SL_CONLAI = 30 
WHERE MAMON = 1 AND MACN = 1
COMMIT

--Lỗi 3: Phantom
BEGIN TRAN
UPDATE THANHVIEN 
SET LOAITHE='Gold' 
WHERE MATV=23 
COMMIT

--Lỗi 4: Lost Update
BEGIN TRAN
SELECT SL_CONLAI
FROM THUCDON 
WHERE MAMON = 1 AND MACN = 1

UPDATE THUCDON 
SET SL_CONLAI =17 
WHERE MAMON = 1 AND MACN = 1
COMMIT

SELECT SL_CONLAI FROM THUCDON WHERE MAMON = 1 AND MACN = 1

--Lỗi 5: Deadlock
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT*FROM DONHANG 
WHERE MADH=3

UPDATE DONHANG 
SET HUYDON=1, TRANGTHAI=N'Đã hủy' 
WHERE MADH=3
COMMIT

/*Người thực hiện: Dương Khánh Vi, MSSV: 1712899, Mã nhóm: 8*/

-- Lỗi 1: Dirty Read
BEGIN TRAN
set tran isolation level Read Uncommitted
SELECT SL_CONLAI FROM THUCDON WHERE MACN = 1 AND MAMON = 1
GO

-- Lỗi 2: Unrepeatable Read
BEGIN TRAN
UPDATE THANHVIEN
SET DIACHI = N'390 CAO THẮNG, PHƯỜNG 12, QUẬN 10' WHERE MATV = 1
COMMIT
GO

-- Lỗi 3: Phantom
BEGIN TRAN
INSERT INTO THANHVIEN VALUES (10,N'ABC','1','3212532','1997-07-07',NULL,
2,'ABC@GMAIL.COM',NULL,N'SILVER')
COMMIT
GO

-- Lỗi 4: Lost Update
BEGIN TRAN
SELECT DIACHI FROM THANHVIEN WHERE MATV = 1
UPDATE THANHVIEN
SET DIACHI = N' 122, Nguyễn Văn Cừ, phường 10, quận 5, TPHCM' WHERE MATV = 1
COMMIT
GO

-- Lỗi 5: Deadlock
BEGIN TRAN
set tran isolation level SERIALIZABLE
SELECT DIACHI FROM THANHVIEN WHERE MATV = 1
UPDATE THANHVIEN
SET DIACHI = N' 122, Nguyễn Văn Cừ, phường 10, quận 5, TPHCM' WHERE MATV = 1
COMMIT
GO
