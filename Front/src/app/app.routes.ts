import { Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { AdmPageComponent } from './adm-page/adm-page.component';
import { PedidosPageComponent } from './pedidos-page/pedidos-page.component';
import { ProdutosPageComponent } from './produtos-page/produtos-page.component';
import { TotemPageComponent } from './totem-page/totem-page.component';

export const routes: Routes = [
    { path: '', component: LoginPageComponent },
    { path: 'adm',
        children: [
            { path: '', component: AdmPageComponent },
            { path: 'pedidos', component: PedidosPageComponent },
            { path: 'totem', component: TotemPageComponent },
            { path: 'produtos', component: ProdutosPageComponent },
    ]},
];
