--1.	In ra danh sách (mã học viên, họ tên, ngày sinh, mã lớp) lớp trưởng của các lớp.
select hv.MAHV,hv.HO,hv.TEN,hv.NGAYSINH,hv.MALOP from lop l join HOCVIEN hv on hv.MAHV=l.TRGLOP

select hv.MAHV,hv.HO,hv.TEN,hv.NGAYSINH,hv.MALOP 
from HOCVIEN hv
where hv.MAHV in (select TRGLOP from LOP)

select hv.MAHV,hv.HO,hv.TEN,hv.NGAYSINH,hv.MALOP 
from HOCVIEN hv
where exists (select * from LOP where hv.MAHV=TRGLOP)

--2.	In ra bảng điểm khi thi (mã học viên, họ tên , lần thi, điểm số) môn CTRR của lớp “K12”, sắp xếp theo tên, họ học viên.
select hv.MAHV,hv.HO,hv.TEN,kq.LANTHI,kq.DIEM
from HOCVIEN hv join KETQUATHI kq on hv.MAHV=kq.MAHV
where kq.MAMH='CTRR' and hv.MALOP='K12'
order by hv.TEN

select hv.MAHV,hv.HO,hv.TEN,kq.LANTHI,kq.DIEM
from HOCVIEN hv join KETQUATHI kq on hv.MAHV=kq.MAHV
where kq.MAMH='CTRR' and hv.MALOP='K12'
order by hv.TEN

--3. In ra danh sách những học viên (mã học viên, họ tên) và những môn học mà học viên đó thi lần thứ nhất đã đạt.
select hv.MAHV,hv.HO,hv.TEN,mh.TENMH
from HOCVIEN hv join KETQUATHI kq on hv.MAHV=kq.MAHV
join MONHOC mh on mh.MAMH=kq.MAMH
where kq.LANTHI=1 and kq.KETQUA='Dat'

--4.	In ra danh sách học viên (mã học viên, họ tên) của lớp “K11” thi môn CTRR không đạt (ở lần thi 1).
select hv.MAHV,hv.HO,hv.TEN
from HOCVIEN hv join KETQUATHI kq on hv.MAHV=kq.MAHV
where kq.MAMH='CTRR' and hv.MALOP='K11' and kq.LANTHI=1 and kq.KETQUA='Khong Dat'

--5.	* Danh sách học viên (mã học viên, họ tên) của lớp “K” thi môn CTRR không đạt (ở tất cả các lần thi).
select distinct hv.MAHV,hv.HO,hv.TEN
from HOCVIEN hv join KETQUATHI kq on hv.MAHV=kq.MAHV
where kq.MAMH='CTRR' and hv.MALOP like 'K%' and kq.KETQUA='Khong Dat' 
and hv.MAHV not in (select kq2.MAHV from KETQUATHI kq2 where kq2.MAMH='CTRR' and kq2.KETQUA='Dat')

--6.	Tìm tên những môn học mà giáo viên có tên “Tran Tam Thanh” dạy trong học kỳ 1 năm 2006
select mh.MAMH,mh.TENMH from MONHOC mh
where mh.MAMH in (
				select gd.MAMH from GIANGDAY gd
				where gd.HOCKY=1 and gd.NAMHOC=2006 and gd.MAGV = (select gv.MAGV from GIAOVIEN gv
				where gv.HOTEN='Tran Tam Thanh')
				)

--7.	Tìm những môn học (mã môn học, tên môn học) mà giáo viên chủ nhiệm lớp “K11” dạy trong học kỳ 1 năm 2006.
select mh.MAMH,mh.TENMH from MONHOC mh
where mh.MAMH in (
				select gd.MAMH from GIANGDAY gd
				where gd.HOCKY=1 and gd.NAMHOC=2006 and gd.MAGV in (select l.MAGVCN from lop l
				where l.MALOP='K11')
				)
--8.	Tìm họ tên lớp trưởng của các lớp mà giáo viên có tên “Nguyen To Lan” dạy môn “Co So Du Lieu”.
select hv.HO,hv.TEN from LOP l, HOCVIEN hv 
where l.TRGLOP=hv.MAHV 
and l.MALOP in (
			select gd.MALOP from GIANGDAY gd,GIAOVIEN gv, MONHOC mh
			where gd.MAGV=gv.MAGV and gd.MAMH=mh.MAMH and mh.TENMH='Co So Du Lieu' and gv.HOTEN='Nguyen To Lan'
			)

