import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { VacancyService } from '../../services/vacancy.service';

import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-edit-vacancy',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './edit-vacancy.html',
  styleUrl: './edit-vacancy.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EditVacancy implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);
  private readonly vacancyService = inject(VacancyService);
private readonly route = inject(ActivatedRoute);

  readonly form = this.fb.nonNullable.group({
  title: ['', Validators.required],
  description: [''],
  location: [''],
  requiredExperienceYears: [0],
  educationRequirement: [''],
  skillIds: [[] as number[]],
  isClosed: [false]
});

ngOnInit(): void {

  const id = Number(this.route.snapshot.paramMap.get('id'));

  this.vacancyService.getById(id).subscribe(v => {

    this.form.patchValue({

      title: v.title,
      description: v.description ?? '',
      location: v.location ?? '',
      requiredExperienceYears: v.requiredExperienceYears,
      educationRequirement: v.educationRequirement ?? '',
      skillIds: v.skillIds,
      isClosed: v.status === 'Closed'

    });

  });

}

  updateVacancy(): void {

  if (this.form.invalid) {

    this.form.markAllAsTouched();

    return;

  }

  const id = Number(this.route.snapshot.paramMap.get('id'));

  this.vacancyService.update(id, this.form.getRawValue())
    .subscribe({

      next: () => {

        alert('Vacancy updated successfully.');

        this.router.navigate(['/employer/vacancies']);

      },

      error: err => {

        console.error(err);

        alert('Update failed.');

      }

    });

}

  cancel(): void {
    this.router.navigate(['/employer/dashboard']);
  }

}