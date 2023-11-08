import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Desconto } from './Desconto';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class DescontosService {
  apiUrl = 'http://localhost:5000/Desconto';
  constructor(private http: HttpClient) { }
  listar(): Observable<Desconto[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Desconto[]>(url);
  }
  buscar(nome: string): Observable<Desconto> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.get<Desconto>(url);
  }
  cadastrar(desconto: Desconto): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Desconto>(url, desconto, httpOptions);
  }
  atualizar(desconto: Desconto): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Desconto>(url, desconto, httpOptions);
  }
  excluir(nome: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
