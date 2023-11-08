import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Taxa } from './Taxa'; 
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class TaxasService {
  apiUrl = 'http://localhost:5000/Taxa';
  constructor(private http: HttpClient) { }
  listar(): Observable<Taxa[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Taxa[]>(url);
  }
  buscar(tipo: string): Observable<Taxa> {
    const url = `${this.apiUrl}/buscar/${tipo}`;
    return this.http.get<Taxa>(url);
  }
  cadastrar(taxa: Taxa): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Taxa>(url, taxa, httpOptions);
  }

  atualizar(taxa: Taxa): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Taxa>(url, taxa, httpOptions);
  }

  excluir(tipo: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${tipo}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
