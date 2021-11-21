import { Component , OnInit} from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';

import { RawMaterial } from '../../../@core/models/raw-material.model';
import { RawMaterialsTableData } from '../../../@core/data/raw-materials-table';

@Component({
  selector: 'ngx-smart-table',
  templateUrl: './list-table.component.html',
  styleUrls: ['./list-table.component.scss'],
})
export class RmListTableComponent  implements OnInit{

  rawMaterials: RawMaterial[];

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
              rawMaterialId: {
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

  constructor(private service: RawMaterialsTableData) {
    }

    ngOnInit() {
      this.service.getData().subscribe((data: RawMaterial[]) => {
       this.rawMaterials = data as RawMaterial[];
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
