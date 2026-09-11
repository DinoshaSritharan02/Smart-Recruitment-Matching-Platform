import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

interface EmployerNotification {

  id: number;
  title: string;
  message: string;
  date: string;
  isRead: boolean;

}

@Component({
  selector: 'app-employer-notifications',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employer-notifications.html',
  styleUrl: './employer-notifications.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployerNotifications {

  readonly notifications = signal<EmployerNotification[]>([
    {
      id: 1,
      title: 'New Application',
      message: 'John Silva applied for Frontend Developer.',
      date: '2026-09-11',
      isRead: false
    },
    {
      id: 2,
      title: 'Interview Scheduled',
      message: 'Interview has been scheduled successfully.',
      date: '2026-09-10',
      isRead: true
    }
  ]);

}