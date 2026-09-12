import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { VacancyService } from '../services/vacancy.service';
import { Vacancy } from '../models/vacancy.model';

@Component({
  selector: 'app-job-search',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './job-search.html',
  styleUrl: './job-search.css'
})
export class JobSearch {

  private vacancyService = inject(VacancyService);
  private router = inject(Router);

  keyword = '';
  location = '';

  jobs: Vacancy[] = [];

  search(): void {

    this.vacancyService.search(
      this.keyword,
      this.location
    ).subscribe({

      next: response => {

        this.jobs = response;

      },

      error: err => {

        console.error(err);
        alert('Failed to load vacancies.');

      }

    });

  }

  viewDetails(id: number): void {

    this.router.navigate(['/job-details', id]);

  }

  apply(id: number): void {

    this.router.navigate(['/job-seeker/apply', id]);

  }

  ngOnInit(): void {

    this.search();

  }

}