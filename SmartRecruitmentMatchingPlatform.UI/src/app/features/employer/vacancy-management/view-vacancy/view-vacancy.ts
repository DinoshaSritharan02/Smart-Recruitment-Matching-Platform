import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

interface VacancyDetails {

  id: number;

  jobTitle: string;

  description: string;

  employmentType: string;

  experienceLevel: string;

  location: string;

  salaryMin: number;

  salaryMax: number;

  applicationDeadline: string;

  status: string;

}

@Component({
  selector: 'app-view-vacancy',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './view-vacancy.html',
  styleUrl: './view-vacancy.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ViewVacancy {

  readonly vacancy = signal<VacancyDetails>({
    id: 1,
    jobTitle: 'Frontend Developer',
    description: 'Develop Angular applications using Angular 21.',
    employmentType: 'Full Time',
    experienceLevel: 'Mid Level',
    location: 'Colombo',
    salaryMin: 150000,
    salaryMax: 250000,
    applicationDeadline: '2026-10-15',
    status: 'Active'
  });

}