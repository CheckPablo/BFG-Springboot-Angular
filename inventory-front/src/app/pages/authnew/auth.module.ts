/**
 * @author khumzzz
 * @email khumzzz@gmail.com
 * @create date 2020-11-03 22:15:06
 * @modify date 2020-11-03 22:15:06
 * @desc Auth related functions
 */
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { LoginComponent } from './login/login.component';
import { AuthComponent } from "./auth.component";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth-routing.module';
import { RequestQuestionComponent } from './request-question/request-question.component';



@NgModule({
  declarations: [
    LoginComponent,
    ChangePasswordComponent,
    AuthComponent,
    RequestQuestionComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AuthModule { }
