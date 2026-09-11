import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { Applicant } from '../../models/applicant.model';

@Component({
  selector: 'app-applicant-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './applicant-list.html',
  styleUrl: './applicant-list.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ApplicantList {

  readonly applicants = signal<Applicant[]>([
    {
      id: 1,
      fullName: 'John Silva',
      email: 'john@example.com',
      phoneNumber: '0771234567',
      education: 'BSc Software Engineering',
      experience: '3 Years',
      matchScore: 91,
      applicationStatus: 'Pending'
    },
    {
      id: 2,
      fullName: 'Nimal Perera',
      email: 'nimal@example.com',
      phoneNumber: '0719876543',
      education: 'BSc Computer Science',
      experience: '2 Years',
      matchScore: 84,
      applicationStatus: 'Shortlisted'
    }
  ]);

}