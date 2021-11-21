import { Component } from '@angular/core';
import { NbDateService } from '@nebular/theme';

@Component({
  selector: 'ngx-form-inputs',
  styleUrls: ['./place-order.component.scss'],
  templateUrl: './place-order.component.html',
})
export class PlaceRawMaterialOrderComponent {

  starRate = 2;
  heartRate = 4;
  radioGroupValue = 'This is value 2';

    min: Date;
    max: Date;

    constructor(protected dateService: NbDateService<Date>) {
      this.min = this.dateService.addDay(this.dateService.today(), -5);
      this.max = this.dateService.addDay(this.dateService.today(), 5);
    }
}
