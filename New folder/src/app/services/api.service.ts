import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:44306/api/';
  apiUrl = {
    login: this.baseUrl + 'nhanvien/login',
    monan: this.baseUrl + 'monan',
    banhang: this.baseUrl + 'monan/banhang',
    loaimonan: this.baseUrl + 'loaimonan',
    hoadon: this.baseUrl + 'hoadon',
    doanhthu: this.baseUrl + 'hoadon/doanhthu',
    tongthuchi: this.baseUrl + 'hoadon/doanhthu/tongthuchi',
    thongkesoluong: this.baseUrl + 'chitietdatban/thongkesoluong',
    thongketonkho: this.baseUrl + 'nguyenlieu/thongketonkho',
    chitietdatban: this.baseUrl + 'chitietdatban',
    congthucMonan: this.baseUrl + 'congthuc/monan/',
    nguyenlieus: this.baseUrl + 'nguyenlieu',
    nguyenlieu: this.baseUrl + 'nguyenlieu/tim',
    timnguyenlieu: this.baseUrl + 'nguyenlieu/tim?q=',
    congthuc: this.baseUrl + 'congthuc/',
    ban: this.baseUrl + 'bans',
    timmonan: this.baseUrl + 'monan/tim?q=',
    timhoadon_phucvu: this.baseUrl + 'bans/hoadon',
    tinhtrangmonan: this.baseUrl + 'monan/tinhtrang',
  };
}
