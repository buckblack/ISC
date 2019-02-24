import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  public UpdateBan(param, id): Observable<BanInfo> {
    return this.http.put<BanInfo>(this.api.apiUrl.ban + '/' + id, param);
  }
}
