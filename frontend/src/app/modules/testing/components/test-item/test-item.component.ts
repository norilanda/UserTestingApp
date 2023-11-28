import { Router } from '@angular/router';
import { IAssignedTest } from './../../../../core/models/IAssignedTest';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-test-item',
  templateUrl: './test-item.component.html',
  styleUrls: ['./test-item.component.sass'],
})
export class TestItemComponent {
  @Input() test!: IAssignedTest;

  constructor(private router: Router) {}

  public isCompleted() {
    return this.test.mark !== null && this.test.mark !== undefined;
  }

  public goToPass() {
    this.router.navigate(['/pass-test', this.test.id]);
  }
}
