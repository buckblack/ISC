import { HoaDonComponent } from './dashboard/hoa-don/hoa-don.component';
import { ThongKeComponent } from './dashboard/thong-ke/thong-ke.component';
import { HangHoaComponent } from './dashboard/hang-hoa/hang-hoa.component';
import { BanHangComponent } from './dashboard/ban-hang/ban-hang.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

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
      { path: 'thong-ke', component: ThongKeComponent }]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
