import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  message = '';
  email = '';
  password = '';
  constructor(private titleService: Title, private userService: LoginService, private router: Router) { }

  ngOnInit() {
    this.titleService.setTitle('Đăng nhập');
    if (localStorage.getItem('username') != null) {
      this.router.navigate(['/dashboard']);
    }
  }

  login() {
    const param = {
      email: this.email,
      password: this.password
    };
    this.userService.login(this.email, this.password).subscribe(result => {
      if (result.errorCode === 1) {
        this.message = result.message;
      } else {
        if (result.data.trangthai === false) {
          this.message = 'Tài khoản này đã bị khóa';
        } else {
          localStorage.setItem('username', result.data.ho + ' ' + result.data.ten);
          localStorage.setItem('userid', result.data.id.toString());
          this.router.navigate(['/dashboard']);
        }
      }
    });
  }

}
