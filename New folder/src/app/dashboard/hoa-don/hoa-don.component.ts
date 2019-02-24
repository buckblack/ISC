import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HoaDonList, HoaDonInfo, HoaDonService, ChiTietHoaDonInfo } from 'src/app/services/hoa-don.service';

@Component({
  selector: 'app-hoa-don',
  templateUrl: './hoa-don.component.html',
  styleUrls: ['./hoa-don.component.css']
})
export class HoaDonComponent implements OnInit {
  hoadons: HoaDonList;
  detail: ChiTietHoaDonInfo;
  constructor(private titleService: Title, private hoadonService: HoaDonService) { }

  ngOnInit() {
    this.titleService.setTitle('Hóa đơn');
    this.hoadonService.getAllHoaDon().subscribe(result => {
      this.hoadons = result;
    });
  }
  click_detail(id) {
    this.hoadonService.getHoaDon(id).subscribe(result => {
      this.detail = result;
    });
  }
}
