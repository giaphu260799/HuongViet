USE HuongViet
GO

/*Người thực hiện: Nguyễn Thị Ngọc Hân, MSSV: 1712415, Mã nhóm: 8*/

--LỖI DIRTY READ
--GIẢI PHÁP: SET CƠ CHẾ READ COMMITTED
BEGIN TRAN
SELECT SL_CONLAI 
FROM THUCDON 
WHERE MACN = 1 AND MAMON=1 AND NGAY='2019-30-11'
COMMIT

--LỖI UNREPEATABLE READ
--GIẢI PHÁP:Set cơ chế khóa Repeatable Read
BEGIN TRAN
UPDATE THUCDON SET SL_CONLAI= 150
WHERE MAMON = 1 AND MACN = 1 AND NGAY='2019-11-30'
COMMIT

--LỖI PHANTOM
--GIẢI PHÁP: SET CƠ CHẾ KHOÁ SERIALIZABLE
BEGIN TRAN
INSERT INTO THANHVIEN 
VALUES (1000, N'Thành Viên 1000', N'123456', N'321907808', CAST(N'1970-11-09' AS Date), N'Phường 10, Quận 4 TP.HCM', 1, N'thanhvien999@gmail.com', 13000000, N'Gold')
COMMIT

--LỖI LOST UPDATE
--GIẢI PHÁP: set cơ chế khoá SERIALIZABLE
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT Sl FROM CHITIETDONHANG
WHERE MADH=1 AND MAMON=1

UPDATE CHITIETDONHANG
SET SL=( SELECT SL FROM CHITIETDONHANG WHERE MADH=1 AND MAMON=1)+1
WHERE MADH=1 AND MAMON=1
COMMIT

--LỖI DEADLOCK
--GIẢI PHÁP: HUỶ 1 GIAO TÁC GÂY RA DEADLOCK


/*Người thực hiện: Lai Gia Phú, MSSV: 1712662, Mã nhóm: 8*/

--Dirty Read
--Sửa mức cô lập T2 thành READ COMMITTED
BEGIN TRAN
set tran isolation level READ COMMITTED
EXEC sp_XemThucDon 1,'2019-01-01'
COMMIT TRAN

--Unrepeatable Read
--Sửa: cài mức cô lập Repeeatable Read ở T1
BEGIN TRAN
EXEC sp_InDH null,null,1,N'Trực tiếp',N'Qua thẻ'
EXEC sp_InCTDH 1,1,5
COMMIT TRAN

--Phantom
--Sửa: mức cô lập Serializable ở T1
--EXEC sp_XoaMonThucDon 1,2,'2020-01-01'
BEGIN TRAN
EXEC sp_ThemMonThucDon 1,2,'2020-01-01',50,50
COMMIT TRAN

--Lost Update
-- Sửa : mức cô lập REPEATABLE READ ở T1 và T2 
--lúc này SQL chọn T2 làm victim deadlock và bắt thưc hiện lại
--EXEC sp_CapNhatSoPhanAn 1,1,'2020-01-01',50,50
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
EXEC sp_XemThucDon 1,'2020-01-01'
EXEC sp_CapNhatSoPhanAn 1,1,'2020-01-01',50,40
COMMIT TRAN

--Deadlock
--SQL chọn T2 là victim Deadlock và bắt thực hiện lại sau

/*Người thực hiện: Nguyễn Đoàn Tấn Phúc, MSSV: 1712671, Mã nhóm: 8*/

--Dirty Read
--Sửa mức cô lập T2 thành READ COMMITTED
BEGIN TRAN
set tran isolation level READ COMMITTED
EXEC sp_XemThucDon 1,'2020-01-01'
COMMIT TRAN

-- Unrepeatable Read
--Sửa: cài mức cô lập Repeeatable Read ở T1
BEGIN TRAN
EXEC sp_XoaMonThucDon 1,2,'2020-01-01'
COMMIT TRAN

--Phantom
--Sửa: mức cô lập Serializable ở T1
BEGIN TRAN
EXEC sp_InDH null,null,1,N'Trực tiếp',N'Qua thẻ'
EXEC sp_InCTDH 1,1,5
COMMIT TRAN

--Lost update
-- Sửa : mức cô lập Serializable ở T1 nhưng gặp Deadlock và thực hiện lại T2
BEGIN TRAN
select * from THANHVIEN where MATV = 1
EXEC sp_UPTHETV3 1,1,3
COMMIT TRAN

--Deadlock
--SQL chọn T2 là victim Deadlock và bắt thực hiện lại sau

/*Người thực hiện: Trịnh Đức Thanh, MSSV: 1712769, Mã nhóm: 8*/

--Lỗi 1: Dirty Read
BEGIN TRAN
SET TRAN ISOLATION LEVEL READ COMMITTED
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
SET TRAN ISOLATION LEVEL REPEATABLE READ
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

-- Giải pháp lỗi 1: Dirty Read
BEGIN TRAN
set tran isolation level READ COMMITTED
SELECT SL_CONLAI FROM THUCDON WHERE MACN = 1 AND MAMON = 1
COMMIT
GO

--Giải pháp Lỗi 2: Unrepeatable Read
--T2 không thay đổi

--Giải pháp lỗi 3: Phantom
--T2 không thay đổi

--Giải pháp lỗi 4: Lost Update
BEGIN TRAN
set tran isolation level SERIALIZABLE
SELECT DIACHI FROM THANHVIEN WHERE MATV = 1
UPDATE THANHVIEN
SET DIACHI = N' 122, Nguyễn Văn Cừ, phường 10, quận 5, TPHCM' WHERE MATV = 1
COMMIT
GO

--Giải pháp lỗi 5: Deadlock
--Chạy lại các giao tác T1 và T2
--T1 không thay đổi