import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';

export interface NguyenLieu {
  id: number;
  tennguyenlieu: string;
  donvitinh: string;
  soluong: number;
}
@Injectable({
  providedIn: 'root'
})
export class NguyenLieuService {

  constructor(private api: ApiService, private http: HttpClient) { }
  public getNguyenlieu(): Observable<NguyenLieu[]> {
    return this.http.get<NguyenLieu[]>(this.api.apiUrl.nguyenlieus);
  }
}
