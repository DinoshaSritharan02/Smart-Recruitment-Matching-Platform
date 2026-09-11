import { ChangeDetectionStrategy, Component, computed, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

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
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployerDashboard {

  readonly cards = signal<DashboardCard[]>([
    {
      title: 'Active Vacancies',
      value: 0,
      icon: '💼',
      color: 'bg-blue-500'
    },
    {
      title: 'Applications',
      value: 0,
      icon: '📄',
      color: 'bg-green-500'
    },
    {
      title: 'Shortlisted',
      value: 0,
      icon: '⭐',
      color: 'bg-yellow-500'
    },
    {
      title: 'Contact Requests',
      value: 0,
      icon: '📩',
      color: 'bg-purple-500'
    }
  ]);

  readonly total = computed(() =>
    this.cards().reduce((sum, card) => sum + card.value, 0)
  );

}