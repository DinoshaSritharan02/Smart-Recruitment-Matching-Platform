import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-skills',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule
  ],
  templateUrl: './skills.html',
  styleUrl: './skills.css'
})
export class Skills {

  newSkill = '';

  skills = [
    '.NET',
    'ASP.NET Core',
    'Angular',
    'SQL Server',
    'Tailwind CSS',
    'Git'
  ];

  addSkill(): void {

    const value = this.newSkill.trim();

    if (!value) {
      return;
    }

    this.skills.push(value);

    this.newSkill = '';

  }

  removeSkill(index: number): void {

    this.skills.splice(index, 1);

  }

}