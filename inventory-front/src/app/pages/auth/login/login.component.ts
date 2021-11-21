import { Component } from '@angular/core';
import { NbLoginComponent} from '@nebular/auth';

import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AuthService } from '../../../@core/services/auth.service';
import { LoadingService } from '../../../@core/services/loading.service';

@Component({
selector: 'ngx-login',
templateUrl: './login.component.html',

})
export class LoginComponent extends NbLoginComponent {
}
