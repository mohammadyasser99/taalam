import { Component } from '@angular/core';

import { AdminTableComponent } from "../../Components/admin-table/admin-table.component";
import { CreateannouncementComponent } from "../../Components/createannouncement/createannouncement.component";

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [AdminTableComponent, CreateannouncementComponent],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent  {

  
}
