// back-to-top.service.ts
import { Injectable } from '@angular/core';
declare var $: any; // Import jQuery

@Injectable({
  providedIn: 'root'
})
export class BackToTopService {

  initializeBackToTop(): void {
    $(window).on('scroll', this.handleScroll);
    $('.back-to-top').on('click', this.scrollToTop);
  }

  private handleScroll = () => {
    if ($(window).scrollTop() > 300) {
      $('.back-to-top').fadeIn('slow');
    } else {
      $('.back-to-top').fadeOut('slow');
    }
  };

  private scrollToTop = (event: Event) => {
    event.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, 1000, 'linear');
  };
}
