import {
  Component,
  ElementRef,
  Input,
  SimpleChanges,
  ViewChild,
} from '@angular/core';

@Component({
  selector: 'app-course-video-player',
  standalone: true,
  imports: [],
  templateUrl: './course-video-player.component.html',
  styleUrl: './course-video-player.component.css',
})
export class CourseVideoPlayerComponent {
  @Input({ required: true }) content!: string;
  @ViewChild('videoPlayer', { static: false }) videoPlayer!: ElementRef;
  ngOnChanges(changes: SimpleChanges) {
    if (changes['content'] && !changes['content'].firstChange) {
      const video = this.videoPlayer.nativeElement;
      video.load();
    }
  }
}
