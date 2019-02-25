import { ChiTietHoaDonInfo } from './../../services/hoa-don.service';
import { HoaDonService } from 'src/app/services/hoa-don.service';
import { BanHangService } from './../../services/ban-hang.service';
import { HangHoaService, MonanList } from 'src/app/services/hang-hoa.service';
import { BanService, BanList } from './../../services/ban.service';
import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { log } from 'util';

@Component({
  selector: 'app-ban-hang',
  templateUrl: './ban-hang.component.html',
  styleUrls: ['./ban-hang.component.css']
})
export class BanHangComponent implements OnInit {
  bans: BanList;
  monans: MonanList;
  ip_tim_monan = ''
  id_hoadon = '';
  soban: number;
  id_ban: number;
  tongtienHD = 0;
  chitietHDs: ChiTietHoaDonInfo;
  constructor(private titleService: Title, private banService: BanService, private monanService: HangHoaService, private banhangService: BanHangService, private hoadonService: HoaDonService) { }

  ngOnInit() {
    this.titleService.setTitle('Bán hàng');
    this.banService.getAllban().subscribe(result => {
      this.bans = result;
    });
    this.monanService.getAllMonAn().subscribe(result => {
      this.monans = result;
    });
  }

  chon_ban(id, soban) {
    this.soban = soban;
    this.id_ban = id;
    this.banhangService.getIdHoadon(id).subscribe(result => {
      this.id_hoadon = result.toString();
      this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result2 => {
        this.chitietHDs = result2;
      });
      this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result3 => {
        this.tongtienHD = Number(result3);
      });
    });
  }
  tim_monan() {
    this.monanService.TimMonan(this.ip_tim_monan).subscribe(result => {
      this.monans = result;
    });
  }
  chon_mon(id, gia) {
    const param = {
      idHoaDon: this.id_hoadon,
      idMonAn: id
    };
    //kiểm tra hóa đơn, chưa có thì tạo mới
    this.hoadonService.getIdHoadon(this.id_hoadon).subscribe(res => {
      if (res.id === 0) {
        const data = {
          ngaydat: new Date(),
          trangthai: false,
          ghichu: null,
          id_nhanvien: 1,
          id_ban: this.id_ban,
          id_khachhang: 1,
        };
        const data_ban = {
          trangthai: true,
          hoadonphucvu: this.id_hoadon,
        };
        this.hoadonService.postHoaDon(data).subscribe();//thêm hóa don mới
        this.banService.UpdateBan(data_ban, this.id_ban).subscribe(); //update bàn
      }
      this.banhangService.KiemTraMonAn(param).subscribe(result => {
        if (result === true) {
          //thêm
          const ct = {
            soluong: 1,
            dongia: gia,
            id_monan: id,
            id_hoadon: this.id_hoadon,
          };
          this.banhangService.ThemChiTiet(ct).subscribe(kq => {
            this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result_ct => {
              this.chitietHDs = result_ct;
            });
            this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result_tongtien => {
              this.tongtienHD = Number(result_tongtien);
            });
            const ban = document.getElementById('ban_' + this.id_ban);
            ban.setAttribute('src', '/assets/images/chair2.png');
          });
        }
      });
    });
    //kiểm tra món ăn trước khi thêm
    /*this.banhangService.KiemTraMonAn(param).subscribe(result => {
      if (result === true) {
        //thêm
        const ct = {
          soluong: 1,
          dongia: gia,
          id_monan: id,
          id_hoadon: this.id_hoadon,
        };
        this.banhangService.ThemChiTiet(ct).subscribe(kq => {
          this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result_ct => {
            this.chitietHDs = result_ct;
          });
          this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result_tongtien => {
            this.tongtienHD = Number(result_tongtien);
          });
          const ban = document.getElementById('ban_' + this.id_ban);
          ban.setAttribute('src', '/assets/images/chair2.png');
        });
      }
    });*/
  }

  xoa_chi_tiet(id_chitiet) {
    this.hoadonService.deleteChitiet(id_chitiet).subscribe(kq => {
      this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result2 => {
        this.chitietHDs = result2;
      });
      this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result3 => {
        this.tongtienHD = Number(result3);
      });
    });

  }

  async doi_so_luong_chi_tiet(id_chitiet) {
    const sl = (<HTMLInputElement>document.getElementById('tp_soluong_' + id_chitiet)).value;
    const data = {
      soluong: sl,
    };
    this.banhangService.UpdateSoluong(id_chitiet, data).subscribe();
    await this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result2 => {
      this.chitietHDs = result2;
    });
    await this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result3 => {
      this.tongtienHD = Number(result3);
    });
  }
}
