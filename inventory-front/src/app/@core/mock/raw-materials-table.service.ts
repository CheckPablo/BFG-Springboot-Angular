import { Injectable } from '@angular/core';
import { RawMaterialsTableData } from '../data/raw-materials-table';
import { RawmaterialService } from '../services/rawmaterial.service';

@Injectable()
export class RawMaterialsTableService extends RawMaterialsTableData {

  constructor(private service: RawmaterialService) {
        super();
      }
    getData() {
      return this.service.fetchAllRawmaterials();
    }

}
