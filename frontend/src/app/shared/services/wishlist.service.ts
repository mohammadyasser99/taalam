import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class WishlistService {
  constructor(private _HttpClient: HttpClient) {}
  baseURL = 'http://localhost:5062';

  getWishListItemsById(id: number): Observable<any> {
    return this._HttpClient.get(
      `${this.baseURL}/api/WishList/GetWishListItems?userId=${id}`
    );
  }

  removeWishListItemById(userId: number, courseId: number): Observable<any> {
    return this._HttpClient.delete(
      `${this.baseURL}/api/WishList/RemoveWishListItem?userId=${userId}&courseId=${courseId}`
    );
  }

  addToWishList(courseId: number): Observable<any> {
    return this._HttpClient.post(
      `${this.baseURL}/api/WishList/AddItemToUserWishList`,
      {
        courseId: courseId,
      }
    );
  }
}
