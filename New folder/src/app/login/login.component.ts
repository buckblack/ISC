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
      if (result.id === 0) {
        this.message = 'Sai tên đăng nhập hoặc mật khẩu';
      } else {
        if (result.trangthai === false) {
          this.message = 'Tài khoản này đã bị khóa';
        } else {
          this.message = '';
          localStorage.setItem('username', result.ten);
          this.router.navigate(['/dashboard']);
        }
      }
    });
  }

}
