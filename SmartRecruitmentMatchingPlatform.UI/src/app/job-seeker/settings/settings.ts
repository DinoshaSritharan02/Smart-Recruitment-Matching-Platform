import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-settings',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink
  ],
  templateUrl: './settings.html',
  styleUrl: './settings.css'
})
export class Settings {

  constructor(private router: Router) {}

  logout() {

    localStorage.clear();

    this.router.navigate(['/login']);

  }

}