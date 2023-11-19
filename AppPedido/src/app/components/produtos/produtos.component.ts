import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProdutosService } from 'src/app/produtos.service';  
import { Produto } from 'src/app/Produto';  

@Component({
  selector: 'app-clientes',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private produtosService: ProdutosService) { 
  }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Produto';  
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      precoUnit: new FormControl(null),
      precoTotal: new FormControl(null),
      observacoes: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const produto: Produto = this.formulario.value;  
    this.produtosService.cadastrar(produto).subscribe(result => {
      alert('Produto inserido com sucesso.');  
    })
  }
}
