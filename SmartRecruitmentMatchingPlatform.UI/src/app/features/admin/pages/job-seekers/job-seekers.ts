import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface JobSeeker {
  id: number;
  name: string;
  email: string;
  skills: string;
  experience: number;
  status: string;
}

@Component({
  selector: 'app-job-seekers',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './job-seekers.html',
  styleUrl: './job-seekers.css'
})
export class JobSeekers {

  seekers: JobSeeker[] = [
    {
      id: 1,
      name: 'Nimal Fernando',
      email: 'nimal@gmail.com',
      skills: 'Angular, .NET',
      experience: 3,
      status: 'Active'
    },
    {
      id: 2,
      name: 'Kasun Perera',
      email: 'kasun@gmail.com',
      skills: 'Java, Spring',
      experience: 5,
      status: 'Active'
    },
    {
      id: 3,
      name: 'Amal Silva',
      email: 'amal@gmail.com',
      skills: 'React, Node.js',
      experience: 2,
      status: 'Inactive'
    }
  ];

}