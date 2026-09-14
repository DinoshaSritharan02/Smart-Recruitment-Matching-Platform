import {
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-employer-notifications',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employer-notifications.html'
})
export class EmployerNotifications implements OnInit {

  private readonly service = inject(NotificationService);

  readonly notifications = signal<any[]>([]);

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.service.getMyNotifications().subscribe({
      next: data => this.notifications.set(data),
      error: () => alert('Failed to load notifications.')
    });
  }

  read(id: number): void {
    this.service.markAsRead(id).subscribe({
      next: () => this.load()
    });
  }
}