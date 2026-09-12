import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  EmployerProfile,
  UpdateEmployerProfileRequest
} from '../models/employer-profile.model';

@Injectable({
  providedIn: 'root'
})
export class EmployerService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/employer/profile`;

  getProfile(): Observable<EmployerProfile> {
    return this.http.get<EmployerProfile>(this.apiUrl);
  }

  createProfile(
    request: UpdateEmployerProfileRequest
  ): Observable<EmployerProfile> {
    return this.http.post<EmployerProfile>(
      this.apiUrl,
      request
    );
  }

  updateProfile(
    request: UpdateEmployerProfileRequest
  ): Observable<EmployerProfile> {
    return this.http.put<EmployerProfile>(
      this.apiUrl,
      request
    );
  }
}