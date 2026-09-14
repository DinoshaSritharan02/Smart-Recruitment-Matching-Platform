import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  VacancyResponse,
  CreateVacancyRequest,
  UpdateVacancyRequest,
  VacancySearchRequest
} from '../models/vacancy.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/vacancies`;

  /**
   * Employer - Get all vacancies created by the logged-in employer
   */
  getMyVacancies(): Observable<VacancyResponse[]> {
    return this.http.get<VacancyResponse[]>(
      `${this.apiUrl}/employer/mine`
    );
  }

  /**
   * Public - Get vacancy by id
   */
  getById(id: number): Observable<VacancyResponse> {
    return this.http.get<VacancyResponse>(
      `${this.apiUrl}/${id}`
    );
  }

  /**
   * Public - Search vacancies
   */
  search(
    request: VacancySearchRequest
  ): Observable<VacancyResponse[]> {

    return this.http.get<VacancyResponse[]>(
      `${this.apiUrl}/search`,
      {
        params: request as any
      }
    );
  }

  /**
   * Employer - Create vacancy
   */
  create(
    request: CreateVacancyRequest
  ): Observable<VacancyResponse> {

    return this.http.post<VacancyResponse>(
      this.apiUrl,
      request
    );
  }

  /**
   * Employer - Update vacancy
   */
  update(
    id: number,
    request: UpdateVacancyRequest
  ): Observable<VacancyResponse> {

    return this.http.put<VacancyResponse>(
      `${this.apiUrl}/${id}`,
      request
    );
  }
}