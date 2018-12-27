create database ql_taxi

create table thanh_pho
(
	ma_thanh_pho int primary key,
	ten_thanh_pho nvarchar(100)
)

create table chi_nhanh
(
	ma_chi_nhanh int primary key,
	ten_chi_nhanh nvarchar(50),
	ma_thanh_pho int,
)

alter table chi_nhanh
add constraint FK_chi_nhanh_TP foreign key(ma_thanh_pho) references thanh_pho(ma_thanh_pho)

create table tai_xe
(
	ma_tai_xe int primary key,
	ma_chi_nhanh int,
	ten_tai_xe nvarchar(50),
	dien_thoai char(11),
	dia_chi nvarchar(250)
)

alter table tai_xe
add constraint FK_chi_nhanh_tai_xe foreign key(ma_chi_nhanh) references chi_nhanh(ma_chi_nhanh)

create table xe
(
	ma_xe int primary key,
	ma_chi_nhanh int,
	hieu_xe nvarchar(50),
	so_cho int
)

alter table xe
add constraint FK_chi_nhanh_xe foreign key(ma_chi_nhanh) references chi_nhanh(ma_chi_nhanh)

create table phan_cong
(
	ma_phan_cong int primary key,
	ma_tai_xe int,
	ma_xe int,
	ngay_giao date,
	so_gio_lai int,
	so_ngay int,
	gio_qui_dinh int
)

alter table phan_cong
add constraint FK_phan_cong_tai_xe foreign key(ma_tai_xe) references tai_xe(ma_tai_xe)

alter table phan_cong
add constraint FK_phan_cong_xe foreign key(ma_xe) references xe(ma_xe)

insert into thanh_pho(ma_thanh_pho,ten_thanh_pho)
values (1,N'Hồ Chí Minh'),(2,N'Hà Nội'),(3,N'Đà Nẵng')

insert into chi_nhanh(ma_chi_nhanh,ten_chi_nhanh,ma_thanh_pho)
values (1,N'Chi nhánh số 1',1),(2,N'Chi nhánh số 2',1),(3,N'Chi nhánh số 3',2)

insert into xe(ma_xe,ma_chi_nhanh,hieu_xe,so_cho)
values (1,1,N'Audi',7),(2,1,N'Audi',4),(3,2,N'Ford',7)

insert into tai_xe(ma_tai_xe,ma_chi_nhanh,ten_tai_xe,dien_thoai,dia_chi)
values (1,1,N'Hồ Minh Tiến','012345679',N'Hồ Chí Minh'),
	(2,1,N'Lưu Quang Bình','0123456654',N'Hồ Chí Minh'),
	(3,3,N'Trần Anh Khoa','0123987654',N'Hồ Chí Minh')

insert into phan_cong(ma_phan_cong,ma_tai_xe,ma_xe,ngay_giao,so_gio_lai,so_ngay,gio_qui_dinh)
values (1,1,1,'12-27-2018',1000,1200,1300),
	(2,2,2,'12-28-2018',1100,1300,1400),
	(3,3,3,'12-29-2018',1200,1400,1500)

select * from phan_cong
