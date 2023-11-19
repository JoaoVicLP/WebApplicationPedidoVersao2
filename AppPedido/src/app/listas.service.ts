import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lista } from './Lista';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ListasService {
  apiUrl = 'http://localhost:5000/Lista';

  constructor(private http: HttpClient) { }

  listar(): Observable<Lista[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Lista[]>(url);
  }

  buscar(id: number): Observable<Lista> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Lista>(url);
  }

  cadastrar(lista: Lista): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Lista>(url, lista, httpOptions);
  }

  atualizar(lista: Lista): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Lista>(url, lista, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
