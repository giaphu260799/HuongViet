USE HuongViet
GO

/*Người thực hiện: Nguyễn Thị Ngọc Hân, MSSV: 1712415, Mã nhóm: 8*/

--LỖI DIRTY READ
--GIẢI PHÁP: SET CƠ CHẾ READ COMMITTED
BEGIN TRAN
UPDATE THUCDON
SET SL_CONLAI= 4 WHERE MACN = 1 AND MAMON=1 AND NGAY='2019-30-11'
waitfor delay'00:00:05'
ROLLBACK

--LỖI UNREPEATABLE READ
--GIẢI PHÁP:Set cơ chế khóa Repeatable Read
BEGIN TRAN
SET TRAN ISOLATION LEVEL REPEATABLE READ
SELECT SL_CONLAI FROM THUCDON WHERE MAMON = 1 AND MACN = 1 AND NGAY='2019-11-30'
waitfor delay'00:00:15'

--LỖI PHANTOM
--GIẢI PHÁP: SET CƠ CHẾ KHOÁ SERIALIZABLE
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT * FROM THANHVIEN WHERE CHINHANHDK=1
waitfor delay'00:00:15'

SELECT * FROM THANHVIEN WHERE CHINHANHDK=1
COMMIT

--LỖI LOST UPDATE
--GIẢI PHÁP: set cơ chế khoá SERIALIZABLE
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT SL FROM CHITIETDONHANG
WHERE MADH=1 AND MAMON=1
waitfor delay'00:00:05'

UPDATE CHITIETDONHANG SET SL=( SELECT SL FROM CHITIETDONHANG WHERE MADH=1 AND MAMON=1)+1
WHERE MADH=1 AND MAMON=1
COMMIT

--LỖI DEADLOCK
--GIẢI PHÁP: HUỶ 1 GIAO TÁC GÂY RA DEADLOCK


/*Người thực hiện: Lai Gia Phú, MSSV: 1712662, Mã nhóm: 8*/

--Dirty Read
--Sửa mức cô lập T2 thành READ COMMITTED
BEGIN TRAN
EXEC sp_CapNhatSoPhanAn 1,1,'2019-01-01',50,10
Waitfor delay '00:00:10'
ROLLBACK TRAN

--Unrepeatable Read
--Sửa: cài mức cô lập Repeeatable Read ở T1
BEGIN TRAN
set tran isolation level Repeatable Read
EXEC sp_XemThucDon 1,'2020-01-01'
Waitfor delay '00:00:10'
EXEC sp_XemThucDon 1,'2020-01-01'
COMMIT TRAN

--Phantom
--Sửa: mức cô lập Serializable ở T1
--EXEC sp_XoaMonThucDon 1,2,'2020-01-01'
set tran isolation level SERIALIZABLE
BEGIN TRAN
EXEC sp_XemThucDon 1,'2020-01-01'
Waitfor delay '00:00:10'
EXEC sp_XemThucDon 1,'2020-01-01'
COMMIT TRAN

--Lost Update
-- Sửa : mức cô lập REPEATABLE READ ở T1 và T2 
--lúc này SQL chọn T2 làm victim deadlock và bắt thưc hiện lại
--EXEC sp_CapNhatSoPhanAn 1,1,'2020-01-01',50,50
BEGIN TRAN
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
EXEC sp_XemThucDon 1,'2020-01-01'
Waitfor delay '00:00:10'
EXEC sp_CapNhatSoPhanAn 1,1,'2020-01-01',50,45
COMMIT TRAN

--Deadlock
--SQL chọn T2 là victim Deadlock và bắt thực hiện lại sau

/*Người thực hiện: Nguyễn Đoàn Tấn Phúc, MSSV: 1712671, Mã nhóm: 8*/

--Dirty Read
BEGIN TRAN
EXEC sp_ThemMonThucDon 1,2,'2020-01-01',50,50
Waitfor delay '00:00:10'
ROLLBACK TRAN

-- Unrepeatable Read
--Sửa: cài mức cô lập Repeeatable Read ở T1
BEGIN TRAN
set tran isolation level Repeatable Read
EXEC sp_XemThucDon 1,'2020-01-01'
Waitfor delay '00:00:10'
EXEC sp_XemThucDon 1,'2020-01-01'
COMMIT TRAN

