import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class ReaderService {

  constructor(private api: ApiService, private http: HttpClient, private cookie: CookieService) { }
  public getAll() {
    return this.http.get(this.api.apiUrl.readers);
  }
}
