import { Injectable } from '@angular/core';
import { ProductTableData } from '../data/product-table';
import { ProductService } from '../services/product.service';

@Injectable({
  providedIn: 'root',
})
export class ProductTableService extends ProductTableData {
    constructor(private productService: ProductService) {
      super();
    }
  getData() {
    return this.productService.fetchAllProducts();
  }
}
