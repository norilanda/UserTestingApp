import { IAnswer } from '../models/IAnswer';
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

  public getTestDetailsById(id: number) {
    return this.testApiService.getTestDetailsById(id);
  }

  public passTest(id: number, answers: IAnswer[]) {
    return this.testApiService.passTest(id, answers);
  }
}
