import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Vacancy } from '../models/vacancy.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = '/api/vacancies';

  getAllVacancies(): Observable<Vacancy[]> {
    return this.http.get<Vacancy[]>(this.apiUrl);
  }

  getVacancyById(id: number): Observable<Vacancy> {
    return this.http.get<Vacancy>(`${this.apiUrl}/${id}`);
  }

  createVacancy(request: Vacancy): Observable<Vacancy> {
    return this.http.post<Vacancy>(this.apiUrl, request);
  }

  updateVacancy(id: number, request: Vacancy): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, request);
  }

  closeVacancy(id: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}/close`, {});
  }

  deleteVacancy(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}