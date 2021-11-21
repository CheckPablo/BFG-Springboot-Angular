/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-11-08 18:20:34
 * @modify date 2020-11-08 18:20:34
 * @desc Manage Raw Material ORders
 */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class RawmaterialOrderService {
//   serviceUrl = `${environment.protocol}${environment.applicationUrl}/${environment.rawMaterialOrderService}`;
  serviceUrl = 'http://localhost:9300/';
  constructor(private http: HttpClient) {}

  fetchAllRawMaterialOrders() {
    return this.http.get(`${this.serviceUrl}/rawMaterialOrder`);
  }

  createRawMaterialOrderRequest(rawMaterialOrder) {
    return this.http.post(`${this.serviceUrl}/rawMaterialOrder`, rawMaterialOrder);
  }

  updateStatus(formData) {
    return this.http.put(`${this.serviceUrl}/rawMaterialOrder`, formData);
  }
}
