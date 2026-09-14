import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';
import { SkillResponse } from '../models/required-skill.model';

@Injectable({
  providedIn: 'root'
})
export class RequiredSkillService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/vacancies/skills`;

  getAllSkills(): Observable<SkillResponse[]> {
    return this.http.get<SkillResponse[]>(this.apiUrl);
  }

  getSkillById(id: number): Observable<SkillResponse> {
    return this.http.get<SkillResponse>(
      `${this.apiUrl}/${id}`
    );
  }

}