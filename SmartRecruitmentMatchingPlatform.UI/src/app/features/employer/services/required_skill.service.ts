import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { RequiredSkill } from '../models/required-skill.model';

@Injectable({
  providedIn: 'root'
})
export class RequiredSkillService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = '/api/required-skills';

  getSkills(vacancyId: number): Observable<RequiredSkill[]> {
    return this.http.get<RequiredSkill[]>(`${this.apiUrl}/${vacancyId}`);
  }

  addSkill(
    vacancyId: number,
    request: RequiredSkill
  ): Observable<RequiredSkill> {

    return this.http.post<RequiredSkill>(
      `${this.apiUrl}/${vacancyId}`,
      request
    );

  }

  deleteSkill(skillId: number): Observable<void> {

    return this.http.delete<void>(
      `${this.apiUrl}/${skillId}`
    );

  }

}