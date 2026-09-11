import {
  ChangeDetectionStrategy,
  Component,
  inject
} from '@angular/core';

import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

@Component({
  selector: 'app-employer-settings',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './employer-settings.html',
  styleUrl: './employer-settings.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class EmployerSettings {

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({

    companyName: ['', Validators.required],

    website: [''],

    emailNotifications: [true],

    interviewNotifications: [true]

  });

  save(): void {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;

    }

    console.log(this.form.getRawValue());

  }

}