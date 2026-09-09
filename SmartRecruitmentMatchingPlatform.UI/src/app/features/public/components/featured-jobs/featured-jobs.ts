import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-featured-jobs',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './featured-jobs.html',
  styleUrl: './featured-jobs.css'
})
export class FeaturedJobs {}