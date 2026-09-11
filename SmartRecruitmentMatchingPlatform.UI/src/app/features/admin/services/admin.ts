import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

import { DashboardStatistics } from '../models/dashboard-statistics';
import { UserSummary } from '../models/user-summary';
import { UserDetails } from '../models/user-details';
import { UpdateUserStatus } from '../models/update-user-status';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  private http = inject(HttpClient);

  private apiUrl = environment.apiUrl;

  getDashboard(): Observable<DashboardStatistics> {
    return this.http.get<DashboardStatistics>(
      `${this.apiUrl}/admin/dashboard`
    );
  }

 getUsers(): Observable<UserSummary[]> {
  return this.http.get<UserSummary[]>(
    `${this.apiUrl}/admin/users`
  );
}
  getUser(id: string): Observable<UserDetails> {
    return this.http.get<UserDetails>(
      `${this.apiUrl}/admin/users/${id}`
    );
  }
getUserById(id: string) {
  return this.http.get<UserDetails>(
    `${this.apiUrl}/admin/users/${id}`
  );
}

 updateUserStatus(id: string, body: { isActive: boolean }) {
    return this.http.patch(
      `${this.apiUrl}/admin/users/${id}/status`,
      body
    );
  }
}