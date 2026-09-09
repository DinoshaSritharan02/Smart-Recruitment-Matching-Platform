import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-jobs',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './jobs.html',
  styleUrl: './jobs.css'
})
export class Jobs {}