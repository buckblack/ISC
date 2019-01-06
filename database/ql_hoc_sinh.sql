create database ql_hoc_sinh
use ql_hoc_sinh
create table nam_hoc
(
	ma_nam_hoc int primary key identity,
	ten_nam_hoc nvarchar(30)
)
create table lop
(
	ma_lop int primary key identity,
	ten_lop nvarchar(30)
)
create table hoc_ky
(
	ma_hoc_ky int primary key identity,
	ten_hoc_ky nvarchar(30)
)
create table mon_hoc
(
	ma_mon_hoc int primary key identity,
	ten_mon_hoc nvarchar(30),
	so_tiet int
)
create table hoc_sinh
(
	ma_hoc_sinh int primary key identity,
	ma_nam_hoc int,
	ma_lop int,
	ho_ten nvarchar(50),
	ngay_sinh date,
	lien_lac nvarchar(100),
	thuong_tru nvarchar(100),
	phu_huynh nvarchar(50)
)

alter table hoc_sinh
add constraint FK_hs_namhoc foreign key(ma_nam_hoc) references nam_hoc(ma_nam_hoc)

alter table hoc_sinh
add constraint FK_hs_lop foreign key(ma_lop) references lop(ma_lop)

create table ket_qua_mon_hoc
(
	ma_ket_qua int primary key identity,
	ma_mon_hoc int,
	ma_hoc_sinh int,
	diem float
)
alter table ket_qua_mon_hoc
add constraint FK_kq_monhoc foreign key(ma_mon_hoc) references mon_hoc(ma_mon_hoc)

alter table ket_qua_mon_hoc
add constraint FK_hs_kq foreign key(ma_hoc_sinh) references hoc_sinh(ma_hoc_sinh)

create table tong_ket
(
	ma_so int primary key identity,
	ma_hoc_ky int,
	ma_hoc_sinh int,
	hanh_kiem nvarchar(20),
	DTB float,
	xep_loai nvarchar(20)
)

alter table tong_ket
add constraint FK_hk_tongket foreign key(ma_hoc_ky) references hoc_ky(ma_hoc_ky)

alter table tong_ket
add constraint FK_hs_tongket foreign key(ma_hoc_sinh) references hoc_sinh(ma_hoc_sinh)

insert into hoc_ky(ten_hoc_ky)
values(N'học kỳ 1'),(N'học kỳ 2'),(N'học kỳ 3')

insert into nam_hoc(ten_nam_hoc)
values(N'2015'),(N'2016'),(N'2017'),(N'2018'),(N'2019')

insert into lop(ten_lop)
values(N'12A1'),(N'12A2'),(N'12A3'),(N'12A4'),(N'12A5')

insert into mon_hoc(ten_mon_hoc,so_tiet)
values(N'Ngữ văn 12',60),(N'Hình học 12',30),(N'Đại số 12',45),(N'Sinh học 12',45),(N'Hóa học 12',45)

insert into hoc_sinh(ma_lop,ma_nam_hoc,ho_ten,ngay_sinh,thuong_tru,lien_lac,phu_huynh)
values(1,1,N'Nguyễn Văn A','1-1-1999',N'Hóc Môn',N'Hóc Môn',N'Nguyễn Văn B'),
	(2,1,N'Nguyễn Văn C','2-1-1999',N'Hóc Môn',N'Hóc Môn',N'Nguyễn Văn D'),
	(3,1,N'Nguyễn Văn E','3-2-1999',N'Hóc Môn',N'Hóc Môn',N'Nguyễn Văn F'),
	(4,2,N'Nguyễn Văn G','1-1-2000',N'Hóc Môn',N'Hóc Môn',N'Nguyễn Văn H'),
	(5,2,N'Nguyễn Văn K','1-2-2000',N'Hóc Môn',N'Hóc Môn',N'Nguyễn Văn M')

insert into ket_qua_mon_hoc(ma_mon_hoc,ma_hoc_sinh,diem)
values(1,1,8.5),(2,1,7.5),(1,2,8),(1,3,5.5),(1,5,5)

insert into tong_ket(ma_hoc_sinh,ma_hoc_ky,DTB,xep_loai,hanh_kiem)
values(1,1,8.3,N'Giỏi',N'Tốt'),
	(1,2,7.3,N'Khá',N'Tốt'),
	(2,1,8,N'Giỏi',N'Tốt'),
	(2,2,6,N'Trung bình',N'Khá'),
	(3,1,7.5,N'Khá',N'Tốt')
