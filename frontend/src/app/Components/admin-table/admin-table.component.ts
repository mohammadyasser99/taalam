import { Component, OnInit } from '@angular/core';
import User from '../../models/User';
import { UserService } from '../../shared/services/user.service';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admin-table',
  standalone: true,
  templateUrl: './admin-table.component.html',
  imports: [NgFor, FormsModule,NgxPaginationModule],
  styleUrls: ['./admin-table.component.css']
})
export class AdminTableComponent implements OnInit {


  users: User[] = [];
  filteredUsers: User[] = [];
  searchTerm: string = '';
  page: number = 1;

  constructor(private userservice:UserService,private toaster:ToastrService) {}
    ngOnInit(): void {
  this.userservice.getusers().subscribe(users => {
    this.users = users;
    this.filteredUsers = users;
  });

  
    }

 

    filterUsers(): void {
      const term = this.searchTerm.trim().toLowerCase();
    
      this.filteredUsers = this.users.filter(user => {
        return (
          user.fName.toLowerCase().includes(term) || 
          user.email.toLowerCase().includes(term)
        );
      });
    }

    approveuser(id: number) {
     this.userservice.approveuser(id).subscribe({
        next: (response) => {
           
          this.toaster.success('User Approved Successfully');
        },
        error: (err) => {
          this.toaster.error('Error in approving user');
           
        }
      });
      }

      deleteuser(id: any) {
        this.userservice.deleteuser(id).subscribe({
          next: (response) => {
          this.toaster.success('User Deleted Successfully');
          this.userservice.getusers().subscribe(users => {
            this.users = users;
            this.filteredUsers = users;
          }
          );
          },
          error: (err) => {
            this.toaster.error('Error in deleting user');
          }
        });
    }
}
