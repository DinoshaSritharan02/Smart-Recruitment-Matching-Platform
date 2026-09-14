import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminService } from '../../services/admin';
import { DashboardStatistics } from '../../models/dashboard-statistics';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard implements OnInit {

  private adminService = inject(AdminService);

  statistics?: DashboardStatistics;

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard(): void {
    this.adminService.getDashboard().subscribe({
      next: (response) => {
        this.statistics = response;
      },
      error: (error) => {
        console.error(error);
      }
    });
  }
}