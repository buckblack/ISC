import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface MonanInfo {
  id: number;
  tenmonan: string;
  dongia: number;
  hinhanh: string;
  trangthai: string;
  noidung: string;
  loaiMonAn: LoaimonanInfo;
}
export interface LoaimonanInfo {
  id: number;
  tenloai: string;
}

export interface MonanList {
  monan: MonanInfo;
}
@Injectable({
  providedIn: 'root'
})
export class HangHoaService {
  constructor(private api: ApiService, private http: HttpClient) { }
  public getAllMonAn(): Observable<MonanList> {
    return this.http.get<MonanList>(this.api.apiUrl.monan);
  }
  public getMonAn(id): Observable<MonanInfo> {
    return this.http.get<MonanInfo>(this.api.apiUrl.monan + '/' + id);
  }
}