--9.	In ra danh sách những môn học (mã môn học, tên môn học) phải học liền trước môn “Co So Du Lieu”.
select mh.MAMH, mh.TENMH from MONHOC mh, DIEUKIEN dk
where dk.MAMH=mh.MAMH and dk.MAMH_TRUOC = (select mh2.MAMH from MONHOC mh2 where mh2.TENMH='Co So Du Lieu')

--10.	Môn “Cau Truc Roi Rac” là môn bắt buộc phải học liền trước những môn học (mã môn học, tên môn học) nào.
select mh.MAMH,mh.TENMH from DIEUKIEN dk,MONHOC mh 
where dk.MAMH=mh.MAMH and 
dk.MAMH_TRUOC=(select mh2.MAMH from MONHOC mh2 where mh2.TENMH='Cau Truc Roi Rac')

--11.	Tìm họ tên giáo viên dạy môn CTRR cho cả hai lớp “K11” và “K12” trong cùng học kỳ 1
select distinct gv.HOTEN from GIAOVIEN gv, GIANGDAY gd
where gv.MAGV=gd.MAGV and gd.HOCKY=1 and gd.MAMH='CTRR' and gd.NAMHOC=2006 and gd.MALOP in ('K11','K12')

--12 Tìm những học viên (mã học viên, họ tên) thi không đạt môn CSDL ở lần thi thứ 1 nhưng chưa thi lại môn này.
select * from KETQUATHI kq,HOCVIEN hv
where kq.MAHV=hv.MAHV and kq.LANTHI=1 and kq.KETQUA='Khong Dat' and kq.MAMH='CSDL'
and hv.MAHV not in (
			select kq2.MAHV from KETQUATHI kq2
			where kq2.LANTHI>1 and kq2.MAMH='CSDL'
			)
--13.	Tìm giáo viên (mã giáo viên, họ tên) không được phân công giảng dạy bất kỳ môn học nào.
select * from GIAOVIEN gv
where gv.MAGV not in
					(
						select gv.MAGV from GIANGDAY gv
					)

select gv.MAGV,gv.HOTEN from GIAOVIEN gv
left join GIANGDAY gd on gd.MAGV=gv.MAGV
where gd.MAGV is null

--14.***	Tìm giáo viên (mã giáo viên, họ tên) không được phân công giảng dạy bất kỳ môn học nào thuộc khoa giáo viên đó phụ trách.
select mh.MAKHOA,gv.MAGV,mh.MAMH 
from GIAOVIEN gv, GIANGDAY gd,MONHOC mh
where gd.MAGV=gv.MAGV and mh.MAMH=gd.MAMH
except
select distinct k.MAKHOA,gv.MAGV,mh.MAMH 
from khoa k, GIAOVIEN gv,MONHOC mh
where k.MAKHOA=gv.MAKHOA and k.MAKHOA=mh.MAKHOA

--****************************************
select distinct gv.MAGV,gv.HOTEN
from GIAOVIEN gv, GIANGDAY gd,MONHOC mh
where gd.MAGV=gv.MAGV and mh.MAMH=gd.MAMH
and gv.MAGV not in
		(
		select distinct gv2.MAGV 
		from khoa k2, GIAOVIEN gv2,MONHOC mh2
		where k2.MAKHOA=gv2.MAKHOA and k2.MAKHOA=mh2.MAKHOA
		and mh.MAKHOA=mh2.MAKHOA and mh.MAMH=mh2.MAMH
		)
--***************************************
select distinct gv.MAGV,gv.HOTEN
from GIAOVIEN gv, GIANGDAY gd,MONHOC mh
where gd.MAGV=gv.MAGV and mh.MAMH=gd.MAMH
and not exists
		(
		select distinct gv2.MAGV 
		from khoa k2, GIAOVIEN gv2,MONHOC mh2
		where k2.MAKHOA=gv2.MAKHOA and k2.MAKHOA=mh2.MAKHOA
		and mh.MAKHOA=mh2.MAKHOA and mh.MAMH=mh2.MAMH
		and gv.MAGV=gv2.MAGV
		)


