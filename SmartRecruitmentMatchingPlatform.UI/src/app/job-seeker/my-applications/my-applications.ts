import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { ApplicationService } from '../services/application.service';
import { Application } from '../models/application.model';

@Component({
  selector: 'app-my-applications',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './my-applications.html',
  styleUrl: './my-applications.css'
})
export class MyApplications implements OnInit {

  private applicationService = inject(ApplicationService);

  applications: Application[] = [];

  loading = true;

  ngOnInit(): void {

    this.applicationService.getMyApplications().subscribe({

      next: (response) => {

        this.applications = response;
        this.loading = false;

      },

      error: (err) => {

        console.error(err);

        this.loading = false;

        alert('Failed to load applications.');

      }

    });

  }

}