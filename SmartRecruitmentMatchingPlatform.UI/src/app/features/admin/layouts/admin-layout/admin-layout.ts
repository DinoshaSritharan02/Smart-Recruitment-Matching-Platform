import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-admin-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './admin-layout.html',
  styleUrl: './admin-layout.css'


})
export class AdminLayout {

  menuItems = [
    {
      label: 'Dashboard',
      icon: '📊',
      route: '/admin'
    },
    {
      label: 'Users',
      icon: '👥',
      route: '/admin/users'
    },
    {
      label: 'Employers',
      icon: '🏢',
      route: '/admin/employers'
    },
    {
      label: 'Jobs',
      icon: '💼',
      route: '/admin/jobs'
    },
    {
      label: 'Job Seekers',
      icon: '🧑‍💻',
      route: '/admin/job-seekers'
    },
    {
      label: 'Reports',
      icon: '📈',
      route: '/admin/reports'
    },
    {
      label: 'Settings',
      icon: '⚙️',
      route: '/admin/settings'
    }
  ];

}