--15.	Tìm họ tên các học viên thuộc lớp “K11” thi một môn bất kỳ quá 3 lần vẫn “Khong dat” hoặc thi lần thứ 2 môn CTRR được 5 điểm.
select * from HOCVIEN hv
where hv.MALOP='K11' and (hv.MAHV in (select mahv from
				(select kq.MAHV,kq.MAMH,count(*) as so_lan from KETQUATHI kq
				where kq.KETQUA='Khong Dat'
				group by kq.MAHV,kq.MAMH
				having count(*)>=3) tmp
				)) or hv.MAHV in (
								select kq2.MAHV from KETQUATHI kq2
								where kq2.MAMH='CTRR' and kq2.LANTHI=2 and kq2.DIEM=5
								)

--****************************************
select hv.MAHV,hv.HO,hv.TEN,kq.MAMH
from HOCVIEN hv
join KETQUATHI kq on hv.MAHV=kq.MAHV
where hv.MALOP='K11' and kq.KETQUA='Khong Dat'
group by hv.MAHV,hv.HO,hv.TEN,kq.MAMH
having count(kq.MAMH)>=3
union
select hv.MAHV,hv.HO,hv.TEN,kq.MAHV
from HOCVIEN hv
join KETQUATHI kq on hv.MAHV=kq.MAHV
where hv.MALOP='K11' and kq.KETQUA='CTRR'
and kq.LANTHI=2 and kq.DIEM=5


--16. Tìm họ tên giáo viên dạy môn CTRR cho ít nhất hai lớp trong cùng một học kỳ của một năm học.
select gv.MAGV,gv.HOTEN 
from GIAOVIEN gv,(
				select gd.MAMH,gd.MAGV,gd.HOCKY,gd.NAMHOC,count(*) as so_lop from GIANGDAY gd
				where gd.MAMH='CTRR'
				group by gd.MAMH,gd.MAGV,gd.HOCKY,gd.NAMHOC
				having COUNT(*)>=2) as tmp
where gv.MAGV=tmp.MAGV
--******************************************
select gv.MAGV,gv.HOTEN,gd.HOCKY,gd.NAMHOC from GIAOVIEN gv
join GIANGDAY gd on gv.MAGV=gd.MAGV
where gd.MAMH='CTRR'
group by gv.MAGV,gv.HOTEN,gd.HOCKY,gd.NAMHOC
having count(gd.MALOP)>=2


--17.	Danh sách học viên và điểm thi môn CSDL (chỉ lấy điểm của lần thi sau cùng).
select hv.MAHV,hv.HO,hv.TEN,kq1.DIEM,kq1.LANTHI from KETQUATHI kq1,HOCVIEN hv
where hv.MAHV=kq1.MAHV and kq1.LANTHI=(
				select MAX(kq2.LANTHI) from KETQUATHI kq2
				where kq1.MAHV=kq2.MAHV and kq1.MAMH=kq2.MAMH and kq2.MAMH='CSDL'
				)
--******************************************
select hv.MAHV,hv.HO,hv.TEN,kq1.DIEM,kq1.LANTHI from KETQUATHI kq1,HOCVIEN hv
where hv.MAHV=kq1.MAHV and kq1.MAMH='CSDL' and kq1.LANTHI>=all(
				select kq2.LANTHI from KETQUATHI kq2
				where kq1.MAHV=kq2.MAHV and kq2.MAMH='CSDL'
				)
--*******************************************
select hv.MAHV,hv.HO,hv.TEN,kq1.DIEM,kq1.LANTHI from KETQUATHI kq1,HOCVIEN hv,
	(
	select kq2.MAHV,kq2.MAMH,MAX(kq2.LANTHI) as lan_thi from KETQUATHI kq2
	where kq2.MAMH='CSDL'
	group by kq2.MAHV,kq2.MAMH
	) as tmp
where hv.MAHV=kq1.MAHV and kq1.LANTHI=tmp.lan_thi and tmp.MAHV=kq1.MAHV and tmp.MAMH=kq1.MAMH

--**************************************
select hv.MAHV,hv.HO,hv.TEN,kq.DIEM,kq.LANTHI
from HOCVIEN hv
join KETQUATHI kq on hv.MAHV=kq.MAHV
where kq.MAMH='CTRR'

