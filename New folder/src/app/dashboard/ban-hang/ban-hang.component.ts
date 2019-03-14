import { ChiTietHoaDonInfo } from './../../services/hoa-don.service';
import { HoaDonService } from 'src/app/services/hoa-don.service';
import { BanHangService } from './../../services/ban-hang.service';
import { HangHoaService, MonanList } from 'src/app/services/hang-hoa.service';
import { BanService, BanList } from './../../services/ban.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { log } from 'util';
import { ModalDirective } from 'ngx-bootstrap';

@Component({
  selector: 'app-ban-hang',
  templateUrl: './ban-hang.component.html',
  styleUrls: ['./ban-hang.component.css']
})
export class BanHangComponent implements OnInit {
  bans: BanList;
  monans: MonanList;
  ip_tim_monan = '';
  id_hoadon = '';
  soban: number;
  id_ban: number;
  tongtienHD = 0;
  chitietHDs: ChiTietHoaDonInfo;
  @ViewChild('modalthanhtoan') modalthanhtoan: ModalDirective;
  @ViewChild('modalphucvu') modalphucvu: ModalDirective;
  constructor(private titleService: Title, private banService: BanService, private monanService: HangHoaService, private banhangService: BanHangService, private hoadonService: HoaDonService) { }

  ngOnInit() {
    this.titleService.setTitle('Bán hàng');
    this.banService.getAllban().subscribe(result => {
      this.bans = result;
    });
    this.loadMonan();
  }
  loadMonan() {
    this.monanService.getAllMonAnBanHang().subscribe(result => {
      this.monans = result;
    });
  }
  loadChitiet() {
    this.hoadonService.getHoaDon(Number(this.id_hoadon)).subscribe(result => {
      this.chitietHDs = result;
      console.log(result);

    });
    this.hoadonService.getTongTienHD(Number(this.id_hoadon)).subscribe(result => {
      this.tongtienHD = Number(result);
      if (this.tongtienHD <= 0) {
        document.getElementById('btn_daphucvu').classList.add('disabled');
        document.getElementById('btn_thanhtoan').classList.add('disabled');
      } else {
        document.getElementById('btn_thanhtoan').classList.remove('disabled');
        document.getElementById('btn_daphucvu').classList.remove('disabled');
      }
    });
  }

  chon_ban(id, soban) {
    this.soban = soban;
    this.id_ban = id;
    this.banhangService.getIdHoadon(id).subscribe(result => {
      this.id_hoadon = result.toString();
      this.loadChitiet();
    });
    document.getElementById('pills-home-tab').classList.remove('active');
    document.getElementById('pills-profile-tab').classList.add('active');
    document.getElementById('maban_' + id).classList.remove('active');
  }
  tim_monan() {
    this.monanService.TimMonan(this.ip_tim_monan).subscribe(result => {
      this.monans = result;
    });
  }
  chon_mon(id, gia) {
    if (this.id_hoadon === undefined || this.id_hoadon === '') {
      alert('Chưa chọn bàn');
      return;
    }

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
          id_nhanvien: localStorage.getItem('userid').toString(),
          id_ban: this.id_ban,
          id_khachhang: 1,
        };
        const data_ban = {
          trangthai: true,
          hoadonphucvu: this.id_hoadon,
        };
        this.hoadonService.postHoaDon(data).subscribe(kq => {
          this.banService.UpdateBan(data_ban, this.id_ban).subscribe(); // update bàn
        });
        // thêm hóa don mới
      }
      //  kiểm tra món ăn trước khi thêm
      this.banhangService.KiemTraMonAn(param).subscribe(result => {
        //  update lại trạng thái hóa đơn nếu trước đó đã thanh toán
        // tslint:disable-next-line: max-line-length
        this.hoadonService.updateThanhToan(this.id_hoadon,
          {
            trangthai: false,
            id_nhanvien: localStorage.getItem('userid').toString()
          }).subscribe();

        if (result === true) {
          // thêm
          const ct = {
            soluong: 1,
            dongia: gia,
            id_monan: id,
            id_hoadon: this.id_hoadon,
          };
          this.banhangService.ThemChiTiet(ct).subscribe(kq => {
            this.loadChitiet();
            const ban = document.getElementById('ban_' + this.id_ban);
            ban.setAttribute('src', '/assets/images/chair2.png');
          });
        } else {
          const ct = {
            id_monan: id,
            id_hoadon: this.id_hoadon,
          };
          this.banhangService.ThemChiTietDaCo(ct).subscribe(kq => {
            this.loadChitiet();
            const ban = document.getElementById('ban_' + this.id_ban);
            ban.setAttribute('src', '/assets/images/chair2.png');
          });
        }
      });

    });
  }

  xoa_chi_tiet(id_chitiet) {
    this.hoadonService.deleteChitiet(id_chitiet).subscribe(kq => {
      this.loadChitiet();
    });

  }

  doi_so_luong_chi_tiet(id_chitiet) {
    const sl = (<HTMLInputElement>document.getElementById('tp_soluong_' + id_chitiet)).value;
    const data = {
      soluong: sl,
    };
    const param = {
      trangthai: false,
      id_nhanvien: localStorage.getItem('userid').toString(),
    };
    this.hoadonService.updateThanhToan(this.id_hoadon, param).subscribe(kq1 => {
      this.banhangService.UpdateSoluong(id_chitiet, data).subscribe(kq => {
        this.loadChitiet();
      });
    });

  }
  printHD() {
    const ghi_chu = (<HTMLInputElement>document.getElementById('ghi_chu')).value;
    const param = {
      trangthai: true,
      id_nhanvien: localStorage.getItem('userid').toString(),
      ghichu: ghi_chu,
    };
    this.hoadonService.updateThanhToan(this.id_hoadon, param).subscribe(kq => {
      const content = document.getElementById('noidungHD').innerHTML;
      const mywindow = window.open('');

      mywindow.document.write('<html><head><title>Print</title>');
      mywindow.document.write('</head><body>');
      mywindow.document.write(content);
      mywindow.document.write('</body></html>');

      mywindow.document.close();
      mywindow.focus();
      mywindow.print();
      mywindow.close();
      document.getElementById('btn_thanhtoan').classList.add('disabled');
      this.chitietHDs[0].hoaDon.trangthai = true;
      this.modalthanhtoan.hide();
    });

  }
  ngungphucvu() {
    if (this.chitietHDs[0].hoaDon.trangthai === false) {
      alert('Bàn chưa thanh toán');
      this.modalphucvu.hide();
      return;
    }
    const param = {
      trangthai: false,
      hoadonphucvu: null,
    };
    this.banService.UpdateBan(param, this.id_ban).subscribe(kq => {
      this.chitietHDs = null;
      this.tongtienHD = 0;
      const ban = document.getElementById('ban_' + this.id_ban);
      ban.setAttribute('src', '/assets/images/chair.png');
      document.getElementById('btn_daphucvu').classList.add('disabled');
      document.getElementById('btn_thanhtoan').classList.add('disabled');
      this.id_hoadon = null;
      this.modalphucvu.hide();
    });
  }
  showThanhtoan() {
    if ((document.getElementById('btn_thanhtoan').classList.contains('disabled'))) {
      return;
    }
    this.modalthanhtoan.show();
  }
  showNgungphucvu() {
    if ((document.getElementById('btn_daphucvu').classList.contains('disabled'))) {
      return;
    }
    this.modalphucvu.show();
  }
}
