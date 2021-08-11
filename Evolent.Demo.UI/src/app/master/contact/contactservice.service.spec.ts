import { TestBed } from '@angular/core/testing';

import { Contactservice } from './contactservice.service';

describe('Contactservice', () => {
  let service: Contactservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Contactservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
