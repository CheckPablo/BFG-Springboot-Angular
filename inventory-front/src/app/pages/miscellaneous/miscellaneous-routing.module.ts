import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MiscellaneousComponent } from './miscellaneous.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TabsComponent } from './all/tabs.component';

const routes: Routes = [
  {
    path: '',
    component: MiscellaneousComponent,
    children: [
//       {
//         path: '404',
//         component: NotFoundComponent,
//       },
      {
        path: 'all',
        component: TabsComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MiscellaneousRoutingModule {
}
