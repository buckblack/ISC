--1) Với mỗi đề án, liệt kê tên đề án (TENDA) và tổng số giờ làm việc một tuần của tất cả các nhân viên tham dự đề án đó. 
select d.TENDA,sum(p.THOIGIAN) as so_gio from DEAN d,PHANCONG p
where d.MADA=p.SODA
group by d.TENDA,d.MADA

select d.TENDA,sum(p.THOIGIAN) as so_gio from DEAN d join PHANCONG p on d.MADA=p.SODA
group by d.TENDA,d.MADA

--2) Với mỗi nhân viên, cho biết họ và tên nhân viên và nhân viên đó có  bao nhiêu nhân nhân
select n.HONV,n.TENNV,count(*) as so_nhan_than from NHANVIEN n,THANNHAN t
where n.MANV=t.MA_NVIEN
group by n.HONV,n.TENNV,n.MANV

select n.HONV,n.TENNV,count(t.TENTN) as so_nhan_than from NHANVIEN n left join THANNHAN t on n.MANV=t.MA_NVIEN
group by n.HONV,n.TENNV,n.MANV

--3) Với mỗi phòng ban, liệt kê tên phòng ban (TENPHG) và lương trung bình của những nhân viên làm việc cho phòng ban đó.
select p.TENPHG,avg(n.LUONG) as luong_TB from PHONGBAN p,NHANVIEN n
where p.MAPHG=n.PHG
group by p.TENPHG,p.MAPHG

select p.TENPHG,avg(n.LUONG) as luong_TB from PHONGBAN p join NHANVIEN n on p.MAPHG=n.PHG
group by p.TENPHG,p.MAPHG

--4) Lương trung bình của tất cả các nữ nhân viên
select avg(LUONG) as luong_TB from NHANVIEN
where PHAI='Nu'

--5) Với các phòng ban có mức lương trung bình trên 30,000, liệt kê tên phòng ban và số lượng nhân viên của phòng ban đó.
select p.MAPHG,p.TENPHG,AVG(LUONG) as Luong_TB,count(n.MANV) as so_nhan_vien from PHONGBAN p, NHANVIEN n
where p.MAPHG=n.PHG
group by p.MAPHG,p.TENPHG
having AVG(LUONG)>30000

/*
	1) Cho biết danh sách các đề án (MADA) có: 
	i.	nhân công với họ (HONV) là ‘Dinh’ hoặc , 
	ii.	có người trưởng phòng chủ trì đề án với họ (HONV) là ‘Dinh’.
*/
select p.SODA from PHANCONG p,NHANVIEN n
where p.MA_NVIEN=n.MANV and n.HONV='Dinh'
union
select p.SODA from PHANCONG p,NHANVIEN n, PHONGBAN ph
where p.MA_NVIEN=n.MANV and n.MANV=ph.TRPHG and n.HONV='Dinh'

--2) Danh sách những nhân viên (HONV, TENLOT, TENNV) có trên 2 thân nhân.
select * from NHANVIEN n
where n.MANV in
	(
		select t.MA_NVIEN from THANNHAN t
		group by t.MA_NVIEN
		having count(t.MA_NVIEN)>2
	)

select * from NHANVIEN n
where exists
	(
		select t.MA_NVIEN from THANNHAN t
		where t.MA_NVIEN=n.MANV
		group by t.MA_NVIEN
		having count(t.MA_NVIEN)>2
	)


--3) Danh sách những nhân viên (HONV, TENLOT, TENNV) không có thân nhân nào. 
select * from NHANVIEN n
where n.MANV not in
	(
		select t.MA_NVIEN from THANNHAN t
		group by t.MA_NVIEN
	)

select * from NHANVIEN n
where not exists
	(
		select t.MA_NVIEN from THANNHAN t
		where t.MA_NVIEN=n.MANV
		group by t.MA_NVIEN
	)

--4) Danh sách những trưởng phòng (HONV, TENLOT, TENNV) có tối thiểu một thân nhân.
select n.* from NHANVIEN n, PHONGBAN p
where p.TRPHG=n.MANV and n.MANV in
	(
		select t.MA_NVIEN from THANNHAN t
		group by t.MA_NVIEN
		having count(t.MA_NVIEN)>=1
	)

