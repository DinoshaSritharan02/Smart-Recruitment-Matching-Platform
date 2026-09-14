import {
  ChangeDetectionStrategy,
  Component,
  OnInit,
  inject,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { VacancyService } from '../../services/vacancy.service';
import { VacancyResponse } from '../../models/vacancy.model';

@Component({
  selector: 'app-vacancy-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './vacancy-list.html',
  styleUrl: './vacancy-list.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class VacancyList implements OnInit {

  private readonly vacancyService = inject(VacancyService);

  readonly loading = signal(true);

  readonly vacancies = signal<VacancyResponse[]>([]);

  ngOnInit(): void {
    this.loadVacancies();
  }

  loadVacancies(): void {

    this.loading.set(true);

    this.vacancyService.getMyVacancies().subscribe({

      next: (data) => {

        this.vacancies.set(data);

        this.loading.set(false);

      },

      error: (err) => {

        console.error(err);

        this.loading.set(false);

        alert('Failed to load vacancies.');

      }

    });

  }

}