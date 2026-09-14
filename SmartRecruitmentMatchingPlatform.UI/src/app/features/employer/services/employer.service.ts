import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RankedApplicant } from '../models/ranked-applicant.model';
import { environment } from '../../../../environments/environment';
import { UpdateApplicationStatusRequest } from '../models/update-application-status.model';

import {
  EmployerProfile,
  UpdateEmployerProfileRequest
} from '../models/employer-profile.model';

@Injectable({
  providedIn: 'root'
})
export class EmployerService {

  private readonly http = inject(HttpClient);

 private readonly profileApi = `${environment.apiUrl}/employer/profile`;

private readonly applicationApi = `${environment.apiUrl}/applications`;

  getProfile(): Observable<EmployerProfile> {
  return this.http.get<EmployerProfile>(this.profileApi);
}

createProfile(request: UpdateEmployerProfileRequest) {
  return this.http.post<EmployerProfile>(
    this.profileApi,
    request
  );
}

updateProfile(request: UpdateEmployerProfileRequest) {
  return this.http.put<EmployerProfile>(
    this.profileApi,
    request
  );
}

getRankedApplicants(vacancyId: number) {
  return this.http.get<RankedApplicant[]>(
    `${this.applicationApi}/vacancy/${vacancyId}/ranked`
  );
}
updateApplicationStatus(
  applicationId: number,
  request: UpdateApplicationStatusRequest
) {
  return this.http.put(
    `${this.applicationApi}/${applicationId}/status`,
    request
  );
}
}