import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HelloBoxComponent } from './hello-box.component';

describe('HelloBoxComponent', () => {
  let component: HelloBoxComponent;
  let fixture: ComponentFixture<HelloBoxComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HelloBoxComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HelloBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
