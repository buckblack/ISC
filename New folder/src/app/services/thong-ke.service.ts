import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface Doanhthu {
  ngay: Date;
  thu: number;
  chi: number;
}
export interface DoanhthusRespone {
  errorCode: number;
  message: string;
  data: Doanhthu[];
}
export interface SoLuong {
  khoa: string;
  ten_mon: string;
  ngay: Date;
  so_luong: number;
}
export interface SoLuongRespone {
  errorCode: number;
  message: string;
  data: SoLuong[];
}
export interface TonKhoRespone {
  errorCode: number;
  message: string;
  data: TonKho[];
}
export interface TonKho {
  id_nguyenlieu: number;
  tennguyenlieu: string;
  dvt: string;
  tondau: number;
  xuat: number;
  nhap: number;
  toncuoi: number;
}
export interface TongThuChi {
  tongthu: number;
  thongchi: number;
  maxthu: number;
  maxchi: number;
}
@Injectable({
  providedIn: 'root'
})
export class ThongKeService {

  constructor(private api: ApiService, private http: HttpClient) { }
  public getDoanhThu(data): Observable<DoanhthusRespone> {
    return this.http.post<DoanhthusRespone>(this.api.apiUrl.doanhthu, data);
  }
  public getSoLuong(param): Observable<SoLuongRespone> {
    return this.http.post<SoLuongRespone>(this.api.apiUrl.thongkesoluong, param);
  }
  public getThongKeTonKho(param): Observable<TonKhoRespone> {
    return this.http.post<TonKhoRespone>(this.api.apiUrl.thongketonkho, param);
  }
  public postThuChi(param): Observable<TongThuChi> {
    return this.http.post<TongThuChi>(this.api.apiUrl.tongthuchi, param);
  }
}
