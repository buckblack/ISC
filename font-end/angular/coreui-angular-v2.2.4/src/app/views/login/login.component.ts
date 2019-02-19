import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  message = '';
  userName = '';
  password = '';
  constructor(private userService: UserService) {}
  login() {
    this.userService.login(this.userName, this.password).subscribe(result => {
      console.log(result.errorCode);
    });
  }
}
