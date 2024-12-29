import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-nav-admin',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './nav-admin.component.html',
  styleUrl: './nav-admin.component.css',
})
export class NavAdminComponent {
  constructor(
  ) {}



}
