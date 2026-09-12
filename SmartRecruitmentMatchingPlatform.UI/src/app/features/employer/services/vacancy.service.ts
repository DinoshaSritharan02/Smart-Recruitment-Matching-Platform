import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import {
  CreateVacancyRequest,
  UpdateVacancyRequest,
  VacancyListItem,
  VacancyResponse,
  VacancySearchRequest
} from '../models/vacancy.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/vacancies`;

  getById(id: number): Observable<VacancyResponse> {
    return this.http.get<VacancyResponse>(`${this.apiUrl}/${id}`);
  }

  search(request: VacancySearchRequest): Observable<VacancyListItem[]> {

    let params = new HttpParams();

    if (request.keyword) {
      params = params.set('keyword', request.keyword);
    }

    if (request.location) {
      params = params.set('location', request.location);
    }

    if (request.minExperienceYears !== undefined) {
      params = params.set(
        'minExperienceYears',
        request.minExperienceYears
      );
    }

    if (request.maxExperienceYears !== undefined) {
      params = params.set(
        'maxExperienceYears',
        request.maxExperienceYears
      );
    }

    if (request.skillId !== undefined) {
      params = params.set(
        'skillId',
        request.skillId
      );
    }

    return this.http.get<VacancyListItem[]>(
      `${this.apiUrl}/search`,
      { params }
    );
  }

  getMyVacancies(): Observable<VacancyListItem[]> {
    return this.http.get<VacancyListItem[]>(
      `${this.apiUrl}/employer/mine`
    );
  }

  create(
    request: CreateVacancyRequest
  ): Observable<VacancyResponse> {

    return this.http.post<VacancyResponse>(
      this.apiUrl,
      request
    );
  }

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