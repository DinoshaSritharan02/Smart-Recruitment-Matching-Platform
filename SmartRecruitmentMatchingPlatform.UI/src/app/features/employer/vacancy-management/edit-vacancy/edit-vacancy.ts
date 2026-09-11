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

import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-edit-vacancy',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './edit-vacancy.html',
  styleUrl: './edit-vacancy.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditVacancy {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);

  readonly form = this.fb.nonNullable.group({
    jobTitle: ['', [Validators.required, Validators.maxLength(150)]],
    jobDescription: ['', Validators.required],
    employmentType: ['', Validators.required],
    experienceLevel: ['', Validators.required],
    location: ['', Validators.required],
    salaryMin: [0, Validators.min(0)],
    salaryMax: [0, Validators.min(0)],
    applicationDeadline: ['', Validators.required]
  });

  updateVacancy(): void {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log(this.form.getRawValue());

    // Backend integration later

  }

  cancel(): void {
    this.router.navigate(['/employer/dashboard']);
  }

}