import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { EmployerService } from '../../services/employer.service';
import { EmployerProfile } from '../../models/employer-profile.model';

@Component({
  selector: 'app-company-profile',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './company-profile.html',
  styleUrl: './company-profile.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CompanyProfile {

  private readonly employerService = inject(EmployerService);

  readonly profile = signal<EmployerProfile | null>(null);

  readonly loading = signal(false);

}