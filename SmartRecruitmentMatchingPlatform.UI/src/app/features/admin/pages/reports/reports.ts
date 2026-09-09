import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reports',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reports.html'
})
export class Reports {

  reports = [
    { title: 'Total Users', value: 1250 },
    { title: 'Total Employers', value: 180 },
    { title: 'Total Job Seekers', value: 1070 },
    { title: 'Total Vacancies', value: 95 }
  ];

}