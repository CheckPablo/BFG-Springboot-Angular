/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-11-08 23:25:16
 * @modify date 2020-11-08 23:25:16
 * @desc Manage roducts
 */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map'
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  serviceUrl = 'http://localhost:9400/';
//   serviceUrl = `${environment.protocol}${environment.applicationUrl}/${environment.stockManagementService}`;
  constructor(private http: HttpClient) {}

  fetchAllProducts(){
      return this.http.get(this.serviceUrl + '/productStock');
  }

  getProductByProductId(productId: number) {
    return this.http.get(this.serviceUrl + '/productStock/' + productId);
  }

  addProduct(formData) {
    return this.http.post(this.serviceUrl + '/productStock', formData);
  }
}
