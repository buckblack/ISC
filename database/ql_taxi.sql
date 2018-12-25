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

alter table tai_xe
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