--Phantom
--Sửa: mức cô lập Serializable ở T1
BEGIN TRAN
set tran isolation level SERIALIZABLE
EXEC sp_ThongKeTheoNgayCN 1
Waitfor delay '00:00:10'
EXEC sp_ThongKeTheoNgayCN 1
COMMIT TRAN

--Lost update
-- Sửa : mức cô lập Serializable ở T1 nhưng gặp Deadlock và thực hiện lại T2
BEGIN TRAN
set tran isolation level Serializable
select * from THANHVIEN where MATV = 1
Waitfor delay '00:00:10'
EXEC sp_UPTHETV3 1,1,2
COMMIT TRAN

select * from THANHVIEN where MATV = 1

--Deadlock
--SQL chọn T2 là victim Deadlock và bắt thực hiện lại sau

/*Người thực hiện: Trịnh Đức Thanh, MSSV: 1712769, Mã nhóm: 8*/

--Lỗi 1: Dirty Read
BEGIN TRAN
UPDATE MONAN 
SET GIATIEN=25000 
WHERE MAMON=2
Waitfor delay '00:00:20'
ROLLBACK

--Lỗi 2: Unrepeatable
BEGIN TRAN
SET TRAN ISOLATION LEVEL REPEATABLE READ
SELECT SL_CONLAI 
FROM THUCDON 
WHERE MAMON = 1 AND MACN = 1
waitfor delay'00:00:20'

SELECT SL_CONLAI
FROM THUCDON 
WHERE MAMON = 1 AND MACN = 1
COMMIT

--Lỗi 3: Phantom
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT * FROM THANHVIEN 
WHERE LOAITHE='Gold' AND CHINHANHDK=1
waitfor delay'00:00:20'

SELECT * FROM THANHVIEN 
WHERE LOAITHE='Gold' AND CHINHANHDK=1
COMMIT

--Lỗi 4: Lost Update
BEGIN TRAN
SET TRAN ISOLATION LEVEL REPEATABLE READ
SELECT SL_CONLAI 
FROM THUCDON 
WHERE MAMON = 1 AND MACN = 1
waitfor delay'00:00:20'

UPDATE THUCDON 
SET SL_CONLAI =19 
WHERE MAMON = 1 AND MACN = 1
COMMIT

--Lỗi 5: Deadlock
BEGIN TRAN
SET TRAN ISOLATION LEVEL SERIALIZABLE
SELECT*FROM DONHANG 
WHERE MADH=3
waitfor delay '00:00:20'

UPDATE DONHANG 
SET TRANGTHAI=N'Đang chuẩn bị' 
WHERE MADH=3
COMMIT

/*Người thực hiện: Dương Khánh Vi, MSSV: 1712899, Mã nhóm: 8*/

-- Giải pháp lỗi 1: Dirty Read
--T1 không thay đổi

--Giải pháp Lỗi 2: Unrepeatable Read
BEGIN TRAN
set tran isolation level REPEATABLE READ
SELECT * FROM THANHVIEN WHERE MATV = 1 
waitfor delay '00:00:15'
SELECT * FROM THANHVIEN WHERE MATV = 1 
COMMIT
GO

--Giải pháp lỗi 3: Phantom
BEGIN TRAN
set tran isolation level SERIALIZABLE
SELECT * FROM THANHVIEN WHERE CHINHANHDK = 2
waitfor delay '00:00:10'
SELECT * FROM THANHVIEN WHERE CHINHANHDK = 2
COMMIT

--Giải pháp lỗi 4: Lost Update
BEGIN TRAN
set tran isolation level SERIALIZABLE
SELECT DIACHI FROM THANHVIEN WHERE MATV = 1
waitfor delay '00:00:10'
UPDATE THANHVIEN
SET DIACHI = N'Khu đô thị Sala, phường 3, quận 2, TPHCM' WHERE MATV = 1
COMMIT

--Giải pháp lỗi 5: Deadlock
--Chạy lại các giao tác T1 và T2
--T1 không thay đổi