import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

interface NavigationItem {
  label: string;
  route: string;
  icon: string;
}

@Component({
  selector: 'app-employer-sidebar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './employer-sidebar.html',
  styleUrl: './employer-sidebar.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployerSidebar {
  @Input() isOpen = false;

  @Output() closeSidebar = new EventEmitter<void>();

  readonly navigationItems: NavigationItem[] = [
    {
      label: 'Dashboard',
      route: '/employer/dashboard',
      icon: '🏠',
    },
    {
      label: 'Company Profile',
      route: '/employer/company-profile',
      icon: '🏢',
    },
    {
      label: 'Vacancies',
      route: '/employer/vacancies',
      icon: '💼',
    },
    {
      label: 'Applicants',
      route: '/employer/applicants',
      icon: '👨‍💼',
    },
    {
      label: 'Contact Requests',
      route: '/employer/contact-requests',
      icon: '📩',
    },
  ];

  close(): void {
    this.closeSidebar.emit();
  }
}