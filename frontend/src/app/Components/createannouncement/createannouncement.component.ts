import { CommonModule } from '@angular/common';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Announcement } from '../../models/Announcement';
import { AnnouncementService } from '../../shared/services/announcement.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-createannouncement',
  standalone: true,
  imports: [FormsModule , CommonModule],
  templateUrl: './createannouncement.component.html',
  styleUrl: './createannouncement.component.css'
})
export class CreateannouncementComponent implements OnInit {

  @ViewChild('closeButtonedit') closeButtonedit!: ElementRef<HTMLButtonElement>; 
  @ViewChild('closeButtoncreate') closeButtoncreate!: ElementRef<HTMLButtonElement>; 

  
minDate: string = '';
deleteannouncement(id: any) {
this.announcementservice.deleteAnnouncement(id).subscribe((data:any)=>{
  this.announcements = this.announcements.filter((x)=>x.id !== id);
  this.toaster.success('Announcement deleted successfully');

    
}, (error)=>{
  console.error('Error deleting announcement',error);
  this.toaster.error('Error deleting announcement');
 // alert('Error deleting announcement');


}
);
}
onSubmitcreate() {

  if (this.announcement.body !== '' && this.announcement.discount >= 0 && this.announcement.discount <= 100) {
    this.announcementservice.createAnnouncement(this.announcement).subscribe((data:any)=>{
      this.announcementservice.getAnnouncements().subscribe((data:any)=>{
        this.announcements = data;
      }
    );

        
      this.toaster.success('Announcement created successfully');
    },
    (error)=>{
      console.error('Error creating announcement',error);
     this.toaster.error('Error creating announcement');
    }
    );
  this.closeButtoncreate.nativeElement.click();
  }else{
    alert('Please fill in all fields correctly.');
  }



}
onEditSubmit() {
if (this.editannouncementmodel.body !== '' && this.editannouncementmodel.discount >0 && this.editannouncementmodel.discount<100) {
 
  this.announcementservice.updateAnnouncement(this.editannouncementmodel).subscribe((data:any)=>{
    const index = this.announcements.findIndex((x)=>x.id === data.id);
    if(index !== -1){
      this.announcements[index] = data;
    }
    this.toaster.success('Announcement updated successfully');
      

 
  },
  (error)=>{
    console.error('Error updating announcement',error);
   this.toaster.error('Error updating announcement');
  }
  );

  this.closeButtonedit.nativeElement.click();
  
}
 
}

announcements:Announcement[] = [];
editannouncementmodel: Announcement = {
  body:'',
  endOfSale:new Date(),
  discount:0
}
  announcement :Announcement = {
  body:'',
  endOfSale:new Date(),
  discount:0
  };


  constructor(private announcementservice:AnnouncementService,private toaster:ToastrService) { }
  ngOnInit(): void {
    const now = new Date();
    this.minDate = this.formatDateForInput(now);
 this.announcementservice.getAnnouncements().subscribe((data:any)=>{

  this.announcements = data;  
    
 },(error)=>{
    console.error('Error fetching announcements',error);
    alert('Error fetching announcements');
 }
  );


  }
  // Helper method to format the date for the datetime-local input
  formatDateForInput(date: Date): string {
    const pad = (n: number) => n < 10 ? '0' + n : n;
    return date.getFullYear() + '-' + pad(date.getMonth() + 1) + '-' + pad(date.getDate()) +
           'T' + pad(date.getHours()) + ':' + pad(date.getMinutes());
  }

    

updatecurrentannouncement(id: number|undefined) {
  this.editannouncementmodel = this.announcements.find((x)=>x.id === id)!;
  }
  

}
