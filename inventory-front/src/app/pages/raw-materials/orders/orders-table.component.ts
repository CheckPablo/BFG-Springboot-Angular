import { Component , OnInit} from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { RawMaterialOrder } from '../../../@core/models/rawmaterial-order.model';
import { RawMaterialsOrdersTableData } from '../../../@core/data/raw-materials-orders-table';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './orders-table.component.html',
  styleUrls: ['./orders-table.component.scss'],
})
export class OrdersTableComponent  implements OnInit {

  rawMaterialOrders: RawMaterialOrder[];

  settings = {
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
     columns: {
                  rawMaterialOrderId: {
                    title: 'ID',
                    type: 'number',
                  },
                  pricePerUnit: {
                    title: 'Price Per Unit',
                    type: 'string',
                  },
                  description: {
                    title: 'Description',
                    type: 'string',
                  },
                  orderStatus: {
                    title: 'Order Status',
                    type: 'string',
                  },
                  deliveryDate: {
                    title: 'Date',
                    type: 'string',
                  },
                },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private service: RawMaterialsOrdersTableData) {
      }

      ngOnInit() {
        this.service.getData().subscribe((data: RawMaterialOrder[]) => {
         this.rawMaterialOrders = data as RawMaterialOrder[];
        });
       }


  onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }
}
