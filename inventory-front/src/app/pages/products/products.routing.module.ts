import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductsComponent } from './products.component';
import { ProductOrdersTableComponent } from './orders/orders-table.component';
import { PlaceOrderComponent } from './place-order/place-order.component';
import { ListTableComponent } from './list/list-table.component';

const routes: Routes = [{
  path: '',
  component: ProductsComponent,
  children: [
    {
      path: 'place-order',
      component: PlaceOrderComponent,
    },
    {
      path: 'orders',
      component: ProductOrdersTableComponent,
    },
    {
      path: 'list',
      component: ListTableComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductsRoutingModule { }

export const routedComponents = [
  ProductsComponent,
  ProductOrdersTableComponent,
  ListTableComponent,
  PlaceOrderComponent,
];
