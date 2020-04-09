import { TestBed } from '@angular/core/testing';

import { EmployeegetService } from './employeeget.service';

describe('EmployeegetService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EmployeegetService = TestBed.get(EmployeegetService);
    expect(service).toBeTruthy();
  });
});
