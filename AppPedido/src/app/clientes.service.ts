import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './Cliente';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  apiUrl = 'http://localhost:5000/Cliente';
  constructor(private http: HttpClient) { }
  listar(): Observable<Cliente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cliente[]>(url);
  }
  buscar(nome: string): Observable<Cliente> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.get<Cliente>(url);
  }
  cadastrar(cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cliente>(url, cliente, httpOptions);
  }
  alterar(cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Cliente>(url, cliente, httpOptions);
  }
  excluir(nome: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
