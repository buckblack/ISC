import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';

export interface ProductsRespone {
  errorCode: number;
  products: Product[];
  errorMessage: string;
}

export interface ProductRespone {
  errorCode: number;
  product: Product;
  errorMessage: string;
}

export interface Product {
  id: number;
  name: string;
  code: string;
  unit: string;
  price: number;
  description: string;
}
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient, private api: ApiService) { }
  public getAll(): Observable<ProductsRespone> {
    return this.http.get<ProductsRespone>(this.api.apiUrl.products);
  }
  public add(data: Product) {
    return this.http.post(this.api.apiUrl.product, data);
  }

  public update(data: Product) {
    return this.http.put(this.api.apiUrl.product + '?id=' + data.id, data);
  }

  public get(id): Observable<ProductRespone> {
    return this.http.get<ProductRespone>(this.api.apiUrl.products + '?id=' + id);
  }

  public delete(id): Observable<ProductRespone> {
    return this.http.delete<ProductRespone>(this.api.apiUrl.product + '?id=' + id);
  }

}
