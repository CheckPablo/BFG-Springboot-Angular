import { NgModule } from '@angular/core';
import { NbCardModule, NbIconModule, NbInputModule, NbDatepickerModule, NbTreeGridModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ThemeModule } from '../../@theme/theme.module';
import { RawMaterialsRoutingModule, routedComponents } from './raw-materials-routing.module';

@NgModule({
  imports: [
    NbCardModule,
    NbTreeGridModule,
    NbIconModule,
    NbInputModule,
    ThemeModule,
    RawMaterialsRoutingModule,
    Ng2SmartTableModule,
    NbDatepickerModule,
  ],
  declarations: [
    ...routedComponents,
  ],
})
export class RawMaterialsModule { }
