import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Garcom } from './Garcom';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GarconsService {
  apiUrl = 'http://localhost:5000/Garcom';
  constructor(private http: HttpClient) { }
  listar(): Observable<Garcom[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Garcom[]>(url);
  }
  buscar(nome: string): Observable<Garcom> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.get<Garcom>(url);
  }
  cadastrar(garcom: Garcom): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Garcom>(url, garcom, httpOptions);
  }
  alterar(garcom: Garcom): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Garcom>(url, garcom, httpOptions);
  }
  excluir(nome: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
