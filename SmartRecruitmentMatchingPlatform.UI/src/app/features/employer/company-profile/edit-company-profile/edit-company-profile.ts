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

import { EmployerService } from '../../services/employer.service';

@Component({
  selector: 'app-edit-company-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './edit-company-profile.html',
  styleUrl: './edit-company-profile.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditCompanyProfile {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);

  // Reserved for API integration
  private readonly employerService = inject(EmployerService);

  readonly form = this.fb.nonNullable.group({
    companyName: ['', [Validators.required, Validators.maxLength(150)]],
    companyDescription: [''],
    industry: [''],
    companyLocation: [''],
    website: ['', Validators.pattern(/^https?:\/\/.+/)]
  });

  updateProfile(): void {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log('Update Profile', this.form.getRawValue());

    // Backend API call will be connected later.
  }

  cancel(): void {
    this.router.navigate(['/employer/company-profile']);
  }

}