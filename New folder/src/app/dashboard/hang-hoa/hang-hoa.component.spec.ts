import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HangHoaComponent } from './hang-hoa.component';

describe('HangHoaComponent', () => {
  let component: HangHoaComponent;
  let fixture: ComponentFixture<HangHoaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HangHoaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HangHoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
