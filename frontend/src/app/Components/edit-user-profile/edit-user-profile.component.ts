import { Component } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { IUserProfile } from '../../shared/interfaces/instructor-info-with-courses';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-user-profile',
  standalone: true,
  templateUrl: './edit-user-profile.component.html',
  styleUrls: ['./edit-user-profile.component.css'],
  imports: [FormsModule],
})
export class EditUserProfileComponent {
  id: any;
  user: IUserProfile = {
    id: '',
    fName: '',
    lName: '',
    description: '',
    github: '',
    facebook: '',
    linkedin: '',
    youtube: '',
    twitter: '',
    profilePicture: '',
  };
  selectedFile: File | null = null;
  profilePicture: string | ArrayBuffer | null = null;
  defaultProfilePicture = 'http://bootdey.com/img/Content/avatar/avatar1.png';

  constructor(
    private userservice: UserService,
    private route: ActivatedRoute,
    private router: Router,
  ) {}

  ngOnInit() {
    // this.id = this.route.snapshot.paramMap.get('id');
    this.route.paramMap.subscribe((params) => {
      const idParam = params.get('id');
      this.id = idParam ? +idParam : undefined;
      this.loadUserProfile(this.id);
      
    });

    
  }

  loadUserProfile(id: string) {
    this.userservice.getUserInfo(id).subscribe((user) => {
      console.log(user);
      
      this.user = user;
    });
  }
  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    
    if (file) {
      this.selectedFile = file;
  
      const reader = new FileReader();
  
      reader.onload = (e: any) => {
        this.profilePicture = e.target.result;
      };
  
      reader.readAsDataURL(file);
    }
  }
  
  saveChanges(user: IUserProfile) {
    const formData: FormData = new FormData();

    formData.append('Id', this.id.toString());
    formData.append('FName', user.fName || '');
    formData.append('LName', user.lName || '');
    formData.append('Description', user.description || '');
    formData.append('Github', user.github || '');
    formData.append('Twitter', user.twitter || '');
    formData.append('Facebook', user.facebook || '');
    formData.append('LinkedIn', user.linkedin || '');
    formData.append('Youtube', user.youtube || '');

    if (this.selectedFile) {
      formData.append('ProfilePictureFile', this.selectedFile);
    }

    this.userservice.updateUserProfile(formData).subscribe(
      (response) => {
        console.log('Profile updated successfully', response);
        this.router.navigate([`/userProfile/${this.id}`]).then(() => {
          window.location.reload();
        });
      },
      (error) => {
        console.error('Error updating profile', error);
      }
    );
  }
}
