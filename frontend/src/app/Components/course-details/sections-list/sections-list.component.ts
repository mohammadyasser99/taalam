import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
import { Section } from '../../../models/CourseDetails';

@Component({
  selector: 'app-sections-list',
  standalone: true,
  imports: [CommonModule, NgbAccordionModule],
  templateUrl: './sections-list.component.html',
  styleUrl: './sections-list.component.css',
})
export class SectionsListComponent {
  @Input({ required: true }) sections!: Section[];
}
