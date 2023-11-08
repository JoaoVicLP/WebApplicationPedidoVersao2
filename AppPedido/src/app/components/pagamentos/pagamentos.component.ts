import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PagamentosService } from 'src/app/pagamentos.service';
import { Pagamento } from 'src/app/Pagamento';

@Component({
  selector: 'app-pagamentos',
  templateUrl: './pagamentos.component.html',
  styleUrls: ['./pagamentos.component.css']
})
export class PagamentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private pagamentosService: PagamentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Pagamento ';
    this.formulario = new FormGroup({
      formaDePagamento: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const pagamento: Pagamento = this.formulario.value;
    this.pagamentosService.cadastrar(pagamento).subscribe(result => {
      alert('Pagamento inserido com sucesso.');
    })
  }
}
