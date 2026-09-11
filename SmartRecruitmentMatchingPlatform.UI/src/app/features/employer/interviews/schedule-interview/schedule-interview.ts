import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-schedule-interview',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './schedule-interview.html',
  styleUrl: './schedule-interview.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ScheduleInterview {

  private fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({
    applicantName: ['', Validators.required],
    vacancy: ['', Validators.required],
    interviewDate: ['', Validators.required],
    interviewTime: ['', Validators.required],
    interviewMode: ['', Validators.required],
    meetingLink: [''],
    interviewer: ['', Validators.required],
    notes: ['']
  });

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log(this.form.getRawValue());
  }
}