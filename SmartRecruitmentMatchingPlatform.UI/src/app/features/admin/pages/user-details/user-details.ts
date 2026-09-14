import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AdminService } from '../../services/admin';
import { UserDetails } from '../../models/user-details';

@Component({
  selector: 'app-user-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-details.html',
  styleUrl: './user-details.css'
})
export class UserDetailsComponent implements OnInit {

  private route = inject(ActivatedRoute);
  private adminService = inject(AdminService);

  user?: UserDetails;

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.adminService.getUserById(id).subscribe({
        next: (response) => {
          this.user = response;
        },
        error: (err) => console.error(err)
      });
    }
  }
  toggleStatus() {

  if (!this.user) return;

  this.adminService.updateUserStatus(this.user.id, {
    isActive: !this.user.isActive
  }).subscribe({

    next: () => {
      this.user!.isActive = !this.user!.isActive;
    },

    error: err => console.error(err)

  });

}

}