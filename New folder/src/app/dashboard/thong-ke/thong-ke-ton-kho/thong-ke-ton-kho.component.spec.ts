import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThongKeTonKhoComponent } from './thong-ke-ton-kho.component';

describe('ThongKeTonKhoComponent', () => {
  let component: ThongKeTonKhoComponent;
  let fixture: ComponentFixture<ThongKeTonKhoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThongKeTonKhoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThongKeTonKhoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
