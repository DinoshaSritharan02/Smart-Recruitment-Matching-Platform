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
  selector: 'app-create-company-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './create-company-profile.html',
  styleUrl: './create-company-profile.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateCompanyProfile {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);

  readonly form = this.fb.group({
    companyName: ['', [Validators.required, Validators.maxLength(150)]],
    companyDescription: [''],
    industry: [''],
    companyLocation: [''],
    website: ['', Validators.pattern('https?://.+')]
  });

  save(): void {

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    console.log(this.form.value);

    // Backend integration later
  }

  cancel(): void {
    this.router.navigate(['/employer/company-profile']);
  }
}