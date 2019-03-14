import { NguyenLieuService } from './../../../services/nguyen-lieu.service';
import { Title } from '@angular/platform-browser';
import { Component, OnInit } from '@angular/core';
import { ThongKeService, TonKho } from 'src/app/services/thong-ke.service';
import { formatDate } from '@angular/common';
import { NguyenLieu } from 'src/app/services/hang-hoa.service';

@Component({
  selector: 'app-thong-ke-ton-kho',
  templateUrl: './thong-ke-ton-kho.component.html',
  styleUrls: ['./thong-ke-ton-kho.component.css']
})
export class ThongKeTonKhoComponent implements OnInit {
  TonKhos: TonKho[];
  dateTo;
  dateFrom;
  nguyenlieus: NguyenLieu[];
  select_nl = 0;
  constructor(private titleService: Title, private thongkeService: ThongKeService, private nguyenlieuService: NguyenLieuService) { }

  ngOnInit() {
    this.titleService.setTitle('Thống kê tồn kho');
    this.dateFrom = formatDate(new Date(), 'yyyy-MM-dd', 'en-GB');
    this.dateTo = formatDate(new Date(), 'yyyy-MM-dd', 'en-GB');
    this.nguyenlieuService.getNguyenlieu().subscribe(result => {
      this.nguyenlieus = result;
    });
  }
  loadData() {
    const param = {
      id: this.select_nl,
      dateFrom: this.dateFrom,
      dateTo: this.dateTo
    };
    this.thongkeService.getThongKeTonKho(param).subscribe(result => {
      this.TonKhos = result.data;
    });
  }
  click() {
    this.loadData();
  }
}