--18. Danh sách học viên và điểm thi môn “Co So Du Lieu” (chỉ lấy điểm cao nhất của các lần thi).
select hv.HO,hv.TEN,kq1.DIEM from KETQUATHI kq1,HOCVIEN hv
where hv.MAHV=kq1.MAHV and kq1.DIEM=(
				select MAX(DIEM) from KETQUATHI kq2
				where kq1.MAHV=kq2.MAHV and kq1.MAMH=kq2.MAMH and kq2.MAMH=(select mh.mamh from MONHOC mh where mh.TENMH='Co So Du Lieu')
				)

--19.	Khoa nào (mã khoa, tên khoa) được thành lập sớm nhất.
select kh.MAKHOA,kh.TENKHOA from KHOA kh
where kh.NGAYTL=(select MIN(kh2.NGAYTL) from KHOA kh2)

--20.	Có bao nhiêu giáo viên có học hàm là “GS” hoặc “PGS”.
select COUNT(*) as so_luong from GIAOVIEN
where HOCHAM='GS' or HOCHAM='PGS'
--*******************************
select HOCHAM,COUNT(*) as so_luong from GIAOVIEN
where HOCHAM='GS' or HOCHAM='PGS'
group by HOCHAM
--*******************************
select sum(case when gv.HOCHAM='GS' then 1 end) GS,sum(case when gv.HOCHAM='PGS' then 1 end) PGS
from GIAOVIEN gv

--21.	Thống kê có bao nhiêu giáo viên có học vị là “CN”, “KS”, “Ths”, “TS”, “PTS” trong mỗi khoa.
select kh.MAKHOA,kh.TENKHOA, count(*) as so_luong from GIAOVIEN gv, KHOA kh
where gv.MAKHOA=kh.MAKHOA and gv.HOCVI in ('CN', 'KS', 'Ths', 'TS', 'PTS')
group by kh.MAKHOA,kh.TENKHOA
--******************************
select kh.MAKHOA,kh.TENKHOA,gv.HOCVI, count(*) as so_luong from GIAOVIEN gv, KHOA kh
where gv.MAKHOA=kh.MAKHOA and gv.HOCVI in ('CN', 'KS', 'Ths', 'TS', 'PTS')
group by kh.MAKHOA,kh.TENKHOA,gv.HOCVI
order by kh.MAKHOA

--22.	Mỗi môn học thống kê số lượng học viên theo kết quả (đạt và không đạt).
select kq.MAMH,mh.TENMH,kq.KETQUA,COUNT(*) as so_luong from monhoc mh,(select distinct kq2.MAHV,kq2.MAMH,kq2.KETQUA from KETQUATHI kq2) kq
where mh.MAMH=kq.MAMH
group by kq.MAMH,mh.TENMH,kq.KETQUA
order by kq.MAMH
--********************************************
select kq.MAMH,mh.TENMH, sum(case when kq.KETQUA='Dat' then 1 end) 'Dat',sum(case when kq.KETQUA='Khong Dat' then 1 end) 'Khong Dat' 
from monhoc mh,KETQUATHI kq
where mh.MAMH=kq.MAMH
group by kq.MAMH,mh.TENMH
order by kq.MAMH

--23.	Tìm giáo viên (mã giáo viên, họ tên) là giáo viên chủ nhiệm của một lớp, đồng thời dạy cho lớp đó ít nhất một môn học.
select gv.MAGV,gv.HOTEN from GIAOVIEN gv, LOP l
where l.MAGVCN=gv.MAGV
and exists (select * from GIANGDAY gd where gd.MAGV=l.MAGVCN and gd.MALOP=l.MALOP)

--24.	Tìm họ tên lớp trưởng của lớp có sỉ số cao nhất.
select hv.MAHV,hv.HO,hv.TEN  
from lop l join HOCVIEN hv on l.TRGLOP=hv.MAHV
where l.SISO>=all(select l1.siso from LOP l1)

--**********************************
select hv.MAHV,hv.HO,hv.TEN from LOP l,HOCVIEN hv
where l.TRGLOP=hv.MAHV and l.MALOP in (
								select hv2.MALOP from HOCVIEN hv2
								group by hv2.MALOP
								having count(*)>=all(select count(*) from HOCVIEN hv3
													group by hv3.MALOP)
								)
