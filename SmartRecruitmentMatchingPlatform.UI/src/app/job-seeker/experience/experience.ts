import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { JobSeekerService } from '../services/job-seeker.service';
import { Experience } from '../models/experience.model';

@Component({
  selector: 'app-experience',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './experience.html',
  styleUrl: './experience.css'
})
export class ExperienceComponent implements OnInit {

  private service = inject(JobSeekerService);

  loading = true;

  experiences: Experience[] = [];

  experience: Experience = {
    companyName: '',
    jobTitle: '',
    description: '',
    startDate: '',
    endDate: ''
  };

  editing = false;

  ngOnInit(): void {
    this.load();
  }

  load(): void {

    this.loading = true;

    this.service.getProfile().subscribe({

      next: profile => {

        this.experiences = profile.experiences;

        this.loading = false;

      },

      error: () => {

        this.loading = false;

        alert('Failed to load experience.');

      }

    });

  }

  save(): void {

    if (this.editing && this.experience.id) {

      this.service.updateExperience(
        this.experience.id,
        this.experience
      ).subscribe({

        next: () => {

          alert('Experience updated.');

          this.reset();

          this.load();

        }

      });

    } else {

      this.service.addExperience(
        this.experience
      ).subscribe({

        next: () => {

          alert('Experience added.');

          this.reset();

          this.load();

        }

      });

    }

  }

  edit(item: Experience): void {

    this.experience = { ...item };

    this.editing = true;

  }

  delete(id: string): void {

    if (!confirm('Delete this experience?')) {
      return;
    }

    this.service.deleteExperience(id).subscribe({

      next: () => {

        alert('Experience deleted.');

        this.load();

      }

    });

  }

  reset(): void {

    this.experience = {
      companyName: '',
      jobTitle: '',
      description: '',
      startDate: '',
      endDate: ''
    };

    this.editing = false;

  }

}