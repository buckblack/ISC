--1
--2
select * from PhieuMuon p
where p.NgayMuon=CONVERT(date,'11/11/2018',105)

--3
select t.* from PhieuMuon p, TheDocGia t, Sach s
where p.MaTheDocGia=t.MaTheDocGia and s.MaSach=p.MaSach and NgayTra=null and s.TenSach=N'Đồ Hoạ Máy Tính'

--4
select t.HoTenDocGia,s.TenSach from PhieuMuon p, TheDocGia t, Sach s
where p.MaTheDocGia=t.MaTheDocGia and s.MaSach=p.MaSach and p.NgayTra!=null and DATEDIFF(DAY, p.NgayMuon, GETDATE())>10

--5
select * from Sach s
where s.MaSach not in (select p.MaSach from PhieuMuon p)

--6
select * from Sach s where s.MaSach in(
	select p.MaSach from PhieuMuon p 
	where MONTH(p.NgayMuon)=11 and YEAR(p.NgayMuon)=2018
	group by p.MaSach
	having COUNT(*)>=(
		select COUNT(*) from PhieuMuon p 
		where MONTH(p.NgayMuon)=11 and YEAR(p.NgayMuon)=2018
		group by p.MaSach
	)
)

--7
select * from TheDocGia t where t.MaTheDocGia in(
	select t.MaTheDocGia from PhieuMuon t
	group by t.MaTheDocGia
	having COUNT(*)>=10
)

--8
select s.TenTacGia from Sach s
where s.MaSach in (
	select p.MaSach from PhieuMuon p
	where YEAR(p.NgayMuon)=2018
	group by p.MaSach
	having COUNT(*)>=(
		select count(*) from PhieuMuon p
		where YEAR(p.NgayMuon)=2018
		group by p.MaSach
	)
)