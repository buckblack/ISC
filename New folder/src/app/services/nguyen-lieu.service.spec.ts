import { TestBed } from '@angular/core/testing';

import { NguyenLieuService } from './nguyen-lieu.service';

describe('NguyenLieuService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NguyenLieuService = TestBed.get(NguyenLieuService);
    expect(service).toBeTruthy();
  });
});
