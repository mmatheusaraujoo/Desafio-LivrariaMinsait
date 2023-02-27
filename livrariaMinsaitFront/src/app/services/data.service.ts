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
    return this.http.get<autor[]>('https://localhost:7154/Autor')
  }
  retornarLivros() {
    return this.http.get<livro[]>('https://localhost:7154/Livro')
  }
}
