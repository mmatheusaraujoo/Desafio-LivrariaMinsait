import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { autor } from '../models/autor.models';
import { livro } from '../models/livro.models';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  retornarAutores() {
    return this.http.get<autor[]>('http://localhost:5011/Autor')
  }
  retornarLivros() {
    return this.http.get<livro[]>('http://localhost:5011/Livro')
  }
}
