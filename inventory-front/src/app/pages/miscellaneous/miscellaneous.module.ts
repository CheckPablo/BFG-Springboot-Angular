import { NgModule } from '@angular/core';
import { NbButtonModule, NbCardModule,
                                       NbRouteTabsetModule,
                                       NbStepperModule,
                                       NbTabsetModule,
                                       NbUserModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { MiscellaneousRoutingModule } from './miscellaneous-routing.module';
import { MiscellaneousComponent } from './miscellaneous.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { TabsComponent } from './all/tabs.component';

@NgModule({
  imports: [
    ThemeModule,
    NbCardModule,
    NbButtonModule,
    MiscellaneousRoutingModule,
    NbTabsetModule,
    NbRouteTabsetModule,
    NbStepperModule,
  ],
  declarations: [
    MiscellaneousComponent,
    NotFoundComponent,
    TabsComponent,
  ],
})
export class MiscellaneousModule { }
