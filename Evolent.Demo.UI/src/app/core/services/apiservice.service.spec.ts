import { TestBed } from '@angular/core/testing';

import { Apiservice} from './apiservice.service'

describe('Apiservice', () => {
  let service: Apiservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Apiservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
