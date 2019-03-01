import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface LoginRespone {
  errorCode: Number;
  errorMessage: string;
  data: LoginInfo;
}
export interface LoginInfo {
  userId: Number;
  account: string;
  fullName: string;
  accessToken: string;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private api: ApiService, private http: HttpClient) { }
  public login(userName: String, password: String): Observable<LoginRespone> {
    const requestData = {
      username: userName,
      password: password
    };
    return this.http.post<LoginRespone>(this.api.apiUrl.login, requestData);
  }
}
