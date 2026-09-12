import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';
import { RouterLink } from '@angular/router';
import { JobSeekerService } from '../services/job-seeker.service';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './settings.html',
  styleUrl: './settings.css'
})
export class Settings implements OnInit {

  private fb = inject(FormBuilder);
  private jobSeekerService = inject(JobSeekerService);
  private router = inject(Router);

  loading = true;

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

    this.jobSeekerService.getProfile().subscribe({

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

    const dto = {
  phoneNumber: this.form.value.phoneNumber!,
  dateOfBirth: this.form.value.dateOfBirth!,
  gender: this.form.value.gender!,
  address: this.form.value.address!,
  city: this.form.value.city!,
  country: this.form.value.country!,
  professionalSummary: this.form.value.professionalSummary!
};

this.jobSeekerService.updateProfile(dto).subscribe({
      next: () => {

        alert('Profile updated successfully.');

        this.router.navigate(['/job-seeker/profile']);

      },

      error: () => {

        alert('Failed to update profile.');

      }

    });

  }

}