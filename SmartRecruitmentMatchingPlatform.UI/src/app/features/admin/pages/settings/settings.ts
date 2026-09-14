import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './settings.html',
  styleUrl: './settings.css'
})
export class Settings {

  systemSettings = {
    platformName: 'Smart Recruitment Matching Platform',
    version: '1.0.0',
    emailNotifications: true,
    maintenanceMode: false,
    lastBackup: '2026-09-09',
    adminEmail: 'admin@smartrecruitment.com'
  };

}