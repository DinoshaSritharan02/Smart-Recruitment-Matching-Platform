import {
  ChangeDetectionStrategy,
  Component,
  signal,
} from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { EmployerSidebar } from '../../shared/employer-sidebar/employer-sidebar';
import { EmployerHeader } from '../../shared/employer-header/employer-header';

@Component({
  selector: 'app-employer-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    EmployerSidebar,
    EmployerHeader
  ],
  templateUrl: './employer-layout.html',
  styleUrl: './employer-layout.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployerLayout {
  readonly sidebarOpen = signal(true);

  toggleSidebar(): void {
    this.sidebarOpen.update(value => !value);
  }

  closeSidebar(): void {
    this.sidebarOpen.set(false);
  }
}