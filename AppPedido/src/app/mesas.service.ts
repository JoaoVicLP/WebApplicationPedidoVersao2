import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mesa } from './Mesa';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class MesasService {
  apiUrl = 'http://localhost:5000/Mesa';
  constructor(private http: HttpClient) { }
  listar(): Observable<Mesa[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Mesa[]>(url);
  }
  buscar(numero: number): Observable<Mesa> {
    const url = `${this.apiUrl}/buscar/${numero}`;
    return this.http.get<Mesa>(url);
  }
  cadastrar(mesa: Mesa): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Mesa>(url, mesa, httpOptions);
  }
  atualizar(mesa: Mesa): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Mesa>(url, mesa, httpOptions);
  }
  excluir(numero: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${numero}`;
    return this.http.delete<number>(url, httpOptions);
  }
}
