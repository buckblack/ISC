import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { getLocaleMonthNames } from '@angular/common';
export interface HoaDonInfo {
  id: number;
  ngaydat: Date;
  trangthai: boolean;
  ghichu: string;
  nhanVien: NhanVienInfo;
  ban: BanInfo;
  khachHang: KhachHangInfo;
  tongtien: number;
}
export interface LoaimonanInfo {
  id: number;
  tenloai: string;
}
export interface MonAnInfo {
  id: number;
  tenmonan: string;
  dongia: number;
  hinhanh: string;
  trangthai: string;
  noidung: string;
  loaiMonAn: LoaimonanInfo;
}
export interface ChiTietHoaDonInfo {
  id: number;
  soluong: number;
  dongia: number;
  hoaDon: HoaDonInfo;
  monAn: MonAnInfo;
}
export interface HoaDonList {
  hoadon: HoaDonInfo;
}
export interface NhanVienInfo {
  id: number;
  honhanvien: string;
  tennhanvien: string;
  email: string;
  password: string;
  diachi: string;
  trangthai: boolean;
}
export interface BanInfo {
  id: number;
  soban: number;
  trangthai: boolean;
  hoadondangphucvu: number;
}
export interface KhachHangInfo {
  id: number;
  hokhachhang: string;
  tenkhachhang: string;
  email: string;
  diachi: string;
  dienthoai: string;
  ghichu: string;
}
@Injectable({
  providedIn: 'root'
})
export class HoaDonService {
  constructor(private api: ApiService, private http: HttpClient) { }
  public getAllHoaDon(): Observable<HoaDonList> {
    return this.http.get<HoaDonList>(this.api.apiUrl.hoadon);
  }

  public getIdHoadon(id): Observable<HoaDonInfo> {
    return this.http.get<HoaDonInfo>(this.api.apiUrl.hoadon + '/' + id);
  }

  public getHoaDon(id): Observable<ChiTietHoaDonInfo> {
    return this.http.get<ChiTietHoaDonInfo>(this.api.apiUrl.chitietdatban + '/hoadon/' + id);
  }

  public postHoaDon(param): Observable<HoaDonInfo> {
    return this.http.post<HoaDonInfo>(this.api.apiUrl.hoadon, param);
  }

  public getTongTienHD(id) {
    return this.http.get(this.api.apiUrl.hoadon + '/tongtien/' + id);
  }

  public deleteChitiet(id) {
    return this.http.delete(this.api.apiUrl.chitietdatban + '/' + id);
  }
}
