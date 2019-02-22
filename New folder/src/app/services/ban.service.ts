import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface BanInfo {
  id: number;
  soban: number;
  trangthai: boolean;
  hoadonphucvu: number;
}

export interface BanList {
  ban: BanInfo;
}

@Injectable({
  providedIn: 'root'
})
export class BanService {
  constructor(private api: ApiService, private http: HttpClient) { }
  public getAllban(): Observable<BanList> {
    return this.http.get<BanList>(this.api.apiUrl.ban);
  }
}
