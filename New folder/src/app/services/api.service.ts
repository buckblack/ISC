import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:44384/api/';
  apiUrl = {
    login: this.baseUrl + 'nhanvien/login',
    monan: this.baseUrl + 'monan',
    loaimonan: this.baseUrl + 'loaimonan',
    hoadon: this.baseUrl + 'hoadon',
    chitietdatban: this.baseUrl + 'chitietdatban',
    congthucMonan: this.baseUrl + 'congthuc/monan/',
    nguyenlieu: this.baseUrl + 'nguyenlieu/tim',
    timnguyenlieu: this.baseUrl + 'nguyenlieu/tim?q=',
    congthuc: this.baseUrl + 'congthuc/',
    ban: this.baseUrl + 'bans',
    timmonan: this.baseUrl + 'monan/tim?q=',
    timhoadon_phucvu: this.baseUrl + 'bans/hoadon'
  };
}
