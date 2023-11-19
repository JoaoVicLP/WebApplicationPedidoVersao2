import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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

  constructor(private listasService: ListasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Lista';
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
    this.listasService.cadastrar(lista).subscribe(result => {
      alert('Lista inserida com sucesso.');
    });
  }
}
