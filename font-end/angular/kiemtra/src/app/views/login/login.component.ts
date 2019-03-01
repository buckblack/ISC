import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  message = '';
  userName = '';
  password = '';
  constructor(private userService: UserService, private auth: AuthService, private router: Router, private cookieService: CookieService) { }
  login() {
    this.userService.login(this.userName, this.password).subscribe(result => {
      console.log(result);
      this.auth.setLoggedIn(true);
      //save token
      this.cookieService.set('token', result.data.accessToken);
      this.cookieService.set('userId', result.data.userId + '');
      this.router.navigate(['/dashboard']);
    });
  }
}
