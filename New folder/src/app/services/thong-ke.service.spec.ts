import { TestBed } from '@angular/core/testing';

import { ThongKeService } from './thong-ke.service';

describe('ThongKeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ThongKeService = TestBed.get(ThongKeService);
    expect(service).toBeTruthy();
  });
});
