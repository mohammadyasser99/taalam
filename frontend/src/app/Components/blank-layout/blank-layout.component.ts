import { Component } from '@angular/core';
import { NavBlankComponent } from "../nav-blank/nav-blank.component";
import { FooterComponent } from "../footer/footer.component";
import { RouterLink, RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-blank-layout',
  standalone: true,
  imports: [NavBlankComponent, FooterComponent, RouterOutlet],
  templateUrl: './blank-layout.component.html',
  styleUrl: './blank-layout.component.css'
})
export class BlankLayoutComponent {
 
}