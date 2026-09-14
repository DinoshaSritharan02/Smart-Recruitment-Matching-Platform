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
  imports: [
  RouterLink,
  RouterLinkActive,
 
],
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
    icon: '⌂',
  },
  {
    label: 'Company Profile',
    route: '/employer/company-profile',
    icon: '🏢',
  },
  {
    label: 'Vacancies',
    route: '/employer/vacancies',
    icon: '📄',
  },
  
  {
    label: 'Contact Request',
    route: '/employer/contact-request',
    icon: '✉',
  },
  {
    label: 'Create Vacancy',
    route: '/employer/create-vacancy',
    icon: '＋',
  },
  {
    label: 'Required Skills',
    route: '/employer/required-skills',
    icon: '✓',
  },
  {
    label: 'Application Status',
    route: '/employer/application-status',
    icon: '📊',
  },
  {
    label: 'Interviews',
    route: '/employer/interviews',
    icon: '🎤',
  },
  {
    label: 'Schedule Interview',
    route: '/employer/schedule-interview',
    icon: '📅',
  },
  {
    label: 'Notifications',
    route: '/employer/notifications',
    icon: '🔔',
  },
  {
    label: 'Settings',
    route: '/employer/settings',
    icon: '⚙',
  }

];

  close(): void {
    this.closeSidebar.emit();
  }
}