import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './components/clientes/clientes.component';
import { CondimentosComponent } from './components/condimentos/condimentos.component';
import { DescontosComponent } from './components/descontos/descontos.component';
import { GarconsComponent } from './components/garcons/garcons.component';
import { MesasComponent } from './components/mesas/mesas.component';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';
import { TaxasComponent } from './components/taxas/taxas.component';
import { ListasComponent } from './components/listas/listas.component';
import { ProdutosComponent } from './components/produtos/produtos.component';



const routes: Routes = [
  { path: 'clientes', component: ClientesComponent },
  { path: 'condimentos', component: CondimentosComponent },
  { path: 'descontos', component: DescontosComponent },
  { path: 'garcons', component: GarconsComponent },
  { path: 'mesas', component: MesasComponent },
  { path: 'pagamentos', component: PagamentosComponent },
  { path: 'taxas', component: TaxasComponent },
  { path: 'listas', component: ListasComponent },
  { path: 'produtos', component: ProdutosComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
