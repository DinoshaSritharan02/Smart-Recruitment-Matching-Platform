import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  ContactRequestResponse,
  CreateContactRequestRequest,
  UpdateContactRequestStatusRequest
} from '../models/contact-request.model';

@Injectable({
  providedIn: 'root'
})
export class ContactRequestService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/contactrequests`;

  getRequests(): Observable<ContactRequestResponse[]> {
    return this.http.get<ContactRequestResponse[]>(this.apiUrl);
  }

  create(
    request: CreateContactRequestRequest
  ): Observable<ContactRequestResponse> {
    return this.http.post<ContactRequestResponse>(
      this.apiUrl,
      request
    );
  }

  updateStatus(
    id: number,
    request: UpdateContactRequestStatusRequest
  ): Observable<void> {
    return this.http.put<void>(
      `${this.apiUrl}/${id}/status`,
      request
    );
  }

}