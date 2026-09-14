import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  LoginRequest,
  RegisterEmployerRequest,
  RegisterJobSeekerRequest,
  AuthResponse
} from '../models/auth.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/Auth`;

  login(request: LoginRequest): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(
      `${this.apiUrl}/login`,
      request
    );
  }

  registerEmployer(
    request: RegisterEmployerRequest
  ): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(
      `${this.apiUrl}/register/employer`,
      request
    );
  }

  registerJobSeeker(
    request: RegisterJobSeekerRequest
  ): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(
      `${this.apiUrl}/register/jobseeker`,
      request
    );
  }
}