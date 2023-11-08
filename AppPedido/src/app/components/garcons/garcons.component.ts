import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GarconsService } from 'src/app/garcons.service';
import { Garcom } from 'src/app/Garcom';

@Component({
  selector: 'app-garcons',
  templateUrl: './garcons.component.html',
  styleUrls: ['./garcons.component.css']
})
export class GarconsComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private garconsService: GarconsService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Garcom';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cracha: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const garcom: Garcom = this.formulario.value;
    this.garconsService.cadastrar(garcom).subscribe(result => {
      alert('Garcom inserido com sucesso.');
    })
  }
}
