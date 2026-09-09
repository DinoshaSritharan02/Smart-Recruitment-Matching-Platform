import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { User } from '../../models/user';
@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './users.html',
  styleUrl: './users.css'
})
export class Users {

  users: User[] = [
    {
      id: 1,
      fullName: 'John Silva',
      email: 'john@gmail.com',
      role: 'Employer',
      status: 'Active',
      createdDate: '2026-09-01'
    },
    {
      id: 2,
      fullName: 'Kasun Perera',
      email: 'kasun@gmail.com',
      role: 'Job Seeker',
      status: 'Inactive',
      createdDate: '2026-09-03'
    },
    {
      id: 3,
      fullName: 'Nimal Fernando',
      email: 'nimal@gmail.com',
      role: 'Employer',
      status: 'Active',
      createdDate: '2026-09-04'
    }
  ];

}