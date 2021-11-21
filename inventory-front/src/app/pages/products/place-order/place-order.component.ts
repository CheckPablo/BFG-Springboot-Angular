import { Component } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { NbDateService } from '@nebular/theme';
/*import {AfterViewInit, Component, ElementRef, ViewChild} from '@angular/core';*/
import { ProductOrdersTableData } from '../../../@core/data/product-orders-table';
import { ProductOrder } from '../../../@core/models/product-order.model';
//import {ProductOrder} from '../../../@core/models/product-order.model';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'ngx-form-inputs',
  styleUrls: ['./place-order.component.scss'],
  templateUrl: './place-order.component.html',

})
/*export class PlaceOrderComponent implements AfterViewInit {
 @ViewChild('txtOrderNumber') txtOrderNo: ElementRef;*/
 export class PlaceOrderComponent {
  starRate = 2;
  heartRate = 4;
  radioGroupValue = 'This is value 2';

    min: Date;
    max: Date;
  public productsOrders: ProductOrder[];
    constructor(protected dateService: NbDateService<Date>,private service: ProductOrdersTableData) {
      this.min = this.dateService.addDay(this.dateService.today(), -5);
      this.max = this.dateService.addDay(this.dateService.today(), 5);

    }

 ShowRawMaterials(orderNo)  {
  //ProductOrder = [];
      console.log(orderNo?.value);
      alert(orderNo?.value);
              this.service.getData().subscribe((data: ProductOrder[]) => {
                console.log(data);
                    this.productsOrders = data;
                    alert(data);
              // this.productsOrders = data as ProductOrder[];
              });
        }
}
