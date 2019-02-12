import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Front End';
  name = '';
  message = '';
  sayhello() {
    this.message = 'Hello ' + this.name;
  }
}
