import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { BanService, BanList } from 'src/app/services/ban.service';

@Component({
  selector: 'app-ban-hang',
  templateUrl: './ban-hang.component.html',
  styleUrls: ['./ban-hang.component.css']
})
export class BanHangComponent implements OnInit {
  bans: BanList;
  constructor(private titleService: Title, private banService: BanService) { }
  ngOnInit() {
    this.titleService.setTitle('Bán hàng');
    this.banService.getAllban().subscribe(result => {
      this.bans = result;
    });
  }

  chon_ban(id) {
    var ban = document.getElementById('ban_' + id);
    ban.setAttribute('src', '/assets/images/chair2.png');
    
  }

}
