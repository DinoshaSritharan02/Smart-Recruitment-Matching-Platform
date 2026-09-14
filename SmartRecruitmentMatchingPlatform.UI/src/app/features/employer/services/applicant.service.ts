import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Applicant } from '../models/applicant.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicantService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = '/api/applications';

  getApplicants(vacancyId: number): Observable<Applicant[]> {
    return this.http.get<Applicant[]>(`${this.apiUrl}/vacancy/${vacancyId}`);
  }

  updateStatus(
    applicationId: number,
    status: string
  ): Observable<void> {

    return this.http.patch<void>(
      `${this.apiUrl}/${applicationId}/status`,
      { status }
    );

  }

  sendContactRequest(
    applicationId: number
  ): Observable<void> {

    return this.http.post<void>(
      `${this.apiUrl}/${applicationId}/contact-request`,
      {}
    );

  }

}