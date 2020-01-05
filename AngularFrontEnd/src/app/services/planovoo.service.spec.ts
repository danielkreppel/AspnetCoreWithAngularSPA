import { TestBed } from '@angular/core/testing';

import { PlanovooService } from './planovoo.service';

describe('PlanovooService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PlanovooService = TestBed.get(PlanovooService);
    expect(service).toBeTruthy();
  });
});
