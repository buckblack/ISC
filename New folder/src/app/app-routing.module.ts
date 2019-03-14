import { ThongKeTonKhoComponent } from './dashboard/thong-ke/thong-ke-ton-kho/thong-ke-ton-kho.component';
import { HoaDonComponent } from './dashboard/hoa-don/hoa-don.component';
import { ThongKeComponent } from './dashboard/thong-ke/thong-ke.component';
import { HangHoaComponent } from './dashboard/hang-hoa/hang-hoa.component';
import { BanHangComponent } from './dashboard/ban-hang/ban-hang.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ThongKeDoanhThuComponent } from './dashboard/thong-ke/thong-ke-doanh-thu/thong-ke-doanh-thu.component';
import { ThongKeSoLuongComponent } from './dashboard/thong-ke/thong-ke-so-luong/thong-ke-so-luong.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: LoginComponent },
  {
    path: 'dashboard', component: DashboardComponent,
    children: [
      { path: 'ban-hang', component: BanHangComponent },
      { path: '', component: BanHangComponent },
      { path: 'hang-hoa', component: HangHoaComponent },
      { path: 'hoa-don', component: HoaDonComponent },
      { path: 'thong-ke', component: ThongKeComponent },
      { path: 'thong-ke-doanh-thu', component: ThongKeDoanhThuComponent },
      { path: 'thong-ke-so-luong', component: ThongKeSoLuongComponent },
      { path: 'thong-ke-ton-kho', component: ThongKeTonKhoComponent },
      { path: 'thong-ke', component: ThongKeComponent }]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
