import { TestBed } from '@angular/core/testing';

import { CondimentosService } from './condimentos.service';

describe('CondimentosService', () => {
  let service: CondimentosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CondimentosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
