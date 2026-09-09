import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface Job {
  id: number;
  title: string;
  company: string;
  location: string;
  type: string;
  status: 'Open' | 'Closed';
}

@Component({
  selector: 'app-jobs',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './jobs.html'
})
export class Jobs {

  jobs: Job[] = [
    {
      id: 1,
      title: 'Frontend Developer',
      company: 'ABC Technologies',
      location: 'Colombo',
      type: 'Full Time',
      status: 'Open'
    },
    {
      id: 2,
      title: 'Backend Developer',
      company: 'XYZ Solutions',
      location: 'Jaffna',
      type: 'Hybrid',
      status: 'Open'
    },
    {
      id: 3,
      title: 'UI/UX Designer',
      company: 'Tech Lanka',
      location: 'Kandy',
      type: 'Remote',
      status: 'Closed'
    }
  ];

}