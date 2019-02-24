import { TestBed } from '@angular/core/testing';

import { HoaDonService } from './hoa-don.service';

describe('HoaDonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HoaDonService = TestBed.get(HoaDonService);
    expect(service).toBeTruthy();
  });
});
