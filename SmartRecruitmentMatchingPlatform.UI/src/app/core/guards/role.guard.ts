import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';

export const roleGuard = (role: string): CanActivateFn => {

  return () => {

    const router = inject(Router);

    const token = localStorage.getItem('token');
    const userRole = localStorage.getItem('role');

    if (!token) {
      router.navigate(['/login']);
      return false;
    }

    if (userRole !== role) {
      router.navigate(['/']);
      return false;
    }

    return true;
  };

};