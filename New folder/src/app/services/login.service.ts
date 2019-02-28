import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
export interface LoginRespone {
  errorCode: number;
  message: string;
  data: LoginData;
}
export interface LoginData {
  id: number;
  trangthai: boolean;
  ten: string;
  ho: string;
  token: '';
}
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private api: ApiService, private http: HttpClient) { }
  public login(Email: string, Password: string): Observable<LoginRespone> {
    const requestData = {
      email: Email,
      password: Password
    };
    return this.http.post<LoginRespone>(this.api.apiUrl.login, requestData);
  }
}
