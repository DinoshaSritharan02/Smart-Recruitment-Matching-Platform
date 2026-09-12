import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { JobSeekerService } from '../services/job-seeker.service';
import { JobSeekerProfile } from '../models/profile.model';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './profile.html',
  styleUrl: './profile.css'
})
export class Profile implements OnInit {

  private jobSeekerService = inject(JobSeekerService);

  profile?: JobSeekerProfile;

  loading = true;

  ngOnInit(): void {

    this.jobSeekerService.getProfile().subscribe({

      next: (response) => {

        this.profile = response;

        this.loading = false;

        
      },

      error: (err) => {

        console.error(err);

        this.loading = false;

        alert('Failed to load profile.');

      }

    });

  }

}