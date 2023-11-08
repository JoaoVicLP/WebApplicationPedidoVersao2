import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Condimento } from './Condimento';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CondimentosService {
  apiUrl = 'http://localhost:5000/Condimento';
  constructor(private http: HttpClient) { }
  listar(): Observable<Condimento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Condimento[]>(url);
  }
  buscar(nome: string): Observable<Condimento> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.get<Condimento>(url);
  }
  cadastrar(condimento: Condimento): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Condimento>(url, condimento, httpOptions);
  }
  atualizar(condimento: Condimento): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Condimento>(url, condimento, httpOptions);
  }
  excluir(nome: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
