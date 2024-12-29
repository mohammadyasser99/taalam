import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'E-learning';

  isLoading = true;

  ngOnInit(): void {
    // Simulate loading time for demonstration purposes
    setTimeout(() => {
      this.isLoading = false;
    }, 3000); // Change 3000 to the time (in ms) you want the preloader to show
  }
}
