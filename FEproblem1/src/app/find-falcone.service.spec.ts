import { TestBed } from '@angular/core/testing';

import { FindFalconeService } from './find-falcone.service';

describe('FindFalconeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FindFalconeService = TestBed.get(FindFalconeService);
    expect(service).toBeTruthy();
  });
});
