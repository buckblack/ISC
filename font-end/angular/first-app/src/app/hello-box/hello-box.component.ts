import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hello-box',
  templateUrl: './hello-box.component.html',
  styleUrls: ['./hello-box.component.css']
})
export class HelloBoxComponent implements OnInit {

  title = 'Front End';
  name = '';
  message = '';
  constructor() { }

  ngOnInit() {
  }

  sayhello() {
    this.message = 'Hello ' + this.name;
  }

}
