import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UploadService {
  // private cloudName = 'doiiwtmvq'; // Replace with your Cloudinary cloud name
  // private apiKey = '542542467633917'; // Replace with your Cloudinary API key
  // private apiSecret = '6c-tmk0S4xRivGVnefOm5qcCGH8'; // Replace with your Cloudinary API secret

  constructor(private _HttpClient: HttpClient) {}
  uploadImage(vals: any): Observable<any> {
    let data = vals;
    return this._HttpClient.post(
      'https://api.cloudinary.com/v1_1/doiiwtmvq/image/upload',
      data
    );
  }

  uploadVideo(vals: any): Observable<any> {
    let data = vals;
    return this._HttpClient.post(
      'https://api.cloudinary.com/v1_1/doiiwtmvq/video/upload',
      data
    );
  }

  // deleteVideo(publicId: string): Observable<any> {
  //   const url = `https://api.cloudinary.com/v1_1/${this.cloudName}/delete_by_token`;
  //   const body = {
  //     public_id: publicId,
  //   };

  //   // Make a DELETE request to delete the video
  //   return this._HttpClient.post(url, body, {
  //     headers: new HttpHeaders({
  //       Authorization: `Basic ${btoa(`${this.apiKey}:${this.apiSecret}`)}`,
  //     }),
  //   });
  // }
}
