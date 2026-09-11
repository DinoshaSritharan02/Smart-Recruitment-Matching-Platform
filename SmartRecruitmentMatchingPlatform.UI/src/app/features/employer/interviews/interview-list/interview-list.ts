import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

interface Interview {

  id: number;

  applicant: string;

  vacancy: string;

  interviewDate: string;

  interviewTime: string;

  mode: string;

  interviewer: string;

  status: string;

}

@Component({
  selector: 'app-interview-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './interview-list.html',
  styleUrl: './interview-list.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class InterviewList {

  readonly interviews = signal<Interview[]>([
    {
      id: 1,
      applicant: 'John Silva',
      vacancy: 'Frontend Developer',
      interviewDate: '2026-09-20',
      interviewTime: '10:00 AM',
      mode: 'Online',
      interviewer: 'HR Manager',
      status: 'Scheduled'
    },
    {
      id: 2,
      applicant: 'Nimal Perera',
      vacancy: 'Backend Developer',
      interviewDate: '2026-09-22',
      interviewTime: '02:30 PM',
      mode: 'Physical',
      interviewer: 'Technical Lead',
      status: 'Completed'
    }
  ]);

}