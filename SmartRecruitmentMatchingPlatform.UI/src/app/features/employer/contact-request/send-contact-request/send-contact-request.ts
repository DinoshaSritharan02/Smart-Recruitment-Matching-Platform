import {
  ChangeDetectionStrategy,
  Component,
  inject,
  Input
} from '@angular/core';

import { CommonModule } from '@angular/common';

import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { ContactRequestService } from '../../services/contact-request.service';

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

  @Input() jobSeekerProfileId = '';

  private readonly fb = inject(FormBuilder);

  private readonly service = inject(ContactRequestService);

  readonly form = this.fb.nonNullable.group({

    message: [
      '',
      [
        Validators.required,
        Validators.minLength(10)
      ]
    ]

  });

  send(): void {

    if (this.form.invalid) {

      this.form.markAllAsTouched();

      return;

    }

    this.service.create({

      jobSeekerProfileId: this.jobSeekerProfileId,

      message: this.form.getRawValue().message

    }).subscribe({

      next: () => {

        alert('Contact request sent successfully.');

        this.form.reset();

      },

      error: () => {

        alert('Failed to send contact request.');

      }

    });

  }

}