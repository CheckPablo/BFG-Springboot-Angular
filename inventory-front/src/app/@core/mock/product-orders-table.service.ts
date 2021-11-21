import { Injectable } from '@angular/core';
import { ProductOrdersTableData } from '../data/product-orders-table';

import { ProductOrderService } from '../services/product-order.service';

@Injectable()
export class ProductOrdersTableService extends ProductOrdersTableData {

 constructor(private productOrderService: ProductOrderService) {
       super();
     }
   getData() {
     return this.productOrderService.fetchAllProductOrders();
   }
}
