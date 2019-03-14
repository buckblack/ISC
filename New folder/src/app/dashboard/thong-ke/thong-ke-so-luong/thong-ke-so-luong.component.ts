import { Component, OnInit } from '@angular/core';
import { SoLuong, ThongKeService } from 'src/app/services/thong-ke.service';
import { Title } from '@angular/platform-browser';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-thong-ke-so-luong',
  templateUrl: './thong-ke-so-luong.component.html',
  styleUrls: ['./thong-ke-so-luong.component.css']
})
export class ThongKeSoLuongComponent implements OnInit {
  SoLuongs: SoLuong[];
  dateTo;
  dateFrom;
  constructor(private titleService: Title, private thongkeService: ThongKeService) { }

  ngOnInit() {
    this.titleService.setTitle('Thống kê số lượng bán được');
    this.dateFrom = formatDate(new Date(), 'yyyy-MM-dd', 'en-GB');
    this.dateTo = formatDate(new Date(), 'yyyy-MM-dd', 'en-GB');
  }
  loadData() {
    const param = {
      dateFrom: this.dateFrom,
      dateTo: this.dateTo
    };
    this.thongkeService.getSoLuong(param).subscribe(result => {
      this.SoLuongs = result.data;
    });
  }
  click() {
    this.loadData();
  }
}
