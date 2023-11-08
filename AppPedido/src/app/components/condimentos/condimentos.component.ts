import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CondimentosService } from 'src/app/condimentos.service';
import { Condimento } from 'src/app/Condimento';

@Component({
  selector: 'app-condimentos',
  templateUrl: './condimentos.component.html',
  styleUrls: ['./condimentos.component.css']
})
export class CondimentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private condimentosService: CondimentosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Condimento';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      quantidade: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const condimento: Condimento = this.formulario.value;
    this.condimentosService.cadastrar(condimento).subscribe(result => {
      alert('Condimento inserido com sucesso.');
    })
  }
}
