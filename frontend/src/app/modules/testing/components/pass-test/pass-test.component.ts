import { Observable, take } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { TestService } from 'src/app/core/services/test.service';
import { ITest } from 'src/app/core/models/ITest';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { IAnswer } from 'src/app/core/models/IAnswer';

@Component({
  selector: 'app-pass-test',
  templateUrl: './pass-test.component.html',
  styleUrls: ['./pass-test.component.sass'],
})
export class PassTestComponent implements OnInit {
  private testId: number;

  public testDetails: ITest | null = null;

  public testForm = this.formBuilder.group({});

  public mark: number | null = null;

  constructor(
    private testService: TestService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder
  ) {
    this.testId = Number(this.route.snapshot.paramMap.get('id'));
  }

  ngOnInit(): void {
    this.testService
      .getTestDetailsById(this.testId)
      .pipe(take(1))
      .subscribe((test) => {
        this.testDetails = test;
        if (this.testDetails && this.testDetails.tasks) {
          this.testDetails.tasks.forEach((task) => {
            const controlName = this.getFormControllName(task.number);
            this.testForm.addControl(
              controlName,
              new FormControl('', [Validators.required])
            );
          });
        }
      });
  }

  canSubmit() {
    return !this.testForm.invalid && this.mark === null;
  }

  onSubmit() {
    const answers: IAnswer[] =
      this.testDetails?.tasks.map((task) => {
        return {
          taskId: task.id,
          answer:
            this.testForm.get(this.getFormControllName(task.number))?.value ??
            '',
        } as IAnswer;
      }) ?? [];

    this.testService
      .passTest(this.testDetails!.id, answers)
      .pipe(take(1))
      .subscribe((mark) => {
        this.mark = mark;
      });
  }

  private getFormControllName(taskNumber: number) {
    return `answer_${taskNumber}`;
  }
}
