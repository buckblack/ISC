import { TestBed } from '@angular/core/testing';

import { BanHangService } from './ban-hang.service';

describe('BanHangService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BanHangService = TestBed.get(BanHangService);
    expect(service).toBeTruthy();
  });
});
