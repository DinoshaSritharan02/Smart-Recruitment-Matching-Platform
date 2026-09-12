import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobSeekerService } from '../services/job-seeker.service';

@Component({
  selector: 'app-cv-upload',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './cv-upload.html',
  styleUrl: './cv-upload.css'
})
export class CvUpload implements OnInit {

  private jobSeekerService = inject(JobSeekerService);

  selectedFile?: File;

  cvInfo: any = null;

  loading = true;

  ngOnInit(): void {
    this.loadCv();
  }

  loadCv(): void {

    this.jobSeekerService.getCvMetadata().subscribe({

      next: (response) => {

        this.cvInfo = response;

        this.loading = false;

      },

      error: (err) => {

        console.error(err);

        this.cvInfo = null;

        this.loading = false;

      }

    });

  }

  onFileSelected(event: Event): void {

    const input = event.target as HTMLInputElement;

    if (input.files && input.files.length > 0) {

      this.selectedFile = input.files[0];

    }

  }

  upload(): void {

    if (!this.selectedFile) {

      alert('Please select a PDF file.');

      return;

    }

    this.jobSeekerService.uploadCv(this.selectedFile).subscribe({

      next: () => {

        alert('CV uploaded successfully.');

        this.selectedFile = undefined;

        this.loadCv();

      },

      error: (err) => {

        console.error(err);

        alert('Failed to upload CV.');

      }

    });

  }

  download(): void {

    this.jobSeekerService.downloadCv().subscribe({

      next: (blob) => {

        const url = window.URL.createObjectURL(blob);

        const link = document.createElement('a');

        link.href = url;

        link.download = this.cvInfo?.fileName ?? 'CV.pdf';

        link.click();

        window.URL.revokeObjectURL(url);

      },

      error: (err) => {

        console.error(err);

        alert('Failed to download CV.');

      }

    });

  }

}