import { Injectable } from '@angular/core';
import { Observable, interval, Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class OfferService {

  private destroy$ = new Subject<void>();

  getCountdown(endTime: Date): Observable<string> {
    return interval(1000).pipe(
      takeUntil(this.destroy$),
      map(() => {
        const now = new Date().getTime();
        const distance = endTime.getTime() - now;
  
        if (distance < 0) {
          this.destroy$.next();
          return 'EXPIRED';
        }
  
        const days = Math.floor(distance / (1000 * 60 * 60 * 24));
        const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((distance % (1000 * 60)) / 1000);
  
        if (days > 0) {
          return `${days}d ${hours}h ${minutes}m ${seconds}s`;
        } else {
          return `${hours}h ${minutes}m ${seconds}s`;
        }
      })
    );
  }
  
  

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}
