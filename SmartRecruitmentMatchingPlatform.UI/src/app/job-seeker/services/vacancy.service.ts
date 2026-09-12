import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { Vacancy } from '../models/vacancy.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {

  private http = inject(HttpClient);

  private api = `${environment.apiUrl}/vacancies`;

  search(keyword = '', location = ''): Observable<Vacancy[]> {

    let params = new HttpParams();

    if (keyword) {
      params = params.set('Keyword', keyword);
    }

    if (location) {
      params = params.set('Location', location);
    }

    return this.http.get<Vacancy[]>(
      `${this.api}/search`,
      { params }
    );
  }

  getVacancyById(id: number): Observable<Vacancy> {
    return this.http.get<Vacancy>(`${this.api}/${id}`);
  }

}