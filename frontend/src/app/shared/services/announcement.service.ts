import { Injectable } from '@angular/core';
import { Announcement } from '../../models/Announcement';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AnnouncementService {

  constructor(private http:HttpClient) { }

  createAnnouncement(announcement: Announcement) {

    return this.http.post('http://localhost:5062/api/announcement', announcement);
  }

  getAnnouncements() {
    return this.http.get('http://localhost:5062/api/announcement');
  }

  updateAnnouncement(announcement: Announcement) {
    return this.http.put(`http://localhost:5062/api/announcement/${announcement.id}`, announcement);
  }

  deleteAnnouncement(id: number) {
    return this.http.delete(`http://localhost:5062/api/announcement/${id}`);
  }

  getAnnouncement(id: number) {
    return this.http.get(`http://localhost:5062/api/announcement/${id}`);
  }
}
