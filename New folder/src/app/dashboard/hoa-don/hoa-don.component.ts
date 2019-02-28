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
  id_hoadon: number;
  nhanvien: string;
  ngay: Date;
  tinhtrang: boolean;
  tongtienHD: number = 0;
  hoadonIf: HoaDonInfo;
  constructor(private titleService: Title, private hoadonService: HoaDonService) { }

  ngOnInit() {
    this.titleService.setTitle('Hóa đơn');
    this.hoadonService.getAllHoaDon().subscribe(result => {
      this.hoadons = result;
    });
  }
  click_detail(id) {
    this.hoadonService.getHoaDon(id).subscribe(result => {
      this.hoadonService.getTongTienHD(id).subscribe(result2 => {
        this.tongtienHD = Number(result2);
      });
      this.hoadonService.getIdHoadon(id).subscribe(result1 => {
        //console.log(result1);
        this.hoadonIf = result1;
        //this.id_hoadon = result1.id;
        //this.nhanvien = (result1.nhanVien.honhanvien) + ' ' + (result1.nhanVien.tennhanvien);
        //this.ngay = result1.ngaydat;
        //this.tinhtrang = result1.trangthai;
      });
      this.detail = result;
    });
  }
}
