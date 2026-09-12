import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { JobSeekerProfile } from '../models/profile.model';
import { UpdateJobSeekerProfile } from '../models/update-job-seeker-profile.model';
import { Education } from '../models/education';
import { Experience } from '../models/experience.model';
import { Skill } from '../models/skill.model';
import { CreateSkill } from '../models/create-skill.model';
import { AddSkill } from '../models/add-skill.model';
import { CvMetadata } from '../models/cv-metadata.model';

@Injectable({
  providedIn: 'root'
})
export class JobSeekerService {

  private http = inject(HttpClient);

  private api = `${environment.apiUrl}/JobSeeker`;

  private skillApi = `${environment.apiUrl}/vacancies/skills`;

  getProfile(): Observable<JobSeekerProfile> {

    return this.http.get<JobSeekerProfile>(
      `${this.api}/profile`
    );

  }

  updateProfile(dto: UpdateJobSeekerProfile): Observable<void> {

    return this.http.put<void>(
      `${this.api}/profile`,
      dto
    );

  }
  addEducation(dto: Education): Observable<void> {

  return this.http.post<void>(
    `${this.api}/education`,
    dto
  );

}

updateEducation(id: string, dto: Education): Observable<void> {

  return this.http.put<void>(
    `${this.api}/education/${id}`,
    dto
  );

}

deleteEducation(id: string): Observable<void> {

  return this.http.delete<void>(
    `${this.api}/education/${id}`
  );

}
addExperience(dto: Experience): Observable<void> {

  return this.http.post<void>(
    `${this.api}/experience`,
    dto
  );

}

updateExperience(id: string, dto: Experience): Observable<void> {

  return this.http.put<void>(
    `${this.api}/experience/${id}`,
    dto
  );

}

deleteExperience(id: string): Observable<void> {

  return this.http.delete<void>(
    `${this.api}/experience/${id}`
  );

}
getAllSkills(): Observable<Skill[]> {
  return this.http.get<Skill[]>(this.skillApi);
}

createSkill(dto: CreateSkill): Observable<Skill> {
  return this.http.post<Skill>(this.skillApi, dto);
}

addSkill(dto: AddSkill): Observable<void> {
  return this.http.post<void>(
    `${this.api}/skills`,
    dto
  );
}

removeSkill(skillId: number): Observable<void> {
  return this.http.delete<void>(
    `${this.api}/skills/${skillId}`
  );
}
getCvMetadata() {
  return this.http.get<CvMetadata>(
    `${this.api}/cv`
  );
}

uploadCv(file: File): Observable<any> {

  const formData = new FormData();

  formData.append('File', file);

  return this.http.post(
    `${this.api}/cv/upload`,
    formData
  );

}

downloadCv(): Observable<Blob> {

  return this.http.get(
    `${this.api}/cv/download`,
    {
      responseType: 'blob'
    }
  );

}

}