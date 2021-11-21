import { Component , OnInit} from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { ProductTableData } from '../../../@core/data/product-table';
import { Product } from '../../../@core/models/product.model';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './list-table.component.html',
  styleUrls: ['./list-table.component.scss'],
})
export class ListTableComponent implements OnInit {

  products: Product[];

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
          productId: {
            title: 'ID',
            type: 'number',
          },
          materialName: {
            title: 'Code',
            type: 'string',
          },
          description: {
            title: 'Description',
            type: 'string',
          },
          quantityUnit: {
            title: 'Unit',
            type: 'string',
          },
          quantityAvailable: {
            title: 'SOH',
            type: 'number',
          },
        },
  };

  source: LocalDataSource = new LocalDataSource();

  constructor(private service: ProductTableData) {
  }

  ngOnInit() {
    this.service.getData().subscribe((data: Product[]) => {
     this.products = data as Product[];
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
