import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
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
}
