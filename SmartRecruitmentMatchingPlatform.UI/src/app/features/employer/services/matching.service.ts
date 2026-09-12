import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import { MatchResult } from '../models/matching.model';

@Injectable({
  providedIn: 'root'
})
export class MatchingService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/Matching`;

  getMatches(userId: string): Observable<MatchResult[]> {
    return this.http.get<MatchResult[]>(
      `${this.apiUrl}/${userId}`
    );
  }

  getRankedApplicants(vacancyId: number): Observable<MatchResult[]> {
    return this.http.get<MatchResult[]>(
      `${this.apiUrl}/ranked-applicants/${vacancyId}`
    );
  }

}