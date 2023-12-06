import { Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { AdmPageComponent } from './adm-page/adm-page.component';
import { PedidosPageComponent } from './pedidos-page/pedidos-page.component';
import { ProdutosPageComponent } from './produtos-page/produtos-page.component';
import { PromocoesPageComponent } from './produtos-page/produtos-page.component';
import { TotemPageComponent } from './totem-page/totem-page.component';
import { UserPageComponent } from './user-page/user-page.component';
import { GraphsPageComponent } from './graphs-page/graphs-page.component';

export const routes: Routes = [
    { path: '', component: LoginPageComponent },
    { path: 'adm',
        children: [
            { path: '', component: AdmPageComponent },
            { path: 'pedidos', component: PedidosPageComponent },
            { path: 'totem', component: TotemPageComponent },
            { path: 'graficos', component: GraphsPageComponent },
    ]},
    { path: 'produtos', component: ProdutosPageComponent },
    { path: 'promocoes', component: PromocoesPageComponent },
    { path: 'user', component: UserPageComponent },
];
