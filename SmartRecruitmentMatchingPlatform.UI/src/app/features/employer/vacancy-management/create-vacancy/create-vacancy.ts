import {
  ChangeDetectionStrategy,
  Component,
  inject,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import {
  Router,
  RouterLink
} from '@angular/router';

import { VacancyService } from '../../services/vacancy.service';

interface Skill {
  id: number;
  name: string;
}

@Component({
  selector: 'app-create-vacancy',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterLink
  ],
  templateUrl: './create-vacancy.html',
  styleUrl: './create-vacancy.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CreateVacancy {

  private readonly fb = inject(FormBuilder);
  private readonly router = inject(Router);
  private readonly vacancyService = inject(VacancyService);

  readonly saving = signal(false);

  readonly skills = signal<Skill[]>([
    { id: 1, name: 'Angular' },
    { id: 2, name: 'ASP.NET Core' },
    { id: 3, name: 'SQL Server' }
  ]);

  readonly form = this.fb.nonNullable.group({
    title: ['', Validators.required],
    description: [''],
    location: [''],
    requiredExperienceYears: [0, Validators.required],
    educationRequirement: [''],
    skillIds: [[] as number[]]
  });

  onSkillChange(event: Event): void {

    const checkbox = event.target as HTMLInputElement;

    const skillId = Number(checkbox.value);

    const currentSkills = [...this.form.controls.skillIds.value];

    if (checkbox.checked) {

      if (!currentSkills.includes(skillId)) {
        currentSkills.push(skillId);
      }

    } else {

      const index = currentSkills.indexOf(skillId);

      if (index > -1) {
        currentSkills.splice(index, 1);
      }

    }

    this.form.controls.skillIds.setValue(currentSkills);
  }

  submit(): void {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;

    }

    this.saving.set(true);

    this.vacancyService.create(this.form.getRawValue())
      .subscribe({

        next: () => {

          this.saving.set(false);

          alert('Vacancy created successfully.');

          this.router.navigate(['/employer/vacancies']);

        },

        error: (err) => {

          console.error(err);

          this.saving.set(false);

          alert('Failed to create vacancy.');

        }

      });

  }

  cancel(): void {

    this.router.navigate(['/employer/vacancies']);

  }

}