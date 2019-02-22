import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl = 'https://localhost:44384/api/';
  apiUrl = {
    login: this.baseUrl + 'nhanvien/login',
    monan: this.baseUrl + 'monan',
    ban: this.baseUrl + 'bans'
  };
}
