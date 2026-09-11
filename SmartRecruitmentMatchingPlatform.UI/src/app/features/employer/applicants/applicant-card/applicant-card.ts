import {
  ChangeDetectionStrategy,
  Component,
  input,
  output
} from '@angular/core';

import { CommonModule } from '@angular/common';

import { Applicant } from '../../models/applicant.model';

@Component({
  selector: 'app-applicant-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './applicant-card.html',
  styleUrl: './applicant-card.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ApplicantCard {

  readonly applicant = input.required<Applicant>();

  readonly view = output<number>();

  readonly updateStatus = output<number>();

  readonly contact = output<number>();

}