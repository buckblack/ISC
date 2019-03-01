import { Injectable, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ModalDirective } from 'ngx-bootstrap';
export interface MajorsRespone {
  errorCode: number;
  majors: Major[];
  errorMessage: string;
}

export interface MajorRespone {
  errorCode: number;
  major: Major;
  errorMessage: string;
}

export interface Major {
  id: number;
  name: string;
}
@Injectable({
  providedIn: 'root'
})
export class MajorService {

  constructor(private http: HttpClient, private api: ApiService) { }

  public getAll(): Observable<MajorsRespone> {
    return this.http.get<MajorsRespone>(this.api.apiUrl.majors);
  }

  public add(data: Major): Observable<MajorRespone> {
    return this.http.post<MajorRespone>(this.api.apiUrl.major, data);
  }

  public update(data: Major): Observable<MajorRespone> {
    return this.http.put<MajorRespone>(this.api.apiUrl.major + '?id=' + data.id, data);
  }

  public delete(id): Observable<MajorRespone> {
    return this.http.delete<MajorRespone>(this.api.apiUrl.major + '?id=' + id);
  }

  public get(id): Observable<MajorRespone> {
    return this.http.get<MajorRespone>(this.api.apiUrl.majors + '?id=' + id);
  }
}
