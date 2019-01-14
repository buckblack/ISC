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

--14.	Tìm giáo viên (mã giáo viên, họ tên) không được phân công giảng dạy bất kỳ môn học nào thuộc khoa giáo viên đó phụ trách.
select * from GIAOVIEN gv
where gv.MAGV not in (
			select gd.MAGV from MONHOC mh, GIANGDAY gd
			where mh.MAMH=gd.MAMH and mh.MAKHOA = gv.MAKHOA
			)

			select * from MONHOC mh, GIANGDAY gd
			where mh.MAMH=gd.MAMH


