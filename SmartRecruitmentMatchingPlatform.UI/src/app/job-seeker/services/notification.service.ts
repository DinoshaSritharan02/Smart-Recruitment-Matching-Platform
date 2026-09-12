import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { Notification } from '../models/notification.model';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private http = inject(HttpClient);

  private api = `${environment.apiUrl}/notifications`;

  getNotifications(): Observable<Notification[]> {

    return this.http.get<Notification[]>(this.api);

  }

  getUnreadNotifications(): Observable<Notification[]> {

    return this.http.get<Notification[]>(
      `${this.api}/unread`
    );

  }

  markAsRead(id: number): Observable<void> {

    return this.http.put<void>(
      `${this.api}/${id}/read`,
      {}
    );

  }

  deleteNotification(id: number): Observable<void> {

    return this.http.delete<void>(
      `${this.api}/${id}`
    );

  }

}