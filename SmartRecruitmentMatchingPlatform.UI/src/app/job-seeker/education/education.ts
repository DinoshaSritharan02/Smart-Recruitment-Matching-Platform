import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { JobSeekerService } from '../services/job-seeker.service';
import { Education } from '../models/education';

@Component({
  selector: 'app-education',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './education.html',
  styleUrl: './education.css'
})
export class EducationComponent implements OnInit {

  private service = inject(JobSeekerService);

  loading = true;

  educations: Education[] = [];

  education: Education = {
    institution: '',
    degree: '',
    fieldOfStudy: '',
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

        this.educations = profile.educations;

        this.loading = false;

      },

      error: () => {

        this.loading = false;

        alert('Failed to load education.');

      }

    });

  }

  save(): void {

    if (this.editing && this.education.id) {

      this.service.updateEducation(
        this.education.id,
        this.education
      ).subscribe({

        next: () => {

          alert('Education updated.');

          this.reset();

          this.load();

        }

      });

    } else {

      this.service.addEducation(
        this.education
      ).subscribe({

        next: () => {

          alert('Education added.');

          this.reset();

          this.load();

        }

      });

    }

  }

  edit(item: Education): void {

    this.education = { ...item };

    this.editing = true;

  }

  delete(id: string): void {

    if (!confirm('Delete this education?')) {
      return;
    }

    this.service.deleteEducation(id).subscribe({

      next: () => {

        alert('Deleted.');

        this.load();

      }

    });

  }

  reset(): void {

    this.education = {

      institution: '',

      degree: '',

      fieldOfStudy: '',

      startDate: '',

      endDate: ''

    };

    this.editing = false;

  }

}