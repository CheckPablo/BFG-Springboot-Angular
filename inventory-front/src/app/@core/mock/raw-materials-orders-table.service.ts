import { Injectable } from '@angular/core';
import { RawMaterialsOrdersTableData } from '../data/raw-materials-orders-table';
import { RawmaterialOrderService } from '../services/rawmaterial-order.service';

@Injectable()
export class RawMaterialsOrdersTableService extends RawMaterialsOrdersTableData {

   constructor(private service: RawmaterialOrderService) {
         super();
       }
     getData() {
       return this.service.fetchAllRawMaterialOrders();
     }
}
