import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationService } from '../services/notification.service';
import { Notification } from '../models/notification.model';

@Component({
  selector: 'app-notifications',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notifications.html',
  styleUrl: './notifications.css'
})
export class Notifications implements OnInit {

  private notificationService = inject(NotificationService);

  notifications: Notification[] = [];

  loading = true;

  ngOnInit(): void {
    this.loadNotifications();
  }

  loadNotifications(): void {

    this.loading = true;

    this.notificationService.getNotifications().subscribe({

      next: (response) => {

        this.notifications = response;

        this.loading = false;

      },

      error: (err) => {

        console.error(err);

        this.loading = false;

        alert('Failed to load notifications.');

      }

    });

  }

  markAsRead(notification: Notification): void {

    if (notification.isRead) {
      return;
    }

    this.notificationService.markAsRead(notification.id).subscribe({

      next: () => {

        notification.isRead = true;

      },

      error: (err) => {

        console.error(err);

        alert('Failed to mark notification as read.');

      }

    });

  }

  deleteNotification(id: number): void {

    if (!confirm('Delete this notification?')) {
      return;
    }

    this.notificationService.deleteNotification(id).subscribe({

      next: () => {

        this.notifications = this.notifications.filter(
          n => n.id !== id
        );

      },

      error: (err) => {

        console.error(err);

        alert('Failed to delete notification.');

      }

    });

  }

}