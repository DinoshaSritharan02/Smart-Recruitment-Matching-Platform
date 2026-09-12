import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';

import { JobSeekerService } from '../services/job-seeker.service';

@Component({
  selector: 'app-edit-profile',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './edit-profile.html',
  styleUrl: './edit-profile.css'
})
export class EditProfile implements OnInit {

  private fb = inject(FormBuilder);
  private service = inject(JobSeekerService);
  private router = inject(Router);

  loading = true;
  saving = false;

  form = this.fb.group({

    phoneNumber: ['', Validators.required],

    dateOfBirth: ['', Validators.required],

    gender: ['', Validators.required],

    address: ['', Validators.required],

    city: ['', Validators.required],

    country: ['', Validators.required],

    professionalSummary: ['']

  });

  ngOnInit(): void {

    this.service.getProfile().subscribe({

      next: profile => {

        this.form.patchValue({

          phoneNumber: profile.phoneNumber,

          dateOfBirth: profile.dateOfBirth.substring(0, 10),

          gender: profile.gender,

          address: profile.address,

          city: profile.city,

          country: profile.country,

          professionalSummary: profile.professionalSummary

        });

        this.loading = false;

      },

      error: () => {

        alert('Failed to load profile.');

        this.loading = false;

      }

    });

  }

  save(): void {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;

    }

    this.saving = true;

    this.service.updateProfile(this.form.getRawValue() as any).subscribe({

      next: () => {

        alert('Profile updated successfully.');

        this.router.navigate(['/job-seeker/profile']);

      },

      error: () => {

        alert('Failed to update profile.');

        this.saving = false;

      }

    });

  }

  cancel(): void {

    this.router.navigate(['/job-seeker/profile']);

  }

}