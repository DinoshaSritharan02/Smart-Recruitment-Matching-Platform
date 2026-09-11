import {
  ChangeDetectionStrategy,
  Component,
  signal
} from '@angular/core';

import { CommonModule } from '@angular/common';

interface Skill {

  id: number;

  skillName: string;

  skillLevel: string;

}

@Component({
  selector: 'app-required-skills',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './required-skills.html',
  styleUrl: './required-skills.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class RequiredSkills {

  readonly skills = signal<Skill[]>([
    {
      id: 1,
      skillName: 'Angular',
      skillLevel: 'Advanced'
    },
    {
      id: 2,
      skillName: 'ASP.NET Core',
      skillLevel: 'Intermediate'
    },
    {
      id: 3,
      skillName: 'SQL Server',
      skillLevel: 'Intermediate'
    }
  ]);

}