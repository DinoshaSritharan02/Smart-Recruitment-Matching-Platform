import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';

import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-application-status-update',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './application-status-update.html',
  styleUrl: './application-status-update.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ApplicationStatusUpdate {

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({
    status: ['', Validators.required]
  });

  readonly statuses = [
    'Pending',
    'Reviewed',
    'Shortlisted',
    'Interview Scheduled',
    'Rejected',
    'Hired'
  ];

  save(): void {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log(this.form.getRawValue());

  }

}