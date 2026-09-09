import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface User {
  id: number;
  fullName: string;
  email: string;
  role: string;
  status: string;
}

@Component({
selector: 'app-user-details',
  standalone: true,
  imports: [CommonModule],
 templateUrl: './user-details.html',
styleUrl: './user-details.css'
})
export class UserDetails {

  users: User[] = [
    {
      id: 1,
      fullName: 'John Silva',
      email: 'john@gmail.com',
      role: 'Employer',
      status: 'Active'
    },
    {
      id: 2,
      fullName: 'Kamal Perera',
      email: 'kamal@gmail.com',
      role: 'Job Seeker',
      status: 'Inactive'
    }
  ];

}