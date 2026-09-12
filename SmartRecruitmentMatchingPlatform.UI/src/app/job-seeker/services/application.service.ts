import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Application } from '../models/application.model';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApplicationService {

  private http = inject(HttpClient);

  private api = `${environment.apiUrl}/applications`;

  apply(vacancyId: number): Observable<any> {

    return this.http.post(
      `${this.api}/vacancy/${vacancyId}/apply`,
      {}
    );

  }
  getMyApplications() {
  return this.http.get<Application[]>(
    `${this.api}/my`
  );}

}