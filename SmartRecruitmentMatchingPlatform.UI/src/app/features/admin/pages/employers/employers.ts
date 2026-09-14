import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

export interface Employer {
  id: number;
  companyName: string;
  email: string;
  contact: string;
  status: 'Active' | 'Inactive';
}

@Component({
  selector: 'app-employers',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './employers.html',
  styleUrl: './employers.css'
})
export class Employers {

  employers: Employer[] = [
    {
      id: 1,
      companyName: 'ABC Technologies',
      email: 'hr@abc.com',
      contact: '0771234567',
      status: 'Active'
    },
    {
      id: 2,
      companyName: 'XYZ Solutions',
      email: 'careers@xyz.com',
      contact: '0719876543',
      status: 'Inactive'
    },
    {
      id: 3,
      companyName: 'Tech Lanka',
      email: 'jobs@techlanka.com',
      contact: '0765551122',
      status: 'Active'
    }
  ];

}