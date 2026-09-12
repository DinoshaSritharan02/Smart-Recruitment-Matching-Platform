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
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  });

  login(): void {

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.authService.login(this.loginForm.getRawValue() as any)
      .subscribe({

        next: response => {

          this.authService.saveAuth(response);

          switch (response.role) {

            case 'Admin':
              this.router.navigate(['/admin']);
              break;

            case 'Employer':
              this.router.navigate(['/employer']);
              break;

            case 'JobSeeker':
              this.router.navigate(['/job-seeker']);
              break;

            default:
              this.router.navigate(['/']);
              break;
          }

        },

        error: err => {
          console.error(err);
          alert('Invalid email or password.');
        }

      });

  }

}