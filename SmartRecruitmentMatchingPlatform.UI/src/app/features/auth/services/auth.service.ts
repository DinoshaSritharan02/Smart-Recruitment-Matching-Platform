import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import { LoginRequest } from '../models/login-request.model';
import { AuthResponse } from '../models/auth-response.model';
import { RegisterJobSeekerRequest } from '../models/register-job-seeker-request.model';
import { RegisterEmployerRequest } from '../models/register-employer-request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);

  private api = `${environment.apiUrl}/Auth`;

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(
      `${this.api}/login`,
      request
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('email');
    localStorage.removeItem('expiresAt');
  }

  saveAuth(response: AuthResponse): void {
    localStorage.setItem('token', response.token);
    localStorage.setItem('role', response.role);
    localStorage.setItem('email', response.email);
    localStorage.setItem('expiresAt', response.expiresAt);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  getRole(): string | null {
    return localStorage.getItem('role');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
  registerJobSeeker(dto: RegisterJobSeekerRequest) {

  return this.http.post(
    `${this.api}/register/jobseeker`,
    dto
  );

}

registerEmployer(dto: RegisterEmployerRequest) {

  return this.http.post(
    `${this.api}/register/employer`,
    dto
  );

}
}