import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Lesson, Section } from '../../../models/CourseDetails';
import { NgbAccordionModule, NgbNavPane } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-sections-sidebar',
  standalone: true,
  imports: [CommonModule, NgbAccordionModule],
  templateUrl: './sections-sidebar.component.html',
  styleUrl: './sections-sidebar.component.css',
})
export class SectionsSidebarComponent {
  @Input() sections: Section[] = [];
  @Output() lessonSelected = new EventEmitter<Lesson>();

  onLessonClick(lesson: Lesson) {
    this.lessonSelected.emit(lesson); // Send the selected lesson to the parent
  }
}
