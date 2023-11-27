import { TestApiService } from './api-services/test-api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class TestService {
  constructor(private testApiService: TestApiService) {}

  public assignedTests$ = this.testApiService.getAssignedTests();

  public incompleteTests$ = this.testApiService.getIncompleteTests();

  public completedTests$ = this.testApiService.getCompletedTests();
}
