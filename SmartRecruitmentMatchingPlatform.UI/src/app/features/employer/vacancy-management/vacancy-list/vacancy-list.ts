import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

interface Vacancy {
  id: number;
  jobTitle: string;
  location: string;
  salary: number;
  status: string;
  applications: number;
}

@Component({
  selector: 'app-vacancy-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './vacancy-list.html',
  styleUrl: './vacancy-list.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class VacancyList {

  readonly vacancies = signal<Vacancy[]>([
    {
      id: 1,
      jobTitle: 'Frontend Developer',
      location: 'Colombo',
      salary: 180000,
      status: 'Active',
      applications: 12
    },
    {
      id: 2,
      jobTitle: 'Backend Developer',
      location: 'Jaffna',
      salary: 200000,
      status: 'Active',
      applications: 8
    },
    {
      id: 3,
      jobTitle: 'UI/UX Designer',
      location: 'Kandy',
      salary: 150000,
      status: 'Closed',
      applications: 15
    }
  ]);

}