--***********************************
with temp
as(
	select hv.malop,count(hv.mahv) siso
	from HOCVIEN hv
	join KETQUATHI kq on hv.MAHV=kq.MAHV
	group by hv.MALOP
)
select hv.mahv,hv.ho,hv.ten
from temp
	join lop on lop.MALOP=temp.MALOP
	join HOCVIEN hv on hv.MAHV=LOP.TRGLOP
where temp.siso>=all(select temp1.siso from temp temp1)

select * from HOCVIEN hv, KETQUATHI kq
where hv.MAHV=kq.MAHV

--25.* Tìm họ tên những LOPTRG thi không đạt quá 3 môn (mỗi môn đều thi không đạt ở tất cả các lần thi).
select hv.MAHV,hv.HO,hv.TEN from LOP l,HOCVIEN hv
where l.TRGLOP=hv.MAHV and hv.MAHV=
								(
								select tmp.MAHV from (select distinct kq1.MAHV,kq1.MAMH  from KETQUATHI kq1
								where kq1.MAHV+kq1.MAMH not in (select kq2.MAHV+kq2.MAMH from KETQUATHI kq2
																where kq2.KETQUA='Dat')
								group by kq1.MAHV,kq1.MAMH) as tmp
								group by tmp.MAHV
								having count(*)>=3
								)

--**********************************
select hv.MAHV,hv.ho,hv.ten,l.MALOP
from lop l join HOCVIEN hv on l.TRGLOP=hv.MAHV


with tmp
as
(select kq.MAHV,kq.MAMH,count(kq.LANTHI) tong_lan_thi,
	sum(case when kq.KETQUA='Khong Dat' then 1 end) lanthi_khongdat
 from KETQUATHI kq
group by kq.MAHV,kq.MAMH
having count(kq.LANTHI)=sum(case when kq.KETQUA='Khong Dat' then 1 end)
)
select tmp.mahv from tmp
group by tmp.MAHV
having count(*)>=3


--26.	Tìm học viên (mã học viên, họ tên) có số môn đạt điểm 9,10 nhiều nhất.
select * from HOCVIEN hv
where hv.MAHV in (
				select kq.MAHV from KETQUATHI kq
				where kq.DIEM>=9
				group by kq.MAHV
				having count(*)>=all(select count(*) from KETQUATHI kq2
									where kq2.DIEM>=9
									group by kq2.MAMH)
				)

--27.	Trong từng lớp, tìm học viên (mã học viên, họ tên) có số môn đạt điểm 9,10 nhiều nhất.
select* from  HOCVIEN hv3
where hv3.MAHV in
(select hv.MAHV as so_mon from LOP l, HOCVIEN hv, KETQUATHI kq
where l.MALOP=hv.MALOP and kq.MAHV=hv.MAHV and kq.DIEM>=9 and l.MALOP=hv3.MALOP
group by l.MALOP,hv.MAHV
having COUNT(*)>=all(
					select count(*) as so_mon from LOP l, HOCVIEN hv, KETQUATHI kq
					where l.MALOP=hv.MALOP and kq.MAHV=hv.MAHV and kq.DIEM>=9 and l.MALOP=hv3.MALOP
					group by l.MALOP,hv.MAHV
					)
)

--28.	Trong  từng  học  kỳ  của  từng  năm,  mỗi  giáo  viên  phân  công  dạy  bao  nhiêu  môn  học,  bao nhiêu lớp.

select tmp1.MAGV,tmp1.HOCKY,tmp1.NAMHOC,tmp1.so_mon,tmp2.so_lop from
	(select tmp_gd.MAGV,tmp_gd.HOCKY,tmp_gd.NAMHOC,COUNT(*) as so_mon
	from 
	(select distinct gd2.MAGV,gd2.HOCKY,gd2.NAMHOC, gd2.MAMH from GIANGDAY gd2
	group by gd2.MAGV,gd2.HOCKY,gd2.NAMHOC, gd2.MAMH) as tmp_gd
	group by tmp_gd.MAGV,tmp_gd.HOCKY,tmp_gd.NAMHOC) as tmp1
,
	(select distinct gd2.MAGV,gd2.HOCKY,gd2.NAMHOC,COUNT(MALOP) as so_lop from GIANGDAY gd2
	group by gd2.MAGV,gd2.HOCKY,gd2.NAMHOC) as tmp2
