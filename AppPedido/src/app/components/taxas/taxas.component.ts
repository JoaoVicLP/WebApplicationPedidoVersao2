import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TaxasService } from 'src/app/taxas.service'; 
import { Taxa } from 'src/app/Taxa'; 

@Component({
  selector: 'app-taxas', 
  templateUrl: './taxas.component.html', 
  styleUrls: ['./taxas.component.css'] 
})
export class TaxasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private taxasService: TaxasService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Taxa'; 
    this.formulario = new FormGroup({
      placa: new FormControl(null),
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const taxa: Taxa = this.formulario.value;
    this.taxasService.cadastrar(taxa).subscribe(result => {
      alert('Taxa inserida com sucesso.');
    })
  }
}
