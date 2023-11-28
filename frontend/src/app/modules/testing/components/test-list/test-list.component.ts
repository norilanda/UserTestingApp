import { Observable } from 'rxjs';
import { Component, Input } from '@angular/core';
import { IAssignedTest } from 'src/app/core/models/IAssignedTest';

@Component({
  selector: 'app-test-list',
  templateUrl: './test-list.component.html',
  styleUrls: ['./test-list.component.sass'],
})
export class TestListComponent {
  @Input() tests$: Observable<IAssignedTest[]> = new Observable<
    IAssignedTest[]
  >();
}
