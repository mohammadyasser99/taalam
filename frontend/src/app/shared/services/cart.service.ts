import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {  BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private _HttpClient:HttpClient) { }
  baseURL='http://localhost:5062';

  getCartItemsById(id:number):Observable<any> {
return this._HttpClient.get(`${this.baseURL}/api/Cart/GetCartItems?userId=${id}`);

  }

  getCartTotalById(id:number):Observable<any>{
    return this._HttpClient.get(`${this.baseURL}/api/Cart/GetCartTotal?userId=${id}`)
  }

  removeCartItemById(userId:number, courseId:number):Observable<any>{
    return this._HttpClient.delete(`${this.baseURL}/api/Cart/RemoveCartItem?userId=${userId}&courseId=${courseId}`)
  }

  addtoCart(courseId:number):Observable<any>{
    return this._HttpClient.post(
      `${this.baseURL}/api/Cart/AddItemToUserCart`,{courseId:courseId}
    );
  }



  // badge
  cartNumber:BehaviorSubject<number> = new BehaviorSubject(0);
}
