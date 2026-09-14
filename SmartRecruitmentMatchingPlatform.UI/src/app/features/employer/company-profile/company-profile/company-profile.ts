import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  inject
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { RouterLink } from '@angular/router';

import { EmployerService } from '../../services/employer.service';

@Component({
  selector: 'app-company-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './company-profile.html',
  styleUrl: './company-profile.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CompanyProfile implements OnInit {

  private readonly fb = inject(FormBuilder);
  private readonly employerService = inject(EmployerService);

  readonly form = this.fb.nonNullable.group({
    companyName: ['', Validators.required],
    companyDescription: [''],
    industry: [''],
    companyLocation: [''],
    website: ['']
  });

  loading = false;

  ngOnInit(): void {
    this.loadProfile();
  }

  loadProfile(): void {

    this.loading = true;

    this.employerService.getProfile().subscribe({

      next: profile => {

        this.form.patchValue({
          companyName: profile.companyName,
          companyDescription: profile.companyDescription ?? '',
          industry: profile.industry ?? '',
          companyLocation: profile.companyLocation ?? '',
          website: profile.website ?? ''
        });

        this.loading = false;

      },

      error: () => {

        this.loading = false;

      }

    });

  }

 save(): void {

  if (this.form.invalid) {
    this.form.markAllAsTouched();
    return;
  }

  const request = this.form.getRawValue();

  this.employerService.getProfile().subscribe({

    next: () => {

      this.employerService.updateProfile(request)
        .subscribe();

    },

    error: () => {

      this.employerService.createProfile(request)
        .subscribe();

    }

  });

}

}