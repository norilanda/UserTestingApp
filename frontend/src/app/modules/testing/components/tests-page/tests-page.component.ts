import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { TestService } from 'src/app/core/services/test.service';

@Component({
  selector: 'app-tests-page',
  templateUrl: './tests-page.component.html',
  styleUrls: ['./tests-page.component.sass'],
})
export class TestsPageComponent {
  public assignedTests$ = this.testService.assignedTests$;

  public incompleteTests$ = this.testService.incompleteTests$;

  public completedTests$ = this.testService.completedTests$;

  constructor(private testService: TestService, private router: Router) {}

  public goToLogin() {
    this.router.navigate(['/auth']);
  }
}
