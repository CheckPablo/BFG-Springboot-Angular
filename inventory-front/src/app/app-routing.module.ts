import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthComponent } from './auth/auth.component';
import { AuthGuard } from './auth-guard.service';
import {
  NbAuthComponent,
  NbLoginComponent,
  NbLogoutComponent,
  NbRegisterComponent,
  NbRequestPasswordComponent,
  NbResetPasswordComponent,
} from '@nebular/auth';

export const routes: Routes = [
  {
    path: 'pages',
    canActivate: [AuthGuard],
    loadChildren: () => import('./pages/pages.module')
      .then(m => m.PagesModule),
  },
  {
      path: 'gate',
      loadChildren: () => import('./auth/auth.module')
        .then(m => m.NgxAuthModule),
   },
//   {
//     path: 'auth',
//     component: NbAuthComponent,
//     children: [
//       {
//         path: '',
//         component: NbLoginComponent,
//       },
//       {
//         path: 'login',
//         component: NbLoginComponent,
//       },
//       {
//         path: 'register',
//         component: NbRegisterComponent,
//       },
//       {
//         path: 'logout',
//         component: NbLogoutComponent,
//       },
//       {
//         path: 'request-password',
//         component: NbRequestPasswordComponent,
//       },
//       {
//         path: 'reset-password',
//         component: NbResetPasswordComponent,
//       },
//     ],
//   },
//   { path: '', redirectTo: 'pages', pathMatch: 'full' },
//   { path: '**', redirectTo: 'pages' },
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
