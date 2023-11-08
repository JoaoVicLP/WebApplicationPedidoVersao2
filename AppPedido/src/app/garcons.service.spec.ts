import { TestBed } from '@angular/core/testing';

import { GarconsService } from './garcons.service';

describe('GarconsService', () => {
  let service: GarconsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GarconsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
