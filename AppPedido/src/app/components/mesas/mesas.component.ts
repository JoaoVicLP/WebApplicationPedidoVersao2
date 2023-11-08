import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MesasService } from 'src/app/mesas.service';
import { Mesa } from 'src/app/Mesa';

@Component({
  selector: 'app-mesas',
  templateUrl: './mesas.component.html',
  styleUrls: ['./mesas.component.css']
})
export class MesasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private mesasService: MesasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Mesa';
    this.formulario = new FormGroup({
      numero: new FormControl(null),
      capacidade: new FormControl(null),
      disponibilidade: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const mesa: Mesa = this.formulario.value;
    this.mesasService.cadastrar(mesa).subscribe(result => {
      alert('Mesa inserida com sucesso.');
    })
  }
}
