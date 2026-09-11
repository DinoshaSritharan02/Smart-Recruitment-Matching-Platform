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
  selector: 'app-send-contact-request',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './send-contact-request.html',
  styleUrl: './send-contact-request.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SendContactRequest {

  private readonly fb = inject(FormBuilder);

  readonly form = this.fb.nonNullable.group({

    subject: ['', Validators.required],

    message: ['', [
      Validators.required,
      Validators.minLength(10)
    ]]

  });

  send(): void {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;

    }

    console.log(this.form.getRawValue());

  }

}