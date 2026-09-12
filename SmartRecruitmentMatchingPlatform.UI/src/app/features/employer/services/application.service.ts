import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  ApplicationResponse,
  RankedApplicantResponse,
  UpdateApplicationStatusRequest
} from '../models/application.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/applications`;

  applyForVacancy(
    vacancyId: number
  ): Observable<{ message: string }> {

    return this.http.post<{ message: string }>(
      `${this.apiUrl}/vacancy/${vacancyId}/apply`,
      {}
    );
  }

  getRankedApplicants(
    vacancyId: number
  ): Observable<RankedApplicantResponse[]> {

    return this.http.get<RankedApplicantResponse[]>(
      `${this.apiUrl}/vacancy/${vacancyId}/ranked`
    );
  }

  updateStatus(
    applicationId: number,
    request: UpdateApplicationStatusRequest
  ): Observable<{ message: string }> {

    return this.http.put<{ message: string }>(
      `${this.apiUrl}/${applicationId}/status`,
      request
    );
  }

}