select * from NHANVIEN
where MANV in (select MA_NVIEN from THANNHAN)
and MANV in (select TRPHG from PHONGBAN)

select * from NHANVIEN
where exists (select MA_NVIEN from THANNHAN where MANV=MA_NVIEN)
and exists (select TRPHG from PHONGBAN where TRPHG=MANV)

--5)Tìm họ (HONV) của những trưởng phòng chưa có gia đình. 
select HONV from NHANVIEN
where MANV not in (select MA_NVIEN from THANNHAN where QUANHE='Vo Chong' and MANV=MA_NVIEN)
and MANV in (select p.TRPHG from PHONGBAN p where TRPHG=MANV)

select n.* from PHONGBAN p, NHANVIEN n
where n.MANV=p.TRPHG and not exists (select * from THANNHAN t where t.MA_NVIEN=n.MANV)

--6) Cho biết họ tên nhân viên (HONV, TENLOT, TENNV) có mức lương trên mức lương trung bình của phòng "Nghien cuu" 
select HONV,TENLOT,TENNV from NHANVIEN nv
where LUONG > (
				select AVG(LUONG) from NHANVIEN n,PHONGBAN p
				where n.PHG=p.MAPHG and p.TENPHG='Nghien cuu'
				)


--7) Cho biết tên phòng ban và họ tên trưởng phòng của phòng ban có đông nhân viên nhất.
select p.TENPHG,n.HONV,n.TENLOT,n.TENNV from PHONGBAN p, NHANVIEN n,
(select p.MAPHG,count(*) as so_luong from NHANVIEN n, PHONGBAN p
							where n.PHG=p.MAPHG
							group by p.MAPHG
							having count(*)>=all(select count(*) as so_luong from NHANVIEN n, PHONGBAN p
													where n.PHG=p.MAPHG
													group by p.MAPHG)
							) as tmp
where n.PHG=p.MAPHG and n.MANV=p.TRPHG and tmp.MAPHG=p.MAPHG


with temp as
(select nv.PHG,count(nv.MANV) as sl_nv from NHANVIEN nv group by nv.PHG)
select nv.HONV,nv.TENLOT,nv.TENNV from temp t1,NHANVIEN nv,PHONGBAN pb
where t1.sl_nv=(select max(t2.sl_nv) from temp t2) and nv.MANV=pb.TRPHG and t1.PHG=pb.MAPHG

--8) Tìm họ tên (HONV, TENLOT, TENNV) và địa chỉ (DCHI) của những nhân viên làm việc cho một đề án ở ‘TP HCM’  nhưng phòng ban mà họ trực thuộc lại không tọa lạc ở thành phố ‘TP HCM’.
select nv.HONV,nv.TENLOT,nv.TENNV,nv.DCHI from DEAN da,PHANCONG pc, NHANVIEN nv
where da.MADA=pc.SODA and nv.MANV=pc.MA_NVIEN and da.DDIEM_DA='TP HCM' 
and da.PHONG in (
				select ph.MAPHG from PHONGBAN ph, DIADIEM_PHG dd
				where ph.MAPHG=dd.MAPHG and dd.DIADIEM <> 'TP HCM'
				)


select nv.HONV,nv.TENLOT,nv.TENNV,nv.DCHI
from NHANVIEN nv join PHANCONG pc on pc.MA_NVIEN=nv.MANV join DEAN da on 
(da.MADA=pc.SODA and da.DDIEM_DA='TP HCM')
except
select nv.HONV,nv.TENLOT,nv.TENNV,nv.DCHI
from NHANVIEN nv join PHONGBAN pb on nv.PHG=pb.MAPHG
join DIADIEM_PHG dd on dd.MAPHG=pb.MAPHG and dd.DIADIEM='TP HCM'

--9) Tìm họ tên và địa chỉ của các nhân viên làm việc cho một đề án ở một thành phố nhưng phòng ban mà họ trực thuộc lại không toạ lạc ở thành phố đó.
select * from DEAN da,PHANCONG pc, NHANVIEN nv
where da.MADA=pc.SODA and nv.MANV=pc.MA_NVIEN
and nv.phg in (
				select ph.maphg from PHONGBAN ph, DIADIEM_PHG dd
				where ph.MAPHG=dd.MAPHG and dd.diadiem <> da.ddiem_da
				)






