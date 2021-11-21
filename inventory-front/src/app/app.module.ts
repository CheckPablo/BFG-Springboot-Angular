/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './@core/core.module';
import { ThemeModule } from './@theme/theme.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxAuthModule } from './auth/auth.module';
import { PagesModule } from './pages/pages.module';
import { httpInterceptors } from './interceptors';
import { environment } from '../environments/environment';
import { NbAuthJWTToken, NbPasswordAuthStrategy, NbAuthModule } from '@nebular/auth';
import { HttpClientModule } from '@angular/common/http';

import { AuthGuard } from './auth-guard.service';

import {
  NbChatModule,
  NbDatepickerModule,
  NbDialogModule,
  NbMenuModule,
  NbSidebarModule,
  NbToastrModule,
  NbWindowModule,
} from '@nebular/theme';

const formSetting: any = {
  redirectDelay: 0,
  showMessages: {
    success: true,
  },
};


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    PagesModule,
    NgxAuthModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbDatepickerModule.forRoot(),
    NbDialogModule.forRoot(),
    NbWindowModule.forRoot(),
    NbToastrModule.forRoot(),
    NbChatModule.forRoot({
      messageGoogleMapKey: 'AIzaSyA_wNuCzia92MAmdLRzmqitRGvCF7wCZPY',
    }),
    CoreModule.forRoot(),
    ThemeModule.forRoot(),
    NbAuthModule.forRoot({
             strategies: [
               NbPasswordAuthStrategy.setup({
                 name: 'email',
                 baseEndpoint: `${environment.protocol}${environment.applicationUrl}/${environment.authService}`,
                 token: {
                     class: NbAuthJWTToken,
                     key: 'token',
                 },
                 login: {
                     endpoint: '/auth/login',
                     method: 'post',
                     redirect: {
                         success: '/pages/dashboard', // welcome page path
                         failure: null, // stay on the same page
                     },
                 },
                 register: {
                     endpoint: '/api/auth/register',
                     method: 'post',
                 },
                 logout: {
                     endpoint: '/auth/sign-out',
                     method: 'post',
                 },
                 requestPass: {
                    endpoint: '/auth/request-pass',
                    method: 'post',
                 },
                 resetPass: {
                    endpoint: '/auth/reset-pass',
                    method: 'post',
                 },
               }),
             ],
             forms: {
                  login: formSetting,
                  register: formSetting,
                  requestPassword: formSetting,
                  resetPassword: formSetting,
                  logout: {
                      redirectDelay: 0,
                  },
             },
           }),
  ],
  providers: [
//       httpInterceptors,
      JwtHelperService,
      AuthGuard
    ],
    bootstrap: [AppComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
})

export class AppModule {
}
