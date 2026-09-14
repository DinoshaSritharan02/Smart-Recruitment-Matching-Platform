import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.css'
})
export class Header {

  @Output() toggleSidebar = new EventEmitter<void>();

  toggle(): void {
    this.toggleSidebar.emit();
  }

}