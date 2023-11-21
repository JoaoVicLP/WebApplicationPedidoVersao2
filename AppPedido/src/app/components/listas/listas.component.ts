import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ProdutosService } from 'src/app/produtos.service';
import { Produto } from 'src/app/Produto';
import { Condimento } from 'src/app/Condimento';
import { CondimentosService } from 'src/app/condimentos.service';
import { MesasService } from 'src/app/mesas.service';
import { Mesa } from 'src/app/Mesa';
import { TaxasService } from 'src/app/taxas.service';
import { Taxa } from 'src/app/Taxa';
import { PagamentosService } from 'src/app/pagamentos.service';
import { Pagamento } from 'src/app/Pagamento';
import { GarconsService } from 'src/app/garcons.service';
import { Garcom } from 'src/app/Garcom';
import { DescontosService } from 'src/app/descontos.service';
import { Desconto } from 'src/app/Desconto';
import { ClientesService } from 'src/app/clientes.service';
import { Cliente } from 'src/app/Cliente';
import { ListasService } from 'src/app/listas.service';
import { Lista } from 'src/app/Lista';

@Component({
  selector: 'app-listas',
  templateUrl: './listas.component.html',
  styleUrls: ['./listas.component.css']
})
export class ListasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  clientes: Array<Cliente> | undefined;
  descontos: Array<Desconto> | undefined;
  garcons: Array<Garcom> | undefined;
  pagamentos: Array<Pagamento> | undefined;
  taxas: Array<Taxa> | undefined;
  mesas: Array<Mesa> | undefined;
  condimentos: Array<Condimento> | undefined;
  produtos: Array<Produto> | undefined;

  constructor(private listasService: ListasService,
              private clientesService: ClientesService,
              private descontosService: DescontosService,
              private garconsService: GarconsService,
              private pagamentosService: PagamentosService,
              private taxasService: TaxasService,
              private mesasService: MesasService,
              private condimentosService: CondimentosService,
              private produtosService: ProdutosService
  ) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Lista';
    this.clientesService.listar().subscribe(clientes => {
      this.clientes = clientes;
      if (this.clientes && this.clientes.length > 0) {
        this.formulario.get('clientesId')?.setValue(this.clientes[0].id);
      }
    });
    this.descontosService.listar().subscribe(descontos => {
      this.descontos = descontos;
      if (this.descontos && this.descontos.length > 0) {
        this.formulario.get('descontosId')?.setValue(this.descontos[0].id);
      }
    });
    this.garconsService.listar().subscribe(garcons => {
      this.garcons = garcons;
      if (this.garcons && this.garcons.length > 0) {
        this.formulario.get('garconsId')?.setValue(this.garcons[0].id);
      }
    });
    this.pagamentosService.listar().subscribe(pagamentos => {
      this.pagamentos = pagamentos;
      if (this.pagamentos && this.pagamentos.length > 0) {
        this.formulario.get('pagamentosId')?.setValue(this.pagamentos[0].id);
      }
    });
    this.taxasService.listar().subscribe(taxas => {
      this.taxas = taxas;
      if (this.taxas && this.taxas.length > 0) {
        this.formulario.get('taxasId')?.setValue(this.taxas[0].id);
      }
    });
    this.mesasService.listar().subscribe(mesas => {
      this.mesas = mesas;
      if (this.mesas && this.mesas.length > 0) {
        this.formulario.get('mesasId')?.setValue(this.mesas[0].id);
      }
    });
    this.produtosService.listar().subscribe(produtos => {
      this.produtos = produtos;
      if (this.produtos && this.produtos.length > 0) {
        this.formulario.get('produtosId')?.setValue(this.produtos[0].id);
      }
    });
    this.produtosService.listar().subscribe(produtos => {
      this.produtos = produtos;
      if (this.produtos && this.produtos.length > 0) {
        this.formulario.get('produtosId')?.setValue(this.produtos[0].id);
      }
    });
    this.condimentosService.listar().subscribe(condimentos => {
      this.condimentos = condimentos;
      if (this.condimentos && this.condimentos.length > 0) {
        this.formulario.get('condimentosId')?.setValue(this.condimentos[0].id);
      }
    });
    this.formulario = new FormGroup({
      status: new FormControl(null),
      somaTotal: new FormControl(null),
      mesa: new FormControl(null),
      desconto: new FormControl(null),
      taxa: new FormControl(null),
      pagamento: new FormControl(null),
      garcom: new FormControl(null),
      produtos: new FormControl(null),
      cliente: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const lista: Lista = this.formulario.value;
    const observer: Observer<Lista> = {
      next(_result): void {
        alert('Lista salva com sucesso.');
      }, error(_error): void {
        alert('Erro ao salvar!');
      }, complete(): void { },
    }; if (lista.id && !isNaN(Number(lista.id))) {
      this.listasService.alterar(lista).subscribe(observer);
    } else {
      this.listasService.cadastrar(lista).subscribe(observer);
    }
  }
}
