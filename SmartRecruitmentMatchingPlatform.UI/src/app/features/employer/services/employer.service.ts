import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import {
  EmployerProfile,
  UpdateEmployerProfileRequest,
} from '../models/employer-profile.model';

@Injectable({
  providedIn: 'root',
})
export class EmployerService {

  private readonly http = inject(HttpClient);

  // TODO: Replace with environment.apiUrl during integration
  private readonly apiUrl = '/api/employer';

  getProfile(): Observable<EmployerProfile> {
    return this.http.get<EmployerProfile>(
      `${this.apiUrl}/profile`
    );
  }

  updateProfile(
    request: UpdateEmployerProfileRequest
  ): Observable<EmployerProfile> {
    return this.http.put<EmployerProfile>(
      `${this.apiUrl}/profile`,
      request
    );
  }

}