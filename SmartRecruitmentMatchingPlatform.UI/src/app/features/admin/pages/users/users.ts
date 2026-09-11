import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBar } from '../../components/search-bar/search-bar';
import { AdminService } from '../../services/admin';
import { UserSummary } from '../../models/user-summary';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, SearchBar,RouterModule],
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class Users implements OnInit {

  private adminService = inject(AdminService);

  users: UserSummary[] = [];

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.adminService.getUsers().subscribe({
      next: (response) => {
        this.users = response;
      },
      error: (err) => console.error(err)
    });
  }

  onSearch(keyword: string) {
    console.log(keyword);
  }
  toggleStatus(user: UserSummary) {

  this.adminService.updateUserStatus(
    user.id,
    { isActive: !user.isActive }
  ).subscribe({

    next: () => {

      user.isActive = !user.isActive;

    },

    error: err => console.error(err)

  });

}
}