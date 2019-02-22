import { MonanList, MonanInfo } from './../../services/hang-hoa.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { HangHoaService } from 'src/app/services/hang-hoa.service';


@Component({
  selector: 'app-hang-hoa',
  templateUrl: './hang-hoa.component.html',
  styleUrls: ['./hang-hoa.component.css']
})
export class HangHoaComponent implements OnInit {
  cke_them = ``;
  detail: MonanInfo;
  sanphams: MonanList;
  constructor(private titleService: Title, private monanService: HangHoaService) { }
  ngOnInit() {
    this.titleService.setTitle('Sản phẩm');
    this.monanService.getAllMonAn().subscribe(result => {
      this.sanphams = result;
    });
  }

  click_detail(id) {
    this.monanService.getMonAn(id).subscribe(result => {
      this.detail = result;
    });
  }
  show() {
    console.log(this.cke_them);
  }
}
