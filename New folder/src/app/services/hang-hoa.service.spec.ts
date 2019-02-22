import { TestBed } from '@angular/core/testing';

import { HangHoaService } from './hang-hoa.service';

describe('HangHoaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HangHoaService = TestBed.get(HangHoaService);
    expect(service).toBeTruthy();
  });
});
