import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Output,
} from '@angular/core';

@Component({
  selector: 'app-employer-header',
  standalone: true,
  imports: [],
  templateUrl: './employer-header.html',
  styleUrl: './employer-header.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class EmployerHeader {

  @Output()
  readonly menuClicked = new EventEmitter<void>();

  openMenu(): void {
    this.menuClicked.emit();
  }
}