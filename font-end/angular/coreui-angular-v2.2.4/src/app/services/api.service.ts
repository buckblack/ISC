import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor() { }
  baseUrl = 'http://www.saigontech.edu.vn/restful-api/';
  apiUrl = {
    login: this.baseUrl + 'login.php'
  };
}
