import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';

import { CondimentosService } from './condimentos.service';
import { CondimentosComponent } from './components/condimentos/condimentos.component';

import { DescontosService } from './descontos.service';
import { DescontosComponent } from './components/descontos/descontos.component';

import { GarconsService } from './garcons.service';
import { GarconsComponent } from './components/garcons/garcons.component';

import { MesasService } from './mesas.service';
import { MesasComponent } from './components/mesas/mesas.component';

import { PagamentosService } from './pagamentos.service';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';


import { TaxasService } from './taxas.service';
import { TaxasComponent } from './components/taxas/taxas.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    CondimentosComponent,
    DescontosComponent,
    GarconsComponent,
    MesasComponent,
    PagamentosComponent,
    TaxasComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule, ClientesService, CondimentosService, DescontosService, GarconsService, MesasService, PagamentosService, TaxasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
