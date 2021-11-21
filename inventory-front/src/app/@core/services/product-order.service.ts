/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-11-08 15:02:52
 * @modify date 2020-11-08 15:02:52
 * @desc [description]
 */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ProductOrderService {
  serviceUrl = 'http://localhost:9200';
//  serviceUrl = `${environment.protocol}${environment.applicationUrl}/${environment.productOrderService}`;
  constructor(private http: HttpClient) {}

  fetchAllProductOrders() {
    return this.http.get(`${this.serviceUrl}/productOrder`);
  }

  createProductOrderRequest(productOrder) {
    return this.http.post(`${this.serviceUrl}/productOrder`, productOrder);
  }

  updateStatus(formData) {
    return this.http.put(`${this.serviceUrl}/productOrder`, formData);
  }
}
