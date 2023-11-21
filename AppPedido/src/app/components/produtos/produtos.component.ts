import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ProdutosService } from 'src/app/produtos.service';  
import { Produto } from 'src/app/Produto';
import { Condimento } from 'src/app/Condimento';
import { CondimentosService } from 'src/app/condimentos.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  condimentos: Array<Condimento> | undefined;

  constructor(private produtosService: ProdutosService,
              private condimentosService : CondimentosService) {
  }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Produto';
    this.condimentosService.listar().subscribe(condimentos => {
      this.condimentos = condimentos;
      if (this.condimentos && this.condimentos.length > 0) {
        this.formulario.get('condimentosId')?.setValue(this.condimentos[0].id);
      }
    });
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      precoUnit: new FormControl(null),
      precoTotal: new FormControl(null),
      observacao: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const produto: Produto = this.formulario.value;
    const observer: Observer<Produto> = {
      next(_result): void {
        alert('Produto salvo com sucesso.');
      }, error(_error): void {
        alert('Erro ao salvar!');
      }, complete(): void { },
    }; if (produto.id && !isNaN(Number(produto.id))) {
      this.produtosService.alterar(produto).subscribe(observer);
    } else {
      this.produtosService.cadastrar(produto).subscribe(observer);
    }
  }
}
