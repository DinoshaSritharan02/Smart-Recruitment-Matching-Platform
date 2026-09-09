import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

interface DashboardCard {
  title: string;
  value: number;
  icon: string;
}

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

  cards = signal<DashboardCard[]>([
    {
      title: 'Total Users',
      value: 0,
      icon: '👥'
    },
    {
      title: 'Employers',
      value: 0,
      icon: '🏢'
    },
    {
      title: 'Job Seekers',
      value: 0,
      icon: '🧑‍💼'
    },
    {
      title: 'Vacancies',
      value: 0,
      icon: '📄'
    },
    {
      title: 'Applications',
      value: 0,
      icon: '📨'
    }
  ]);

user = {
  status: 'Active'
};
}