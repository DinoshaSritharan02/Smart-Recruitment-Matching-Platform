import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { EmployerService } from '../../services/employer.service';
import { RankedApplicant } from '../../models/ranked-applicant.model';

@Component({
  selector: 'app-applicant-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './applicant-list.html',
  styleUrl: './applicant-list.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ApplicantList implements OnInit {

  private readonly route = inject(ActivatedRoute);
  private readonly employerService = inject(EmployerService);

  readonly applicants = signal<RankedApplicant[]>([]);

  loading = true;

  ngOnInit(): void {

    const vacancyId = Number(
      this.route.snapshot.paramMap.get('vacancyId')
    );

    this.employerService
      .getRankedApplicants(vacancyId)
      .subscribe({

        next: data => {

          this.applicants.set(data);

          this.loading = false;

        },

        error: err => {

          console.error(err);

          this.loading = false;

          alert('Failed to load applicants.');

        }

      });

  }
  updateStatus(applicationId: number, status: string): void {

  this.employerService
    .updateApplicationStatus(applicationId, { status })
    .subscribe({

      next: () => {

        const vacancyId = Number(
          this.route.snapshot.paramMap.get('vacancyId')
        );

        this.employerService
          .getRankedApplicants(vacancyId)
          .subscribe(data => this.applicants.set(data));

      },

      error: () => {

        alert('Failed to update application status.');

      }

    });

}

}