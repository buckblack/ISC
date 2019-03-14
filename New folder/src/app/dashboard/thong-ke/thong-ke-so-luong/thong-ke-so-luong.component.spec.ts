import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThongKeSoLuongComponent } from './thong-ke-so-luong.component';

describe('ThongKeSoLuongComponent', () => {
  let component: ThongKeSoLuongComponent;
  let fixture: ComponentFixture<ThongKeSoLuongComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThongKeSoLuongComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongKeSoLuongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
