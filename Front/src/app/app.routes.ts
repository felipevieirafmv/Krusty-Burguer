import { Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { AdmPageComponent } from './adm-page/adm-page.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent},
    { path: 'adm', component: AdmPageComponent}
];
