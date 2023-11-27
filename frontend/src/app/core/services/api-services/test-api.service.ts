import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { IAssignedTest } from '../../models/IAssignedTest';

@Injectable({
  providedIn: 'root',
})
export class TestApiService {
  private baseUrl = 'tests';
  constructor(private http: HttpClient) {}

  public getAssignedTests() {
    const url = this.getUrl('assigned');
    return this.http.get<IAssignedTest[]>(url);
  }

  public getIncompleteTests() {
    const url = this.getUrl('incomplete');
    return this.http.get<IAssignedTest[]>(url);
  }

  public getCompletedTests() {
    const url = this.getUrl('completed');
    return this.http.get<IAssignedTest[]>(url);
  }

  private getUrl(endpoint: string) {
    return `${environment.apiUrl}${this.baseUrl}/${endpoint}`;
  }
}
