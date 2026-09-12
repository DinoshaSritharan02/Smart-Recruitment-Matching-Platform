import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css'
})
export class Dashboard {

  stats = [
    {
      title: 'Applications',
      value: 12,
      icon: '📄'
    },
    {
      title: 'Interviews',
      value: 3,
      icon: '🎯'
    },
    {
      title: 'Saved Jobs',
      value: 8,
      icon: '❤️'
    },
    {
      title: 'Profile Completion',
      value: '85%',
      icon: '👤'
    }
  ];

}