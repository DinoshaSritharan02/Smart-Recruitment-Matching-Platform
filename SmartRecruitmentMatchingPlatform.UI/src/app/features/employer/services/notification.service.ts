import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl =
    `${environment.apiUrl}/notifications`;

  getMyNotifications(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  markAsRead(id: number) {
    return this.http.put(
      `${this.apiUrl}/${id}/read`,
      {}
    );
  }
}