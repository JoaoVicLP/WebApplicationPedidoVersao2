import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DescontosService } from 'src/app/descontos.service';
import { Desconto } from 'src/app/Desconto';

@Component({
  selector: 'app-descontos',
  templateUrl: './descontos.component.html',
  styleUrls: ['./descontos.component.css']
})
export class DescontosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private descontosService: DescontosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Desconto';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      valor: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const desconto: Desconto = this.formulario.value;
    this.descontosService.cadastrar(desconto).subscribe(result => {
      alert('Desconto inserido com sucesso.');
    })
  }
}
