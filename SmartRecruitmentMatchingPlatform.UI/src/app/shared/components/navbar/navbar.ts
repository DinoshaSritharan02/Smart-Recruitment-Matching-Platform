import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../../features/auth/services/auth.service';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css'
})
export class Navbar {

  private authService = inject(AuthService);
  private router = inject(Router);

  isMenuOpen = false;

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }

  closeMenu(): void {
    this.isMenuOpen = false;
  }

  isLoggedIn(): boolean {
  return this.authService.isLoggedIn();
}

  logout(): void {
    this.authService.logout();
    this.closeMenu();
    this.router.navigate(['/login']);
  }
}