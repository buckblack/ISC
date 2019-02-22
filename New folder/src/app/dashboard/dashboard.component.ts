import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  username = localStorage.getItem('username');
  constructor(private router: Router) { }

  ngOnInit() {
    if (this.username == null) {
      this.router.navigate(['/login']);
    }
  }
  logout() {
    localStorage.removeItem('username');
    this.router.navigate(['/login']);
  }

}
