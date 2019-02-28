import { ThanhPhan } from './hang-hoa.service';
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
  id_loaimonan: number;
  loaiMonAn: LoaimonanInfo;
}
export interface LoaimonanInfo {
  id: number;
  tenloai: string;
}

export interface MonanList {
  monan: MonanInfo;
}

export interface ListLoaimonanInfo {
  loaimonan: LoaimonanInfo;
}

export interface ThanhPhan {
  id: number;
  soluong: number;
  nguyenLieu: NguyenLieu[];
}
export interface NguyenLieu {
  id: number;
  tennguyenlieu: string;
  donvitinh: string;
  soluong: number;
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

  public getThanhPhanHienTai(id_monan): Observable<ThanhPhan> {
    return this.http.get<ThanhPhan>(this.api.apiUrl.congthucMonan + id_monan);
  }

  public TimNguyenLieu(query): Observable<NguyenLieu[]> {
    return this.http.get<NguyenLieu[]>(this.api.apiUrl.timnguyenlieu + query);
  }

  public TimMonan(query): Observable<MonanList> {
    return this.http.get<MonanList>(this.api.apiUrl.timmonan + query);
  }

  public XoaCongThuc(id): Observable<ThanhPhan> {
    return this.http.delete<ThanhPhan>(this.api.apiUrl.congthuc + id);
  }

  public ThemCongThuc(param): Observable<ThanhPhan> {
    return this.http.post<ThanhPhan>(this.api.apiUrl.congthuc, param);
  }

  public ThemHangHoa(param): Observable<MonanInfo> {
    console.log(param);
    return this.http.post<MonanInfo>(this.api.apiUrl.monan, param) ;
  }

  public getAllLoaiHangHoa(): Observable<ListLoaimonanInfo> {
    return this.http.get<ListLoaimonanInfo>(this.api.apiUrl.loaimonan);
  }
}
