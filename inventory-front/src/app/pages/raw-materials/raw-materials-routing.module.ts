import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RawMaterialsComponent } from './raw-materials.component';
import { OrdersTableComponent } from './orders/orders-table.component';
import { PlaceRawMaterialOrderComponent } from './place-order/place-order.component';
import { RmListTableComponent } from './list/list-table.component';

const routes: Routes = [{
  path: '',
  component: RawMaterialsComponent,
  children: [
    {
      path: 'orders',
      component: OrdersTableComponent,
    },
    {
      path: 'place-order',
      component: PlaceRawMaterialOrderComponent,
    },
    {
      path: 'list',
      component: RmListTableComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RawMaterialsRoutingModule { }

export const routedComponents = [
  RawMaterialsComponent,
  OrdersTableComponent,
  RmListTableComponent,
  PlaceRawMaterialOrderComponent,
];
