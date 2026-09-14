import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-job-seeker-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './job-seeker-details.html'
})
export class JobSeekerDetails {

  jobSeeker = {
    id: 1,
    fullName: 'Amal Silva',
    email: 'amal@gmail.com',
    phone: '0771234567',
    skills: 'Angular, .NET',
    experience: '3 Years',
    status: 'Active'
  };

}