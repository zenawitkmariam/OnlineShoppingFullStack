import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {CommonData} from '../Component/Common/CommonData'
import { Observable } from 'rxjs';
import { HttpHeaders } from '@angular/common/http';
import { Product } from '../Models/ProductModels';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    Authorization: 'my-auth-token'
  })
};
@Injectable({
  providedIn: 'root'
})

export class ApiService {

  public productModel: Product = new Product();
  baseUrl:string=CommonData.ApiUrlLink;

  constructor(private http : HttpClient) {}

  readonly productListUrl = this.baseUrl + "/Home/GetProductList";
  readonly postProductUrl = this.baseUrl + "/Home/AddProduct";

 GetProductList(searchtext:string) : Observable<any>{
    return this.http.get<any>(this.productListUrl +'/' + searchtext);
 }
 AddProduct(productModel: Product): Observable<string> {
  return this.http.post<string>(this.postProductUrl, productModel, httpOptions);
 }

}
