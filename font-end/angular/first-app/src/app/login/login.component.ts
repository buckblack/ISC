import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  message = '';
  username = '';
  password = '';
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  login() {
    const param = {
      username: this.username,
      password: this.password
    };
    this.http.post('http://www.saigontech.edu.vn/restful-api/login.php', param)
      .subscribe(result => {
        if (result['errorCode'] === 1) {
          this.message = result['errorMessage'];
        } else {
          this.message = '';
          this.router.navigate(['/dashboard']);
        }
      });
    console.log(this.username, this.password);
  }
}
