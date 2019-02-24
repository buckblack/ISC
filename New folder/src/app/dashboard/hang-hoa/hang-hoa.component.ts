import { MonanList, MonanInfo, ThanhPhan, NguyenLieu } from './../../services/hang-hoa.service';
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
  tp_idmonan: number;
  sl_tp_up: number;
  sl_tp_down: number;
  ip_tp_soluong: number;
  detail: MonanInfo;
  sanphams: MonanList;
  thanhphans: ThanhPhan;
  nguyenlieus: NguyenLieu[];
  constructor(private titleService: Title, private monanService: HangHoaService) { }
  ngOnInit() {
    this.titleService.setTitle('Sản phẩm');
    this.monanService.getAllMonAn().subscribe(result => {
      this.sanphams = result;
    });
  }

  tp_uptodown() {
    if (this.sl_tp_up === undefined) {
      alert("Chưa chọn nguyên liệu");
      return;
    }
    if (this.ip_tp_soluong === undefined || this.ip_tp_soluong === null || this.ip_tp_soluong === 0) {
      alert("Số lượng nguyên liệu không hợp lệ");
      return;
    }
    const param = {
      "soluong": this.ip_tp_soluong,
      "id_nguyenlieu": this.sl_tp_up,
      "id_monan": this.tp_idmonan
    }
    this.monanService.ThemCongThuc(param).subscribe(result => {
      this.getThanhphan(this.tp_idmonan);//load lại thành phần nguyên liệu sau khi thêm
    });
  }

  tp_downtoup() {
    if (this.sl_tp_down === undefined) {
      alert("Chưa chọn nguyên liệu");
      return;
    }
    this.monanService.XoaCongThuc(this.sl_tp_down).subscribe(result => {
      this.getThanhphan(this.tp_idmonan);//load lại thành phần nguyên liệu sau khi xóa
    });
  }

  click_detail(id) {
    this.monanService.getMonAn(id).subscribe(result => {
      this.tp_idmonan = result.id;
      this.detail = result;
    });
  }
  getThanhphan(idmonan) {
    this.monanService.getThanhPhanHienTai(idmonan).subscribe(result => {
      this.thanhphans = result;
    });
  }

  TimNguyenLieu(query) {
    this.monanService.TimNguyenLieu(query).subscribe(result => {
      this.nguyenlieus = result;
    });
  }

  show() {
    console.log(this.cke_them);
  }
}