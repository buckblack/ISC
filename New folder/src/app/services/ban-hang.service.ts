import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BanHangService {

  constructor(private api: ApiService, private http: HttpClient) { }
  public getIdHoadon(id) {
    return this.http.get(this.api.apiUrl.timhoadon_phucvu + '/' + id);
  }

  public KiemTraMonAn(param) {
    return this.http.post(this.api.apiUrl.chitietdatban + '/kiemtra', param);
  }

  public ThemChiTiet(param) {
    return this.http.post(this.api.apiUrl.chitietdatban, param);
  }

  public UpdateSoluong(id, param) {
    return this.http.put(this.api.apiUrl.chitietdatban + '/' + id, param);
  }
}
