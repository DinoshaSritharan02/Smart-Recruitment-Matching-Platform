import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import {
  CommonModule
} from '@angular/common';

import {
  RouterLink
} from '@angular/router';

interface DashboardStats {
  vacancies: number;
  applications: number;
  interviews: number;
  hired: number;
}

interface Vacancy {
  id: number;
  title: string;
  location: string;
  status: string;
}

interface Applicant {
  id: number;
  fullName: string;
  position: string;
  matchScore: number;
}
interface DashboardCard {
  title: string;
  value: number;
  icon: string;
  color: string;
}

@Component({
  selector: 'app-employer-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './employer-dashboard.html',
  styleUrl: './employer-dashboard.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployerDashboard {

  readonly stats = signal<DashboardStats>({
    vacancies: 12,
    applications: 58,
    interviews: 9,
    hired: 4
  });
  readonly cards = signal<DashboardCard[]>([
  {
    title: 'Active Vacancies',
    value: this.stats().vacancies,
    icon: '💼',
    color: 'bg-emerald-700'
  },
  {
    title: 'Applications',
    value: this.stats().applications,
    icon: '📄',
    color: 'btn-primary'
  },
  {
    title: 'Interviews',
    value: this.stats().interviews,
    icon: '📅',
    color: 'bg-teal-600'
  },
  {
    title: 'Hired',
    value: this.stats().hired,
    icon: '✔',
    color: 'bg-green-700'
  }
]);
  readonly recentVacancies = signal<Vacancy[]>([
    {
      id: 1,
      title: 'Frontend Developer',
      location: 'Colombo',
      status: 'Active'
    },
    {
      id: 2,
      title: 'Backend Developer',
      location: 'Kandy',
      status: 'Active'
    },
    {
      id: 3,
      title: 'UI/UX Designer',
      location: 'Remote',
      status: 'Closed'
    }
  ]);

  readonly recentApplicants = signal<Applicant[]>([
    {
      id: 1,
      fullName: 'John Silva',
      position: 'Frontend Developer',
      matchScore: 94
    },
    {
      id: 2,
      fullName: 'Nimal Perera',
      position: 'Backend Developer',
      matchScore: 89
    },
    {
      id: 3,
      fullName: 'Kasun Fernando',
      position: 'UI Designer',
      matchScore: 86
    }
  ]);

}