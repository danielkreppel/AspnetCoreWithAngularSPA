import { TestBed } from '@angular/core/testing';

import { GenericBaseService } from './genericbase.service';

describe('BaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GenericBaseService = TestBed.get(GenericBaseService);
    expect(service).toBeTruthy();
  });
});
