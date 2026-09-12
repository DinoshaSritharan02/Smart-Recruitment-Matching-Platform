import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';

import { VacancyService } from '../../../../job-seeker/services/vacancy.service';
import { ApplicationService } from '../../../../job-seeker/services/application.service';
import { Vacancy } from '../../../../job-seeker/models/vacancy.model';

@Component({
  selector: 'app-job-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './job-details.html',
  styleUrl: './job-details.css'
})
export class JobDetails implements OnInit {

  private route = inject(ActivatedRoute);
  private vacancyService = inject(VacancyService);
  private applicationService = inject(ApplicationService);

  vacancy?: Vacancy;
  applied = false;

  ngOnInit(): void {

    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.vacancyService.getVacancyById(id).subscribe({

      next: (response) => {

        console.log('Vacancy:', response);

        this.vacancy = response;

      },

      error: (err) => {

        console.error(err);

        alert('Failed to load vacancy.');

      }

    });

  }

  apply(): void {

    if (!this.vacancy) {
      return;
    }

    const confirmed = confirm('Do you want to apply for this job?');

    if (!confirmed) {
      return;
    }

    this.applicationService.apply(this.vacancy.id).subscribe({

      next: () => {

        this.applied = true;

        alert('Application submitted successfully.');

      },

      error: (err) => {

        console.error(err);

        if (err.status === 401) {

          alert('Please login as a Job Seeker.');

        } else if (err.status === 409) {

          alert('You have already applied for this vacancy.');

        } else if (err.status === 400) {

          alert('Unable to apply. The vacancy may be closed or you have already applied.');

        } else {

          alert('Failed to submit application.');

        }

      }

    });

  }

}