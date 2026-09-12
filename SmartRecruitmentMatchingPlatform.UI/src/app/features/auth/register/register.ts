import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {

  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  registerForm = this.fb.group({
    registerAs: ['JobSeeker', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    confirmPassword: ['', Validators.required]
  });

  register(): void {

    if (this.registerForm.invalid) {
      this.registerForm.markAllAsTouched();
      return;
    }

    const dto = {
      firstName: this.registerForm.value.firstName ?? '',
      lastName: this.registerForm.value.lastName ?? '',
      email: this.registerForm.value.email ?? '',
      password: this.registerForm.value.password ?? '',
      confirmPassword: this.registerForm.value.confirmPassword ?? ''
    };

    if (this.registerForm.value.registerAs === 'Employer') {

      this.authService.registerEmployer(dto).subscribe({
        next: () => {
          alert('Employer account created successfully.');
          this.router.navigate(['/login']);
        },
        error: err => {
  console.error(err);
  console.log('Status:', err.status);
  console.log('Error:', err.error);
  alert(`Status: ${err.status}\n${JSON.stringify(err.error)}`);
}
      });

    } else {

      this.authService.registerJobSeeker(dto).subscribe({
        next: () => {
          alert('Job Seeker account created successfully.');
          this.router.navigate(['/login']);
        },
        error: err => {
  console.error(err);
  console.log('Status:', err.status);
  console.log('Error:', err.error);
  alert(`Status: ${err.status}\n${JSON.stringify(err.error)}`);
}
      });

    }

  }

}