where tmp1.HOCKY=tmp2.HOCKY and tmp1.MAGV=tmp2.MAGV and tmp1.NAMHOC=tmp2.NAMHOC

--**********************************************
select gd.HOCKY,gd.NAMHOC,gv.HOTEN,count(distinct gd.MAMH) sl_mh, count(distinct gd.MALOP) sl_lop
from GIAOVIEN gv join GIANGDAY gd on gv.MAGV=gd.MAGV
group by gd.HOCKY,gd.NAMHOC,gv.HOTEN


--29.**	Trong từng học kỳ của từng năm, tìm giáo viên (mã giáo viên, họ tên) giảng dạy nhiều nhất.????
select tmp1.MAGV,tmp1.HOCKY,tmp1.NAMHOC from 
	(select gv.MAGV,gv.NAMHOC,gv.HOCKY,count(gv.MAMH) as so_mon from GIANGDAY gv
	group by gv.MAGV,gv.NAMHOC,gv.HOCKY) as tmp1
	,
	(select NAMHOC,HOCKY,max(so_mon) as so_mon from
	(select gv.MAGV,gv.NAMHOC,gv.HOCKY,count(gv.MAMH) as so_mon from GIANGDAY gv
	group by gv.MAGV,gv.NAMHOC,gv.HOCKY) as tmp
	group by NAMHOC,HOCKY
	) as tmp2
where tmp1.HOCKY=tmp2.HOCKY and tmp1.NAMHOC=tmp2.NAMHOC and tmp1.so_mon=tmp2.so_mon

--******************************************
select gd.HOCKY,gd.NAMHOC,gv.HOTEN,count(distinct gd.MAMH) sl_mh, count(distinct gd.MALOP) sl_lop
from GIAOVIEN gv join GIANGDAY gd on gv.MAGV=gd.MAGV
group by gd.HOCKY,gd.NAMHOC,gv.HOTEN

--30.	Tìm môn học (mã môn học, tên môn học) có nhiều học viên thi không đạt (ở lần thi thứ 1) nhất.
select MAMH,TENMH from MONHOC where MAMH in
						(select kq.MAMH from KETQUATHI kq
						where kq.KETQUA='Khong Dat' and kq.LANTHI=1
						group by kq.MAMH
						having COUNT(*)>=all(select COUNT(*) from KETQUATHI kq
											where kq.KETQUA='Khong Dat' and kq.LANTHI=1
											group by kq.MAMH)
						)

--31.	Tìm học viên (mã học viên, họ tên) thi môn nào cũng đạt (chỉ xét lần thi thứ 1).
select hv.MAHV,hv.HO,hv.TEN from HOCVIEN hv
where hv.MAHV in
		(select kq.MAHV from KETQUATHI kq
		where kq.KETQUA='Dat' and kq.LANTHI=1 and kq.MAHV not in
									(select kq1.MAHV from KETQUATHI kq1
									where kq1.KETQUA='Khong Dat' and kq1.LANTHI=1)
		)

--32.	Tìm học viên (mã học viên, họ tên) thi môn nào cũng đạt (chỉ xét lần thi sau cùng).
select kq1.MAHV,kq1.MAMH,MAX(kq1.LANTHI) as lan_thi from KETQUATHI kq1
where kq1.KETQUA='Dat' and kq1.MAHV not in
							(
							select tmp.MAHV from
								(select kq2.MAHV,kq2.MAMH,MAX(kq2.LANTHI) as lan_thi from KETQUATHI kq2
								where kq2.KETQUA='Khong Dat'
								group by kq2.MAHV,kq2.MAMH) tmp
							)
group by kq1.MAHV,kq1.MAMH

--33.	Tìm học viên (mã học viên, họ tên) đã thi tất cả các môn đều đạt (chỉ xét lần thi thứ 1--).
select * from MONHOC
select distinct kq.MAHV,kq.MAMH from KETQUATHI kq
where kq
group by kq.MAHV,kq.MAMH

--34.	Tìm học viên (mã học viên, họ tên) đã thi tất cả các môn đều đạt  (chỉ xét lần thi sau cùng).


--35.	Tìm học viên (mã học viên, họ tên) có điểm thi cao nhất trong từng môn (lấy điểm ở lần thi sau cùng).

