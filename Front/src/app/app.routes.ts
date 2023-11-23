import { Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { AdmPageComponent } from './adm-page/adm-page.component';
import { PedidosPageComponent } from './pedidos-page/pedidos-page.component';
import { ProdutosPageComponent } from './produtos-page/produtos-page.component';

export const routes: Routes = [
    { path: 'login', component: LoginPageComponent},
    { path: 'adm', component: AdmPageComponent},
    { path: 'pedidos', component: PedidosPageComponent},
    { path: 'produtos', component: ProdutosPageComponent},
];
