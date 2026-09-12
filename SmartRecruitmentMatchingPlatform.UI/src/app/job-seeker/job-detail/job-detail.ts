import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-job-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './job-detail.html',
  styleUrl: './job-detail.css'
})
export class JobDetail {

  applied = false;

  job = {
    title: 'Senior .NET Developer',
    company: 'ABC Technologies',
    location: 'Colombo',
    employmentType: 'Full Time',
    salary: 'LKR 350,000',
    experience: '3+ Years',
    description:
      'We are looking for an experienced .NET Developer to join our growing development team.',
    responsibilities: [
      'Develop ASP.NET Core APIs',
      'Build Angular applications',
      'Write clean and maintainable code',
      'Participate in code reviews'
    ],
    skills: [
      '.NET',
      'ASP.NET Core',
      'Angular',
      'SQL Server',
      'Git'
    ]
  };

  apply(): void {

    if (this.applied) {

      alert('You have already applied for this job.');

      return;

    }

    const confirmed = confirm('Do you want to apply for this job?');

    if (confirmed) {

      this.applied = true;

      alert('Application submitted successfully.');

    }

  }

}